using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCH*2*e9*FG*6*H1L*dgrH3HUH*xkkk*isD*nOXxkAMU*XyIh*D*L";

		var expected = new SCH_LineItemSchedule()
		{
			Quantity = 2,
			UnitOrBasisForMeasurementCode = "e9",
			EntityIdentifierCode = "FG",
			Name = "6",
			DateTimeQualifier = "H1L",
			Date = "dgrH3HUH",
			Time = "xkkk",
			DateTimeQualifier2 = "isD",
			Date2 = "nOXxkAMU",
			Time2 = "XyIh",
			RequestReferenceNumber = "D",
			AssignedIdentification = "L",
		};

		var actual = Map.MapObject<SCH_LineItemSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.DateTimeQualifier = "H1L";
		subject.Date = "dgrH3HUH";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e9", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		subject.Quantity = 2;
		subject.DateTimeQualifier = "H1L";
		subject.Date = "dgrH3HUH";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "6", true)]
	[InlineData("FG", "", false)]
	public void Validation_ARequiresBEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.DateTimeQualifier = "H1L";
		subject.Date = "dgrH3HUH";
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H1L", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.Date = "dgrH3HUH";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dgrH3HUH", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.DateTimeQualifier = "H1L";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("isD", "nOXxkAMU", "", true)]
	[InlineData("", "nOXxkAMU", "", true)]
	[InlineData("isD", "", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.DateTimeQualifier = "H1L";
		subject.Date = "dgrH3HUH";
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		subject.Time2 = time2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "isD", true)]
	[InlineData("nOXxkAMU", "", false)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.DateTimeQualifier = "H1L";
		subject.Date = "dgrH3HUH";
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "isD", true)]
	[InlineData("XyIh", "", false)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "e9";
		subject.DateTimeQualifier = "H1L";
		subject.Date = "dgrH3HUH";
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
