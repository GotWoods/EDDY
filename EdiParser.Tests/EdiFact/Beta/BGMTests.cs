using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiParser.EdiFact.Models.Beta;
using EdiParser.x12;
using EdiParser.x12.Mapping;
using Map = EdiFact.Mapping.Map;

namespace EdiParser.Tests.EdiFact.Beta
{
    public class BGMTests
    {
        [Fact]
        public void ShouldParse()
        {
            var expected = new BGM_BeginningOfMessage();
            expected.DocumentMessageName.Documentnamecode = "44";
            expected.DocumentMessageIdentification.DocumentIdentifier = "95-455";
            expected.MessageFunctionCode = "9";


            var options = new MapOptions();
            options.Separator = "+";
            var actual = Map.MapObject<BGM_BeginningOfMessage>("BGM+44+95-455+9", options);

            Assert.Equivalent(expected,actual);
        }
    }
}
