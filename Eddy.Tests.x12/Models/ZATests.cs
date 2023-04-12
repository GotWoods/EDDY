using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ZATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZA*9o*9*H4*3kb*agIQuUUY*mE*Y*y";

		var expected = new ZA_ProductActivityReporting()
		{
			ActivityCode = "9o",
			Quantity = 9,
			UnitOrBasisForMeasurementCode = "H4",
			DateTimeQualifier = "3kb",
			Date = "agIQuUUY",
			ReferenceIdentificationQualifier = "mE",
			ReferenceIdentification = "Y",
			YesNoConditionOrResponseCode = "y",
		};

		var actual = Map.MapObject<ZA_ProductActivityReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9o", true)]
	public void Validation_RequiredActivityCode(string activityCode, bool isValidExpected)
	{
		var subject = new ZA_ProductActivityReporting();
		subject.ActivityCode = activityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "H4", true)]
	[InlineData(0, "H4", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new ZA_ProductActivityReporting();
		subject.ActivityCode = "9o";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("3kb", "agIQuUUY", true)]
	[InlineData("", "agIQuUUY", false)]
	[InlineData("3kb", "", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new ZA_ProductActivityReporting();
		subject.ActivityCode = "9o";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("mE", "Y", true)]
	[InlineData("", "Y", false)]
	[InlineData("mE", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ZA_ProductActivityReporting();
		subject.ActivityCode = "9o";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
