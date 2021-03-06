﻿using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.DTO
{
    public class ClientDTO
    {
        [JsonPropertyName("ID")]
        public Guid Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("TIN")]
        public string TIN { get; set; }

        [JsonPropertyName("ClientType")]
        public string ClientType { get; set; }

        [JsonPropertyName("CreateDate")]
        public string CreateDate { get; set; }

        [JsonPropertyName("UpdateDate")]
        public DateTime? UpdateDate { get; set; }
    }
}
