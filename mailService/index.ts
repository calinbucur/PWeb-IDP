import nodemailer from "nodemailer";
import 'dotenv/config'
import client, {Connection} from 'amqplib'
import { connectToChannel } from "./services/rabbitMqService";
import { connectToMailServer, sendMail } from "./services/mailService";
import Ajv, { JSONSchemaType } from "ajv";

interface RabbitMqMessage {
    to: string,
    subject: string,
    body: string
}

const rabbitMqMsgSchema: JSONSchemaType<RabbitMqMessage> = {
    type: "object",
    properties: {
        to: {type: "string"},
        subject: {type: "string"},
        body: {type: "string"},
    },
    required: ["to", "subject", "body"],
    additionalProperties: false,
}

const ajv = new Ajv()

const validateRabbitMqMsg = ajv.compile(rabbitMqMsgSchema)

async function main() {   
    const email_hostname = process.env.MAIL_HOSTNAME ?? "smtp.gmail.com";
    const email_username = process.env.MAIL_USERNAME ?? "petaway.test@gmail.com";
    const email_password = process.env.MAIL_PASSWORD ?? "6C2XzHvuqDk7Nd8X95ME8jH7pj7Q";

    const rabbitmq_username = process.env.RABBITMQ_USERNAME ?? "username"
    const rabbitmq_password = process.env.RABBITMQ_PASSWORD ?? "password"
    const rabbitmq_hostname = process.env.RABBITMQ_HOSTNAME ?? "localhost"
    const rabbitmq_queue = process.env.RABBITMQ_QUEUE ?? "queue"

    const mailServer = await connectToMailServer(
        email_hostname,
        email_username,
        email_password
    );

    const channel = await connectToChannel(
        rabbitmq_username,
        rabbitmq_password,
        rabbitmq_hostname,
        rabbitmq_queue
    );

    await channel.consume(rabbitmq_queue, (msg) => {
        if (msg) {
            const contentString = msg?.content.toString();
            try {
                const content = JSON.parse(contentString);
                if (validateRabbitMqMsg(content)) {
                    sendMail(
                        mailServer,
                        email_username,
                        content.to,
                        content.subject,
                        content.body
                    )
                    channel.ack(msg);
                    return;
                }
                channel.nack(msg)
            } catch {
                channel.nack(msg)
            }
        }
    })
}

main()


