using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class W17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W17*T*BWND0g*V*w*n*V*UbKK*5*744915";

		var expected = new W17_WarehouseReceiptIdentification()
		{
			ReportingCode = "T",
			Date = "BWND0g",
			WarehouseReceiptNumber = "V",
			DepositorOrderNumber = "w",
			ShipmentIdentificationNumber = "n",
			TimeQualifier = "V",
			Time = "UbKK",
			MasterReferenceLinkNumber = "5",
			LinkSequenceNumber = 744915,
		};

		var actual = Map.MapObject<W17_WarehouseReceiptIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.Date = "BWND0g";
		subject.WarehouseReceiptNumber = "V";
		//Test Parameters
		subject.ReportingCode = reportingCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "V";
			subject.Time = "UbKK";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "5";
			subject.LinkSequenceNumber = 744915;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BWND0g", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "T";
		subject.WarehouseReceiptNumber = "V";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "V";
			subject.Time = "UbKK";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "5";
			subject.LinkSequenceNumber = 744915;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredWarehouseReceiptNumber(string warehouseReceiptNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "T";
		subject.Date = "BWND0g";
		//Test Parameters
		subject.WarehouseReceiptNumber = warehouseReceiptNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "V";
			subject.Time = "UbKK";
		}
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "5";
			subject.LinkSequenceNumber = 744915;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "UbKK", true)]
	[InlineData("V", "", false)]
	[InlineData("", "UbKK", false)]
	public void Validation_AllAreRequiredTimeQualifier(string timeQualifier, string time, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "T";
		subject.Date = "BWND0g";
		subject.WarehouseReceiptNumber = "V";
		//Test Parameters
		subject.TimeQualifier = timeQualifier;
		subject.Time = time;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "5";
			subject.LinkSequenceNumber = 744915;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("5", 744915, true)]
	[InlineData("5", 0, false)]
	[InlineData("", 744915, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		//Required fields
		subject.ReportingCode = "T";
		subject.Date = "BWND0g";
		subject.WarehouseReceiptNumber = "V";
		//Test Parameters
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0) 
			subject.LinkSequenceNumber = linkSequenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "V";
			subject.Time = "UbKK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
