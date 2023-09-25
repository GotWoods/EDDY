using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W06Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W06*v*h*xdnCxo*j*I*L*P*199276*NC*xR*AD*B";

		var expected = new W06_WarehouseShipmentIdentification()
		{
			ReportingCode = "v",
			DepositorOrderNumber = "h",
			ShipmentDate = "xdnCxo",
			ShipmentIdentificationNumber = "j",
			AgentShipmentIDNumber = "I",
			PurchaseOrderNumber = "L",
			MasterReferenceLinkNumber = "P",
			LinkSequenceNumber = 199276,
			SpecialHandlingCode = "NC",
			ShippingDateChangeReasonCode = "xR",
			TransactionTypeCode = "AD",
			ActionCode = "B",
		};

		var actual = Map.MapObject<W06_WarehouseShipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		//Test Parameters
		subject.ReportingCode = reportingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "P";
			subject.LinkSequenceNumber = 199276;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("P", 199276, true)]
	[InlineData("P", 0, false)]
	[InlineData("", 199276, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		subject.ReportingCode = "v";
		//Test Parameters
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0) 
			subject.LinkSequenceNumber = linkSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
