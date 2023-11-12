using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class SCNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCN*rF*j*sb*Y7*N";

		var expected = new SCN_BeginningSegmentForCartageWorkAssignment()
		{
			StandardCarrierAlphaCode = "rF",
			ReferenceIdentification = "j",
			TransactionSetPurposeCode = "sb",
			ShipmentMethodOfPaymentCode = "Y7",
			Amount = "N",
		};

		var actual = Map.MapObject<SCN_BeginningSegmentForCartageWorkAssignment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rF", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.ReferenceIdentification = "j";
		subject.TransactionSetPurposeCode = "sb";
		subject.ShipmentMethodOfPaymentCode = "Y7";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "rF";
		subject.TransactionSetPurposeCode = "sb";
		subject.ShipmentMethodOfPaymentCode = "Y7";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sb", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "rF";
		subject.ReferenceIdentification = "j";
		subject.ShipmentMethodOfPaymentCode = "Y7";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y7", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "rF";
		subject.ReferenceIdentification = "j";
		subject.TransactionSetPurposeCode = "sb";
		//Test Parameters
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
