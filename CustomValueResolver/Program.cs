using System;
using AutoMapper;

namespace CustomValueResolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Source, Destination>()
                    .ForMember(dest => dest.Total, opt => opt.MapFrom<CustomValueResolver>());
            });

            var source = new Source
            {
                Value1 = 2,
                Value2 = 3
            };

            var destination = Mapper.Map<Destination>(source);
            Console.WriteLine(destination.Total.ToString());


        }
    }

    public class CustomValueResolver : IValueResolver<Source, Destination, int>
    {
        public int Resolve(Source source, Destination destination, int destMember, ResolutionContext context)
            => source.Value1 + source.Value2;
    }



    public class Source
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }

    public class Destination
    {
        public int Total { get; set; }
    }
}
