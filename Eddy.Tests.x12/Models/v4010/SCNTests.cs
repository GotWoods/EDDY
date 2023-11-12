using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SCNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCN*sS*B*5f*QZ*Y";

		var expected = new SCN_BeginningSegmentForCartageWorkAssignment()
		{
			StandardCarrierAlphaCode = "sS",
			ReferenceIdentification = "B",
			TransactionSetPurposeCode = "5f",
			ShipmentMethodOfPayment = "QZ",
			Amount = "Y",
		};

		var actual = Map.MapObject<SCN_BeginningSegmentForCartageWorkAssignment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sS", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.ReferenceIdentification = "B";
		subject.TransactionSetPurposeCode = "5f";
		subject.ShipmentMethodOfPayment = "QZ";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "sS";
		subject.TransactionSetPurposeCode = "5f";
		subject.ShipmentMethodOfPayment = "QZ";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5f", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "sS";
		subject.ReferenceIdentification = "B";
		subject.ShipmentMethodOfPayment = "QZ";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QZ", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "sS";
		subject.ReferenceIdentification = "B";
		subject.TransactionSetPurposeCode = "5f";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
