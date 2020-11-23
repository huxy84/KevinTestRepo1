using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitmentStep1
{
    public static class MappingHelper
    {
        public static Guid GetId(string[] line)
        {
            Guid customerId = new Guid();

            foreach (var item in line)
            {
                if(Guid.TryParse(item, out customerId))
                {
                    break;
                }
            }

            return customerId;
        }

        public static string GetName(string[] line)
        {
            string name = "# Invalid value";

            foreach (var item in line)
            {
                if(item.Contains(" "))
                {
                    name = item;
                    break;
                }
            }

            return name;
        }

        public static string GetCountry(string[] line)
        {
            string country = "# Missing value";

            foreach (var item in line)
            {
                if (item.Contains(" "))
                {
                    country = item;
                    break;
                }
            }

            return country;
        }

        public static int GetAge (string [] line)
        {
            return GetAllIntegers(line).Min();
        }

        public static int GetSalary(string[] line)
        {
            return GetAllIntegers(line).Max();
        }

        private static List<int> GetAllIntegers(string[] line)
        {
            List<int> numbers = new List<int>();

            foreach (var item in line)
            {
                int num;
                if (int.TryParse(item, out num))
                    numbers.Add(num);
            }

            return numbers;
        }
    }
}
