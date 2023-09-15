using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class B4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B4*Ic*2*L*eNiPIyfi*qv8C*xX9*x*y*u*orNE*G*X*1";

		var expected = new B4_BeginningSegmentForInquiryOrReply()
		{
			SpecialHandlingCode = "Ic",
			InquiryRequestNumber = 2,
			ShipmentStatusCode = "L",
			Date = "eNiPIyfi",
			Time = "qv8C",
			StatusLocation = "xX9",
			EquipmentInitial = "x",
			EquipmentNumber = "y",
			EquipmentStatusCode = "u",
			EquipmentType = "orNE",
			LocationIdentifier = "G",
			LocationQualifier = "X",
			EquipmentNumberCheckDigit = 1,
		};

		var actual = Map.MapObject<B4_BeginningSegmentForInquiryOrReply>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "y", true)]
	[InlineData("x", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationQualifier))
		{
			subject.LocationIdentifier = "G";
			subject.LocationQualifier = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "X", true)]
	[InlineData("G", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "x";
			subject.EquipmentNumber = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
