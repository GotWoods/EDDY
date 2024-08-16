using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class ATRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ATR+U+";

		var expected = new ATR_Attribute()
		{
			AttributeFunctionQualifier = "U",
			AttributeInformation = null,
		};

		var actual = Map.MapObject<ATR_Attribute>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredAttributeFunctionQualifier(string attributeFunctionQualifier, bool isValidExpected)
	{
		var subject = new ATR_Attribute();
		//Required fields
		subject.AttributeInformation = new E003_AttributeInformation();
		//Test Parameters
		subject.AttributeFunctionQualifier = attributeFunctionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAttributeInformation(string attributeInformation, bool isValidExpected)
	{
		var subject = new ATR_Attribute();
		//Required fields
		subject.AttributeFunctionQualifier = "U";
		//Test Parameters
		if (attributeInformation != "") 
			subject.AttributeInformation = new E003_AttributeInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
