using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GV.DVDCentral.BL.Models
{
    public class ShoppingCart
    {
             public  double TAX_VALUE { get; set; } = .055;

            // Declaration application specific - Declaration Cost

            public List<Movie> Items { get; set; } = new List<Movie>();
            public int NumberOfItems { get { return Items.Sum(item => item.Quantity); } }

            [DisplayFormat(DataFormatString = "{0:C}")]

            public double SubTotal { get { return Items.Sum(item => item.Cost * item.Quantity); } }

            [DisplayFormat(DataFormatString = "{0:C}")]
            public double Tax { get { return SubTotal * TAX_VALUE; } }

            [DisplayFormat(DataFormatString = "{0:C}")]
            public double Total { get { return SubTotal + Tax; } }

       
        
    }
}
