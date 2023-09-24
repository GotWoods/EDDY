using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAX*M1rS5x*K*Lba*j3kBSrRG*dIhf*I*hfHTyD*u*5*3AFyHl89*xEVv*Ub*5s*io";

		var expected = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID()
		{
			StandardPointLocationCode = "M1rS5x",
			TypeOfConsistCode = "K",
			DateTimeQualifier = "Lba",
			Date = "j3kBSrRG",
			Time = "dIhf",
			InterchangeTrainIdentification = "I",
			StandardPointLocationCode2 = "hfHTyD",
			ReferenceIdentification = "u",
			DirectionIdentifierCode = "5",
			Date2 = "3AFyHl89",
			Time2 = "xEVv",
			TimeCode = "Ub",
			TransactionSetPurposeCode = "5s",
			ServiceLevelCode = "io",
		};

		var actual = Map.MapObject<BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M1rS5x", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.TypeOfConsistCode = "K";
		subject.DateTimeQualifier = "Lba";
		subject.Date = "j3kBSrRG";
		subject.Time = "dIhf";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredTypeOfConsistCode(string typeOfConsistCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "M1rS5x";
		subject.DateTimeQualifier = "Lba";
		subject.Date = "j3kBSrRG";
		subject.Time = "dIhf";
		subject.TypeOfConsistCode = typeOfConsistCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lba", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "M1rS5x";
		subject.TypeOfConsistCode = "K";
		subject.Date = "j3kBSrRG";
		subject.Time = "dIhf";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j3kBSrRG", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "M1rS5x";
		subject.TypeOfConsistCode = "K";
		subject.DateTimeQualifier = "Lba";
		subject.Time = "dIhf";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dIhf", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "M1rS5x";
		subject.TypeOfConsistCode = "K";
		subject.DateTimeQualifier = "Lba";
		subject.Date = "j3kBSrRG";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xEVv", "3AFyHl89", true)]
	[InlineData("xEVv", "", false)]
	[InlineData("", "3AFyHl89", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "M1rS5x";
		subject.TypeOfConsistCode = "K";
		subject.DateTimeQualifier = "Lba";
		subject.Date = "j3kBSrRG";
		subject.Time = "dIhf";
		subject.Time2 = time2;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ub", "xEVv", true)]
	[InlineData("Ub", "", false)]
	[InlineData("", "xEVv", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "M1rS5x";
		subject.TypeOfConsistCode = "K";
		subject.DateTimeQualifier = "Lba";
		subject.Date = "j3kBSrRG";
		subject.Time = "dIhf";
		subject.TimeCode = timeCode;
		subject.Time2 = time2;
		if (time2 != "")
			subject.Date2 = "3AFyHl89";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
