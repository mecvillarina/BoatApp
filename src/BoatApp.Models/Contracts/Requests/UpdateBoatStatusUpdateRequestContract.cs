﻿using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public  class UpdateBoatStatusUpdateRequestContract
{
    [JsonPropertyName("$set")]
    public UpdateBoatStatusUpdateSetRequestContract Set { get; set; }
}