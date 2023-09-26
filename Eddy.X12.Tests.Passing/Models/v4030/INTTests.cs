using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class INTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INT*t*2*7L*m*6*gx";

		var expected = new INT_Interest()
		{
			InterestTypeCode = "t",
			InterestRate = 2,
			DateTimePeriodFormatQualifier = "7L",
			DateTimePeriod = "m",
			Quantity = 6,
			QuantityQualifier = "gx",
		};

		var actual = Map.MapObject<INT_Interest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredInterestTypeCode(string interestTypeCode, bool isValidExpected)
	{
		var subject = new INT_Interest();
		//Required fields
		//Test Parameters
		subject.InterestTypeCode = interestTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "7L";
			subject.DateTimePeriod = "m";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.QuantityQualifier))
		{
			subject.Quantity = 6;
			subject.QuantityQualifier = "gx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7L", "m", true)]
	[InlineData("7L", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new INT_Interest();
		//Required fields
		subject.InterestTypeCode = "t";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.QuantityQualifier))
		{
			subject.Quantity = 6;
			subject.QuantityQualifier = "gx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "gx", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "gx", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string quantityQualifier, bool isValidExpected)
	{
		var subject = new INT_Interest();
		//Required fields
		subject.InterestTypeCode = "t";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.QuantityQualifier = quantityQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "7L";
			subject.DateTimePeriod = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
