//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Magenic.BadgeApplication.DataAccess.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class QueueEvent
    {
        public QueueEvent()
        {
            this.QueueEventLogs = new HashSet<QueueEventLog>();
        }
    
        public int QueueEventId { get; set; }
        public string QueueEventName { get; set; }
        public string QueueEventDescription { get; set; }
    
        public virtual ICollection<QueueEventLog> QueueEventLogs { get; set; }
    }
}
