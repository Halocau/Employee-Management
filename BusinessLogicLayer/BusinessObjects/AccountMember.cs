using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.BusinessObjects;

public partial class AccountMember
{
    public string MemberId { get; set; } = null!;

    public string MemberPassword { get; set; } = null!;

    public string? FullName { get; set; }

    public string? EmailAddress { get; set; }

    public int MemberRole { get; set; }

    public virtual Role MemberRoleNavigation { get; set; } = null!;
}
