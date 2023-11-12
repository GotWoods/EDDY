using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BOXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOX*I*HC*tA*6*Y5S*4*8*5*1*5*3*1*2*4*9";

		var expected = new BOX_BoxOfficeDetail()
		{
			FrequencyCode = "I",
			ShowCode = "HC",
			TicketCategoryCode = "tA",
			MonetaryAmount = 6,
			CurrencyCode = "Y5S",
			MonetaryAmount2 = 4,
			Quantity = 8,
			Quantity2 = 5,
			Quantity3 = 1,
			Quantity4 = 5,
			MonetaryAmount3 = 3,
			UnitPrice = 1,
			MonetaryAmount4 = 2,
			ReferenceIdentification = "4",
			ReferenceIdentification2 = "9",
		};

		var actual = Map.MapObject<BOX_BoxOfficeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.ShowCode = "HC";
		subject.TicketCategoryCode = "tA";
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HC", true)]
	public void Validation_RequiredShowCode(string showCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "I";
		subject.TicketCategoryCode = "tA";
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.ShowCode = showCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tA", true)]
	public void Validation_RequiredTicketCategoryCode(string ticketCategoryCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "I";
		subject.ShowCode = "HC";
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.TicketCategoryCode = ticketCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "I";
		subject.ShowCode = "HC";
		subject.TicketCategoryCode = "tA";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
