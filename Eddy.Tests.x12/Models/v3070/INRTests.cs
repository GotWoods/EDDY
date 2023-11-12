using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class INRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INR*VW*be*5";

		var expected = new INR_InformationRequest()
		{
			CodeCategory = "VW",
			InformationType = "be",
			InformationStatusCode = "5",
		};

		var actual = Map.MapObject<INR_InformationRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VW", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new INR_InformationRequest();
		//Required fields
		subject.InformationType = "be";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("be", true)]
	public void Validation_RequiredInformationType(string informationType, bool isValidExpected)
	{
		var subject = new INR_InformationRequest();
		//Required fields
		subject.CodeCategory = "VW";
		//Test Parameters
		subject.InformationType = informationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
