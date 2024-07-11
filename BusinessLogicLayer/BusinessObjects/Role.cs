using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.BusinessObjects;

public partial class Role
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AccountMember> AccountMembers { get; set; } = new List<AccountMember>();
}
