using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.Tests.Models.v8030;

public class BAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAX*QZgZNN*5*DX3*aUQfikcs*i3wK*q*LlA7Gg*t*c*hmGSgtOz*uxn9*oh*JM*6v*H*9";

		var expected = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID()
		{
			StandardPointLocationCode = "QZgZNN",
			TypeOfConsistCode = "5",
			DateTimeQualifier = "DX3",
			Date = "aUQfikcs",
			Time = "i3wK",
			InterchangeTrainIdentification = "q",
			StandardPointLocationCode2 = "LlA7Gg",
			ReferenceIdentification = "t",
			DirectionIdentifierCode = "c",
			Date2 = "hmGSgtOz",
			Time2 = "uxn9",
			TimeCode = "oh",
			TransactionSetPurposeCode = "JM",
			ServiceLevelCode = "6v",
			InterchangeTrainIdentification2 = "H",
			Number = 9,
		};

		var actual = Map.MapObject<BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QZgZNN", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.TypeOfConsistCode = "5";
		subject.DateTimeQualifier = "DX3";
		subject.Date = "aUQfikcs";
		subject.Time = "i3wK";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredTypeOfConsistCode(string typeOfConsistCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "QZgZNN";
		subject.DateTimeQualifier = "DX3";
		subject.Date = "aUQfikcs";
		subject.Time = "i3wK";
		subject.TypeOfConsistCode = typeOfConsistCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DX3", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "QZgZNN";
		subject.TypeOfConsistCode = "5";
		subject.Date = "aUQfikcs";
		subject.Time = "i3wK";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aUQfikcs", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "QZgZNN";
		subject.TypeOfConsistCode = "5";
		subject.DateTimeQualifier = "DX3";
		subject.Time = "i3wK";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i3wK", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "QZgZNN";
		subject.TypeOfConsistCode = "5";
		subject.DateTimeQualifier = "DX3";
		subject.Date = "aUQfikcs";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uxn9", "hmGSgtOz", true)]
	[InlineData("uxn9", "", false)]
	[InlineData("", "hmGSgtOz", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "QZgZNN";
		subject.TypeOfConsistCode = "5";
		subject.DateTimeQualifier = "DX3";
		subject.Date = "aUQfikcs";
		subject.Time = "i3wK";
		subject.Time2 = time2;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oh", "uxn9", true)]
	[InlineData("oh", "", false)]
	[InlineData("", "uxn9", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "QZgZNN";
		subject.TypeOfConsistCode = "5";
		subject.DateTimeQualifier = "DX3";
		subject.Date = "aUQfikcs";
		subject.Time = "i3wK";
		subject.TimeCode = timeCode;
		subject.Time2 = time2;
		if (time2 != "")
			subject.Date2 = "hmGSgtOz";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
