using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SCNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCN*lD*0*yJ*O6*n";

		var expected = new SCN_BeginningSegmentForCartageWorkAssignment()
		{
			StandardCarrierAlphaCode = "lD",
			ReferenceIdentification = "0",
			TransactionSetPurposeCode = "yJ",
			ShipmentMethodOfPayment = "O6",
			Amount = "n",
		};

		var actual = Map.MapObject<SCN_BeginningSegmentForCartageWorkAssignment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lD", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.TransactionSetPurposeCode = "yJ";
		subject.ShipmentMethodOfPayment = "O6";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "lD";
		subject.TransactionSetPurposeCode = "yJ";
		subject.ShipmentMethodOfPayment = "O6";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yJ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "lD";
		subject.ReferenceIdentification = "0";
		subject.ShipmentMethodOfPayment = "O6";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O6", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new SCN_BeginningSegmentForCartageWorkAssignment();
		//Required fields
		subject.StandardCarrierAlphaCode = "lD";
		subject.ReferenceIdentification = "0";
		subject.TransactionSetPurposeCode = "yJ";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
