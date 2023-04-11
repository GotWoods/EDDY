using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RQSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RQS*7*a*F*P*d";

		var expected = new RQS_RequestForInformation()
		{
			CodeListQualifierCode = "7",
			IndustryCode = "a",
			Description = "F",
			YesNoConditionOrResponseCode = "P",
			Description2 = "d",
		};

		var actual = Map.MapObject<RQS_RequestForInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("7", "a", true)]
	[InlineData("", "a", false)]
	[InlineData("7", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new RQS_RequestForInformation();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("a","F", true)]
	[InlineData("", "F", true)]
	[InlineData("a", "", true)]
	public void Validation_AtLeastOneIndustryCode(string industryCode, string description, bool isValidExpected)
	{
		var subject = new RQS_RequestForInformation();
		subject.IndustryCode = industryCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
