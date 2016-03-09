using System;
using Microsoft.Win32;

namespace AssociateRecords.Domain
{
    public class ConversationHistory : IAmHistorical
    {
        public DateTime FromDateTime { get; set; }

        public DateTime? ToDateTime { get; set; }

        public string Conversation { get; set; }

        public User ConversationHadWith { get; set; }
    }
}