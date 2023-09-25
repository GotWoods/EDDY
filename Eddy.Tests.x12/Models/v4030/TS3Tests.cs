using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class TS3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS3*Q*s*BPeq8GoT*9*6*2*1*5*2*9*4*2*2*9*3*3*8*2*3*9*1*7*8*9";

		var expected = new TS3_TransactionStatistics()
		{
			ReferenceIdentification = "Q",
			FacilityCodeValue = "s",
			Date = "BPeq8GoT",
			Quantity = 9,
			MonetaryAmount = 6,
			MonetaryAmount2 = 2,
			MonetaryAmount3 = 1,
			MonetaryAmount4 = 5,
			MonetaryAmount5 = 2,
			MonetaryAmount6 = 9,
			MonetaryAmount7 = 4,
			MonetaryAmount8 = 2,
			MonetaryAmount9 = 2,
			MonetaryAmount10 = 9,
			MonetaryAmount11 = 3,
			MonetaryAmount12 = 3,
			MonetaryAmount13 = 8,
			MonetaryAmount14 = 2,
			MonetaryAmount15 = 3,
			MonetaryAmount16 = 9,
			MonetaryAmount17 = 1,
			MonetaryAmount18 = 7,
			Quantity2 = 8,
			MonetaryAmount19 = 9,
		};

		var actual = Map.MapObject<TS3_TransactionStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.FacilityCodeValue = "s";
		subject.Date = "BPeq8GoT";
		subject.Quantity = 9;
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredFacilityCodeValue(string facilityCodeValue, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "Q";
		subject.Date = "BPeq8GoT";
		subject.Quantity = 9;
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.FacilityCodeValue = facilityCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BPeq8GoT", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "Q";
		subject.FacilityCodeValue = "s";
		subject.Quantity = 9;
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "Q";
		subject.FacilityCodeValue = "s";
		subject.Date = "BPeq8GoT";
		subject.MonetaryAmount = 6;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "Q";
		subject.FacilityCodeValue = "s";
		subject.Date = "BPeq8GoT";
		subject.Quantity = 9;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
