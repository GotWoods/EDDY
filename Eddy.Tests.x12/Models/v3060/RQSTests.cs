using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RQSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RQS*N*N*s*q*U";

		var expected = new RQS_RequestForInformation()
		{
			CodeListQualifierCode = "N",
			IndustryCode = "N",
			Description = "s",
			YesNoConditionOrResponseCode = "q",
			Description2 = "U",
		};

		var actual = Map.MapObject<RQS_RequestForInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "N", true)]
	[InlineData("N", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new RQS_RequestForInformation();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		//At Least one
		subject.Description = "s";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("N", "s", true)]
	[InlineData("N", "", true)]
	[InlineData("", "s", true)]
	public void Validation_AtLeastOneIndustryCode(string industryCode, string description, bool isValidExpected)
	{
		var subject = new RQS_RequestForInformation();
		//Required fields
		//Test Parameters
		subject.IndustryCode = industryCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "N";
			subject.IndustryCode = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
