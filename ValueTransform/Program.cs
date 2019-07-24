using System;
using AutoMapper;

namespace ValueTransform
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Source, Destination>();
                cfg.ValueTransformers.Add<string>(val => val + "!!");
            });

            var destination = Mapper.Map<Destination>(new Source { Greeting = "Hi Edwin", Name = "Edwin" });
            Console.WriteLine(destination.Name);
        }
    }

    public class Source
    {
        public string Greeting { get; set; }
        public string Name { get; set; }
    }

    public class Destination
    {
        public string Greeting { get; set; }

        public string Name { get; set; }
    }

}
