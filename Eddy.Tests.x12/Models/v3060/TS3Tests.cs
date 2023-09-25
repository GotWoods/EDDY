using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TS3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS3*I*N*cj2L1r*1*9*4*7*8*3*6*5*1*2*2*3*5*1*9*6*1*5*5*7*4";

		var expected = new TS3_TransactionStatistics()
		{
			ReferenceIdentification = "I",
			FacilityCodeValue = "N",
			Date = "cj2L1r",
			Quantity = 1,
			MonetaryAmount = 9,
			MonetaryAmount2 = 4,
			MonetaryAmount3 = 7,
			MonetaryAmount4 = 8,
			MonetaryAmount5 = 3,
			MonetaryAmount6 = 6,
			MonetaryAmount7 = 5,
			MonetaryAmount8 = 1,
			MonetaryAmount9 = 2,
			MonetaryAmount10 = 2,
			MonetaryAmount11 = 3,
			MonetaryAmount12 = 5,
			MonetaryAmount13 = 1,
			MonetaryAmount14 = 9,
			MonetaryAmount15 = 6,
			MonetaryAmount16 = 1,
			MonetaryAmount17 = 5,
			MonetaryAmount18 = 5,
			Quantity2 = 7,
			MonetaryAmount19 = 4,
		};

		var actual = Map.MapObject<TS3_TransactionStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.FacilityCodeValue = "N";
		subject.Date = "cj2L1r";
		subject.Quantity = 1;
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredFacilityCodeValue(string facilityCodeValue, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "I";
		subject.Date = "cj2L1r";
		subject.Quantity = 1;
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.FacilityCodeValue = facilityCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cj2L1r", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "I";
		subject.FacilityCodeValue = "N";
		subject.Quantity = 1;
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "I";
		subject.FacilityCodeValue = "N";
		subject.Date = "cj2L1r";
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
		subject.ReferenceIdentification = "I";
		subject.FacilityCodeValue = "N";
		subject.Date = "cj2L1r";
		subject.Quantity = 1;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
