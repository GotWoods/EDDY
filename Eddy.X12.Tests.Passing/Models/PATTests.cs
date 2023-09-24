using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAT*Gq*E*vj*f*Zv*p*6u*3*E";

		var expected = new PAT_PatientInformation()
		{
			IndividualRelationshipCode = "Gq",
			PatientLocationCode = "E",
			EmploymentStatusCode = "vj",
			StudentStatusCode = "f",
			DateTimePeriodFormatQualifier = "Zv",
			DateTimePeriod = "p",
			UnitOrBasisForMeasurementCode = "6u",
			Weight = 3,
			YesNoConditionOrResponseCode = "E",
		};

		var actual = Map.MapObject<PAT_PatientInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Zv", "p", true)]
	[InlineData("", "p", false)]
	[InlineData("Zv", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PAT_PatientInformation();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("6u", 3, true)]
	[InlineData("", 3, false)]
	[InlineData("6u", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal weight, bool isValidExpected)
	{
		var subject = new PAT_PatientInformation();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (weight > 0)
		subject.Weight = weight;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
