using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApi.Resources;
using VehicleApiData.DomainModels;

namespace VehicleApi
{
    public class MappingProfile : Profile
    {
   
        public MappingProfile()
        {
            //DomainModel to ApiResource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Users, UsersResource>();
            CreateMap<Categories, CategoriesDto> ();
            CreateMap<Products, ProductsResource>();

             //Api Resource to DomainModel
             CreateMap<MakeResource, Make>()
                .ForMember(v => v.Id, opt => opt.Ignore());
            CreateMap<MakeUpdateResource, Make>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.Models, opt => opt.Ignore());
            CreateMap<ModelResource, Model>()
                .ForMember(v=> v.Id, opt => opt.Ignore())
                .ForMember(v => v.MakeId, opt => opt.Ignore());
            CreateMap<UsersResource, Users>()
                .ForMember(v => v.Id, opt => opt.Ignore());
            CreateMap<CategoriesDto, Categories>().
                ForMember(v => v.Id, opt => opt.Ignore());
            CreateMap<ProductsResource, Products>().
                ForMember(v=>v.Id, opt=> opt.Ignore());
        }
    }
}
