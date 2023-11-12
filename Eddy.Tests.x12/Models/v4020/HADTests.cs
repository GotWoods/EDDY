using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class HADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HAD*hD*f*y*7*Z*u";

		var expected = new HAD_HospitalAffiliationDetail()
		{
			StatusCode = "hD",
			YesNoConditionOrResponseCode = "f",
			YesNoConditionOrResponseCode2 = "y",
			YesNoConditionOrResponseCode3 = "7",
			CodeListQualifierCode = "Z",
			IndustryCode = "u",
		};

		var actual = Map.MapObject<HAD_HospitalAffiliationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hD", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new HAD_HospitalAffiliationDetail();
		//Required fields
		//Test Parameters
		subject.StatusCode = statusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "Z";
			subject.IndustryCode = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z", "u", true)]
	[InlineData("Z", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new HAD_HospitalAffiliationDetail();
		//Required fields
		subject.StatusCode = "hD";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
