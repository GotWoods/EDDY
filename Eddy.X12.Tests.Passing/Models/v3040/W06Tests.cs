using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class W06Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W06*p*R*exS58G*z*j*G*k*226255*k4*pP*PS*e";

		var expected = new W06_WarehouseShipmentIdentification()
		{
			ReportingCode = "p",
			DepositorOrderNumber = "R",
			ShipmentDate = "exS58G",
			ShipmentIdentificationNumber = "z",
			AgentShipmentIDNumber = "j",
			PurchaseOrderNumber = "G",
			MasterReferenceLinkNumber = "k",
			LinkSequenceNumber = 226255,
			SpecialHandlingCode = "k4",
			ShippingDateChangeReasonCode = "pP",
			TransactionTypeCode = "PS",
			ActionCode = "e",
		};

		var actual = Map.MapObject<W06_WarehouseShipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		//Test Parameters
		subject.ReportingCode = reportingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "k";
			subject.LinkSequenceNumber = 226255;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("k", 226255, true)]
	[InlineData("k", 0, false)]
	[InlineData("", 226255, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		subject.ReportingCode = "p";
		//Test Parameters
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0) 
			subject.LinkSequenceNumber = linkSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
