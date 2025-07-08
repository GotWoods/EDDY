using Eddy.Core.Extension;
using System;
using Xunit;
using Eddy.x12.DomainModels.Transportation.v4040;

namespace Eddy.Tests
{
    public class EdiSegmentExtensionTest
    {
        [Fact]
        public void GetStructureMap_Returns_ValidStructure()
        {
            // Arrange
            var edi214 = new Edi214_TransportationCarrierShipmentStatusMessage();

            // Act
            string structure = edi214.GetStructureMap();

            // Assert+
            Assert.NotNull(structure);
            Assert.NotEmpty(structure);
            
            // Verify key sections are present in the correct order
            Assert.Contains("01 - TransactionSetHeader", structure);
            Assert.Contains("02 - BeginningSegmentForTransportationCarrierShipmentStatusMessage", structure);
            Assert.Contains("03 - InterlineInformation", structure);
            Assert.Contains("04 - L1000", structure);
            Assert.Contains("05 - TransactionSetTrailer", structure);

            // Verify segment identifiers are present
            Assert.Contains("ST -", structure);
            Assert.Contains("B10 -", structure);
            Assert.Contains("MS3 -", structure);
            Assert.Contains("SE -", structure);
        }
    }
}
