using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BAXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAX*hR33FS*H*z9W*0aHEKg*LOf8*j*Fk5eNJ*y*a*2IrXiX*S45a*si*D3";

		var expected = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID()
		{
			StandardPointLocationCode = "hR33FS",
			TypeOfConsistCode = "H",
			DateTimeQualifier = "z9W",
			Date = "0aHEKg",
			Time = "LOf8",
			InterchangeTrainIdentification = "j",
			StandardPointLocationCode2 = "Fk5eNJ",
			ReferenceIdentification = "y",
			DirectionIdentifierCode = "a",
			Date2 = "2IrXiX",
			Time2 = "S45a",
			TimeCode = "si",
			TransactionTypeCode = "D3",
		};

		var actual = Map.MapObject<BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hR33FS", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.TypeOfConsistCode = "H";
		subject.DateTimeQualifier = "z9W";
		subject.Date = "0aHEKg";
		subject.Time = "LOf8";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredTypeOfConsistCode(string typeOfConsistCode, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "hR33FS";
		subject.DateTimeQualifier = "z9W";
		subject.Date = "0aHEKg";
		subject.Time = "LOf8";
		subject.TypeOfConsistCode = typeOfConsistCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z9W", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "hR33FS";
		subject.TypeOfConsistCode = "H";
		subject.Date = "0aHEKg";
		subject.Time = "LOf8";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0aHEKg", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "hR33FS";
		subject.TypeOfConsistCode = "H";
		subject.DateTimeQualifier = "z9W";
		subject.Time = "LOf8";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LOf8", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "hR33FS";
		subject.TypeOfConsistCode = "H";
		subject.DateTimeQualifier = "z9W";
		subject.Date = "0aHEKg";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S45a", "2IrXiX", true)]
	[InlineData("S45a", "", false)]
	[InlineData("", "2IrXiX", true)]
	public void Validation_ARequiresBTime2(string time2, string date2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "hR33FS";
		subject.TypeOfConsistCode = "H";
		subject.DateTimeQualifier = "z9W";
		subject.Date = "0aHEKg";
		subject.Time = "LOf8";
		subject.Time2 = time2;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("si", "S45a", true)]
	[InlineData("si", "", false)]
	[InlineData("", "S45a", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time2, bool isValidExpected)
	{
		var subject = new BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentID();
		subject.StandardPointLocationCode = "hR33FS";
		subject.TypeOfConsistCode = "H";
		subject.DateTimeQualifier = "z9W";
		subject.Date = "0aHEKg";
		subject.Time = "LOf8";
		subject.TimeCode = timeCode;
		subject.Time2 = time2;
		if (time2 != "")
			subject.Date2 = "2IrXiX";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
