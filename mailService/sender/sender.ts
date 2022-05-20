import { connectToChannel, sendMessageToChannel } from "../services/rabbitMqService";

const username = process.env.RABBITMQ_USERNAME ?? "username";
const password = process.env.RABBITMQ_PASSWORD ?? "password";
const hostname = process.env.RABBITMQ_HOSTNAME ?? "localhost";
const queue = process.env.RABBITMQ_QUEUE ?? "queue";


async function main() {
    const channel = await connectToChannel(
        username,
        password,
        hostname,
        queue
    );
    
    for (let i = 0; i < 5; ++i) {
        sendMessageToChannel(
            `{
                "subject": "subject ${i}",
                "to": "petaway.test@gmail.com",
                "body": "body ${i}"
            }`,
            channel,
            queue
        );
    }
}

main();