using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiParser.x12;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Beta
{
    public class EdiSectionParserFactoryTests
    {
        [Fact]
        public void ShouldGetOne()
        {
            var results = EdiSectionParserFactory.LoadSegmentProviders();

            Assert.NotNull(results);
            Assert.Equivalent(typeof(AT7_ShipmentStatusDetails), results["AT7"]);
            Assert.Equivalent(typeof(B3_BeginningSegmentForCarriersInvoice), results["B3"]);

        }
    }
}
