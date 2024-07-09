﻿using System;
using System.Collections.Generic;

namespace Section02.DatabaseFirst.Scaffold.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }
}
