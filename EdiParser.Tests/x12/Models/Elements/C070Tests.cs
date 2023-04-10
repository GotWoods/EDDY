using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C070Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "ux*1P*Jc*PX*0h";

        var expected = new C070_CompositeChannelOfDistribution()
        {
            ChannelOfDistribution = "ux",
            ChannelOfDistribution2 = "1P",
            ChannelOfDistribution3 = "Jc",
            ChannelOfDistribution4 = "PX",
            ChannelOfDistribution5 = "0h",
        };

        var actual = Map.MapObject<C070_CompositeChannelOfDistribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        try
        {
            Assert.Equivalent(expected, actual);
        }
        catch
        {
            Assert.Fail(actual.ValidationResult.ToString());
        }
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("ux", true)]
    public void Validatation_RequiredChannelOfDistribution(string channelOfDistribution, bool isValidExpected)
    {
        var subject = new C070_CompositeChannelOfDistribution();
        subject.ChannelOfDistribution = channelOfDistribution;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}