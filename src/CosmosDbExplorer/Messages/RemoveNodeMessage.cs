﻿namespace CosmosDbExplorer.Messages
{

    public class RemoveNodeMessage
    {
        public RemoveNodeMessage(string altLink)
        {
            AltLink = altLink;
        }

        public string AltLink { get; }
    }
}
