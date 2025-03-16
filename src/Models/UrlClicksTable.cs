using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace Models
{
    [DynamoDBTable("UrlShortener_UrlClicksTable")]
    public class UrlClicksTable
    {
        
        public string Id { get; set; }
        public string UrlId { get; set; }
        public DateTime ClickedAt { get; set; }
        public string UserAgent { get; set; }
        public string Referrer { get; set; }
        public string IPAddress { get; set; }
    }
}
