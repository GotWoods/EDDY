using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CROTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRO*Xv*0*sb*U*X*x";

		var expected = new CRO_CreditReportOrderDetails()
		{
			DateTimePeriodFormatQualifier = "Xv",
			DateTimePeriod = "0",
			ProductServiceIDQualifier = "sb",
			ProductServiceID = "U",
			ActionCode = "X",
			CreditReportMergeTypeCode = "x",
		};

		var actual = Map.MapObject<CRO_CreditReportOrderDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xv", true)]
	public void Validatation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		subject.DateTimePeriod = "0";
		subject.ProductServiceIDQualifier = "sb";
		subject.ProductServiceID = "U";
		subject.ActionCode = "X";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validatation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		subject.DateTimePeriodFormatQualifier = "Xv";
		subject.ProductServiceIDQualifier = "sb";
		subject.ProductServiceID = "U";
		subject.ActionCode = "X";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sb", true)]
	public void Validatation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		subject.DateTimePeriodFormatQualifier = "Xv";
		subject.DateTimePeriod = "0";
		subject.ProductServiceID = "U";
		subject.ActionCode = "X";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validatation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		subject.DateTimePeriodFormatQualifier = "Xv";
		subject.DateTimePeriod = "0";
		subject.ProductServiceIDQualifier = "sb";
		subject.ActionCode = "X";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validatation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		subject.DateTimePeriodFormatQualifier = "Xv";
		subject.DateTimePeriod = "0";
		subject.ProductServiceIDQualifier = "sb";
		subject.ProductServiceID = "U";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
