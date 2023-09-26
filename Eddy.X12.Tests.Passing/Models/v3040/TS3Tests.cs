using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class TS3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS3*A*q*RvGAsr*9*8*8*4*2*5*3*5*6*5*4*6*8*4*3*7*3*3*7*2*7";

		var expected = new TS3_TransactionStatistics()
		{
			ReferenceNumber = "A",
			FacilityCodeValue = "q",
			Date = "RvGAsr",
			Quantity = 9,
			MonetaryAmount = 8,
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 4,
			MonetaryAmount4 = 2,
			MonetaryAmount5 = 5,
			MonetaryAmount6 = 3,
			MonetaryAmount7 = 5,
			MonetaryAmount8 = 6,
			MonetaryAmount9 = 5,
			MonetaryAmount10 = 4,
			MonetaryAmount11 = 6,
			MonetaryAmount12 = 8,
			MonetaryAmount13 = 4,
			MonetaryAmount14 = 3,
			MonetaryAmount15 = 7,
			MonetaryAmount16 = 3,
			MonetaryAmount17 = 3,
			MonetaryAmount18 = 7,
			Quantity2 = 2,
			MonetaryAmount19 = 7,
		};

		var actual = Map.MapObject<TS3_TransactionStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.FacilityCodeValue = "q";
		subject.Date = "RvGAsr";
		subject.Quantity = 9;
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredFacilityCodeValue(string facilityCodeValue, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceNumber = "A";
		subject.Date = "RvGAsr";
		subject.Quantity = 9;
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.FacilityCodeValue = facilityCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RvGAsr", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceNumber = "A";
		subject.FacilityCodeValue = "q";
		subject.Quantity = 9;
		subject.MonetaryAmount = 8;
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
		subject.ReferenceNumber = "A";
		subject.FacilityCodeValue = "q";
		subject.Date = "RvGAsr";
		subject.MonetaryAmount = 8;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceNumber = "A";
		subject.FacilityCodeValue = "q";
		subject.Date = "RvGAsr";
		subject.Quantity = 9;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
