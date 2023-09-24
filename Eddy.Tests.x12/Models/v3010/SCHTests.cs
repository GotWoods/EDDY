using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCH*5*5W*tR*z*3Mk*d5PIi0*tC9K*VFu*n1tvy2*JEuW";

		var expected = new SCH_LineItemSchedule()
		{
			Quantity = 5,
			UnitOfMeasurementCode = "5W",
			EntityIdentifierCode = "tR",
			Name = "z",
			DateTimeQualifier = "3Mk",
			Date = "d5PIi0",
			Time = "tC9K",
			DateTimeQualifier2 = "VFu",
			Date2 = "n1tvy2",
			Time2 = "JEuW",
		};

		var actual = Map.MapObject<SCH_LineItemSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.UnitOfMeasurementCode = "5W";
		subject.DateTimeQualifier = "3Mk";
		subject.Date = "d5PIi0";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5W", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 5;
		subject.DateTimeQualifier = "3Mk";
		subject.Date = "d5PIi0";
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3Mk", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "5W";
		subject.Date = "d5PIi0";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d5PIi0", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "5W";
		subject.DateTimeQualifier = "3Mk";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
