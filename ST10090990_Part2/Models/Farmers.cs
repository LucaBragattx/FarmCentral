namespace ST10090990_Part2.Models
{
    public class Farmers
    {
        private string name;
        private string pass;

        public string FarmerID{ get; set; }
        public string FarmerName { get; set; }
        public string FarmerPassword { get; set; }

        public Farmers() 
        {

        }

        public Farmers(string farmerID, string farmerName, string farmerPassword)
        {
            FarmerID = farmerID;
            FarmerName = farmerName;
            FarmerPassword = farmerPassword;
        }

    }
}
