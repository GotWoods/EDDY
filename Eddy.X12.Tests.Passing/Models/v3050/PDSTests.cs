using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDS*hn*h";

		var expected = new PDS_PropertyDescriptionLegalDescription()
		{
			PropertyDescriptionQualifier = "hn",
			FreeFormMessageText = "h",
		};

		var actual = Map.MapObject<PDS_PropertyDescriptionLegalDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hn", true)]
	public void Validation_RequiredPropertyDescriptionQualifier(string propertyDescriptionQualifier, bool isValidExpected)
	{
		var subject = new PDS_PropertyDescriptionLegalDescription();
		//Required fields
		//Test Parameters
		subject.PropertyDescriptionQualifier = propertyDescriptionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
