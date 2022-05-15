import { Connection } from "amqplib";
import client from 'amqplib';

export async function connectToChannel(
    username: string,
    password: string,
    hostname: string,
    queue: string
) {
    const queueConnection: Connection = await client.connect(
        `amqp://${username}:${password}@${hostname}:5672`
    );

    const channel = await queueConnection.createChannel();

    await channel.assertQueue(queue);

    return channel;
}

export async function sendMessageToChannel(
    msg: string,
    channel: client.Channel,
    queue: string
) {
    channel.sendToQueue(queue, Buffer.from(msg))
}