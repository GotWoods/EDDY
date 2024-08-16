using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ATRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ATR+T+";

		var expected = new ATR_Attribute()
		{
			AttributeFunctionCodeQualifier = "T",
			AttributeInformation = null,
		};

		var actual = Map.MapObject<ATR_Attribute>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredAttributeFunctionCodeQualifier(string attributeFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new ATR_Attribute();
		//Required fields
		subject.AttributeInformation = new E003_AttributeInformation();
		//Test Parameters
		subject.AttributeFunctionCodeQualifier = attributeFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAttributeInformation(string attributeInformation, bool isValidExpected)
	{
		var subject = new ATR_Attribute();
		//Required fields
		subject.AttributeFunctionCodeQualifier = "T";
		//Test Parameters
		if (attributeInformation != "") 
			subject.AttributeInformation = new E003_AttributeInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
