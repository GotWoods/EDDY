using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAX*VO67ku*W*Ill*uRcuS773*Pyhz*9*2V44tv*K*9*XKYrkMMC*GCE3*42*W7*KY";

		var expected = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentId()
		{
			StandardPointLocationCode = "VO67ku",
			TypeOfConsistCode = "W",
			DateTimeQualifier = "Ill",
			Date = "uRcuS773",
			Time = "Pyhz",
			InterchangeTrainIdentification = "9",
			StandardPointLocationCode2 = "2V44tv",
			ReferenceIdentification = "K",
			DirectionIdentifierCode = "9",
			Date2 = "XKYrkMMC",
			Time2 = "GCE3",
			TimeCode = "42",
			TransactionSetPurposeCode = "W7",
			ServiceLevelCode = "KY",
		};

		var actual = Map.MapObject<BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentId>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

	[Theory]
	[InlineData("", false)]
	[InlineData("VO67ku", true)]
	public void Validatation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentId();
		subject.TypeOfConsistCode = "W";
		subject.DateTimeQualifier = "Ill";
		subject.Date = "uRcuS773";
		subject.Time = "Pyhz";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validatation_RequiredTypeOfConsistCode(string typeOfConsistCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentId();
		subject.StandardPointLocationCode = "VO67ku";
		subject.DateTimeQualifier = "Ill";
		subject.Date = "uRcuS773";
		subject.Time = "Pyhz";
		subject.TypeOfConsistCode = typeOfConsistCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ill", true)]
	public void Validatation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentId();
		subject.StandardPointLocationCode = "VO67ku";
		subject.TypeOfConsistCode = "W";
		subject.Date = "uRcuS773";
		subject.Time = "Pyhz";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uRcuS773", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentId();
		subject.StandardPointLocationCode = "VO67ku";
		subject.TypeOfConsistCode = "W";
		subject.DateTimeQualifier = "Ill";
		subject.Time = "Pyhz";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pyhz", true)]
	public void Validatation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentId();
		subject.StandardPointLocationCode = "VO67ku";
		subject.TypeOfConsistCode = "W";
		subject.DateTimeQualifier = "Ill";
		subject.Date = "uRcuS773";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "XKYrkMMC", true)]
	[InlineData("GCE3", "", false)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentId();
		subject.StandardPointLocationCode = "VO67ku";
		subject.TypeOfConsistCode = "W";
		subject.DateTimeQualifier = "Ill";
		subject.Date = "uRcuS773";
		subject.Time = "Pyhz";
		subject.Time2 = time2;
		subject.Date2 = date2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "GCE3", true)]
	[InlineData("42", "", false)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentId();
		subject.StandardPointLocationCode = "VO67ku";
		subject.TypeOfConsistCode = "W";
		subject.DateTimeQualifier = "Ill";
		subject.Date = "uRcuS773";
		subject.Time = "Pyhz";
		subject.TimeCode = timeCode;
		subject.Time2 = time2;
		if (time2 != "")
			subject.Date2 = "20020101";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
