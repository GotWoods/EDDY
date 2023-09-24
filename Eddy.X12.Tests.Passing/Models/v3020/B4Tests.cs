using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class B4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B4*EPu*9*C*WzpFR2*pr5J*TiD*m*S*BcxI*p*D";

		var expected = new B4_BeginningSegmentForInquiryOrReply()
		{
			TransactionSetIdentifierCode = "EPu",
			InquiryRequestNumber = 9,
			StatusCode = "C",
			StatusDate = "WzpFR2",
			StatusTime = "pr5J",
			StatusLocation = "TiD",
			EquipmentInitial = "m",
			EquipmentNumber = "S",
			EquipmentType = "BcxI",
			LocationIdentifier = "p",
			EquipmentStatusCode = "D",
		};

		var actual = Map.MapObject<B4_BeginningSegmentForInquiryOrReply>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "S", true)]
	[InlineData("m", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
