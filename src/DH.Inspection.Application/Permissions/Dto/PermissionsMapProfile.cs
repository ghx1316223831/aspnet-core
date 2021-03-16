using Abp.Authorization;
using Abp.Authorization.Users;
using AutoMapper;
using DH.Inspection.Authorization.Permissions.Dto;
using DH.Inspection.Authorization.Users;

namespace DH.Inspection.Users.Dto
{
    public class PermissionsMapProfile : Profile
    {

        public PermissionsMapProfile()
        {

            CreateMap<Permission, FlatPermissionDto>();

            CreateMap<Permission, FlatPermissionWithLevelDto>()
                    //.ForMember(x => x.Id, opt => opt.MapFrom(x => x.Properties["id"]))
                    .ForMember(x => x.Sequence, opt => opt.MapFrom(x => x.Properties["Sequence"]))
                    .ForMember(x => x.Permission, opt => opt.MapFrom(x => x.Name))
                    .ForMember(x => x.Children, opt => opt.Ignore());
        }
    }
}
