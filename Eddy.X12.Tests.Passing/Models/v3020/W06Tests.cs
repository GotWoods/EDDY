using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W06Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W06*a*3*20ulFv*z*K*B*T*371518*xi*co";

		var expected = new W06_WarehouseShipmentIdentification()
		{
			ReportingCode = "a",
			DepositorOrderNumber = "3",
			ShipmentDate = "20ulFv",
			ShipmentIdentificationNumber = "z",
			AgentShipmentIDNumber = "K",
			PurchaseOrderNumber = "B",
			MasterReferenceLinkNumber = "T",
			LinkSequenceNumber = 371518,
			SpecialHandlingCode = "xi",
			ShippingDateChangeReasonCode = "co",
		};

		var actual = Map.MapObject<W06_WarehouseShipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		subject.DepositorOrderNumber = "3";
		subject.ShipmentDate = "20ulFv";
		//Test Parameters
		subject.ReportingCode = reportingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "T";
			subject.LinkSequenceNumber = 371518;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredDepositorOrderNumber(string depositorOrderNumber, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		subject.ReportingCode = "a";
		subject.ShipmentDate = "20ulFv";
		//Test Parameters
		subject.DepositorOrderNumber = depositorOrderNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "T";
			subject.LinkSequenceNumber = 371518;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("20ulFv", true)]
	public void Validation_RequiredShipmentDate(string shipmentDate, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		subject.ReportingCode = "a";
		subject.DepositorOrderNumber = "3";
		//Test Parameters
		subject.ShipmentDate = shipmentDate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "T";
			subject.LinkSequenceNumber = 371518;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("T", 371518, true)]
	[InlineData("T", 0, false)]
	[InlineData("", 371518, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		subject.ReportingCode = "a";
		subject.DepositorOrderNumber = "3";
		subject.ShipmentDate = "20ulFv";
		//Test Parameters
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0) 
			subject.LinkSequenceNumber = linkSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
