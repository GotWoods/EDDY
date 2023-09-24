using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W17*z*meIjZt*1*D*Q*B*bn2J*G*271523";

		var expected = new W17_WarehouseReceiptIdentification()
		{
			ReportingCode = "z",
			DateOfReceipt = "meIjZt",
			WarehouseReceiptNumber = "1",
			DepositorOrderNumber = "D",
			ShipmentIdentificationNumber = "Q",
			TimeQualifier = "B",
			Time = "bn2J",
			MasterReferenceLinkNumber = "G",
			LinkSequenceNumber = 271523,
		};

		var actual = Map.MapObject<W17_WarehouseReceiptIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.DateOfReceipt = "meIjZt";
		subject.WarehouseReceiptNumber = "1";
		subject.DepositorOrderNumber = "D";
		//Test Parameters
		subject.ReportingCode = reportingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("meIjZt", true)]
	public void Validation_RequiredDateOfReceipt(string dateOfReceipt, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "z";
		subject.WarehouseReceiptNumber = "1";
		subject.DepositorOrderNumber = "D";
		//Test Parameters
		subject.DateOfReceipt = dateOfReceipt;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredWarehouseReceiptNumber(string warehouseReceiptNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "z";
		subject.DateOfReceipt = "meIjZt";
		subject.DepositorOrderNumber = "D";
		//Test Parameters
		subject.WarehouseReceiptNumber = warehouseReceiptNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredDepositorOrderNumber(string depositorOrderNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "z";
		subject.DateOfReceipt = "meIjZt";
		subject.WarehouseReceiptNumber = "1";
		//Test Parameters
		subject.DepositorOrderNumber = depositorOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
