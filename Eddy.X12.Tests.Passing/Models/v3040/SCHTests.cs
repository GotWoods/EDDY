using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCH*6*3z*nf*3*qKR*jGYUTF*dEaI*YNh*mn8jkH*1Xbo*e*4";

		var expected = new SCH_LineItemSchedule()
		{
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "3z",
			EntityIdentifierCode = "nf",
			Name = "3",
			DateTimeQualifier = "qKR",
			Date = "jGYUTF",
			Time = "dEaI",
			DateTimeQualifier2 = "YNh",
			Date2 = "mn8jkH",
			Time2 = "1Xbo",
			RequestReferenceNumber = "e",
			AssignedIdentification = "4",
		};

		var actual = Map.MapObject<SCH_LineItemSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "3z";
		subject.DateTimeQualifier = "qKR";
		subject.Date = "jGYUTF";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3z", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.DateTimeQualifier = "qKR";
		subject.Date = "jGYUTF";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nf", "3", true)]
	[InlineData("nf", "", false)]
	[InlineData("", "3", true)]
	public void Validation_ARequiresBEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "3z";
		subject.DateTimeQualifier = "qKR";
		subject.Date = "jGYUTF";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qKR", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "3z";
		subject.Date = "jGYUTF";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jGYUTF", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "3z";
		subject.DateTimeQualifier = "qKR";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mn8jkH", "YNh", true)]
	[InlineData("mn8jkH", "", false)]
	[InlineData("", "YNh", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "3z";
		subject.DateTimeQualifier = "qKR";
		subject.Date = "jGYUTF";
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
