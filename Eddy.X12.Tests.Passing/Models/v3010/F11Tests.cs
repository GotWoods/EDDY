using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F11*3FcIuK*F*1*3*q*JI*1TM8EE*Dsr";

		var expected = new F11_Status()
		{
			Date = "3FcIuK",
			ReferenceNumber = "F",
			ReferenceNumber2 = "1",
			Amount = "3",
			Amount2 = "q",
			StatusCode = "JI",
			Date2 = "1TM8EE",
			DeclineAmendReasonCode = "Dsr",
		};

		var actual = Map.MapObject<F11_Status>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3FcIuK", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.ReferenceNumber = "F";
		subject.ReferenceNumber2 = "1";
		subject.Amount = "3";
		subject.StatusCode = "JI";
		subject.Date2 = "1TM8EE";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "3FcIuK";
		subject.ReferenceNumber2 = "1";
		subject.Amount = "3";
		subject.StatusCode = "JI";
		subject.Date2 = "1TM8EE";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "3FcIuK";
		subject.ReferenceNumber = "F";
		subject.Amount = "3";
		subject.StatusCode = "JI";
		subject.Date2 = "1TM8EE";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "3FcIuK";
		subject.ReferenceNumber = "F";
		subject.ReferenceNumber2 = "1";
		subject.StatusCode = "JI";
		subject.Date2 = "1TM8EE";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JI", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "3FcIuK";
		subject.ReferenceNumber = "F";
		subject.ReferenceNumber2 = "1";
		subject.Amount = "3";
		subject.Date2 = "1TM8EE";
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1TM8EE", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new F11_Status();
		subject.Date = "3FcIuK";
		subject.ReferenceNumber = "F";
		subject.ReferenceNumber2 = "1";
		subject.Amount = "3";
		subject.StatusCode = "JI";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
