using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GV.DVDCentral.BL.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public int MovieId { get; set; }
        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")] 

        public double Cost { get; set; }

        [DisplayName("Title")]

        public string MovieTitle { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }


    }
}
