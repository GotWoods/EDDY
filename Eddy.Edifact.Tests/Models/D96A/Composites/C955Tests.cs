using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C955Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "t:g:k";

		var expected = new C955_AttributeType()
		{
			AttributeTypeCoded = "t",
			CodeListQualifier = "g",
			CodeListResponsibleAgencyCoded = "k",
		};

		var actual = Map.MapComposite<C955_AttributeType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredAttributeTypeCoded(string attributeTypeCoded, bool isValidExpected)
	{
		var subject = new C955_AttributeType();
		//Required fields
		//Test Parameters
		subject.AttributeTypeCoded = attributeTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
