using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CROTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRO*hC*0*MU*b*p*e";

		var expected = new CRO_CreditReportOrderDetails()
		{
			DateTimePeriodFormatQualifier = "hC",
			DateTimePeriod = "0",
			ProductServiceIDQualifier = "MU",
			ProductServiceID = "b",
			ActionCode = "p",
			CreditReportMergeTypeCode = "e",
		};

		var actual = Map.MapObject<CRO_CreditReportOrderDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hC", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriod = "0";
		subject.ProductServiceIDQualifier = "MU";
		subject.ProductServiceID = "b";
		subject.ActionCode = "p";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "hC";
		subject.ProductServiceIDQualifier = "MU";
		subject.ProductServiceID = "b";
		subject.ActionCode = "p";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MU", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "hC";
		subject.DateTimePeriod = "0";
		subject.ProductServiceID = "b";
		subject.ActionCode = "p";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "hC";
		subject.DateTimePeriod = "0";
		subject.ProductServiceIDQualifier = "MU";
		subject.ActionCode = "p";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "hC";
		subject.DateTimePeriod = "0";
		subject.ProductServiceIDQualifier = "MU";
		subject.ProductServiceID = "b";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
