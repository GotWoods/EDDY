using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class VARTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAR*tu*U*Vt*WC*5y*kE*wY";

		var expected = new VAR_CreditFileVariation()
		{
			IdentificationCode = "tu",
			ReferenceIdentification = "U",
			CreditFileVariationCode = "Vt",
			CreditFileVariationCode2 = "WC",
			CreditFileVariationCode3 = "5y",
			CreditFileVariationCode4 = "kE",
			CreditFileVariationCode5 = "wY",
		};

		var actual = Map.MapObject<VAR_CreditFileVariation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tu", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new VAR_CreditFileVariation();
		//Required fields
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
