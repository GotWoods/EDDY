using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class C955Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "3:G:s";

		var expected = new C955_AttributeType()
		{
			AttributeTypeIdentification = "3",
			CodeListQualifier = "G",
			CodeListResponsibleAgencyCoded = "s",
		};

		var actual = Map.MapComposite<C955_AttributeType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredAttributeTypeIdentification(string attributeTypeIdentification, bool isValidExpected)
	{
		var subject = new C955_AttributeType();
		//Required fields
		//Test Parameters
		subject.AttributeTypeIdentification = attributeTypeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
