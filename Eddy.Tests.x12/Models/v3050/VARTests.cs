using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class VARTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAR*bp*h*0N*MF*5y*c9*GP";

		var expected = new VAR_CreditFileVariation()
		{
			IdentificationCode = "bp",
			ReferenceNumber = "h",
			CreditFileVariationCode = "0N",
			CreditFileVariationCode2 = "MF",
			CreditFileVariationCode3 = "5y",
			CreditFileVariationCode4 = "c9",
			CreditFileVariationCode5 = "GP",
		};

		var actual = Map.MapObject<VAR_CreditFileVariation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bp", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new VAR_CreditFileVariation();
		//Required fields
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
