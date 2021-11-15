for i in {1..50};
do
    /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P MeuDB@123 -i criacao-banco-docker.sql
    if [ $? -eq 0 ]
    then
        echo "criacao-banco-docker.sql completed"
        break
    else
        echo "not ready yet..."
        sleep 1
    fi
done