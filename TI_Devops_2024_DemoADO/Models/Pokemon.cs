﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_Devops_2024_DemoADO.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Height { get; set; }
        public int Weight { get; set; }
        public string? Description { get; set; }
        public int Type1Id { get; set; }
        public int? Type2Id { get; set;}

        public override string ToString()
        {
            return $"Id : {Id}\nName : {Name}";
        }
    }
}
