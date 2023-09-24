using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class B4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B4*cKh*5*i*5YWaoE*5wML*kLo*G*g*m*Ev3B*E";

		var expected = new B4_BeginningSegmentForInquiryOrReply()
		{
			TransactionSetIdentifierCode = "cKh",
			InquiryRequestNumber = 5,
			StatusCode = "i",
			StatusDate = "5YWaoE",
			StatusTime = "5wML",
			StatusLocation = "kLo",
			EquipmentInitial = "G",
			EquipmentNumber = "g",
			EquipmentStatusCode = "m",
			EquipmentType = "Ev3B",
			LocationIdentifier = "E",
		};

		var actual = Map.MapObject<B4_BeginningSegmentForInquiryOrReply>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "g", true)]
	[InlineData("G", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new B4_BeginningSegmentForInquiryOrReply();
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
