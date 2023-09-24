using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W06Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W06*0*q*QO3eNpeA*N*4*m*r*867321*Qi*cA*NB*o";

		var expected = new W06_WarehouseShipmentIdentification()
		{
			ReportingCode = "0",
			DepositorOrderNumber = "q",
			Date = "QO3eNpeA",
			ShipmentIdentificationNumber = "N",
			AgentShipmentIDNumber = "4",
			PurchaseOrderNumber = "m",
			MasterReferenceLinkNumber = "r",
			LinkSequenceNumber = 867321,
			SpecialHandlingCode = "Qi",
			ShippingDateChangeReasonCode = "cA",
			TransactionTypeCode = "NB",
			ActionCode = "o",
		};

		var actual = Map.MapObject<W06_WarehouseShipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		subject.ReportingCode = reportingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("r", 867321, true)]
	[InlineData("", 867321, false)]
	[InlineData("r", 0, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		subject.ReportingCode = "0";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0)
		subject.LinkSequenceNumber = linkSequenceNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
