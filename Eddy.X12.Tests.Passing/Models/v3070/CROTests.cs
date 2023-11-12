using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CROTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRO*4T*H*Bi*C*L*e";

		var expected = new CRO_CreditReportOrderDetails()
		{
			DateTimePeriodFormatQualifier = "4T",
			DateTimePeriod = "H",
			ProductServiceIDQualifier = "Bi",
			ProductServiceID = "C",
			ActionCode = "L",
			CreditReportMergeTypeCode = "e",
		};

		var actual = Map.MapObject<CRO_CreditReportOrderDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4T", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriod = "H";
		subject.ProductServiceIDQualifier = "Bi";
		subject.ProductServiceID = "C";
		subject.ActionCode = "L";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "4T";
		subject.ProductServiceIDQualifier = "Bi";
		subject.ProductServiceID = "C";
		subject.ActionCode = "L";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bi", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "4T";
		subject.DateTimePeriod = "H";
		subject.ProductServiceID = "C";
		subject.ActionCode = "L";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "4T";
		subject.DateTimePeriod = "H";
		subject.ProductServiceIDQualifier = "Bi";
		subject.ActionCode = "L";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new CRO_CreditReportOrderDetails();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "4T";
		subject.DateTimePeriod = "H";
		subject.ProductServiceIDQualifier = "Bi";
		subject.ProductServiceID = "C";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
