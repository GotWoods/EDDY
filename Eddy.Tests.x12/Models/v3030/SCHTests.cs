using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCH*1*RV*qS*4*YZR*JEiWvD*NB8r*w9v*NWskss*DFzy*k";

		var expected = new SCH_LineItemSchedule()
		{
			Quantity = 1,
			UnitOrBasisForMeasurementCode = "RV",
			EntityIdentifierCode = "qS",
			Name = "4",
			DateTimeQualifier = "YZR",
			Date = "JEiWvD",
			Time = "NB8r",
			DateTimeQualifier2 = "w9v",
			Date2 = "NWskss",
			Time2 = "DFzy",
			RequestReferenceNumber = "k",
		};

		var actual = Map.MapObject<SCH_LineItemSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "RV";
		subject.DateTimeQualifier = "YZR";
		subject.Date = "JEiWvD";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RV", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 1;
		subject.DateTimeQualifier = "YZR";
		subject.Date = "JEiWvD";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qS", "4", true)]
	[InlineData("qS", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 1;
		subject.UnitOrBasisForMeasurementCode = "RV";
		subject.DateTimeQualifier = "YZR";
		subject.Date = "JEiWvD";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YZR", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 1;
		subject.UnitOrBasisForMeasurementCode = "RV";
		subject.Date = "JEiWvD";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JEiWvD", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 1;
		subject.UnitOrBasisForMeasurementCode = "RV";
		subject.DateTimeQualifier = "YZR";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NWskss", "w9v", true)]
	[InlineData("NWskss", "", false)]
	[InlineData("", "w9v", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 1;
		subject.UnitOrBasisForMeasurementCode = "RV";
		subject.DateTimeQualifier = "YZR";
		subject.Date = "JEiWvD";
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
