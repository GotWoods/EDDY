using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class VARTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAR*ZW*R*8X*zm*O5*Kr*ii";

		var expected = new VAR_CreditFileVariation()
		{
			IdentificationCode = "ZW",
			ReferenceIdentification = "R",
			CreditFileVariationCode = "8X",
			CreditFileVariationCode2 = "zm",
			CreditFileVariationCode3 = "O5",
			CreditFileVariationCode4 = "Kr",
			CreditFileVariationCode5 = "ii",
		};

		var actual = Map.MapObject<VAR_CreditFileVariation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZW", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new VAR_CreditFileVariation();
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
