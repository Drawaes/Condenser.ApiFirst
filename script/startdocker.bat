docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Strong!Password12" -p 1433:1433 -d condenserdotnet.sqlserver
docker run -p 8500:8500 -d condenserdotnet.consul
