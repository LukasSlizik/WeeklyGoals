using System;
using Newtonsoft.Json;

namespace WeeklyGoals.Models.Activity
{
    public class TimePeriod
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }

        [JsonProperty("from", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset From { get; set; }

        [JsonProperty("to", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset To { get; set; }
    }
}