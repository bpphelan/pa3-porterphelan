namespace api
{
    public class Connect
    {
        public string cs { get; set; }

        public Connect()
        {
            string server = "z5zm8hebixwywy9d.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";

            string database = "s80nt7070ufuczp0"; 

            string port = "3306";

            string username = "knsqre8xser6yry9";

            string password = "c9dtxjk1v79juq5c";

            cs = $@"server = {server}; username = {username}; database = {database}; port = {port}; password ={password};";
        }
    }
}