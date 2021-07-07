
namespace Project_UAS_Pemrograman_Framework.NET
{
    class User
    {
        private int idUser;
        private string username;
        private string password;
        private string tipe;

        public void setIdUser(int idUser)
        {
            this.idUser = idUser;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public void setTipe(string tipe)
        {
            this.tipe= tipe;
        }

        public int getIdUser()
        {
            return this.idUser;
        }
        
        public string getUsername()
        {
            return this.username;
        }

        public string getPassword()
        {
            return this.password;
        }

        public string getTipe()
        {
            return this.tipe;
        }
    }
}
