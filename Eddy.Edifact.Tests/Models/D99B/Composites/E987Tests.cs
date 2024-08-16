using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E987Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "e:hh8f:E:sBvr:b";

		var expected = new E987_ProductDateAndTime()
		{
			DateValue = "e",
			Time = "hh8f",
			DateValue2 = "E",
			Time2 = "sBvr",
			DateVariation = "b",
		};

		var actual = Map.MapComposite<E987_ProductDateAndTime>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredDateValue(string dateValue, bool isValidExpected)
	{
		var subject = new E987_ProductDateAndTime();
		//Required fields
		//Test Parameters
		subject.DateValue = dateValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
