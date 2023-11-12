using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class SCNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCN*Ut*t*yR*KT*s";

		var expected = new SCN_BeginningSegmentForCartageWorkAssignment()
		{
			StandardCarrierAlphaCode = "Ut",
			ReferenceIdentification = "t",
			TransactionSetPurposeCode = "yR",
			ShipmentMethodOfPayment = "KT",
			Amount = "s",
		};

		var actual = Map.MapObject<SCN_BeginningSegmentForCartageWorkAssignment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ut", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.ReferenceIdentification = "t";
		subject.TransactionSetPurposeCode = "yR";
		subject.ShipmentMethodOfPayment = "KT";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "Ut";
		subject.TransactionSetPurposeCode = "yR";
		subject.ShipmentMethodOfPayment = "KT";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yR", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "Ut";
		subject.ReferenceIdentification = "t";
		subject.ShipmentMethodOfPayment = "KT";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KT", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "Ut";
		subject.ReferenceIdentification = "t";
		subject.TransactionSetPurposeCode = "yR";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
