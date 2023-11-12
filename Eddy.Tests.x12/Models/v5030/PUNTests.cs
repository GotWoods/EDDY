using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PUNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PUN*se*55ySCIli*rc4Q*F*QFhe*lz";

		var expected = new PUN_BeginningSegmentForMotorCarrierPickupNotification()
		{
			StandardCarrierAlphaCode = "se",
			Date = "55ySCIli",
			Time = "rc4Q",
			ReferenceIdentification = "F",
			Time2 = "QFhe",
			TransactionSetPurposeCode = "lz",
		};

		var actual = Map.MapObject<PUN_BeginningSegmentForMotorCarrierPickupNotification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("se", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickupNotification();
		//Required fields
		subject.Date = "55ySCIli";
		subject.TransactionSetPurposeCode = "lz";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("55ySCIli", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickupNotification();
		//Required fields
		subject.StandardCarrierAlphaCode = "se";
		subject.TransactionSetPurposeCode = "lz";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lz", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickupNotification();
		//Required fields
		subject.StandardCarrierAlphaCode = "se";
		subject.Date = "55ySCIli";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
