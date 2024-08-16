using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E969Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "w:E";

		var expected = new E969_ValidityDates()
		{
			DateValue = "w",
			DateValue2 = "E",
		};

		var actual = Map.MapComposite<E969_ValidityDates>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredDateValue(string dateValue, bool isValidExpected)
	{
		var subject = new E969_ValidityDates();
		//Required fields
		//Test Parameters
		subject.DateValue = dateValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
