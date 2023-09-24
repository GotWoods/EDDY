using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W17*P*v8Ymtw*t*h*k*l*lpyM*8*519152";

		var expected = new W17_WarehouseReceiptIdentification()
		{
			ReportingCode = "P",
			DateOfReceipt = "v8Ymtw",
			WarehouseReceiptNumber = "t",
			DepositorOrderNumber = "h",
			ShipmentIdentificationNumber = "k",
			TimeQualifier = "l",
			Time = "lpyM",
			MasterReferenceLinkNumber = "8",
			LinkSequenceNumber = 519152,
		};

		var actual = Map.MapObject<W17_WarehouseReceiptIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.DateOfReceipt = "v8Ymtw";
		subject.WarehouseReceiptNumber = "t";
		//Test Parameters
		subject.ReportingCode = reportingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "l";
			subject.Time = "lpyM";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "8";
			subject.LinkSequenceNumber = 519152;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v8Ymtw", true)]
	public void Validation_RequiredDateOfReceipt(string dateOfReceipt, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "P";
		subject.WarehouseReceiptNumber = "t";
		//Test Parameters
		subject.DateOfReceipt = dateOfReceipt;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "l";
			subject.Time = "lpyM";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "8";
			subject.LinkSequenceNumber = 519152;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredWarehouseReceiptNumber(string warehouseReceiptNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "P";
		subject.DateOfReceipt = "v8Ymtw";
		//Test Parameters
		subject.WarehouseReceiptNumber = warehouseReceiptNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "l";
			subject.Time = "lpyM";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "8";
			subject.LinkSequenceNumber = 519152;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "lpyM", true)]
	[InlineData("l", "", false)]
	[InlineData("", "lpyM", false)]
	public void Validation_AllAreRequiredTimeQualifier(string timeQualifier, string time, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "P";
		subject.DateOfReceipt = "v8Ymtw";
		subject.WarehouseReceiptNumber = "t";
		//Test Parameters
		subject.TimeQualifier = timeQualifier;
		subject.Time = time;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "8";
			subject.LinkSequenceNumber = 519152;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("8", 519152, true)]
	[InlineData("8", 0, false)]
	[InlineData("", 519152, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "P";
		subject.DateOfReceipt = "v8Ymtw";
		subject.WarehouseReceiptNumber = "t";
		//Test Parameters
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0) 
			subject.LinkSequenceNumber = linkSequenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "l";
			subject.Time = "lpyM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
