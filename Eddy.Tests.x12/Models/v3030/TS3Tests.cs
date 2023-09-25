using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TS3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS3*x*9*C6zaXq*5*1*6*6*3*5*1*8*2*1*4*9*3*3*5*6*8*9*1*1*6";

		var expected = new TS3_TransactionStatistics()
		{
			ReferenceNumber = "x",
			FacilityCode = "9",
			Date = "C6zaXq",
			Quantity = 5,
			MonetaryAmount = 1,
			MonetaryAmount2 = 6,
			MonetaryAmount3 = 6,
			MonetaryAmount4 = 3,
			MonetaryAmount5 = 5,
			MonetaryAmount6 = 1,
			MonetaryAmount7 = 8,
			MonetaryAmount8 = 2,
			MonetaryAmount9 = 1,
			MonetaryAmount10 = 4,
			MonetaryAmount11 = 9,
			MonetaryAmount12 = 3,
			MonetaryAmount13 = 3,
			MonetaryAmount14 = 5,
			MonetaryAmount15 = 6,
			MonetaryAmount16 = 8,
			MonetaryAmount17 = 9,
			MonetaryAmount18 = 1,
			Quantity2 = 1,
			MonetaryAmount19 = 6,
		};

		var actual = Map.MapObject<TS3_TransactionStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.FacilityCode = "9";
		subject.Date = "C6zaXq";
		subject.Quantity = 5;
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredFacilityCode(string facilityCode, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceNumber = "x";
		subject.Date = "C6zaXq";
		subject.Quantity = 5;
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.FacilityCode = facilityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C6zaXq", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceNumber = "x";
		subject.FacilityCode = "9";
		subject.Quantity = 5;
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceNumber = "x";
		subject.FacilityCode = "9";
		subject.Date = "C6zaXq";
		subject.MonetaryAmount = 1;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceNumber = "x";
		subject.FacilityCode = "9";
		subject.Date = "C6zaXq";
		subject.Quantity = 5;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
