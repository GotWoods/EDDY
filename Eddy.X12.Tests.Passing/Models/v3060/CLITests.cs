using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLI*kh*mZ*D*a*U*Nf";

		var expected = new CLI_CostLineItem()
		{
			EntityIdentifierCode = "kh",
			BreakdownStructureDetailCode = "mZ",
			AssignedIdentification = "D",
			FreeFormDescription = "a",
			RateOrValueTypeCode = "U",
			ContractTypeCode = "Nf",
		};

		var actual = Map.MapObject<CLI_CostLineItem>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
