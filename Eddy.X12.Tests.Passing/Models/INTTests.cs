using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class INTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INT*f*2*K5*a*7*MN";

		var expected = new INT_Interest()
		{
			InterestTypeCode = "f",
			InterestRate = 2,
			DateTimePeriodFormatQualifier = "K5",
			DateTimePeriod = "a",
			Quantity = 7,
			QuantityQualifier = "MN",
		};

		var actual = Map.MapObject<INT_Interest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredInterestTypeCode(string interestTypeCode, bool isValidExpected)
	{
		var subject = new INT_Interest();
		subject.InterestTypeCode = interestTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("K5", "a", true)]
	[InlineData("", "a", false)]
	[InlineData("K5", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new INT_Interest();
		subject.InterestTypeCode = "f";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "MN", true)]
	[InlineData(0, "MN", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string quantityQualifier, bool isValidExpected)
	{
		var subject = new INT_Interest();
		subject.InterestTypeCode = "f";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.QuantityQualifier = quantityQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
