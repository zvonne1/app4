using System;

namespace App4.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Firstname  { get; set; }
        public string Lastname { get; set; }
        public DateTime BDay { get; set; }
        public int ClubId { get; set; }
        public int Nationid { get; set; }
        public bool SonderLiz { get; set; }

    }
}