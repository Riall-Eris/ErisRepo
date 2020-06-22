using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Eris
{
    public static class DBConfigData
    {
        public static List<DBConfigEntity> SelectAllCompany(string ConnectionString, SqlConnection sqlcon = null, SqlTransaction sqlTran = null)
        {
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

            SqlCommand cmd = ErisConnectionManager.ConfigureCommand(sqlcon, sqlTran, ConnectionString);
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

            SqlCommand cmd1 = ErisConnectionManager.ConfigureCommand(sqlcon, sqlTran, ConnectionString);
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


        public static List<DBConfigEntity> SelectAllDataBase(string PatternDB, string ConnectionString, SqlConnection sqlcon = null, SqlTransaction sqlTran = null)
        {
            string StrCmd = @"SELECT name AS CompanyNameLatin
	FROM master..sysdatabases
	WHERE name Like '" + PatternDB + "%'";

            SqlCommand Cmd = ErisConnectionManager.ConfigureCommand(sqlcon, sqlTran, ConnectionString);
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

        public static List<DBConfigEntity> SelectAllYear(string CompanyNameLatin, string ConnectionString, SqlConnection sqlcon = null, SqlTransaction sqlTran = null)
        {
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
WHERE CompanyName <> '''''

EXEC (@Query);";

            SqlCommand cmd = ErisConnectionManager.ConfigureCommand(sqlcon, sqlTran, ConnectionString);
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

    public class ErisConnectionManager
    {
        public static SqlConnection GetConnection(SqlConnection sqlcon, string connectionString)
        {
            sqlcon = new SqlConnection(connectionString);

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
            }
            catch //(Exception ex)
            {
                sqlcon = null;
            }


            return sqlcon;
        }

        public static SqlCommand ConfigureCommand(SqlConnection sqlcon, SqlTransaction sqlTran, string ConnectionString)
        {
            if (sqlcon == null)
                sqlcon = ErisConnectionManager.GetConnection(sqlcon, ConnectionString);

            if (sqlcon.State != ConnectionState.Open)
                sqlcon.Open();

            SqlCommand cmd = sqlcon.CreateCommand();

            if (sqlTran != null)
                cmd.Transaction = sqlTran;

            cmd.CommandTimeout = int.MaxValue;

            return cmd;
        }

        public static void CloseConnection(SqlConnection sqlcon, SqlTransaction sqlTran)
        {
            if (sqlTran == null)
                if (sqlcon != null)
                    sqlcon.Close();
        }

        internal static DataSet ExecuteDataset(SqlCommand cmd)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}