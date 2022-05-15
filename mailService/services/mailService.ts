import nodemailer from 'nodemailer';
import SMTPTransport from 'nodemailer/lib/smtp-transport';

export async function connectToMailServer(
    hostname: string,
    username: string,
    password: string
): Promise<nodemailer.Transporter<SMTPTransport.SentMessageInfo>> {
    return nodemailer.createTransport({
        host: hostname,
        port: 587,
        secure: false,
        requireTLS: true,
        auth: {
          user: username,
          pass: password,
        },
        logger: true
      });
}

export async function sendMail(
    transporter: nodemailer.Transporter<SMTPTransport.SentMessageInfo>,
    from: string,
    to: string,
    subject: string,
    body: string
) {
    console.log("Sending mail")
    console.log(JSON.stringify({
        from,
        to,
        subject,
        body
    }))
    transporter.sendMail({
        from: `"PetAway" ${from}`,
        to,
        subject,
        text: body,
      }).then(info => {
        console.log({info});
      }).catch(console.error);
}