using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiParser.EdiFact.Models.Beta;
using EdiParser.x12;
using EdiParser.x12.Mapping;
using Map = EdiFact.Mapping.Map;

namespace EdiParser.Tests.EdiFact.Beta
{
    public class UNBTests
    {
        [Fact]
        public void Map_ShouldMapToObject()
        {
            var expected = new UNB_InterchangeHeader();
            expected.SyntaxIdentifier.SyntaxIdentifier = "UNOC";
            expected.SyntaxIdentifier.SyntaxVersionNumber = "3";
            expected.Sender.InterchangeSenderIdentification = "LY78";
            expected.Recipient.InterchangeRecipientIdentification = "16390913";
            expected.Date.Date = "230127";
            expected.Date.Time = "0814";
            expected.InterchangeControlReference = "614720311";

            var options = new MapOptions();
            options.Separator = "+";

            var actual = Map.MapObject<UNB_InterchangeHeader>("UNB+UNOC:3+LY78+16390913+230127:0814+614720311", options);

            Assert.Equivalent(expected,actual);
        }
    }
}
