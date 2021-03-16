using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using DH.Inspection.Authorization;
using DH.Inspection.Authorization.Permissions;
using DH.Inspection.Authorization.Roles;
using DH.Inspection.Authorization.Users;
using DH.Inspection.Roles.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DH.Inspection.Roles
{
    [AbpAuthorize(PermissionNames.Pages_Roles)]
    public class RoleAppService : AsyncCrudAppService<Role, RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>, IRoleAppService
    {
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;
        private readonly PermissionAppService _permissionAppService;
        List<string> commonPermissions = new List<string>() { PermissionNames.Pages.ToLower(),
                PermissionNames.Pages_Users.ToLower(),
                PermissionNames.Pages_Roles.ToLower()};
        public RoleAppService(IRepository<Role> repository, RoleManager roleManager, UserManager userManager, PermissionAppService permissionAppService)
            : base(repository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _permissionAppService = permissionAppService;
        }
        [AbpAuthorize(PermissionNames.Pages_Sys_Role)]
        public override async Task<RoleDto> CreateAsync(CreateRoleDto input)
        {
            CheckCreatePermission();

            var role = ObjectMapper.Map<Role>(input);
            role.SetNormalizedName();

            CheckErrors(await _roleManager.CreateAsync(role));
            if (role.Name.ToLower() == "admin"
                || input.GrantedPermissions.Contains(PermissionNames.Pages_Sys)
                || input.GrantedPermissions.Contains(PermissionNames.Pages_Sys_Role)
                || input.GrantedPermissions.Contains(PermissionNames.Pages_Sys_SysUser)
                )
            {
                input.GrantedPermissions.AddRange(commonPermissions);
            }
            var grantedPermissions = PermissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissions.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            return MapToEntityDto(role);
        }
        [AbpAuthorize(PermissionNames.Pages_Sys_Role)]
        public async Task<bool> GetIsRoleNameRepeat(string name, int id)
        {
            if (!string.IsNullOrEmpty(name))
            {

                var roles = await Repository.GetAll().FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

                if (roles != null)
                {
                    //创建
                    if (id == 0)
                    {
                        return true;
                    }
                    //更新时是原名字
                    else if (roles.Id == id)
                    {
                        return false;
                    }
                    //更新时是其他重复的名字
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        [AbpAuthorize(PermissionNames.Pages_Sys_Role)]
        public async Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input)
        {
            var roles = await _roleManager
                .Roles
                .WhereIf(
                    !input.Permission.IsNullOrWhiteSpace(),
                    r => r.Permissions.Any(rp => rp.Name == input.Permission && rp.IsGranted)
                )
                .ToListAsync();

            return new ListResultDto<RoleListDto>(ObjectMapper.Map<List<RoleListDto>>(roles));
        }
        [AbpAuthorize(PermissionNames.Pages_Sys_Role)]
        public override async Task<RoleDto> UpdateAsync(RoleDto input)
        {
            CheckUpdatePermission();

            var role = await _roleManager.GetRoleByIdAsync(input.Id);
            input.CreationTime = role.CreationTime;
            ObjectMapper.Map(input, role);

            CheckErrors(await _roleManager.UpdateAsync(role));
            if (role.Name.ToLower() == "admin"
                || input.GrantedPermissions.Contains(PermissionNames.Pages_Sys)
                || input.GrantedPermissions.Contains(PermissionNames.Pages_Sys_Role)
                || input.GrantedPermissions.Contains(PermissionNames.Pages_Sys_SysUser)
                )
            {
                input.GrantedPermissions.AddRange(commonPermissions);
            }
            var grantedPermissions = PermissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissions.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            return MapToEntityDto(role);
        }
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();
            var role = await _roleManager.FindByIdAsync(input.Id.ToString());
            if (role.Name.ToLower() == "admin")
            {
                throw new Abp.UI.UserFriendlyException("不能删除管理员！");
            }
            var users = await _userManager.GetUsersInRoleAsync(role.NormalizedName);

            foreach (var user in users)
            {
                CheckErrors(await _userManager.RemoveFromRoleAsync(user, role.NormalizedName));
            }

            CheckErrors(await _roleManager.DeleteAsync(role));
        }

        public Task<ListResultDto<PermissionDto>> GetAllPermissions()
        {
            var permissions = PermissionManager.GetAllPermissions();

            return Task.FromResult(new ListResultDto<PermissionDto>(
                ObjectMapper.Map<List<PermissionDto>>(permissions).OrderBy(p => p.DisplayName).ToList()
            ));
        }

        protected override IQueryable<Role> CreateFilteredQuery(PagedRoleResultRequestDto input)
        {

            return Repository.GetAllIncluding(x => x.Permissions)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => (x.Name.Contains(input.Keyword)
                || x.DisplayName.Contains(input.Keyword)
                || x.Description.Contains(input.Keyword)))
                .Where(x => !x.IsDeleted);
        }

        protected override async Task<Role> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAllIncluding(x => x.Permissions).FirstOrDefaultAsync(x => x.Id == id);
        }

        protected override IQueryable<Role> ApplySorting(IQueryable<Role> query, PagedRoleResultRequestDto input)
        {
            return query.OrderBy(r => r.DisplayName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
        public async Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input)
        {
            var permissions = PermissionManager.GetAllPermissions();
            var role = await _roleManager.GetRoleByIdAsync(input.Id);
            var grantedPermissions = (await _roleManager.GetGrantedPermissionsAsync(role)).ToArray();
            var roleEditDto = ObjectMapper.Map<RoleEditDto>(role);

            return new GetRoleForEditOutput
            {
                Role = roleEditDto,
                Permissions = ObjectMapper.Map<List<FlatPermissionDto>>(permissions).OrderBy(p => p.DisplayName).ToList(),
                GrantedPermissionNames = grantedPermissions.Select(p => p.Name).ToList()
            };
        }
        public async Task<GetRoleForEditOutput> GetRoleForEdit1(EntityDto input)
        {
            var permissions = _permissionAppService.GetAllPermissionsOfTree();

            var permissions1 = PermissionManager.GetAllPermissions();
            var role = await _roleManager.GetRoleByIdAsync(input.Id);
            var grantedPermissions = (await _roleManager.GetGrantedPermissionsAsync(role)).ToArray();
            var roleEditDto = ObjectMapper.Map<RoleEditDto>(role);

            return new GetRoleForEditOutput
            {
                Role = roleEditDto,
                Permissions = ObjectMapper.Map<List<FlatPermissionDto>>(permissions1).OrderBy(p => p.DisplayName).ToList(),
                PermissionsTree = permissions.OrderBy(p => p.DisplayName).ToList(),
                GrantedPermissionNames = grantedPermissions.Select(p => p.Name).ToList()
            };
        }
    }
}

