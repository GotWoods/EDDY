using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class INRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INR*bP*bv*S";

		var expected = new INR_InformationRequest()
		{
			CodeCategory = "bP",
			InformationTypeCode = "bv",
			InformationStatusCode = "S",
		};

		var actual = Map.MapObject<INR_InformationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bP", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new INR_InformationRequest();
		subject.InformationTypeCode = "bv";
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bv", true)]
	public void Validation_RequiredInformationTypeCode(string informationTypeCode, bool isValidExpected)
	{
		var subject = new INR_InformationRequest();
		subject.CodeCategory = "bP";
		subject.InformationTypeCode = informationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
