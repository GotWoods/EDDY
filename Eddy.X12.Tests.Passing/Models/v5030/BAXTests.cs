using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAX*JGMMDN*1*AVt*GeYWoyfx*HOk7*3*RInwk7*D*b*8PusYbkB*snVZ*so*kw*ku";

		var expected = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID()
		{
			StandardPointLocationCode = "JGMMDN",
			TypeOfConsistCode = "1",
			DateTimeQualifier = "AVt",
			Date = "GeYWoyfx",
			Time = "HOk7",
			InterchangeTrainIdentification = "3",
			StandardPointLocationCode2 = "RInwk7",
			ReferenceIdentification = "D",
			DirectionIdentifierCode = "b",
			Date2 = "8PusYbkB",
			Time2 = "snVZ",
			TimeCode = "so",
			TransactionSetPurposeCode = "kw",
			ServiceLevelCode = "ku",
		};

		var actual = Map.MapObject<BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JGMMDN", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.TypeOfConsistCode = "1";
		subject.DateTimeQualifier = "AVt";
		subject.Date = "GeYWoyfx";
		subject.Time = "HOk7";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredTypeOfConsistCode(string typeOfConsistCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "JGMMDN";
		subject.DateTimeQualifier = "AVt";
		subject.Date = "GeYWoyfx";
		subject.Time = "HOk7";
		subject.TypeOfConsistCode = typeOfConsistCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AVt", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "JGMMDN";
		subject.TypeOfConsistCode = "1";
		subject.Date = "GeYWoyfx";
		subject.Time = "HOk7";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GeYWoyfx", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "JGMMDN";
		subject.TypeOfConsistCode = "1";
		subject.DateTimeQualifier = "AVt";
		subject.Time = "HOk7";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HOk7", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "JGMMDN";
		subject.TypeOfConsistCode = "1";
		subject.DateTimeQualifier = "AVt";
		subject.Date = "GeYWoyfx";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("snVZ", "8PusYbkB", true)]
	[InlineData("snVZ", "", false)]
	[InlineData("", "8PusYbkB", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "JGMMDN";
		subject.TypeOfConsistCode = "1";
		subject.DateTimeQualifier = "AVt";
		subject.Date = "GeYWoyfx";
		subject.Time = "HOk7";
		subject.Time2 = time2;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("so", "snVZ", true)]
	[InlineData("so", "", false)]
	[InlineData("", "snVZ", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "JGMMDN";
		subject.TypeOfConsistCode = "1";
		subject.DateTimeQualifier = "AVt";
		subject.Date = "GeYWoyfx";
		subject.Time = "HOk7";
		subject.TimeCode = timeCode;
		subject.Time2 = time2;
		if (time2 != "")
			subject.Date2 = "8PusYbkB";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
