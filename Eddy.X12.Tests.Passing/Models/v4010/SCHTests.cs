using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCH*6*W4*dX*1*0KQ*5vZXukdL*lhVB*pJi*2d6xwqCM*clbc*H*w";

		var expected = new SCH_LineItemSchedule()
		{
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "W4",
			EntityIdentifierCode = "dX",
			Name = "1",
			DateTimeQualifier = "0KQ",
			Date = "5vZXukdL",
			Time = "lhVB",
			DateTimeQualifier2 = "pJi",
			Date2 = "2d6xwqCM",
			Time2 = "clbc",
			RequestReferenceNumber = "H",
			AssignedIdentification = "w",
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
		subject.UnitOrBasisForMeasurementCode = "W4";
		subject.DateTimeQualifier = "0KQ";
		subject.Date = "5vZXukdL";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "pJi";
			subject.Date2 = "2d6xwqCM";
			subject.Time2 = "clbc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W4", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.DateTimeQualifier = "0KQ";
		subject.Date = "5vZXukdL";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "pJi";
			subject.Date2 = "2d6xwqCM";
			subject.Time2 = "clbc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dX", "1", true)]
	[InlineData("dX", "", false)]
	[InlineData("", "1", true)]
	public void Validation_ARequiresBEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "W4";
		subject.DateTimeQualifier = "0KQ";
		subject.Date = "5vZXukdL";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "pJi";
			subject.Date2 = "2d6xwqCM";
			subject.Time2 = "clbc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0KQ", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "W4";
		subject.Date = "5vZXukdL";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "pJi";
			subject.Date2 = "2d6xwqCM";
			subject.Time2 = "clbc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5vZXukdL", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "W4";
		subject.DateTimeQualifier = "0KQ";
		//Test Parameters
		subject.Date = date;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "pJi";
			subject.Date2 = "2d6xwqCM";
			subject.Time2 = "clbc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("pJi", "2d6xwqCM", "clbc", true)]
	[InlineData("pJi", "", "", false)]
	[InlineData("", "2d6xwqCM", "clbc", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "W4";
		subject.DateTimeQualifier = "0KQ";
		subject.Date = "5vZXukdL";
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		subject.Time2 = time2;
		//A Requires B
		if (date2 != "")
			subject.DateTimeQualifier2 = "pJi";
		if (time2 != "")
			subject.DateTimeQualifier2 = "pJi";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2d6xwqCM", "pJi", true)]
	[InlineData("2d6xwqCM", "", false)]
	[InlineData("", "pJi", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "W4";
		subject.DateTimeQualifier = "0KQ";
		subject.Date = "5vZXukdL";
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "clbc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("clbc", "pJi", true)]
	[InlineData("clbc", "", false)]
	[InlineData("", "pJi", true)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "W4";
		subject.DateTimeQualifier = "0KQ";
		subject.Date = "5vZXukdL";
		//Test Parameters
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.Date2 = "2d6xwqCM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
