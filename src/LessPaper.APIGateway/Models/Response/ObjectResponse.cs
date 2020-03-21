﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.APIGateway.Models.Response
{
    public class ObjectResponse : IMetadata
    {
        public ObjectResponse(IMetadata metadata)
        {
            ObjectName = metadata.ObjectName;
            ObjectId = metadata.ObjectId;
            SizeInByte = metadata.SizeInByte;
        }

        /// <inheritdoc />
        [JsonPropertyName("object_name")]
        public string ObjectName { get; }

        /// <inheritdoc />
        [JsonPropertyName("object_id")]
        public string ObjectId { get; }

        /// <inheritdoc />
        [JsonPropertyName("size_in_bytes")]
        public uint SizeInByte { get; }
    }
}
