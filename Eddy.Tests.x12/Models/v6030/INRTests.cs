using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class INRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INR*Z4*03*j";

		var expected = new INR_InformationRequest()
		{
			CodeCategory = "Z4",
			InformationTypeCode = "03",
			InformationStatusCode = "j",
		};

		var actual = Map.MapObject<INR_InformationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z4", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new INR_InformationRequest();
		//Required fields
		subject.InformationTypeCode = "03";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("03", true)]
	public void Validation_RequiredInformationTypeCode(string informationTypeCode, bool isValidExpected)
	{
		var subject = new INR_InformationRequest();
		//Required fields
		subject.CodeCategory = "Z4";
		//Test Parameters
		subject.InformationTypeCode = informationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
