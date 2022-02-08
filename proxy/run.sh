set -e

envsubst < /etc/nginx/default.template.conf > /etc/nginx/conf.d/default.conf
nginx -g 'daemon off;'