using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class VARTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAR*T5*j*x4*Fj*UJ*kx*Ci";

		var expected = new VAR_CreditFileVariation()
		{
			IdentificationCode = "T5",
			ReferenceIdentification = "j",
			CreditFileVariationCode = "x4",
			CreditFileVariationCode2 = "Fj",
			CreditFileVariationCode3 = "UJ",
			CreditFileVariationCode4 = "kx",
			CreditFileVariationCode5 = "Ci",
		};

		var actual = Map.MapObject<VAR_CreditFileVariation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T5", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new VAR_CreditFileVariation();
		//Required fields
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
