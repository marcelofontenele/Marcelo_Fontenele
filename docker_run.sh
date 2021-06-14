#!/bin/bash

docker run -d --hostname rabbitserver --name rabbitmq-server -p 15672:15672 -p 5672:5672 rabbitmq:3-management

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=T0ro!nvest" -e "MSSQL_PID=Express" -p 1433:1433  --name sql1 -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

#docker build -t angular-app ./005-UI

#docker run -d -it -p 4200:4200/tcp --name angular-app angular-app