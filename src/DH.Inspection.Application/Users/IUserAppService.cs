using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DH.Inspection.Roles.Dto;
using DH.Inspection.Users.Dto;

namespace DH.Inspection.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
