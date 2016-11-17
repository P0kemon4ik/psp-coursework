using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationLab.Models
{
    public class Mobile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int Camera { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int ProducerId { get; set; }
        public Producer producer { get; set; }
        public int BatteryId { get; set; }
        public Battery battery { get; set; }
        public int ColorId { get; set; }
        public Color color { get; set; }
    }
}