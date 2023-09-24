using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PUNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PUN*ap*vieHe5Ex*Oamo*o*ZMvg*YW";

		var expected = new PUN_BeginningSegmentForMotorCarrierPickupNotification()
		{
			StandardCarrierAlphaCode = "ap",
			Date = "vieHe5Ex",
			Time = "Oamo",
			ReferenceIdentification = "o",
			Time2 = "ZMvg",
			TransactionSetPurposeCode = "YW",
		};

		var actual = Map.MapObject<PUN_BeginningSegmentForMotorCarrierPickupNotification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ap", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickupNotification();
		subject.Date = "vieHe5Ex";
		subject.TransactionSetPurposeCode = "YW";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vieHe5Ex", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickupNotification();
		subject.StandardCarrierAlphaCode = "ap";
		subject.TransactionSetPurposeCode = "YW";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YW", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickupNotification();
		subject.StandardCarrierAlphaCode = "ap";
		subject.Date = "vieHe5Ex";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
