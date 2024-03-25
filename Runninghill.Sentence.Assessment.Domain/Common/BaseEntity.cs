using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Runninghill.Sentence.Assessment.Domain.Common
{
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
    public abstract class BaseEntity<T>
    {
        [Key]
        public required T Id { get; set; }
    }
}
