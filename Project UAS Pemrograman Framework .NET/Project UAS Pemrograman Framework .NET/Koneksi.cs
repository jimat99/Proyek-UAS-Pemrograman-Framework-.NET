using System.Data.OleDb;

namespace Project_UAS_Pemrograman_Framework.NET
{
    class Koneksi
    {
        private string connectionString;
        private OleDbConnection connection;

        public Koneksi()
        {
            this.connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DELL\source\" +
                @"repos\Project UAS Pemrograman Framework .NET\Project UAS Pemrograman Framework .NET\" +
                @"Inventori Toko.accdb";
        }

        public void openConnection()
        {
            this.connection = new OleDbConnection(this.connectionString);
            this.connection.Open();
        }

        public void closeConnection()
        {
            this.connection.Close();
        }

        public OleDbDataReader executeSelectQuery(string sql)
        {
            OleDbCommand command = new OleDbCommand(sql, this.connection);
            OleDbDataReader reader = command.ExecuteReader();
            return reader;
        }

        public object executeScalarSelectQuery(string sql)
        {
            OleDbCommand command = new OleDbCommand(sql, this.connection);
            object value = command.ExecuteScalar();
            return value;
        }

        public void executeNonSelectQuery(string sql)
        {
            OleDbCommand command = new OleDbCommand(sql, this.connection);
            command.ExecuteNonQuery();
        }
    }
}
