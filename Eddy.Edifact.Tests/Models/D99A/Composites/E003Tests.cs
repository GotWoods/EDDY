using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E003Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "L:I";

		var expected = new E003_AttributeInformation()
		{
			AttributeTypeIdentification = "L",
			Attribute = "I",
		};

		var actual = Map.MapComposite<E003_AttributeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredAttributeTypeIdentification(string attributeTypeIdentification, bool isValidExpected)
	{
		var subject = new E003_AttributeInformation();
		//Required fields
		//Test Parameters
		subject.AttributeTypeIdentification = attributeTypeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
