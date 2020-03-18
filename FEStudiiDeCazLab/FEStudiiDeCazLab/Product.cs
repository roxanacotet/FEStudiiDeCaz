using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEStudiiDeCazLab
{
    class Product
    { 
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int SKU { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string ImageURL { get; set; }
        }
    }
