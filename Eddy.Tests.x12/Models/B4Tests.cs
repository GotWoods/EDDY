using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class B4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B4*RM*4*6*VVI2Mt0f*FA73*lUx*k*Y*N*EqVQ*e*o*8";

		var expected = new B4_BeginningSegmentForInquiryOrReply()
		{
			SpecialHandlingCode = "RM",
			InquiryRequestNumber = 4,
			ShipmentStatusCode = "6",
			Date = "VVI2Mt0f",
			Time = "FA73",
			StatusLocation = "lUx",
			EquipmentInitial = "k",
			EquipmentNumber = "Y",
			EquipmentStatusCode = "N",
			EquipmentTypeCode = "EqVQ",
			LocationIdentifier = "e",
			LocationQualifier = "o",
			EquipmentNumberCheckDigit = 8,
		};

		var actual = Map.MapObject<B4_BeginningSegmentForInquiryOrReply>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("k", "Y", true)]
	[InlineData("", "Y", false)]
	[InlineData("k", "", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("e", "o", true)]
	[InlineData("", "o", false)]
	[InlineData("e", "", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
