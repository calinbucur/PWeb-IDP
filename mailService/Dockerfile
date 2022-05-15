FROM node:18-alpine

WORKDIR /usr/app/

COPY package*.json ./

RUN npm install

COPY . .

EXPOSE 5672
EXPOSE 587

CMD ["npm", "run", "start"]