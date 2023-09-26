using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DB*ZN*D*1*1*2*q";

		var expected = new DB_DisbursementInformation()
		{
			DateTimePeriodFormatQualifier = "ZN",
			DateTimePeriod = "D",
			MonetaryAmount = 1,
			MonetaryAmount2 = 1,
			MonetaryAmount3 = 2,
			YesNoConditionOrResponseCode = "q",
		};

		var actual = Map.MapObject<DB_DisbursementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZN", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new DB_DisbursementInformation();
		//Required fields
		subject.DateTimePeriod = "D";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DB_DisbursementInformation();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "ZN";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new DB_DisbursementInformation();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "ZN";
		subject.DateTimePeriod = "D";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
