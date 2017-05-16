#wait for sql server to start
sleep 20s
for i in *.sql;
do
echo $i
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -d master -i $i -P $SA_PASSWORD;
done