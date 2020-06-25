using Eris.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Eris.Access
{
    public class DBConfigData
    {
        public static List<DBConfigEntity> SelectAllCompany(SqlConnection sqlcon = null, SqlTransaction sqlTran = null)
        {
            //            string StrCmd = @"DECLARE @QQQ NVARCHAR(1000)
            //DECLARE @Query NVARCHAR(MAX)

            //SET @Query = 'SELECT DISTINCT CompanyName, CompanyNameLatin FROM 
            //(SELECT TOP 1 '''' AS CompanyName, '''' AS CompanyNameLatin  FROM master..sysdatabases'

            //DECLARE curs CURSOR FOR
            //	SELECT 'SELECT ''1'' AS CompanyName, CompanyNameLatin FROM ' + name + '..Setting'
            //	FROM master..sysdatabases
            //	WHERE name Like 'Eris%'

            //OPEN curs
            //FETCH NEXT FROM curs INTO @QQQ
            //WHILE @@FETCH_STATUS = 0
            //BEGIN
            //	SET @Query = @Query + '
            //UNION 
            //' + @QQQ

            //	FETCH NEXT FROM curs INTO @QQQ
            //END

            //CLOSE curs
            //DEALLOCate curs

            //SET @Query = @Query + ') AS CompanyList
            //WHERE CompanyName <> '''''

            //EXEC (@Query);";

            string StrCmd = @"DECLARE @AllTables table (DbName sysname)
DECLARE
     @SearchDb nvarchar(200)
    ,@SearchSchema nvarchar(200)
    ,@SearchTable nvarchar(200)
    ,@SQL nvarchar(4000)
SET @SearchDb='Eris%'
SET @SearchSchema='%'
SET @SearchTable='Setting'
SET @SQL='SELECT ''?'' AS DbName FROM [?].sys.tables t inner join sys.schemas s on t.schema_id=s.schema_id WHERE ''?'' LIKE '''+@SearchDb+''' AND s.name LIKE '''+@SearchSchema+''' AND t.name LIKE '''+@SearchTable+''''

INSERT INTO @AllTables (DbName)
    EXEC sp_msforeachdb @SQL

DECLARE @QQQ NVARCHAR(1000)
DECLARE @Query NVARCHAR(MAX)

SET @Query = 'SELECT DISTINCT CompanyName, CompanyNameLatin FROM 
(SELECT TOP 1 '''' AS CompanyName, '''' AS CompanyNameLatin  FROM master..sysdatabases'

DECLARE curs CURSOR FOR
SELECT * FROM @AllTables ORDER BY DbName 

OPEN curs
FETCH NEXT FROM curs INTO @QQQ
WHILE @@FETCH_STATUS = 0
BEGIN
	SET @Query = @Query + '
UNION 
SELECT ''1'' AS CompanyName, CompanyNameLatin FROM ' + @QQQ + '..Setting'

	FETCH NEXT FROM curs INTO @QQQ
END

CLOSE curs
DEALLOCate curs

SET @Query = @Query + ') AS CompanyList
WHERE CompanyName <> '''''

EXEC (@Query);";

            SqlCommand cmd = ErisConnectionManager.ConfigureCommand(sqlcon, sqlTran, "Master");
            cmd.CommandText = StrCmd;
            IDataReader dr = cmd.ExecuteReader();

            string StrCmdNew = "";
            while (dr.Read())
            {
                StrCmdNew += @"UNION ALL
				SELECT CompanyName, CompanyNameLatin FROM " + dr["CompanyNameLatin"].ToString() + @"..Setting
				";
            }
            dr.Close();
            cmd.Connection.Close();

            SqlCommand cmd1 = ErisConnectionManager.ConfigureCommand(sqlcon, sqlTran, "Master");
            cmd1.CommandText = StrCmdNew.Substring(9);
            IDataReader drNew = cmd1.ExecuteReader();

            List<DBConfigEntity> LstConfig = new List<DBConfigEntity>();

            while (drNew.Read())
            {
                DBConfigEntity DBConfig = new DBConfigEntity();
                DBConfig.CompanyNameLatin = drNew["CompanyNameLatin"].ToString();
                DBConfig.CompanyName = drNew["CompanyName"].ToString();
                LstConfig.Add(DBConfig);
            }

            return LstConfig;
        }

        public static List<DBConfigEntity> SelectAllDataBase(string PatternDB, SqlConnection sqlcon = null, SqlTransaction sqlTran = null)
        {
            string StrCmd = @"SELECT name AS CompanyNameLatin
	FROM master..sysdatabases
	WHERE name Like '" + PatternDB + "%'";

            SqlCommand cmd = ErisConnectionManager.ConfigureCommand(sqlcon, sqlTran, "Master");
            cmd.CommandText = StrCmd;
            IDataReader dr = cmd.ExecuteReader();

            List<DBConfigEntity> LstConfig = new List<DBConfigEntity>();
            while (dr.Read())
            {
                DBConfigEntity DBConfig = new DBConfigEntity();
                DBConfig.CompanyNameLatin = dr["CompanyNameLatin"].ToString();
                LstConfig.Add(DBConfig);
            }

			dr.Close();
            ErisConnectionManager.CloseConnection(cmd.Connection, sqlTran);

			return LstConfig;
        }

        public static List<DBConfigEntity> SelectAllDataBase(string PatternDB, string connectionString, SqlConnection sqlcon = null, SqlTransaction sqlTran = null)
        {
            string StrCmd = @"SELECT name AS CompanyNameLatin
	FROM master..sysdatabases
	WHERE name Like '" + PatternDB + "%'";

            SqlCommand Cmd = ErisConnectionManager.ConfigureCommand(sqlcon, sqlTran, "Master");
            Cmd.CommandText = StrCmd;

            IDataReader dr = Cmd.ExecuteReader();

            List<DBConfigEntity> LstConfig = new List<DBConfigEntity>();
            while (dr.Read())
            {
                DBConfigEntity DBConfig = new DBConfigEntity();
                DBConfig.CompanyNameLatin = dr["CompanyNameLatin"].ToString();
                LstConfig.Add(DBConfig);
            }

            dr.Close();
            ErisConnectionManager.CloseConnection(Cmd.Connection, sqlTran);

            return LstConfig;
        }

        public static List<DBConfigEntity> SelectAllYear(string CompanyNameLatin, SqlConnection sqlcon = null, SqlTransaction sqlTran = null)
        {
            //            string StrCmd = @"DECLARE @QQQ NVARCHAR(1000)
            //DECLARE @Query NVARCHAR(MAX)

            //SET @Query = 'SELECT CompanyName, CompanyNameLatin, AccYear, DBName FROM 
            //(SELECT TOP 1 '''' AS CompanyName, '''' AS CompanyNameLatin, 0 AS AccYear, '''' AS DBName FROM master..sysdatabases'

            //DECLARE curs CURSOR FOR
            //	SELECT 'SELECT CompanyName, CompanyNameLatin, AccYear, ''' + name + ''' AS DBName FROM ' + name + '..Setting'
            //	FROM master..sysdatabases
            //	WHERE name Like 'Eris%'

            //OPEN curs
            //FETCH NEXT FROM curs INTO @QQQ
            //WHILE @@FETCH_STATUS = 0
            //BEGIN
            //	SET @Query = @Query + '
            //UNION 
            //' + @QQQ

            //	FETCH NEXT FROM curs INTO @QQQ
            //END

            //CLOSE curs
            //DEALLOCate curs

            //SET @Query = @Query + ') AS CompanyList
            //WHERE CompanyNameLatin = ''" + CompanyNameLatin + @"'''

            //EXEC (@Query);";

            string StrCmd = @"DECLARE @AllTables table (DbName sysname)
DECLARE
     @SearchDb nvarchar(200)
    ,@SearchSchema nvarchar(200)
    ,@SearchTable nvarchar(200)
    ,@SQL nvarchar(4000)
SET @SearchDb='Eris%'
SET @SearchSchema='%'
SET @SearchTable='Setting'
SET @SQL='SELECT ''?'' AS DbName FROM [?].sys.tables t inner join sys.schemas s on t.schema_id=s.schema_id WHERE ''?'' LIKE '''+@SearchDb+''' AND s.name LIKE '''+@SearchSchema+''' AND t.name LIKE '''+@SearchTable+''''

INSERT INTO @AllTables (DbName)
    EXEC sp_msforeachdb @SQL

DECLARE @QQQ NVARCHAR(1000)
DECLARE @Query NVARCHAR(MAX)

SET @Query = 'SELECT CompanyName, CompanyNameLatin, AccYear, DBName FROM 
(SELECT TOP 1 '''' AS CompanyName, '''' AS CompanyNameLatin, 0 AS AccYear, '''' AS DBName FROM master..sysdatabases'

DECLARE curs CURSOR FOR
SELECT * FROM @AllTables ORDER BY DbName 

OPEN curs
FETCH NEXT FROM curs INTO @QQQ
WHILE @@FETCH_STATUS = 0
BEGIN
	SET @Query = @Query + '
UNION 
SELECT CompanyName, CompanyNameLatin, AccYear, ''' + @QQQ + ''' AS DBName FROM ' + @QQQ + '..Setting'

	FETCH NEXT FROM curs INTO @QQQ
END

CLOSE curs
DEALLOCate curs

SET @Query = @Query + ') AS CompanyList
WHERE CompanyNameLatin = ''" + CompanyNameLatin + @"'''

EXEC (@Query);";

            SqlCommand cmd = ErisConnectionManager.ConfigureCommand(sqlcon, sqlTran, "Master");
            cmd.CommandText = StrCmd;
            IDataReader dr = cmd.ExecuteReader();

            List<DBConfigEntity> LstConfig = new List<DBConfigEntity>();

            while (dr.Read())
            {
                DBConfigEntity DBConfig = new DBConfigEntity();
                DBConfig.AccYear = int.Parse(dr["AccYear"].ToString());
                DBConfig.DBName = dr["DBName"].ToString();
                LstConfig.Add(DBConfig);
            }

            return LstConfig;
        }
    }

    public class DBConfigEntity
    {
        public Guid ID { get; set; }

        public string CompanyName { get; set; }

        public string CompanyNameLatin { get; set; }

        public int AccYear { get; set; }

        public string DBName { get; set; }
    }
}