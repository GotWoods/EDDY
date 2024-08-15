using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests;

public class MapTests
{
    [Fact]
    public void ParseSimpleElement()
    {
        var line = "ALI+1+2+3+4+5+6+7";
        var result = Map.MapObject<ALI_AdditionalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);

        Assert.Equal("1", result.CountryOfOriginCoded);
        Assert.Equal("2", result.TypeOfDutyRegimeCoded);
        Assert.Equal("3", result.SpecialConditionsCoded);
        Assert.Equal("4", result.SpecialConditionsCoded2);
        Assert.Equal("5", result.SpecialConditionsCoded3);
        Assert.Equal("6", result.SpecialConditionsCoded4);
        Assert.Equal("7", result.SpecialConditionsCoded5);
    }

    [Fact]
    public void ParseComponent()
    {
        var line = "BRN:3";
        var result = (C002_DocumentMessageName)Map.MapObject(typeof(C002_DocumentMessageName), line, ":", -1, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);

        Assert.Equal("BRN", result.DocumentMessageNameCoded);
        Assert.Equal("3", result.CodeListQualifier);
        
    }

    [Fact]
    public void ParseMixOfElementAndComponent()
    {
        var line = "UNB+UNOC:3+LY78+16390913+230127:0814+614720311";


        var expected = new UNB_InterchangeHeader();
        expected.SyntaxIdentifier.SyntaxIdentifier = "UNOC";
        expected.SyntaxIdentifier.SyntaxVersionNumber = "3";
        expected.InterchangeSender.SenderIdentification = "LY78";
        expected.InterchangeRecipient.RecipientIdentification= "16390913";
        expected.DateTimeOfPreparation.DateOfPreparation = "230127";
        expected.DateTimeOfPreparation.TimeOfPreparation = "0814";
        expected.InterchangeControlReference = "614720311";

        var options = new MapOptions();
        options.Separator = "+";
        options.ComponentElementSeparator = ":";

        
        var actual = Map.MapObject<Models.D96A.UNB_InterchangeHeader>(line, options);

        Assert.Equivalent(expected, actual);
    }
}