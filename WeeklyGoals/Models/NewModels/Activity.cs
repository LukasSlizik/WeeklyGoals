﻿using System;
using Newtonsoft.Json;

namespace WeeklyGoals.Models.NewModels
{
    public class Activity
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }

        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }
}