using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SCHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCH*2*Ek*sQ*X*rhn*8RPdgX*yEle*LG8*8a4mQI*mWy9*7*M";

		var expected = new SCH_LineItemSchedule()
		{
			Quantity = 2,
			UnitOrBasisForMeasurementCode = "Ek",
			EntityIdentifierCode = "sQ",
			Name = "X",
			DateTimeQualifier = "rhn",
			Date = "8RPdgX",
			Time = "yEle",
			DateTimeQualifier2 = "LG8",
			Date2 = "8a4mQI",
			Time2 = "mWy9",
			RequestReferenceNumber = "7",
			AssignedIdentification = "M",
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
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Ek";
		subject.DateTimeQualifier = "rhn";
		subject.Date = "8RPdgX";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "LG8";
			subject.Date2 = "8a4mQI";
			subject.Time2 = "mWy9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ek", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 2;
		subject.DateTimeQualifier = "rhn";
		subject.Date = "8RPdgX";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "LG8";
			subject.Date2 = "8a4mQI";
			subject.Time2 = "mWy9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sQ", "X", true)]
	[InlineData("sQ", "", false)]
	[InlineData("", "X", true)]
	public void Validation_ARequiresBEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "Ek";
		subject.DateTimeQualifier = "rhn";
		subject.Date = "8RPdgX";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "LG8";
			subject.Date2 = "8a4mQI";
			subject.Time2 = "mWy9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rhn", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "Ek";
		subject.Date = "8RPdgX";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "LG8";
			subject.Date2 = "8a4mQI";
			subject.Time2 = "mWy9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8RPdgX", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "Ek";
		subject.DateTimeQualifier = "rhn";
		//Test Parameters
		subject.Date = date;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "LG8";
			subject.Date2 = "8a4mQI";
			subject.Time2 = "mWy9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("LG8", "8a4mQI", "mWy9", true)]
	[InlineData("LG8", "", "", false)]
	[InlineData("", "8a4mQI", "mWy9", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "Ek";
		subject.DateTimeQualifier = "rhn";
		subject.Date = "8RPdgX";
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		subject.Time2 = time2;
		//A Requires B
		if (date2 != "")
			subject.DateTimeQualifier2 = "LG8";
		if (time2 != "")
			subject.DateTimeQualifier2 = "LG8";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8a4mQI", "LG8", true)]
	[InlineData("8a4mQI", "", false)]
	[InlineData("", "LG8", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "Ek";
		subject.DateTimeQualifier = "rhn";
		subject.Date = "8RPdgX";
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "mWy9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mWy9", "LG8", true)]
	[InlineData("mWy9", "", false)]
	[InlineData("", "LG8", true)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new SCH_LineItemSchedule();
		//Required fields
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "Ek";
		subject.DateTimeQualifier = "rhn";
		subject.Date = "8RPdgX";
		//Test Parameters
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.Date2 = "8a4mQI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
