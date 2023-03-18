using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12;

public class MapTests
{
    [Fact]
    public void ShouldConvertToString()
    {
        var header = new ST_TransactionSetHeader();
        header.TransactionSetIdentifierCode = "AB";
        header.TransactionSetControlNumber = "CD";
        header.ImplementationConventionReference = "EF";
        
        

        var actual = Map.SegmentToString(header, MapOptionsForTesting.x12DefaultEndsWithTilde);
        Assert.Equal("ST*AB*CD*EF~", actual);
    }


    [Fact]
    public void ShouldConvertToStringWhenElementNull()
    {
        var header = new ST_TransactionSetHeader();
        header.TransactionSetIdentifierCode = "AB";
        header.TransactionSetControlNumber = "CD";
        //header.ImplementationConventionReference = "EF"; 

        var actual = Map.SegmentToString(header, MapOptionsForTesting.x12DefaultEndsWithTilde);
        Assert.Equal("ST*AB*CD~", actual);
    }

    [Fact]
    public void ShouldConvertToStringWhenPropertyNull()
    {
        var header = new ST_TransactionSetHeader();
        header.TransactionSetIdentifierCode = "AB";
        header.TransactionSetControlNumber = "\0";
        
        var actual = Map.SegmentToString(header, MapOptionsForTesting.x12DefaultEndsWithTilde);
        Assert.Equal("ST*AB~", actual);
    }
}