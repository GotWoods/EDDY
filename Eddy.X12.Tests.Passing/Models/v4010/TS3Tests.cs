using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TS3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS3*s*I*FhOoNEXR*2*7*9*2*8*3*4*3*9*2*9*4*2*1*4*3*3*8*8*7*6";

		var expected = new TS3_TransactionStatistics()
		{
			ReferenceIdentification = "s",
			FacilityCodeValue = "I",
			Date = "FhOoNEXR",
			Quantity = 2,
			MonetaryAmount = 7,
			MonetaryAmount2 = 9,
			MonetaryAmount3 = 2,
			MonetaryAmount4 = 8,
			MonetaryAmount5 = 3,
			MonetaryAmount6 = 4,
			MonetaryAmount7 = 3,
			MonetaryAmount8 = 9,
			MonetaryAmount9 = 2,
			MonetaryAmount10 = 9,
			MonetaryAmount11 = 4,
			MonetaryAmount12 = 2,
			MonetaryAmount13 = 1,
			MonetaryAmount14 = 4,
			MonetaryAmount15 = 3,
			MonetaryAmount16 = 3,
			MonetaryAmount17 = 8,
			MonetaryAmount18 = 8,
			Quantity2 = 7,
			MonetaryAmount19 = 6,
		};

		var actual = Map.MapObject<TS3_TransactionStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.FacilityCodeValue = "I";
		subject.Date = "FhOoNEXR";
		subject.Quantity = 2;
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredFacilityCodeValue(string facilityCodeValue, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "s";
		subject.Date = "FhOoNEXR";
		subject.Quantity = 2;
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.FacilityCodeValue = facilityCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FhOoNEXR", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "s";
		subject.FacilityCodeValue = "I";
		subject.Quantity = 2;
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new TS3_TransactionStatistics();
		//Required fields
		subject.ReferenceIdentification = "s";
		subject.FacilityCodeValue = "I";
		subject.Date = "FhOoNEXR";
		subject.MonetaryAmount = 7;
		//Test Parameters
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
		//Required fields
		subject.ReferenceIdentification = "s";
		subject.FacilityCodeValue = "I";
		subject.Date = "FhOoNEXR";
		subject.Quantity = 2;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
