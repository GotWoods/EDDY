using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BRRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRR*eT*d9*kg*0I*A*r";

		var expected = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity()
		{
			TransactionSetPurposeCode = "eT",
			StandardCarrierAlphaCode = "d9",
			StandardCarrierAlphaCode2 = "kg",
			IdentificationCode = "0I",
			YesNoConditionOrResponseCode = "A",
			YesNoConditionOrResponseCode2 = "r",
		};

		var actual = Map.MapObject<BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eT", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity();
		subject.StandardCarrierAlphaCode = "d9";
		subject.StandardCarrierAlphaCode2 = "kg";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d9", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity();
		subject.TransactionSetPurposeCode = "eT";
		subject.StandardCarrierAlphaCode2 = "kg";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kg", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity();
		subject.TransactionSetPurposeCode = "eT";
		subject.StandardCarrierAlphaCode = "d9";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
