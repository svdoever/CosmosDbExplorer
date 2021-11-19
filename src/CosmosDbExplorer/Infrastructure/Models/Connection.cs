﻿using System;
using System.ComponentModel;
using System.Windows.Media;
using CosmosDbExplorer.Infrastructure.MarkupExtensions;
using Newtonsoft.Json;

namespace CosmosDbExplorer.Infrastructure.Models
{
    public class Connection : IEquatable<Connection>
    {
        public Connection(Guid id)
        {
            Id = id;
            EnableEndpointDiscovery = true;
        }

        [JsonConstructor]
        public Connection(Guid? id, string label, Uri endpoint, string secret, ConnectionType connectionType, bool enableEndpointDiscovery, Color? accentColor)
        {
            Id = id ?? Guid.NewGuid();
            Label = label;
            DatabaseUri = endpoint;
            AuthenticationKey = secret;
            ConnectionType = connectionType;
            EnableEndpointDiscovery = enableEndpointDiscovery;
            AccentColor = accentColor;
        }

        [JsonProperty]
        public Guid Id { get; protected set; }

        [JsonProperty]
        public string Label { get; protected set; }

        [JsonProperty]
        public Uri DatabaseUri { get; protected set; }

        [JsonProperty]
        public string AuthenticationKey { get; protected set; }

        [JsonProperty]
        public ConnectionType ConnectionType { get; protected set; }

        [JsonProperty]
        public bool EnableEndpointDiscovery { get; protected set; }

        [JsonProperty]
        public Color? AccentColor { get; protected set; }

        public bool IsLocalEmulator()
        {
            return DatabaseUri == Constants.Emulator.Endpoint
                && AuthenticationKey == Constants.Emulator.Secret;
        }

        public bool Equals(Connection other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum ConnectionType
    {
        Gateway,
        [Description("Direct HTTPS")]
        DirectHttps,
        [Description("Direct TCP")]
        DirectTcp
    }
}
