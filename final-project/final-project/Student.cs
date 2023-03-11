﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
        public Student(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}