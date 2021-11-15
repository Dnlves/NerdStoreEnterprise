FROM mcr.microsoft.com/mssql/server:latest
RUN mkdir -p /usr/work
WORKDIR /usr/work
COPY . /usr/work

USER root
RUN chmod +x /usr/work/import-data.sh
USER mssql

EXPOSE 1433

ENTRYPOINT ["/bin/bash", "./entrypoint.sh"]
