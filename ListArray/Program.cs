using System;
using System.Collections.Generic;
using AutoMapper;

namespace ListArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ParentSource, ParentDestination>()
                .Include<Source, Destination>();
                cfg.CreateMap<Source, Destination>();
            });

            var sources = new[] { new Source { Value = 1, Value1 = 2 } };
            var arrayDestination = Mapper.Map<Source[], Destination[]>(sources);
            var listDestianation = Mapper.Map<Source[], List<Destination>>(sources);
            Console.WriteLine("Hello World!");
        }
    }

    public class ParentSource
    {
        public int Value1 { get; set; }
    }

    public class Source : ParentSource
    {
        public int Value { get; set; }
    }

    public class ParentDestination
    {
        public int Value1 { get; set; }
    }

    public class Destination : ParentDestination
    {
        public int Value { get; set; }
    }
}
