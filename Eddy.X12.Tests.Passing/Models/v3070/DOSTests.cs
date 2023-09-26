using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class DOSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DOS*ka*2*2*6*1*hL*X";

		var expected = new DOS_DefinitionOfShare()
		{
			ContractTypeCode = "ka",
			MonetaryAmount = 2,
			Percent = 2,
			MonetaryAmount2 = 6,
			Percent2 = 1,
			EntityIdentifierCode = "hL",
			Description = "X",
		};

		var actual = Map.MapObject<DOS_DefinitionOfShare>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ka", true)]
	public void Validation_RequiredContractTypeCode(string contractTypeCode, bool isValidExpected)
	{
		var subject = new DOS_DefinitionOfShare();
		//Required fields
		//Test Parameters
		subject.ContractTypeCode = contractTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
