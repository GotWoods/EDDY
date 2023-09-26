using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BRRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRR*Cm*Dw*ko*gU*J*e";

		var expected = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity()
		{
			TransactionSetPurposeCode = "Cm",
			StandardCarrierAlphaCode = "Dw",
			StandardCarrierAlphaCode2 = "ko",
			IdentificationCode = "gU",
			YesNoConditionOrResponseCode = "J",
			YesNoConditionOrResponseCode2 = "e",
		};

		var actual = Map.MapObject<BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cm", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity();
		//Required fields
		subject.StandardCarrierAlphaCode = "Dw";
		subject.StandardCarrierAlphaCode2 = "ko";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dw", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity();
		//Required fields
		subject.TransactionSetPurposeCode = "Cm";
		subject.StandardCarrierAlphaCode2 = "ko";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ko", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity();
		//Required fields
		subject.TransactionSetPurposeCode = "Cm";
		subject.StandardCarrierAlphaCode = "Dw";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
