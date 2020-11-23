using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentStep1
{
    class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string OccupationType { get; set; }

        public int Age { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            var rn = Environment.NewLine;
            return $"User Id: {Id.ToString()}{rn}Name: {Name}{rn}Age: {Age}{rn}Salary: ${Salary}{rn}{rn}";
        }
    }
}
