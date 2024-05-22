using System;

namespace ST.Domain.Commons.Abstractions
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }
        DateTime? LastModifiedOn { get; set; }
    }
}