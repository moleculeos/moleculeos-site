#!/bin/bash
docker container stop $(docker container ls -a -q);
docker container rm $(docker container ls -a -q);
docker-compose down;
docker-compose -f ./moleculeos-site-frontend/docker-compose.yml --env-file .env.dev up --build