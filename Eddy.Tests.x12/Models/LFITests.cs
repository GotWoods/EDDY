using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LFI*PkVx60*opUnVJn9*UtRu*J*o*5*0*2";

		var expected = new LFI_BeginningSegmentForLocomotiveInformation()
		{
			StandardPointLocationCode = "PkVx60",
			Date = "opUnVJn9",
			Time = "UtRu",
			EquipmentStatusCode = "J",
			IndustryCode = "o",
			IndustryCode2 = "5",
			IndustryCode3 = "0",
			InterchangeTrainIdentification = "2",
		};

		var actual = Map.MapObject<LFI_BeginningSegmentForLocomotiveInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PkVx60", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		subject.Date = "opUnVJn9";
		subject.Time = "UtRu";
		subject.EquipmentStatusCode = "J";
		subject.IndustryCode = "o";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("opUnVJn9", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		subject.StandardPointLocationCode = "PkVx60";
		subject.Time = "UtRu";
		subject.EquipmentStatusCode = "J";
		subject.IndustryCode = "o";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UtRu", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		subject.StandardPointLocationCode = "PkVx60";
		subject.Date = "opUnVJn9";
		subject.EquipmentStatusCode = "J";
		subject.IndustryCode = "o";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		subject.StandardPointLocationCode = "PkVx60";
		subject.Date = "opUnVJn9";
		subject.Time = "UtRu";
		subject.IndustryCode = "o";
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		subject.StandardPointLocationCode = "PkVx60";
		subject.Date = "opUnVJn9";
		subject.Time = "UtRu";
		subject.EquipmentStatusCode = "J";
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
