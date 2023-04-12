using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TS3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS3*T*W*RuE9hQGV*6*7*8*3*9*3*5*3*6*8*3*5*5*3*3*7*3*3*8*5*9";

		var expected = new TS3_TransactionStatistics()
		{
			ReferenceIdentification = "T",
			FacilityCodeValue = "W",
			Date = "RuE9hQGV",
			Quantity = 6,
			MonetaryAmount = 7,
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 3,
			MonetaryAmount4 = 9,
			MonetaryAmount5 = 3,
			MonetaryAmount6 = 5,
			MonetaryAmount7 = 3,
			MonetaryAmount8 = 6,
			MonetaryAmount9 = 8,
			MonetaryAmount10 = 3,
			MonetaryAmount11 = 5,
			MonetaryAmount12 = 5,
			MonetaryAmount13 = 3,
			MonetaryAmount14 = 3,
			MonetaryAmount15 = 7,
			MonetaryAmount16 = 3,
			MonetaryAmount17 = 3,
			MonetaryAmount18 = 8,
			Quantity2 = 5,
			MonetaryAmount19 = 9,
		};

		var actual = Map.MapObject<TS3_TransactionStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		subject.FacilityCodeValue = "W";
		subject.Date = "RuE9hQGV";
		subject.Quantity = 6;
		subject.MonetaryAmount = 7;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredFacilityCodeValue(string facilityCodeValue, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		subject.ReferenceIdentification = "T";
		subject.Date = "RuE9hQGV";
		subject.Quantity = 6;
		subject.MonetaryAmount = 7;
		subject.FacilityCodeValue = facilityCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RuE9hQGV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		subject.ReferenceIdentification = "T";
		subject.FacilityCodeValue = "W";
		subject.Quantity = 6;
		subject.MonetaryAmount = 7;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		subject.ReferenceIdentification = "T";
		subject.FacilityCodeValue = "W";
		subject.Date = "RuE9hQGV";
		subject.MonetaryAmount = 7;
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		subject.ReferenceIdentification = "T";
		subject.FacilityCodeValue = "W";
		subject.Date = "RuE9hQGV";
		subject.Quantity = 6;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
