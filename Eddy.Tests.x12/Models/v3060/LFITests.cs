using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LFI*9XZaat*FS84Om*gyLR*e*J*k*a*g";

		var expected = new LFI_BeginningSegmentForLocomotiveInformation()
		{
			StandardPointLocationCode = "9XZaat",
			Date = "FS84Om",
			Time = "gyLR",
			EquipmentStatusCode = "e",
			IndustryCode = "J",
			IndustryCode2 = "k",
			IndustryCode3 = "a",
			InterchangeTrainIdentification = "g",
		};

		var actual = Map.MapObject<LFI_BeginningSegmentForLocomotiveInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9XZaat", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		//Required fields
		subject.Date = "FS84Om";
		subject.Time = "gyLR";
		subject.EquipmentStatusCode = "e";
		subject.IndustryCode = "J";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FS84Om", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		//Required fields
		subject.StandardPointLocationCode = "9XZaat";
		subject.Time = "gyLR";
		subject.EquipmentStatusCode = "e";
		subject.IndustryCode = "J";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gyLR", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		//Required fields
		subject.StandardPointLocationCode = "9XZaat";
		subject.Date = "FS84Om";
		subject.EquipmentStatusCode = "e";
		subject.IndustryCode = "J";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		//Required fields
		subject.StandardPointLocationCode = "9XZaat";
		subject.Date = "FS84Om";
		subject.Time = "gyLR";
		subject.IndustryCode = "J";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		//Required fields
		subject.StandardPointLocationCode = "9XZaat";
		subject.Date = "FS84Om";
		subject.Time = "gyLR";
		subject.EquipmentStatusCode = "e";
		//Test Parameters
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
