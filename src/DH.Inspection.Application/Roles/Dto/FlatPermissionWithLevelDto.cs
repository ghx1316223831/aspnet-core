using System;
using System.Collections.Generic;
using System.Text;

namespace DH.Inspection.Roles.Dto
{
    public class FlatPermissionWithLevelDto : FlatPermissionDto
    {
        public int Level { get; set; }
        public bool Disabled { get; set; }
        public bool IsLeaf { get; set; }
        public List<FlatPermissionWithLevelDto> Children { get; set; }
    }
}
