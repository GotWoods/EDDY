using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E969Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "N:8";

		var expected = new E969_ValidityDates()
		{
			Date = "N",
			Date2 = "8",
		};

		var actual = Map.MapComposite<E969_ValidityDates>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new E969_ValidityDates();
		//Required fields
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
