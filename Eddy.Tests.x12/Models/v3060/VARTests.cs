using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class VARTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAR*4X*I*em*lU*wK*Jk*sO";

		var expected = new VAR_CreditFileVariation()
		{
			IdentificationCode = "4X",
			ReferenceIdentification = "I",
			CreditFileVariationCode = "em",
			CreditFileVariationCode2 = "lU",
			CreditFileVariationCode3 = "wK",
			CreditFileVariationCode4 = "Jk",
			CreditFileVariationCode5 = "sO",
		};

		var actual = Map.MapObject<VAR_CreditFileVariation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4X", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new VAR_CreditFileVariation();
		//Required fields
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
