using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BOXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOX*w*Rq*TR*4*wi6*3*8*3*2*3*6*5*6*J*f";

		var expected = new BOX_BoxOfficeDetail()
		{
			FrequencyCode = "w",
			ShowCode = "Rq",
			TicketCategoryCode = "TR",
			MonetaryAmount = 4,
			CurrencyCode = "wi6",
			MonetaryAmount2 = 3,
			Quantity = 8,
			Quantity2 = 3,
			Quantity3 = 2,
			Quantity4 = 3,
			MonetaryAmount3 = 6,
			UnitPrice = 5,
			MonetaryAmount4 = 6,
			ReferenceIdentification = "J",
			ReferenceIdentification2 = "f",
		};

		var actual = Map.MapObject<BOX_BoxOfficeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validatation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		subject.ShowCode = "Rq";
		subject.TicketCategoryCode = "TR";
		subject.MonetaryAmount = 4;
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rq", true)]
	public void Validatation_RequiredShowCode(string showCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		subject.FrequencyCode = "w";
		subject.TicketCategoryCode = "TR";
		subject.MonetaryAmount = 4;
		subject.ShowCode = showCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TR", true)]
	public void Validatation_RequiredTicketCategoryCode(string ticketCategoryCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		subject.FrequencyCode = "w";
		subject.ShowCode = "Rq";
		subject.MonetaryAmount = 4;
		subject.TicketCategoryCode = ticketCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		subject.FrequencyCode = "w";
		subject.ShowCode = "Rq";
		subject.TicketCategoryCode = "TR";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
