using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class DOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DOS*LI*9*7*7*2*Re*6";

		var expected = new DOS_DefinitionOfShare()
		{
			ContractTypeCode = "LI",
			MonetaryAmount = 9,
			Percent = 7,
			MonetaryAmount2 = 7,
			Percent2 = 2,
			EntityIdentifierCode = "Re",
			Description = "6",
		};

		var actual = Map.MapObject<DOS_DefinitionOfShare>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LI", true)]
	public void Validation_RequiredContractTypeCode(string contractTypeCode, bool isValidExpected)
	{
		var subject = new DOS_DefinitionOfShare();
		//Required fields
		//Test Parameters
		subject.ContractTypeCode = contractTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
