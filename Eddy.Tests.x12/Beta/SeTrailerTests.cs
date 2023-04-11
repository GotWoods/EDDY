using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Beta;

public class SeTrailerTests
{
    [Fact]
    public void Parse_X12_SE_Line_Should_Populate_Properties()
    {
        var expected = new SE_TransactionSetTrailer()
        {
            NumberOfIncludedSegments = 5,
            TransactionSetControlNumber = "0001",
        };

        // Act
        var actual = Map.MapObject<SE_TransactionSetTrailer>("SE*5*0001", MapOptionsForTesting.x12DefaultEndsWithNewline);

        // Assert
        Assert.Equal(expected.NumberOfIncludedSegments, actual.NumberOfIncludedSegments);
        Assert.Equal(expected.TransactionSetControlNumber, actual.TransactionSetControlNumber);
    }
}