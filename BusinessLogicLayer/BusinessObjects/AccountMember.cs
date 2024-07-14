using System;
using System.Collections.Generic;

namespace BusinessObjects.BusinessObjects;

public partial class AccountMember
{
    public int MemberId { get; set; }

    public string MemberPassword { get; set; } = null!;

    public string? FullName { get; set; }

    public string? EmailAddress { get; set; }

    public int MemberRole { get; set; }

    public virtual Role MemberRoleNavigation { get; set; } = null!;
}
