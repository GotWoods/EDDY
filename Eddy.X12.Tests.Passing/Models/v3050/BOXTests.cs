using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BOXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOX*c*1r*Rw*7*uea*8*6*3*3*1*5*1*4*m*A";

		var expected = new BOX_BoxOfficeDetail()
		{
			FrequencyCode = "c",
			ShowCode = "1r",
			TicketCatagoryCode = "Rw",
			MonetaryAmount = 7,
			CurrencyCode = "uea",
			MonetaryAmount2 = 8,
			Quantity = 6,
			Quantity2 = 3,
			Quantity3 = 3,
			Quantity4 = 1,
			MonetaryAmount3 = 5,
			UnitPrice = 1,
			MonetaryAmount4 = 4,
			ReferenceNumber = "m",
			ReferenceNumber2 = "A",
		};

		var actual = Map.MapObject<BOX_BoxOfficeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.ShowCode = "1r";
		subject.TicketCatagoryCode = "Rw";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1r", true)]
	public void Validation_RequiredShowCode(string showCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "c";
		subject.TicketCatagoryCode = "Rw";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.ShowCode = showCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rw", true)]
	public void Validation_RequiredTicketCatagoryCode(string ticketCatagoryCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "c";
		subject.ShowCode = "1r";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.TicketCatagoryCode = ticketCatagoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "c";
		subject.ShowCode = "1r";
		subject.TicketCatagoryCode = "Rw";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
