using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class B4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B4*i3*9*p*qaUSSugI*Cy57*Jxn*8*R*2*gXTt*Q*z*8";

		var expected = new B4_BeginningSegmentForInquiryOrReply()
		{
			SpecialHandlingCode = "i3",
			InquiryRequestNumber = 9,
			ShipmentStatusCode = "p",
			Date = "qaUSSugI",
			StatusTime = "Cy57",
			StatusLocation = "Jxn",
			EquipmentInitial = "8",
			EquipmentNumber = "R",
			EquipmentStatusCode = "2",
			EquipmentType = "gXTt",
			LocationIdentifier = "Q",
			LocationQualifier = "z",
			EquipmentNumberCheckDigit = 8,
		};

		var actual = Map.MapObject<B4_BeginningSegmentForInquiryOrReply>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "R", true)]
	[InlineData("8", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationQualifier))
		{
			subject.LocationIdentifier = "Q";
			subject.LocationQualifier = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "z", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "8";
			subject.EquipmentNumber = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
