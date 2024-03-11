using System;

namespace ST.Domain.Commons
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }
        DateTime? LastModifiedOn { get; set; }
    }
}