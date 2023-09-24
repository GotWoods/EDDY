using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class W17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W17*Z*5V7N4P*o*X*Y*R*ap9m*D*412872";

		var expected = new W17_WarehouseReceiptIdentification()
		{
			ReportingCode = "Z",
			DateOfReceipt = "5V7N4P",
			WarehouseReceiptNumber = "o",
			DepositorOrderNumber = "X",
			ShipmentIdentificationNumber = "Y",
			TimeQualifier = "R",
			Time = "ap9m",
			MasterReferenceLinkNumber = "D",
			LinkSequenceNumber = 412872,
		};

		var actual = Map.MapObject<W17_WarehouseReceiptIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.DateOfReceipt = "5V7N4P";
		subject.WarehouseReceiptNumber = "o";
		//Test Parameters
		subject.ReportingCode = reportingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "R";
			subject.Time = "ap9m";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "D";
			subject.LinkSequenceNumber = 412872;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5V7N4P", true)]
	public void Validation_RequiredDateOfReceipt(string dateOfReceipt, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "Z";
		subject.WarehouseReceiptNumber = "o";
		//Test Parameters
		subject.DateOfReceipt = dateOfReceipt;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "R";
			subject.Time = "ap9m";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "D";
			subject.LinkSequenceNumber = 412872;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredWarehouseReceiptNumber(string warehouseReceiptNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "Z";
		subject.DateOfReceipt = "5V7N4P";
		//Test Parameters
		subject.WarehouseReceiptNumber = warehouseReceiptNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "R";
			subject.Time = "ap9m";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "D";
			subject.LinkSequenceNumber = 412872;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "ap9m", true)]
	[InlineData("R", "", false)]
	[InlineData("", "ap9m", false)]
	public void Validation_AllAreRequiredTimeQualifier(string timeQualifier, string time, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "Z";
		subject.DateOfReceipt = "5V7N4P";
		subject.WarehouseReceiptNumber = "o";
		//Test Parameters
		subject.TimeQualifier = timeQualifier;
		subject.Time = time;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "D";
			subject.LinkSequenceNumber = 412872;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("D", 412872, true)]
	[InlineData("D", 0, false)]
	[InlineData("", 412872, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "Z";
		subject.DateOfReceipt = "5V7N4P";
		subject.WarehouseReceiptNumber = "o";
		//Test Parameters
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0) 
			subject.LinkSequenceNumber = linkSequenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "R";
			subject.Time = "ap9m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
