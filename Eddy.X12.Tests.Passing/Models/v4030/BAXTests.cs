using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAX*2ebIZa*R*aTu*lUSmFVdF*lf1e*0*y25tNS*g*8*quY9mvsu*xYxJ*eQ*ze*Mw";

		var expected = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID()
		{
			StandardPointLocationCode = "2ebIZa",
			TypeOfConsistCode = "R",
			DateTimeQualifier = "aTu",
			Date = "lUSmFVdF",
			Time = "lf1e",
			InterchangeTrainIdentification = "0",
			StandardPointLocationCode2 = "y25tNS",
			ReferenceIdentification = "g",
			DirectionIdentifierCode = "8",
			Date2 = "quY9mvsu",
			Time2 = "xYxJ",
			TimeCode = "eQ",
			TransactionSetPurposeCode = "ze",
			ServiceLevelCode = "Mw",
		};

		var actual = Map.MapObject<BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2ebIZa", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.TypeOfConsistCode = "R";
		subject.DateTimeQualifier = "aTu";
		subject.Date = "lUSmFVdF";
		subject.Time = "lf1e";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredTypeOfConsistCode(string typeOfConsistCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "2ebIZa";
		subject.DateTimeQualifier = "aTu";
		subject.Date = "lUSmFVdF";
		subject.Time = "lf1e";
		subject.TypeOfConsistCode = typeOfConsistCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aTu", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "2ebIZa";
		subject.TypeOfConsistCode = "R";
		subject.Date = "lUSmFVdF";
		subject.Time = "lf1e";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lUSmFVdF", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "2ebIZa";
		subject.TypeOfConsistCode = "R";
		subject.DateTimeQualifier = "aTu";
		subject.Time = "lf1e";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lf1e", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "2ebIZa";
		subject.TypeOfConsistCode = "R";
		subject.DateTimeQualifier = "aTu";
		subject.Date = "lUSmFVdF";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xYxJ", "quY9mvsu", true)]
	[InlineData("xYxJ", "", false)]
	[InlineData("", "quY9mvsu", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "2ebIZa";
		subject.TypeOfConsistCode = "R";
		subject.DateTimeQualifier = "aTu";
		subject.Date = "lUSmFVdF";
		subject.Time = "lf1e";
		subject.Time2 = time2;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eQ", "xYxJ", true)]
	[InlineData("eQ", "", false)]
	[InlineData("", "xYxJ", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "2ebIZa";
		subject.TypeOfConsistCode = "R";
		subject.DateTimeQualifier = "aTu";
		subject.Date = "lUSmFVdF";
		subject.Time = "lf1e";
		subject.TimeCode = timeCode;
		subject.Time2 = time2;
		if (time2 != "")
			subject.Date2 = "quY9mvsu";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
