using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C780Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "4:4";

		var expected = new C780_ValueListIdentification()
		{
			ValueListIdentifier = "4",
			IdentityNumberQualifier = "4",
		};

		var actual = Map.MapComposite<C780_ValueListIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredValueListIdentifier(string valueListIdentifier, bool isValidExpected)
	{
		var subject = new C780_ValueListIdentification();
		//Required fields
		//Test Parameters
		subject.ValueListIdentifier = valueListIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
