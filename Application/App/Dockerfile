FROM node:lts-alpine

WORKDIR /App

COPY package*.json ./

RUN npm install -g @angular/cli

RUN npm install

run npm i --save-dev @types/node

COPY . .

EXPOSE 4200

CMD ["ng", "serve", "--host", "0.0.0.0", "--port", "4200"]
