using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elf.Core.Models
{
    public class Elf
    {
        public enum IntelligenceType
        {
            SuperDumb,
            Dumb,
            Average,
            Smart,
            SuperSmart
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Naughtiness { get; set; }

        public string Specialty { get; set; }

        public IntelligenceType Intelligence { get; set; }
    }
}
