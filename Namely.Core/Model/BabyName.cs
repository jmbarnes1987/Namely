﻿using SQLite;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namely.Core.Model
{
    public class BabyName
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Meaning { get; set; }//Implement this throughout
        public string History { get; set; }
        public string Pronunciation { get; set; }
        //public List<string> NickNames { get; set; }
        //Continue adding additional name attributes
    }
}
