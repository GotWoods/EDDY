using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E003Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "a:A";

		var expected = new E003_AttributeInformation()
		{
			AttributeTypeDescriptionCode = "a",
			AttributeDescription = "A",
		};

		var actual = Map.MapComposite<E003_AttributeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredAttributeTypeDescriptionCode(string attributeTypeDescriptionCode, bool isValidExpected)
	{
		var subject = new E003_AttributeInformation();
		//Required fields
		//Test Parameters
		subject.AttributeTypeDescriptionCode = attributeTypeDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
