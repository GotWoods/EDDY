using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class HADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HAD*Sr*0*V*1*s*D";

		var expected = new HAD_HospitalAffiliationDetail()
		{
			StatusCode = "Sr",
			YesNoConditionOrResponseCode = "0",
			YesNoConditionOrResponseCode2 = "V",
			YesNoConditionOrResponseCode3 = "1",
			CodeListQualifierCode = "s",
			IndustryCode = "D",
		};

		var actual = Map.MapObject<HAD_HospitalAffiliationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sr", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new HAD_HospitalAffiliationDetail();
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("s", "D", true)]
	[InlineData("", "D", false)]
	[InlineData("s", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new HAD_HospitalAffiliationDetail();
		subject.StatusCode = "Sr";
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
