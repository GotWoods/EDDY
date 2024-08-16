using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E987Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "v:5Kjy:K:OWER:Z";

		var expected = new E987_ProductDateAndTime()
		{
			Date = "v",
			Time = "5Kjy",
			Date2 = "K",
			Time2 = "OWER",
			DateVariation = "Z",
		};

		var actual = Map.MapComposite<E987_ProductDateAndTime>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new E987_ProductDateAndTime();
		//Required fields
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
