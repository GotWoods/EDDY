using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class ATTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ATT+O++";

		var expected = new ATT_Attribute()
		{
			AttributeFunctionQualifier = "O",
			AttributeType = null,
			AttributeDetails = null,
		};

		var actual = Map.MapObject<ATT_Attribute>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredAttributeFunctionQualifier(string attributeFunctionQualifier, bool isValidExpected)
	{
		var subject = new ATT_Attribute();
		//Required fields
		//Test Parameters
		subject.AttributeFunctionQualifier = attributeFunctionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
