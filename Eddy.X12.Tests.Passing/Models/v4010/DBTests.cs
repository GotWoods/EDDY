using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DB*SP*0*2*6*8*W";

		var expected = new DB_DisbursementInformation()
		{
			DateTimePeriodFormatQualifier = "SP",
			DateTimePeriod = "0",
			MonetaryAmount = 2,
			MonetaryAmount2 = 6,
			MonetaryAmount3 = 8,
			YesNoConditionOrResponseCode = "W",
		};

		var actual = Map.MapObject<DB_DisbursementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SP", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new DB_DisbursementInformation();
		//Required fields
		subject.DateTimePeriod = "0";
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DB_DisbursementInformation();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "SP";
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new DB_DisbursementInformation();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "SP";
		subject.DateTimePeriod = "0";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
