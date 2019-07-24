using System;
using AutoMapper;

namespace NullSubstitution
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new Source
            {
                Name = null
            };
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Source, Destination>()
                    .ForMember(dest => dest.Name, opt => opt.NullSubstitute("Not Null"));
            });

            var destination = Mapper.Map<Destination>(source);

            Console.WriteLine(destination.Name);
        }
    }

    public class Source
    {
        public string Name { get; set; }
    }

    public class Destination
    {
        public string Name { get; set; }
    }
}
