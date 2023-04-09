using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BDD*q*Pz*b";

		var expected = new BDD_BeginningSegmentForShipmentDeliveryDiscrepancyInformation()
		{
			InvoiceNumber = "q",
			StandardCarrierAlphaCode = "Pz",
			ShipmentIdentificationNumber = "b",
		};

		var actual = Map.MapObject<BDD_BeginningSegmentForShipmentDeliveryDiscrepancyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validatation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BDD_BeginningSegmentForShipmentDeliveryDiscrepancyInformation();
		subject.StandardCarrierAlphaCode = "Pz";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pz", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BDD_BeginningSegmentForShipmentDeliveryDiscrepancyInformation();
		subject.InvoiceNumber = "q";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
