using System;
using System.Collections.Generic;
using NetcoreSaas.Application.Dtos.Core.Workspaces;

namespace NetcoreSaas.Application.Dtos.Core.Tenants
{
    public class TenantDto : MasterEntityDto
    {
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Subdomain { get; set; }
        public string Icon { get; set; }
        public string Logo { get; set; }
        public string LogoDarkmode { get; set; }
        public string SubscriptionCustomerId { get; set; }
        public string SubscriptionPlanId { get; set; }
        public ICollection<TenantUserDto> Users { get; set; }
        public ICollection<TenantProductDto> Products { get; set; }
        public ICollection<WorkspaceSimpleDto> Workspaces { get; set; }
        public TenantUserDto CurrentUser { get; set; }

    }
}
