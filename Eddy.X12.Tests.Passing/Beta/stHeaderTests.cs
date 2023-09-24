using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Beta
{
    public class stHeaderTests
    {
        [Fact]
        public void Parse_X12_ST_Line_Should_Populate_Properties()
        {
            var expected = new ST_TransactionSetHeader()
            {
                TransactionSetIdentifierCode = "204",
                TransactionSetControlNumber = "0001",
                ImplementationConventionReference = "005010X222A1",
            };

            // Act
            var actual = Map.MapObject<ST_TransactionSetHeader>("ST*204*0001*005010X222A1", MapOptionsForTesting.x12DefaultEndsWithNewline);

            // Assert
            Assert.Equal(expected.TransactionSetIdentifierCode, actual.TransactionSetIdentifierCode);
            Assert.Equal(expected.TransactionSetControlNumber, actual.TransactionSetControlNumber);
            Assert.Equal(expected.ImplementationConventionReference, actual.ImplementationConventionReference);
        }
    }
}
