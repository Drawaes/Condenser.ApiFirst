using Newtonsoft.Json;
using System;
using Xunit;

namespace Condenser.ApiFirst.SwaggerDoc.Facts
{
    public class LoadingDocFacts
    {
        [Fact]
        public void LoadPetStore()
        {
            var doc = System.IO.File.ReadAllText("petstore.json");
            var swagger = JsonConvert.DeserializeObject<Core.Schema>(doc);
        }
    }
}
