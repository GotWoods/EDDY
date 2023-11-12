using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BDDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BDD*R*XT*p";

		var expected = new BDD_BeginningSegmentForShipmentDeliveryDiscrepancyInformation()
		{
			InvoiceNumber = "R",
			StandardCarrierAlphaCode = "XT",
			ShipmentIdentificationNumber = "p",
		};

		var actual = Map.MapObject<BDD_BeginningSegmentForShipmentDeliveryDiscrepancyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new BDD_BeginningSegmentForShipmentDeliveryDiscrepancyInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "XT";
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XT", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BDD_BeginningSegmentForShipmentDeliveryDiscrepancyInformation();
		//Required fields
		subject.InvoiceNumber = "R";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
