using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TOATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TOA*Hp*82*fm*oz*5Y";

		var expected = new TOA_TypeOfActivity()
		{
			TypeOfActivityCode = "Hp",
			LicenseTypeCode = "82",
			StatusCode = "fm",
			TypeOfRatingCode = "oz",
			TypeOfRatingCode2 = "5Y",
		};

		var actual = Map.MapObject<TOA_TypeOfActivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hp", true)]
	public void Validation_RequiredTypeOfActivityCode(string typeOfActivityCode, bool isValidExpected)
	{
		var subject = new TOA_TypeOfActivity();
		subject.TypeOfActivityCode = typeOfActivityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("82", "fm", true)]
	[InlineData("", "fm", false)]
	[InlineData("82", "", false)]
	public void Validation_AllAreRequiredLicenseTypeCode(string licenseTypeCode, string statusCode, bool isValidExpected)
	{
		var subject = new TOA_TypeOfActivity();
		subject.TypeOfActivityCode = "Hp";
		subject.LicenseTypeCode = licenseTypeCode;
		subject.StatusCode = statusCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
