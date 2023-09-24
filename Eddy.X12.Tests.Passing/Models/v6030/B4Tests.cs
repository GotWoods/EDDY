using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class B4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B4*vs*1*T*F7rUAAOZ*9h6Q*GEn*P*2*2*1VAz*4*M*5";

		var expected = new B4_BeginningSegmentForInquiryOrReply()
		{
			SpecialHandlingCode = "vs",
			InquiryRequestNumber = 1,
			ShipmentStatusCode = "T",
			Date = "F7rUAAOZ",
			Time = "9h6Q",
			StatusLocation = "GEn",
			EquipmentInitial = "P",
			EquipmentNumber = "2",
			EquipmentStatusCode = "2",
			EquipmentTypeCode = "1VAz",
			LocationIdentifier = "4",
			LocationQualifier = "M",
			EquipmentNumberCheckDigit = 5,
		};

		var actual = Map.MapObject<B4_BeginningSegmentForInquiryOrReply>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "2", true)]
	[InlineData("P", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationQualifier))
		{
			subject.LocationIdentifier = "4";
			subject.LocationQualifier = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "M", true)]
	[InlineData("4", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "P";
			subject.EquipmentNumber = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
