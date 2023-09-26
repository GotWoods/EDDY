using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ER*2m*9x*Aar*TnwkYR*g7L*XP*N*ev*R*obboeY";

		var expected = new ER_RailEventReporting()
		{
			TransactionSetPurposeCode = "2m",
			StandardCarrierAlphaCode = "9x",
			EventCode = "Aar",
			StandardPointLocationCode = "TnwkYR",
			DateTimeQualifier = "g7L",
			DateTimePeriodFormatQualifier = "XP",
			DateTimePeriod = "N",
			StandardCarrierAlphaCode2 = "ev",
			InterchangeTrainIdentification = "R",
			Date = "obboeY",
		};

		var actual = Map.MapObject<ER_RailEventReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2m", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.StandardCarrierAlphaCode = "9x";
		subject.EventCode = "Aar";
		subject.StandardPointLocationCode = "TnwkYR";
		subject.DateTimeQualifier = "g7L";
		subject.DateTimePeriodFormatQualifier = "XP";
		subject.DateTimePeriod = "N";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9x", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "2m";
		subject.EventCode = "Aar";
		subject.StandardPointLocationCode = "TnwkYR";
		subject.DateTimeQualifier = "g7L";
		subject.DateTimePeriodFormatQualifier = "XP";
		subject.DateTimePeriod = "N";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Aar", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "2m";
		subject.StandardCarrierAlphaCode = "9x";
		subject.StandardPointLocationCode = "TnwkYR";
		subject.DateTimeQualifier = "g7L";
		subject.DateTimePeriodFormatQualifier = "XP";
		subject.DateTimePeriod = "N";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TnwkYR", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "2m";
		subject.StandardCarrierAlphaCode = "9x";
		subject.EventCode = "Aar";
		subject.DateTimeQualifier = "g7L";
		subject.DateTimePeriodFormatQualifier = "XP";
		subject.DateTimePeriod = "N";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g7L", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "2m";
		subject.StandardCarrierAlphaCode = "9x";
		subject.EventCode = "Aar";
		subject.StandardPointLocationCode = "TnwkYR";
		subject.DateTimePeriodFormatQualifier = "XP";
		subject.DateTimePeriod = "N";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XP", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "2m";
		subject.StandardCarrierAlphaCode = "9x";
		subject.EventCode = "Aar";
		subject.StandardPointLocationCode = "TnwkYR";
		subject.DateTimeQualifier = "g7L";
		subject.DateTimePeriod = "N";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "2m";
		subject.StandardCarrierAlphaCode = "9x";
		subject.EventCode = "Aar";
		subject.StandardPointLocationCode = "TnwkYR";
		subject.DateTimeQualifier = "g7L";
		subject.DateTimePeriodFormatQualifier = "XP";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "obboeY", true)]
	[InlineData("R", "", false)]
	[InlineData("", "obboeY", true)]
	public void Validation_ARequiresBInterchangeTrainIdentification(string interchangeTrainIdentification, string date, bool isValidExpected)
	{
		var subject = new ER_RailEventReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "2m";
		subject.StandardCarrierAlphaCode = "9x";
		subject.EventCode = "Aar";
		subject.StandardPointLocationCode = "TnwkYR";
		subject.DateTimeQualifier = "g7L";
		subject.DateTimePeriodFormatQualifier = "XP";
		subject.DateTimePeriod = "N";
		//Test Parameters
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
