using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W06Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W06*q*9*UI1J2G*F*C*i*E*261442*SB*hy";

		var expected = new W06_WarehouseShipmentIdentification()
		{
			ReportingCode = "q",
			DepositorOrderNumber = "9",
			ShipmentDate = "UI1J2G",
			ShipmentIdentificationNumber = "F",
			AgentShipmentIDNumber = "C",
			PurchaseOrderNumber = "i",
			MasterReferenceLinkNumber = "E",
			LinkSequenceNumber = 261442,
			SpecialHandlingCode = "SB",
			ShippingDateChangeReasonCode = "hy",
		};

		var actual = Map.MapObject<W06_WarehouseShipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		subject.DepositorOrderNumber = "9";
		subject.ShipmentDate = "UI1J2G";
		//Test Parameters
		subject.ReportingCode = reportingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredDepositorOrderNumber(string depositorOrderNumber, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		subject.ReportingCode = "q";
		subject.ShipmentDate = "UI1J2G";
		//Test Parameters
		subject.DepositorOrderNumber = depositorOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UI1J2G", true)]
	public void Validation_RequiredShipmentDate(string shipmentDate, bool isValidExpected)
	{
		var subject = new W06_WarehouseShipmentIdentification();
		//Required fields
		subject.ReportingCode = "q";
		subject.DepositorOrderNumber = "9";
		//Test Parameters
		subject.ShipmentDate = shipmentDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
