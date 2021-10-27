using mini.DTO.Responses;
using Newtonsoft.Json;
using RiskFirst.Hateoas.Models;
using System.Collections.Generic;

namespace mini.API.Models
{
    public class ProductHateoasResponse : ILinkContainer
    {

        public ProductSimpleUpdateResponse Product { get; set; }

        private Dictionary<string, Link> links;
        [JsonProperty("_links")]
        public Dictionary<string, Link> Links { get => links ?? new Dictionary<string, Link>(); set => links = value; }

        public void AddLink(string id, Link link)
        {
            Links.Add(id, link);
        }
    }
}