﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section06.RelatedDataLoad.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //[Precision(18,2)] // ################,##
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProductFeature ProductFeature { get; set; }
    }
}
