# Define node version
FROM node:18.10-alpine as build
# Define container directory
WORKDIR /usr/src/app
# Copy package*.json for npm install
COPY package*.json .
# Run npm clean install, including dev dependencies for @angular-devkit
RUN npm install
# Run npm install @angular/cli
RUN npm install -g @angular/cli@16.1.0
# Copy all files
COPY . .
# Run ng build through npm to create dist folder
RUN npm run build --prod
# Define nginx for front-end server
FROM nginx:1.15.8-alpine
# Copy dist from ng build to nginx html folder
COPY --from=build /usr/src/app/dist /usr/share/nginx/html