using System;
using AutoMapper;

namespace CustomTypeConverters
{
    class Program
    {
        static void Main(string[] args)
        {
            NewMethod();

            var source = new Source
            {
                Number = "5",
                Date = "01/01/2019"
            };

            var destination = Mapper.Map<Destination>(source);

            Console.WriteLine(destination.Number.Equals(5));
            Console.WriteLine(destination.Date.Equals(new DateTime(2019, 2, 1)));
            Console.ReadLine();

        }

        private static void NewMethod()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Source, Destination>();
                cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
                cfg.CreateMap<string, DateTime>().ConvertUsing<DateTimeTypeConvert>();
            });
        }
    }

    public class DateTimeTypeConvert : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return System.Convert.ToDateTime(source);
        }
    }

    public class Source
    {
        public string Number { get; set; }
        public string Date { get; set; }
    }

    public class Destination
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
    }
}
