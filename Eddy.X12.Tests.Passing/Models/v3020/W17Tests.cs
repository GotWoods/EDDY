using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W17*B*yY9TOM*q*K*r*J*l7nR*P*266553";

		var expected = new W17_WarehouseReceiptIdentification()
		{
			ReportingCode = "B",
			DateOfReceipt = "yY9TOM",
			WarehouseReceiptNumber = "q",
			DepositorOrderNumber = "K",
			ShipmentIdentificationNumber = "r",
			TimeQualifier = "J",
			Time = "l7nR",
			MasterReferenceLinkNumber = "P",
			LinkSequenceNumber = 266553,
		};

		var actual = Map.MapObject<W17_WarehouseReceiptIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.DateOfReceipt = "yY9TOM";
		subject.WarehouseReceiptNumber = "q";
		subject.DepositorOrderNumber = "K";
		//Test Parameters
		subject.ReportingCode = reportingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "J";
			subject.Time = "l7nR";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "P";
			subject.LinkSequenceNumber = 266553;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yY9TOM", true)]
	public void Validation_RequiredDateOfReceipt(string dateOfReceipt, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "B";
		subject.WarehouseReceiptNumber = "q";
		subject.DepositorOrderNumber = "K";
		//Test Parameters
		subject.DateOfReceipt = dateOfReceipt;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "J";
			subject.Time = "l7nR";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "P";
			subject.LinkSequenceNumber = 266553;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredWarehouseReceiptNumber(string warehouseReceiptNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "B";
		subject.DateOfReceipt = "yY9TOM";
		subject.DepositorOrderNumber = "K";
		//Test Parameters
		subject.WarehouseReceiptNumber = warehouseReceiptNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "J";
			subject.Time = "l7nR";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "P";
			subject.LinkSequenceNumber = 266553;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredDepositorOrderNumber(string depositorOrderNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "B";
		subject.DateOfReceipt = "yY9TOM";
		subject.WarehouseReceiptNumber = "q";
		//Test Parameters
		subject.DepositorOrderNumber = depositorOrderNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "J";
			subject.Time = "l7nR";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "P";
			subject.LinkSequenceNumber = 266553;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "l7nR", true)]
	[InlineData("J", "", false)]
	[InlineData("", "l7nR", false)]
	public void Validation_AllAreRequiredTimeQualifier(string timeQualifier, string time, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "B";
		subject.DateOfReceipt = "yY9TOM";
		subject.WarehouseReceiptNumber = "q";
		subject.DepositorOrderNumber = "K";
		//Test Parameters
		subject.TimeQualifier = timeQualifier;
		subject.Time = time;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "P";
			subject.LinkSequenceNumber = 266553;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("P", 266553, true)]
	[InlineData("P", 0, false)]
	[InlineData("", 266553, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "B";
		subject.DateOfReceipt = "yY9TOM";
		subject.WarehouseReceiptNumber = "q";
		subject.DepositorOrderNumber = "K";
		//Test Parameters
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0) 
			subject.LinkSequenceNumber = linkSequenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "J";
			subject.Time = "l7nR";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
