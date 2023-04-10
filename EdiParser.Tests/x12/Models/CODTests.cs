using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models;

public class CODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COD*fE*aa";

		var expected = new COD_ChannelOfDistribution()
		{
			AgencyQualifierCode = "fE",
			CompositeChannelOfDistribution = new C070_CompositeChannelOfDistribution() { ChannelOfDistribution = "aa" },
		};

		var actual = Map.MapObject<COD_ChannelOfDistribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
		
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fE", true)]
	public void Validatation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new COD_ChannelOfDistribution();
		subject.CompositeChannelOfDistribution = new C070_CompositeChannelOfDistribution() { };
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aa", true)]
	public void Validatation_RequiredCompositeChannelOfDistribution(string compositeChannelOfDistribution, bool isValidExpected)
	{
		var subject = new COD_ChannelOfDistribution();
		subject.AgencyQualifierCode = "fE";
		if (compositeChannelOfDistribution != "")
		    subject.CompositeChannelOfDistribution = new C070_CompositeChannelOfDistribution() { ChannelOfDistribution = compositeChannelOfDistribution };

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
