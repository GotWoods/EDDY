using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

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
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new COD_ChannelOfDistribution();
		subject.CompositeChannelOfDistribution = new C070_CompositeChannelOfDistribution() { };
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aa", true)]
	public void Validation_RequiredCompositeChannelOfDistribution(string compositeChannelOfDistribution, bool isValidExpected)
	{
		var subject = new COD_ChannelOfDistribution();
		subject.AgencyQualifierCode = "fE";
		if (compositeChannelOfDistribution != "")
		    subject.CompositeChannelOfDistribution = new C070_CompositeChannelOfDistribution() { ChannelOfDistribution = compositeChannelOfDistribution };

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
