using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BOXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOX*D*Ok*nM*4*qtB*6*5*6*2*5*9*7*7*9*B";

		var expected = new BOX_BoxOfficeDetail()
		{
			FrequencyCode = "D",
			ShowCode = "Ok",
			TicketCategoryCode = "nM",
			MonetaryAmount = 4,
			CurrencyCode = "qtB",
			MonetaryAmount2 = 6,
			Quantity = 5,
			Quantity2 = 6,
			Quantity3 = 2,
			Quantity4 = 5,
			MonetaryAmount3 = 9,
			UnitPrice = 7,
			MonetaryAmount4 = 7,
			ReferenceIdentification = "9",
			ReferenceIdentification2 = "B",
		};

		var actual = Map.MapObject<BOX_BoxOfficeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.ShowCode = "Ok";
		subject.TicketCategoryCode = "nM";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ok", true)]
	public void Validation_RequiredShowCode(string showCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "D";
		subject.TicketCategoryCode = "nM";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.ShowCode = showCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nM", true)]
	public void Validation_RequiredTicketCategoryCode(string ticketCategoryCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "D";
		subject.ShowCode = "Ok";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.TicketCategoryCode = ticketCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "D";
		subject.ShowCode = "Ok";
		subject.TicketCategoryCode = "nM";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
