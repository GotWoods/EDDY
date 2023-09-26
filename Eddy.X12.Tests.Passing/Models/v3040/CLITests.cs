using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLI*XM*J9*v*C*y*ee";

		var expected = new CLI_CostLineItem()
		{
			EntityIdentifierCode = "XM",
			BreakdownStructureDetailCode = "J9",
			AssignedIdentification = "v",
			FreeFormDescription = "C",
			RateOrValueTypeCode = "y",
			ContractTypeCode = "ee",
		};

		var actual = Map.MapObject<CLI_CostLineItem>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
