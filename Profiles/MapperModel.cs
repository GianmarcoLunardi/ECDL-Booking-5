using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Identity2.Dto;
using Identity2.Models;
using Identity2.Models.Identity;
using Identity2.Areas.Identity.Data;
using Identity2.ViewModel;
using Identity2.Service.Interface;
using Microsoft.IdentityModel.Tokens;

namespace Identity2.Profiles
{
    public class MapperModel : Profile
    {
        private readonly ISchoolRepository _SchoolRepo;
        public MapperModel(
            )
        {

            //CreateMap<School, SchoolDto>();

            //CreateMap<ApplicationUser, InputViewModel_Manage_index>();
            CreateMap<Admin_Users_User, ApplicationUser>()
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.IdSchool, opt => opt.MapFrom(src => src.IdSchool))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                ;
            CreateMap<ApplicationUser, Admin_Users_User>();

            // DATA BINDING Model exam con la ViewModel Exam

            CreateMap<Exam, Admin_Exam_Create>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Ora, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.TipoSessione, opt => opt.MapFrom(src => src.SessionType))
                .ForMember(dest => dest.LuogoEsameId, opt => opt.MapFrom(src => src.IdSchool))
                //.ForMember(d => d.LuogoEsameLista, opt => null)
                .ForMember(dest => dest.EsaminatoreId, opt => opt.MapFrom(src => src.ExaminerId))
                ;
        }
    }
}

//