using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BOXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOX*c*nx*yH*1*FbS*3*4*5*5*1*7*9*1*t*J";

		var expected = new BOX_BoxOfficeDetail()
		{
			FrequencyCode = "c",
			ShowCode = "nx",
			TicketCatagoryCode = "yH",
			MonetaryAmount = 1,
			CurrencyCode = "FbS",
			MonetaryAmount2 = 3,
			Quantity = 4,
			Quantity2 = 5,
			Quantity3 = 5,
			Quantity4 = 1,
			MonetaryAmount3 = 7,
			UnitPrice = 9,
			MonetaryAmount4 = 1,
			ReferenceNumber = "t",
			ReferenceNumber2 = "J",
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
		subject.ShowCode = "nx";
		subject.TicketCatagoryCode = "yH";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nx", true)]
	public void Validation_RequiredShowCode(string showCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "c";
		subject.TicketCatagoryCode = "yH";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ShowCode = showCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yH", true)]
	public void Validation_RequiredTicketCatagoryCode(string ticketCatagoryCode, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "c";
		subject.ShowCode = "nx";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.TicketCatagoryCode = ticketCatagoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BOX_BoxOfficeDetail();
		//Required fields
		subject.FrequencyCode = "c";
		subject.ShowCode = "nx";
		subject.TicketCatagoryCode = "yH";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
