using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auxilium.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime MessageSent { get; set; }
        public bool Read { get; set; }

        //Recipient
        public int RecipientId { get; set; }
        //Parent Message.
        public int ParentId { get; set; }
    }
}