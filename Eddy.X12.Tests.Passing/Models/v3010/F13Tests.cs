using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F13*u*DUNUrT*SlyBZI*3429751217633395*KOlupl";

		var expected = new F13_PaymentInformation()
		{
			CheckNumber = "u",
			Date = "DUNUrT",
			Date2 = "SlyBZI",
			MICRNumber = 3429751217633395,
			Date3 = "KOlupl",
		};

		var actual = Map.MapObject<F13_PaymentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredCheckNumber(string checkNumber, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.Date = "DUNUrT";
		subject.Date2 = "SlyBZI";
		subject.CheckNumber = checkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DUNUrT", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "u";
		subject.Date2 = "SlyBZI";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SlyBZI", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "u";
		subject.Date = "DUNUrT";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
