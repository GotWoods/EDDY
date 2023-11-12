using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPL*vH*lt5E7r*AhwbSY*W*R";

		var expected = new PPL_PriceSupportData()
		{
			PricingProposalDataCode = "vH",
			Date = "lt5E7r",
			Date2 = "AhwbSY",
			Description = "W",
			ProposalDataDetailIdentifierCode = "R",
		};

		var actual = Map.MapObject<PPL_PriceSupportData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
