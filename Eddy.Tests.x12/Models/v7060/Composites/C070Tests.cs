using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7060;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Tests.Models.v7060.Composites;

public class C070Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "IS*vI*Uz*x5*lw";

		var expected = new C070_CompositeChannelOfDistribution()
		{
			ChannelOfDistribution = "IS",
			ChannelOfDistribution2 = "vI",
			ChannelOfDistribution3 = "Uz",
			ChannelOfDistribution4 = "x5",
			ChannelOfDistribution5 = "lw",
		};

		var actual = Map.MapObject<C070_CompositeChannelOfDistribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IS", true)]
	public void Validation_RequiredChannelOfDistribution(string channelOfDistribution, bool isValidExpected)
	{
		var subject = new C070_CompositeChannelOfDistribution();
		//Required fields
		//Test Parameters
		subject.ChannelOfDistribution = channelOfDistribution;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
