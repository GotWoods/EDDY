using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class B4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B4*uW*4*o*7y5XsK0k*fSud*Arr*i*y*P*p4U6*V*H*8";

		var expected = new B4_BeginningSegmentForInquiryOrReply()
		{
			SpecialHandlingCode = "uW",
			InquiryRequestNumber = 4,
			ShipmentStatusCode = "o",
			Date = "7y5XsK0k",
			Time = "fSud",
			StatusLocation = "Arr",
			EquipmentInitial = "i",
			EquipmentNumber = "y",
			EquipmentStatusCode = "P",
			EquipmentType = "p4U6",
			LocationIdentifier = "V",
			LocationQualifier = "H",
			EquipmentNumberCheckDigit = 8,
		};

		var actual = Map.MapObject<B4_BeginningSegmentForInquiryOrReply>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "y", true)]
	[InlineData("i", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationQualifier))
		{
			subject.LocationIdentifier = "V";
			subject.LocationQualifier = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "H", true)]
	[InlineData("V", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "i";
			subject.EquipmentNumber = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
