using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BOXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOX*E*Zx*lr*9*dYQ*2*7*2*7*3*4*2*9*M*n";

		var expected = new BOX_BoxOfficeDetail()
		{
			FrequencyCode = "E",
			ShowCode = "Zx",
			TicketCategoryCode = "lr",
			MonetaryAmount = 9,
			CurrencyCode = "dYQ",
			MonetaryAmount2 = 2,
			Quantity = 7,
			Quantity2 = 2,
			Quantity3 = 7,
			Quantity4 = 3,
			MonetaryAmount3 = 4,
			UnitPrice = 2,
			MonetaryAmount4 = 9,
			ReferenceIdentification = "M",
			ReferenceIdentification2 = "n",
		};

		var actual = Map.MapObject<BOX_BoxOfficeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.ShowCode = "Zx";
		subject.TicketCategoryCode = "lr";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zx", true)]
	public void Validation_RequiredShowCode(string showCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "E";
		subject.TicketCategoryCode = "lr";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ShowCode = showCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lr", true)]
	public void Validation_RequiredTicketCategoryCode(string ticketCategoryCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "E";
		subject.ShowCode = "Zx";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.TicketCategoryCode = ticketCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "E";
		subject.ShowCode = "Zx";
		subject.TicketCategoryCode = "lr";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
