using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class VARTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAR*IM*V*qF*50*wk*FM*hr";

		var expected = new VAR_CreditFileVariation()
		{
			IdentificationCode = "IM",
			ReferenceIdentification = "V",
			CreditFileVariationCode = "qF",
			CreditFileVariationCode2 = "50",
			CreditFileVariationCode3 = "wk",
			CreditFileVariationCode4 = "FM",
			CreditFileVariationCode5 = "hr",
		};

		var actual = Map.MapObject<VAR_CreditFileVariation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IM", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new VAR_CreditFileVariation();
		//Required fields
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
