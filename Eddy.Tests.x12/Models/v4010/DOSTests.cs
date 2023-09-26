using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DOS*up*9*5*6*1*Uc*G";

		var expected = new DOS_DefinitionOfShare()
		{
			ContractTypeCode = "up",
			MonetaryAmount = 9,
			Percent = 5,
			MonetaryAmount2 = 6,
			Percent2 = 1,
			EntityIdentifierCode = "Uc",
			Description = "G",
		};

		var actual = Map.MapObject<DOS_DefinitionOfShare>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("up", true)]
	public void Validation_RequiredContractTypeCode(string contractTypeCode, bool isValidExpected)
	{
		var subject = new DOS_DefinitionOfShare();
		//Required fields
		//Test Parameters
		subject.ContractTypeCode = contractTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
