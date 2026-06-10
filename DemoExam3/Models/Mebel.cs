using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam3.Models
{
    public class Mebel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public decimal Weight { get; set; }
        public decimal Size { get; set; }
        public decimal Cost { get; set; }
        public int IdCategory { get; set; }


    }
}
