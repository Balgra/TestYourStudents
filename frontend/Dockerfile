FROM node:14-alpine as builder

WORKDIR /app

COPY package.json package-lock.json  .npmrc ./
RUN npm ci

COPY ./ ./

RUN npm run build

# =================== RUNTIME ===================

FROM nginx:alpine

COPY --from=builder /app/build /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
