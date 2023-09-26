using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPL*0s*pMUbdA*2e7DHo*W*e";

		var expected = new PPL_PriceSupportData()
		{
			AcquisitionDataCode = "0s",
			Date = "pMUbdA",
			Date2 = "2e7DHo",
			Description = "W",
			ProposalDataDetailIdentifierCode = "e",
		};

		var actual = Map.MapObject<PPL_PriceSupportData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
