FROM node:alpine

RUN mkdir -p /app

WORKDIR /app

COPY package.json /app
COPY yarn.lock /app

RUN yarn install

COPY . /app

RUN yarn run build
EXPOSE 3000

CMD ["yarn", "dev"]
