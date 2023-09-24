using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SCNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCN*kF*g*Uk*og*D";

		var expected = new SCN_BeginningSegmentForCartageWorkAssignment()
		{
			StandardCarrierAlphaCode = "kF",
			ReferenceIdentification = "g",
			TransactionSetPurposeCode = "Uk",
			ShipmentMethodOfPaymentCode = "og",
			Amount = "D",
		};

		var actual = Map.MapObject<SCN_BeginningSegmentForCartageWorkAssignment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kF", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		subject.ReferenceIdentification = "g";
		subject.TransactionSetPurposeCode = "Uk";
		subject.ShipmentMethodOfPaymentCode = "og";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		subject.StandardCarrierAlphaCode = "kF";
		subject.TransactionSetPurposeCode = "Uk";
		subject.ShipmentMethodOfPaymentCode = "og";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Uk", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		subject.StandardCarrierAlphaCode = "kF";
		subject.ReferenceIdentification = "g";
		subject.ShipmentMethodOfPaymentCode = "og";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("og", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		subject.StandardCarrierAlphaCode = "kF";
		subject.ReferenceIdentification = "g";
		subject.TransactionSetPurposeCode = "Uk";
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
