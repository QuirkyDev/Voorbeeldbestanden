using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImages.Models
{
    [Table("Product", Schema = "UploadImages")]
    public class Product
    {
        public int ProductID { get; set; }
        public string Naam { get; set; }

        public string Bestandsnaam { get; set; }

    }
}
