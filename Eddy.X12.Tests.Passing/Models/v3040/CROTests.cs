using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CROTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRO*J9*D*O6*t*h";

		var expected = new CRO_CreditReportOrderDetails()
		{
			DateTimePeriodFormatQualifier = "J9",
			DateTimePeriod = "D",
			ProductServiceIDQualifier = "O6",
			ProductServiceID = "t",
			ActionCode = "h",
		};

		var actual = Map.MapObject<CRO_CreditReportOrderDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J9", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriod = "D";
		subject.ProductServiceIDQualifier = "O6";
		subject.ProductServiceID = "t";
		subject.ActionCode = "h";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "J9";
		subject.ProductServiceIDQualifier = "O6";
		subject.ProductServiceID = "t";
		subject.ActionCode = "h";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O6", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "J9";
		subject.DateTimePeriod = "D";
		subject.ProductServiceID = "t";
		subject.ActionCode = "h";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "J9";
		subject.DateTimePeriod = "D";
		subject.ProductServiceIDQualifier = "O6";
		subject.ActionCode = "h";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "J9";
		subject.DateTimePeriod = "D";
		subject.ProductServiceIDQualifier = "O6";
		subject.ProductServiceID = "t";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
