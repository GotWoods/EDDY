using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class TS3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS3*5*w*PHHr1qYw*7*9*9*7*3*2*1*8*8*1*6*3*7*7*1*6*2*6*5*3*1";

		var expected = new TS3_TransactionStatistics()
		{
			ReferenceIdentification = "5",
			FacilityCodeValue = "w",
			Date = "PHHr1qYw",
			Quantity = 7,
			MonetaryAmount = 9,
			MonetaryAmount2 = 9,
			MonetaryAmount3 = 7,
			MonetaryAmount4 = 3,
			MonetaryAmount5 = 2,
			MonetaryAmount6 = 1,
			MonetaryAmount7 = 8,
			MonetaryAmount8 = 8,
			MonetaryAmount9 = 1,
			MonetaryAmount10 = 6,
			MonetaryAmount11 = 3,
			MonetaryAmount12 = 7,
			MonetaryAmount13 = 7,
			MonetaryAmount14 = 1,
			MonetaryAmount15 = 6,
			MonetaryAmount16 = 2,
			MonetaryAmount17 = 6,
			MonetaryAmount18 = 5,
			Quantity2 = 3,
			MonetaryAmount19 = 1,
		};

		var actual = Map.MapObject<TS3_TransactionStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.FacilityCodeValue = "w";
		subject.Date = "PHHr1qYw";
		subject.Quantity = 7;
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredFacilityCodeValue(string facilityCodeValue, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "5";
		subject.Date = "PHHr1qYw";
		subject.Quantity = 7;
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.FacilityCodeValue = facilityCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PHHr1qYw", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "5";
		subject.FacilityCodeValue = "w";
		subject.Quantity = 7;
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "5";
		subject.FacilityCodeValue = "w";
		subject.Date = "PHHr1qYw";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "5";
		subject.FacilityCodeValue = "w";
		subject.Date = "PHHr1qYw";
		subject.Quantity = 7;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
