using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C780Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "b:U";

		var expected = new C780_ValueListIdentification()
		{
			ValueListIdentifier = "b",
			ObjectIdentificationCodeQualifier = "U",
		};

		var actual = Map.MapComposite<C780_ValueListIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredValueListIdentifier(string valueListIdentifier, bool isValidExpected)
	{
		var subject = new C780_ValueListIdentification();
		//Required fields
		//Test Parameters
		subject.ValueListIdentifier = valueListIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
