using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ST.Domain.Commons.Primitives;

public abstract class Entity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [NotMapped]
    [JsonIgnore]
    public virtual EntityState? CurrentStateTracker { get; set; }
}