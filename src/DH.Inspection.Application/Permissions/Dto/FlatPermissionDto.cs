using Abp.Application.Services.Dto;

namespace DH.Inspection.Authorization.Permissions.Dto
{
    public class FlatPermissionDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int Sequence { get; set; }
        
        public string Permission { get; set; }

    }
}