using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class CROTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRO*kB*J*ta*w*l*Z";

		var expected = new CRO_CreditReportOrderDetails()
		{
			DateTimePeriodFormatQualifier = "kB",
			DateTimePeriod = "J",
			ProductServiceIDQualifier = "ta",
			ProductServiceID = "w",
			ActionCode = "l",
			CreditReportMergeTypeCode = "Z",
		};

		var actual = Map.MapObject<CRO_CreditReportOrderDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kB", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriod = "J";
		subject.ProductServiceIDQualifier = "ta";
		subject.ProductServiceID = "w";
		subject.ActionCode = "l";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "kB";
		subject.ProductServiceIDQualifier = "ta";
		subject.ProductServiceID = "w";
		subject.ActionCode = "l";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ta", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "kB";
		subject.DateTimePeriod = "J";
		subject.ProductServiceID = "w";
		subject.ActionCode = "l";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "kB";
		subject.DateTimePeriod = "J";
		subject.ProductServiceIDQualifier = "ta";
		subject.ActionCode = "l";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "kB";
		subject.DateTimePeriod = "J";
		subject.ProductServiceIDQualifier = "ta";
		subject.ProductServiceID = "w";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
