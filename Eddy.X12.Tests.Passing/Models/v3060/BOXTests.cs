using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BOXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOX*z*tm*sr*5*ffv*6*4*4*4*1*5*5*6*p*l";

		var expected = new BOX_BoxOfficeDetail()
		{
			FrequencyCode = "z",
			ShowCode = "tm",
			TicketCatagoryCode = "sr",
			MonetaryAmount = 5,
			CurrencyCode = "ffv",
			MonetaryAmount2 = 6,
			Quantity = 4,
			Quantity2 = 4,
			Quantity3 = 4,
			Quantity4 = 1,
			MonetaryAmount3 = 5,
			UnitPrice = 5,
			MonetaryAmount4 = 6,
			ReferenceIdentification = "p",
			ReferenceIdentification2 = "l",
		};

		var actual = Map.MapObject<BOX_BoxOfficeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.ShowCode = "tm";
		subject.TicketCatagoryCode = "sr";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tm", true)]
	public void Validation_RequiredShowCode(string showCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "z";
		subject.TicketCatagoryCode = "sr";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.ShowCode = showCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sr", true)]
	public void Validation_RequiredTicketCatagoryCode(string ticketCatagoryCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "z";
		subject.ShowCode = "tm";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.TicketCatagoryCode = ticketCatagoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "z";
		subject.ShowCode = "tm";
		subject.TicketCatagoryCode = "sr";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
