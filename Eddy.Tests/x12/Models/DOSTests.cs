using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DOS*vY*7*3*3*7*8L*h";

		var expected = new DOS_DefinitionOfShare()
		{
			ContractTypeCode = "vY",
			MonetaryAmount = 7,
			PercentageAsDecimal = 3,
			MonetaryAmount2 = 3,
			PercentageAsDecimal2 = 7,
			EntityIdentifierCode = "8L",
			Description = "h",
		};

		var actual = Map.MapObject<DOS_DefinitionOfShare>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vY", true)]
	public void Validation_RequiredContractTypeCode(string contractTypeCode, bool isValidExpected)
	{
		var subject = new DOS_DefinitionOfShare();
		subject.ContractTypeCode = contractTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
