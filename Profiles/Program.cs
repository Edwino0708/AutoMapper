using System;
using AutoMapper;

namespace Profiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new Source
            {
                Date = new DateTime(2018, 7, 7, 7, 7, 7)
            };

            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
            var destination = Mapper.Map<Destination>(source);

            // destination.Hour
            Console.WriteLine(destination.Hour.Equals(source.Date.Hour) + " " +
             destination.Minute.Equals(source.Date.Minute));
        }
    }

    public class Source
    {
        public DateTime Date { get; set; }
    }
    public class Destination
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }

    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Source, Destination>()
                .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => src.Date.Hour))
                .ForMember(dest => dest.Minute, opt => opt.MapFrom(src => src.Date.Minute))
                .ForMember(dest => dest.Second, opt => opt.MapFrom(src => src.Date.Second));
        }
    }
}
