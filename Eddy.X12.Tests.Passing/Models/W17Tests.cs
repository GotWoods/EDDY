using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W17*7*XHoeV8Jo*1*u*V*a*pGEE*5*671681";

		var expected = new W17_WarehouseReceiptIdentification()
		{
			ReportingCode = "7",
			Date = "XHoeV8Jo",
			WarehouseReceiptNumber = "1",
			DepositorOrderNumber = "u",
			ShipmentIdentificationNumber = "V",
			TimeQualifier = "a",
			Time = "pGEE",
			MasterReferenceLinkNumber = "5",
			LinkSequenceNumber = 671681,
		};

		var actual = Map.MapObject<W17_WarehouseReceiptIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredReportingCode(string reportingCode, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		subject.Date = "XHoeV8Jo";
		subject.WarehouseReceiptNumber = "1";
		subject.ReportingCode = reportingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XHoeV8Jo", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		subject.ReportingCode = "7";
		subject.WarehouseReceiptNumber = "1";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredWarehouseReceiptNumber(string warehouseReceiptNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		subject.ReportingCode = "7";
		subject.Date = "XHoeV8Jo";
		subject.WarehouseReceiptNumber = warehouseReceiptNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("a", "pGEE", true)]
	[InlineData("", "pGEE", false)]
	[InlineData("a", "", false)]
	public void Validation_AllAreRequiredTimeQualifier(string timeQualifier, string time, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		subject.ReportingCode = "7";
		subject.Date = "XHoeV8Jo";
		subject.WarehouseReceiptNumber = "1";
		subject.TimeQualifier = timeQualifier;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("5", 671681, true)]
	[InlineData("", 671681, false)]
	[InlineData("5", 0, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new W17_WarehouseReceiptIdentification();
		subject.ReportingCode = "7";
		subject.Date = "XHoeV8Jo";
		subject.WarehouseReceiptNumber = "1";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0)
		subject.LinkSequenceNumber = linkSequenceNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
