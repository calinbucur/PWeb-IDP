FROM node:18-alpine

WORKDIR /usr/react/

COPY package*.json ./

RUN npm install

COPY . .

EXPOSE 8080

CMD ["npm", "run", "start"]