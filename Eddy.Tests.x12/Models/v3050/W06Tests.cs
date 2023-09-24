using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class W06Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W06*N*p*Wrqnfw*L*f*H*o*175989*8Z*BR*PB*q";

		var expected = new W06_WarehouseShipmentIdentification()
		{
			ReportingCode = "N",
			DepositorOrderNumber = "p",
			Date = "Wrqnfw",
			ShipmentIdentificationNumber = "L",
			AgentShipmentIDNumber = "f",
			PurchaseOrderNumber = "H",
			MasterReferenceLinkNumber = "o",
			LinkSequenceNumber = 175989,
			SpecialHandlingCode = "8Z",
			ShippingDateChangeReasonCode = "BR",
			TransactionTypeCode = "PB",
			ActionCode = "q",
		};

		var actual = Map.MapObject<W06_WarehouseShipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		//Test Parameters
		subject.ReportingCode = reportingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "o";
			subject.LinkSequenceNumber = 175989;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("o", 175989, true)]
	[InlineData("o", 0, false)]
	[InlineData("", 175989, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		subject.ReportingCode = "N";
		//Test Parameters
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0) 
			subject.LinkSequenceNumber = linkSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
