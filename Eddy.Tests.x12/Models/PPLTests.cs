using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPL*vH*XZgS1g8J*B2yTnvkP*b*a";

		var expected = new PPL_PriceSupportData()
		{
			AcquisitionDataCode = "vH",
			Date = "XZgS1g8J",
			Date2 = "B2yTnvkP",
			Description = "b",
			ProposalDataDetailIdentifierCode = "a",
		};

		var actual = Map.MapObject<PPL_PriceSupportData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
