using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLI*Ns*LE*7*7*m*cW";

		var expected = new CLI_CostLineItem()
		{
			EntityIdentifierCode = "Ns",
			BreakdownStructureDetailCode = "LE",
			AssignedIdentification = "7",
			FreeFormDescription = "7",
			RateOrValueTypeCode = "m",
			ContractTypeCode = "cW",
		};

		var actual = Map.MapObject<CLI_CostLineItem>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

}
