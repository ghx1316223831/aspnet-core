using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using DH.Inspection.Authorization.Permissions.Dto;
using AutoMapper;

namespace DH.Inspection.Authorization.Permissions
{
    public class PermissionAppService : InspectionAppServiceBase, IPermissionAppService
    {
       
        #region 树形权限
        public List<FlatPermissionWithLevelDto> GetAllPermissionsOfTree()
        {
            var permissions = PermissionManager.GetAllPermissions();
            var rootPermissions = permissions.Where(p => p.Parent == null);
            var id = 0;
            var result = new List<FlatPermissionWithLevelDto>();

            foreach (var rootPermission in rootPermissions)
            {
                
                AddPermissionOfTree(rootPermission, permissions, rootPermission, result,ref id);
                id++;
            }
            //去除权限树出现多余权限，在更新创建角色时再加上
            List<string> permissionName = new List<string>() { PermissionNames.Pages.ToLower(),
                PermissionNames.Pages_Users.ToLower(),
                PermissionNames.Pages_Roles.ToLower()
                /*PermissionNames.Pages_Administration.ToLower()*/ };            // var perm = FindPermission("pages.index", result);
            //var resultList = result.Where(x => !permissionName.Contains(x.Name.ToLower())).OrderBy(x => x.Sequence).ToList().Prepend(perm).ToList();
            var resultList = result.Where(x => !permissionName.Contains(x.Name.ToLower())).OrderBy(x => x.Sequence).ToList();
            return resultList;
        }
        private void AddPermissionOfTree(Permission permission, IReadOnlyList<Permission> allpermissions, Permission rootPermission, List<FlatPermissionWithLevelDto> result,ref int id)
        {
            var childrenNew = new List<FlatPermissionWithLevelDto>();
            var flatpermission = ObjectMapper.Map<FlatPermissionWithLevelDto>(permission);
            flatpermission.Id = id;
            //加入只有一级的页面
            if (permission.Parent!=null && permission.Parent.Equals(rootPermission) && (permission.Children == null || permission.Children.Count <= 0) )
            {
                flatpermission.IsLeaf = true;
                result.Add(flatpermission);
                return;
            }
            if (permission.Children == null || permission.Children.Count <= 0)
            {
                flatpermission.IsLeaf = true;
                return;
            }
            flatpermission.Level = 0;
            var children = allpermissions.Where(p => p.Parent != null && p.Parent.Name == permission.Name).ToList();
            
           
            foreach (var childpermission in children)
            {
                
                id++;
                AddPermissionOfTree(childpermission, allpermissions, rootPermission, result,ref id);
               var newChild= ObjectMapper.Map<FlatPermissionWithLevelDto>(childpermission);
                newChild.Id = id;
                newChild.Level = 1;
                if (childpermission.Children == null || childpermission.Children.Count <= 0)
                {
                    newChild.IsLeaf = true;
                }
                childrenNew.Add(newChild);
            }
            flatpermission.Children = childrenNew;
            result.Add(flatpermission);
        }
        private FlatPermissionWithLevelDto FindPermission(string permissionName, List<FlatPermissionWithLevelDto> allpermissions)
        {
            if (allpermissions != null && allpermissions.Count>0)
            {
                foreach (var permission in allpermissions)
                {
                  var model=  FindPermissionByName(permission, permissionName);
                    if(model!=null && model.Name.ToLower() == permissionName)
                    {
                        return model;
                    }
                }
            }
            return null;
        }
        private FlatPermissionWithLevelDto FindPermissionByName(FlatPermissionWithLevelDto tnParent, string strValue)
        {
            if (tnParent == null) return null;

            if (tnParent.Name.ToLower() == strValue) return tnParent;
            FlatPermissionWithLevelDto tnRet = null;
            if (tnParent.Children != null && tnParent.Children.Count > 0)
            {
                foreach (var tn in tnParent.Children)
                {

                    tnRet = FindPermissionByName(tn, strValue);

                    if (tnRet != null) break;

                }
            }

            return tnRet;

        }
        #endregion

        #region 当前使用数组权限
        public ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions()
        {
            var permissions = PermissionManager.GetAllPermissions();
            var rootPermissions = permissions.Where(p => p.Parent == null);

            var result = new List<FlatPermissionWithLevelDto>();

            foreach (var rootPermission in rootPermissions)
            {
                var level = 0;
                AddPermission(rootPermission, permissions, result, level);
            }

            return new ListResultDto<FlatPermissionWithLevelDto>
            {
                Items = result
            };
        }
        private void AddPermission(Permission permission, IReadOnlyList<Permission> allPermissions, List<FlatPermissionWithLevelDto> result, int level)
        {
            var flatPermission = ObjectMapper.Map<FlatPermissionWithLevelDto>(permission);
            flatPermission.Level = level;
            result.Add(flatPermission);

            if (permission.Children == null)
            {
                return;
            }

            var children = allPermissions.Where(p => p.Parent != null && p.Parent.Name == permission.Name).ToList();

            foreach (var childPermission in children)
            {
                AddPermission(childPermission, allPermissions, result, level + 1);
            }
        }

        #endregion
    }
}