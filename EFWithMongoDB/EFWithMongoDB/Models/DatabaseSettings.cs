using System;

namespace EFWithMongoDB.Models
{
    public class DatabaseSettings
    {
        public const String Section = "ConnectionStrings";

        public String Name { get; set; }

        public String Database { get; set; }
    }
}
