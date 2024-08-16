using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ATTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ATT+y++";

		var expected = new ATT_Attribute()
		{
			AttributeFunctionCodeQualifier = "y",
			AttributeType = null,
			AttributeDetail = null,
		};

		var actual = Map.MapObject<ATT_Attribute>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredAttributeFunctionCodeQualifier(string attributeFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new ATT_Attribute();
		//Required fields
		//Test Parameters
		subject.AttributeFunctionCodeQualifier = attributeFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
