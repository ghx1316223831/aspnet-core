using Abp.Authorization;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace DH.Inspection.Authorization.Permissions.Dto
{
  
    public class FlatPermissionWithLevelDto: FlatPermissionDto
    {
        public int Level { get; set; }
        public bool Disabled { get; set; }
        public bool IsLeaf { get; set; }
        public List<FlatPermissionWithLevelDto> Children { get; set; }
    }
}
