using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCH*9*Nt*Fw*9*Z2Q*yxydmo*W0aI*VRL*aLcY9g*CesP*q*6";

		var expected = new SCH_LineItemSchedule()
		{
			Quantity = 9,
			UnitOrBasisForMeasurementCode = "Nt",
			EntityIdentifierCode = "Fw",
			Name = "9",
			DateTimeQualifier = "Z2Q",
			Date = "yxydmo",
			Time = "W0aI",
			DateTimeQualifier2 = "VRL",
			Date2 = "aLcY9g",
			Time2 = "CesP",
			RequestReferenceNumber = "q",
			AssignedIdentification = "6",
		};

		var actual = Map.MapObject<SCH_LineItemSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Nt";
		subject.DateTimeQualifier = "Z2Q";
		subject.Date = "yxydmo";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "VRL";
			subject.Date2 = "aLcY9g";
			subject.Time2 = "CesP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nt", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 9;
		subject.DateTimeQualifier = "Z2Q";
		subject.Date = "yxydmo";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "VRL";
			subject.Date2 = "aLcY9g";
			subject.Time2 = "CesP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fw", "9", true)]
	[InlineData("Fw", "", false)]
	[InlineData("", "9", true)]
	public void Validation_ARequiresBEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "Nt";
		subject.DateTimeQualifier = "Z2Q";
		subject.Date = "yxydmo";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "VRL";
			subject.Date2 = "aLcY9g";
			subject.Time2 = "CesP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z2Q", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "Nt";
		subject.Date = "yxydmo";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "VRL";
			subject.Date2 = "aLcY9g";
			subject.Time2 = "CesP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yxydmo", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "Nt";
		subject.DateTimeQualifier = "Z2Q";
		//Test Parameters
		subject.Date = date;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "VRL";
			subject.Date2 = "aLcY9g";
			subject.Time2 = "CesP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("VRL", "aLcY9g", "CesP", true)]
	[InlineData("VRL", "", "", false)]
	[InlineData("", "aLcY9g", "CesP", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "Nt";
		subject.DateTimeQualifier = "Z2Q";
		subject.Date = "yxydmo";
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		subject.Time2 = time2;
		//A Requires B
		if (date2 != "")
			subject.DateTimeQualifier2 = "VRL";
		if (time2 != "")
			subject.DateTimeQualifier2 = "VRL";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aLcY9g", "VRL", true)]
	[InlineData("aLcY9g", "", false)]
	[InlineData("", "VRL", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "Nt";
		subject.DateTimeQualifier = "Z2Q";
		subject.Date = "yxydmo";
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "CesP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CesP", "VRL", true)]
	[InlineData("CesP", "", false)]
	[InlineData("", "VRL", true)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "Nt";
		subject.DateTimeQualifier = "Z2Q";
		subject.Date = "yxydmo";
		//Test Parameters
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.Date2 = "aLcY9g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
