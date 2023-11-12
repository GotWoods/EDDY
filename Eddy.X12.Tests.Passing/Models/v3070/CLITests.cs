using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLI*v2*Fh*1*5*1*QO";

		var expected = new CLI_CostLineItem()
		{
			EntityIdentifierCode = "v2",
			BreakdownStructureDetailCode = "Fh",
			AssignedIdentification = "1",
			FreeFormDescription = "5",
			RateOrValueTypeCode = "1",
			ContractTypeCode = "QO",
		};

		var actual = Map.MapObject<CLI_CostLineItem>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
