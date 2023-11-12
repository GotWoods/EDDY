using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TOATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TOA*iu*O5*20*EC*Rq";

		var expected = new TOA_TypeOfActivity()
		{
			TypeOfActivityCode = "iu",
			LicenseTypeCode = "O5",
			StatusCode = "20",
			TypeOfRatingCode = "EC",
			TypeOfRatingCode2 = "Rq",
		};

		var actual = Map.MapObject<TOA_TypeOfActivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iu", true)]
	public void Validation_RequiredTypeOfActivityCode(string typeOfActivityCode, bool isValidExpected)
	{
		var subject = new TOA_TypeOfActivity();
		//Required fields
		//Test Parameters
		subject.TypeOfActivityCode = typeOfActivityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LicenseTypeCode) || !string.IsNullOrEmpty(subject.LicenseTypeCode) || !string.IsNullOrEmpty(subject.StatusCode))
		{
			subject.LicenseTypeCode = "O5";
			subject.StatusCode = "20";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O5", "20", true)]
	[InlineData("O5", "", false)]
	[InlineData("", "20", false)]
	public void Validation_AllAreRequiredLicenseTypeCode(string licenseTypeCode, string statusCode, bool isValidExpected)
	{
		var subject = new TOA_TypeOfActivity();
		//Required fields
		subject.TypeOfActivityCode = "iu";
		//Test Parameters
		subject.LicenseTypeCode = licenseTypeCode;
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
