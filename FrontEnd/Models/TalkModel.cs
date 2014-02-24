using MongoDB.Bson.Serialization.Attributes;
using System;

namespace FrontEnd.Models
{
    public class TalkModel
    {
        [BsonId] 
        public String Id { get; set; }
        [BsonElement("speaker")]
        public String Speaker { get; set; }
        [BsonElement("title")]
        public String Title { get; set; }
        [BsonElement("abstract")]
        public String Abstract { get; set; }
        [BsonElement("approved")]
        public Boolean Approved { get; set; }
    }
}