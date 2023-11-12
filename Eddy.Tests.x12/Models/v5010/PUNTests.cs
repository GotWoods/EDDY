using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class PUNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PUN*oN*iWrOXYDb*boZM*g*b6sH*Kg";

		var expected = new PUN_BeginningSegmentForMotorCarrierPickupNotification()
		{
			StandardCarrierAlphaCode = "oN",
			Date = "iWrOXYDb",
			Time = "boZM",
			ReferenceIdentification = "g",
			Time2 = "b6sH",
			TransactionSetPurposeCode = "Kg",
		};

		var actual = Map.MapObject<PUN_BeginningSegmentForMotorCarrierPickupNotification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oN", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickupNotification();
		//Required fields
		subject.Date = "iWrOXYDb";
		subject.TransactionSetPurposeCode = "Kg";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iWrOXYDb", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickupNotification();
		//Required fields
		subject.StandardCarrierAlphaCode = "oN";
		subject.TransactionSetPurposeCode = "Kg";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kg", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickupNotification();
		//Required fields
		subject.StandardCarrierAlphaCode = "oN";
		subject.Date = "iWrOXYDb";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
