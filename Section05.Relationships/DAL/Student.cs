﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section05.Relationships.DAL
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
