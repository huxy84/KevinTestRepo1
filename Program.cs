using System;
using AutoMapper;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO.Compression;
using System.Text;
using System.Reflection;

namespace RecruitmentStep1
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Attribute, Customer>()
                    .ForMember(dest => dest.Id, src => src.MapFrom(m => m.AttributeId))
                    .ForMember(dest => dest.Name, src => src.MapFrom(m => m.AttributeName))
                    .ForMember(dest => dest.Age, src => src.MapFrom(m => m.MinValue))
                    .ForMember(dest => dest.Salary, src => src.MapFrom(m => m.MaxValue)));

            var mapper = new Mapper(config);

            StringBuilder resultBuilder = new StringBuilder();

            var dsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "datasets");
            var dsFiles = Directory.EnumerateFiles(dsPath).ToList();

            dsFiles.ForEach(filePath =>
            {
                var contents = File.ReadAllText(filePath);
                int dataStartIndex = contents.IndexOf("UserId");
                int dataEndIndex = contents.IndexOf("# Attribute Mapping");
                contents = contents.Substring(dataStartIndex, dataEndIndex - dataStartIndex);
                var formattedResults = contents.Split(Environment.NewLine);
                formattedResults = formattedResults.Where(w => !string.IsNullOrEmpty(w)).ToArray();
                var finalRead = formattedResults.Skip(1).ToList();

                finalRead.ForEach(fe =>
                {
                    var args = fe.Split(",");
                    var id = new Guid(args[0]);
                    var name = MappingHelper.GetName(args);
                    Attribute att = new Attribute
                    {
                        AttributeId = MappingHelper.GetId(args),
                        AttributeName = MappingHelper.GetName(args),
                        MinValue = MappingHelper.GetAge(args),
                        MaxValue = MappingHelper.GetSalary(args)
                    };

                    var customer = mapper.Map<Customer>(att);

                    resultBuilder.AppendLine(customer.ToString());
                });
            });

            var result = resultBuilder.ToString(); // TODO - See readme for output format.
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}


