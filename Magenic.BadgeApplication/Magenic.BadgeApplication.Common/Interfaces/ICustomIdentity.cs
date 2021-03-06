﻿using Csla.Security;

namespace Magenic.BadgeApplication.Common.Interfaces
{
    /// <summary>
    /// Custom identity to use with application security.
    /// </summary>
    public interface ICustomIdentity : ICslaIdentity
    {
        /// <summary>
        /// The employee id of this user.
        /// </summary>
        int EmployeeId { get; }
    }
}
