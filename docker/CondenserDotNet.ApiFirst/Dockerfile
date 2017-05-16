FROM microsoft/mssql-server-linux:latest

RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app
COPY . /usr/src/app

EXPOSE 1433

CMD /bin/bash ./entrypoint.sh