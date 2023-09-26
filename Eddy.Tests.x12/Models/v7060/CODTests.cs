using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class CODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COD*os*";

		var expected = new COD_ChannelOfDistribution()
		{
			AgencyQualifierCode = "os",
			CompositeChannelOfDistribution = null,
		};

		var actual = Map.MapObject<COD_ChannelOfDistribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("os", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new COD_ChannelOfDistribution();
		//Required fields
		subject.CompositeChannelOfDistribution = new C070_CompositeChannelOfDistribution();
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeChannelOfDistribution(string compositeChannelOfDistribution, bool isValidExpected)
	{
		var subject = new COD_ChannelOfDistribution();
		//Required fields
		subject.AgencyQualifierCode = "os";
		//Test Parameters
		if (compositeChannelOfDistribution != "") 
			subject.CompositeChannelOfDistribution = new C070_CompositeChannelOfDistribution();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
