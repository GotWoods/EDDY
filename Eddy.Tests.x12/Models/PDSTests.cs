using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDS*1T*x*";

		var expected = new PDS_PropertyDescriptionLegalDescription()
		{
			PropertyDescriptionQualifier = "1T",
			FreeFormMessageText = "x",
			ReferenceIdentifier = null,
		};

		var actual = Map.MapObject<PDS_PropertyDescriptionLegalDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1T", true)]
	public void Validation_RequiredPropertyDescriptionQualifier(string propertyDescriptionQualifier, bool isValidExpected)
	{
		var subject = new PDS_PropertyDescriptionLegalDescription();
		subject.PropertyDescriptionQualifier = propertyDescriptionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
