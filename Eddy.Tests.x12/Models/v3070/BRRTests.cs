using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BRRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRR*zx*ZV*uZ*C3";

		var expected = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity()
		{
			TransactionSetPurposeCode = "zx",
			StandardCarrierAlphaCode = "ZV",
			StandardCarrierAlphaCode2 = "uZ",
			IdentificationCode = "C3",
		};

		var actual = Map.MapObject<BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zx", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity();
		//Required fields
		subject.StandardCarrierAlphaCode = "ZV";
		subject.StandardCarrierAlphaCode2 = "uZ";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZV", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity();
		//Required fields
		subject.TransactionSetPurposeCode = "zx";
		subject.StandardCarrierAlphaCode2 = "uZ";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uZ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity();
		//Required fields
		subject.TransactionSetPurposeCode = "zx";
		subject.StandardCarrierAlphaCode = "ZV";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
