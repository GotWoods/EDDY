using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E003Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "s:U";

		var expected = new E003_AttributeInformation()
		{
			AttributeTypeCoded = "s",
			Attribute = "U",
		};

		var actual = Map.MapComposite<E003_AttributeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredAttributeTypeCoded(string attributeTypeCoded, bool isValidExpected)
	{
		var subject = new E003_AttributeInformation();
		//Required fields
		//Test Parameters
		subject.AttributeTypeCoded = attributeTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
