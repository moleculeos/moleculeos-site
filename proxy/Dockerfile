FROM nginxinc/nginx-unprivileged:1-alpine

WORKDIR /proxy/

COPY ./default.template.conf /etc/nginx/default.template.conf
COPY ./run.sh .
COPY ./proxy_params.conf /etc/ngnix/proxy_params.conf

ENV LISTEN_PORT=80

ENV DOTNET_HOST=${DOTNET_HOST}
ENV DOTNET_PORT=${DOTNET_PORT}

ENV NEXTJS_HOST=${NEXTJS_HOST}
ENV NEXTJS_PORT=${NEXTJS_PORT}

USER root

RUN touch /etc/nginx/conf.d/default.conf && \
    chown nginx:nginx /etc/nginx/conf.d/default.conf && \
    chmod +x ./run.sh

USER nginx

CMD ["./run.sh"]