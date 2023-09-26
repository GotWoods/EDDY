using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LFI*Ur6CTe*HEAAuqxf*eYlR*a*t*t*L*c";

		var expected = new LFI_BeginningSegmentForLocomotiveInformation()
		{
			StandardPointLocationCode = "Ur6CTe",
			Date = "HEAAuqxf",
			Time = "eYlR",
			EquipmentStatusCode = "a",
			IndustryCode = "t",
			IndustryCode2 = "t",
			IndustryCode3 = "L",
			InterchangeTrainIdentification = "c",
		};

		var actual = Map.MapObject<LFI_BeginningSegmentForLocomotiveInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ur6CTe", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		//Required fields
		subject.Date = "HEAAuqxf";
		subject.Time = "eYlR";
		subject.EquipmentStatusCode = "a";
		subject.IndustryCode = "t";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HEAAuqxf", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		//Required fields
		subject.StandardPointLocationCode = "Ur6CTe";
		subject.Time = "eYlR";
		subject.EquipmentStatusCode = "a";
		subject.IndustryCode = "t";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eYlR", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		//Required fields
		subject.StandardPointLocationCode = "Ur6CTe";
		subject.Date = "HEAAuqxf";
		subject.EquipmentStatusCode = "a";
		subject.IndustryCode = "t";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		//Required fields
		subject.StandardPointLocationCode = "Ur6CTe";
		subject.Date = "HEAAuqxf";
		subject.Time = "eYlR";
		subject.IndustryCode = "t";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new LFI_BeginningSegmentForLocomotiveInformation();
		//Required fields
		subject.StandardPointLocationCode = "Ur6CTe";
		subject.Date = "HEAAuqxf";
		subject.Time = "eYlR";
		subject.EquipmentStatusCode = "a";
		//Test Parameters
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
