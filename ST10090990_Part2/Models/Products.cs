using Microsoft.AspNetCore.Mvc;

namespace ST10090990_Part2.Models
{
    public class Products
    {
        public string ProductID { get; set; }
        public string FarmerID{ get; set; }
        public string ProductName { get; set; }
        public DateTime DateAdded { get; set; }

        public Products()
        {

        }

        public Products(string productID,string farmerID, string productName, DateTime dateAdded)
        {
            ProductID = productID;
            FarmerID = farmerID;
            ProductName = productName;
            DateAdded = dateAdded;
        }
    }
}
