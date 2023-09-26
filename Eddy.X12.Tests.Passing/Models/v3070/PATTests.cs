using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAT*4a*2*d6*D*lO*1*gR*6*3";

		var expected = new PAT_PatientInformation()
		{
			IndividualRelationshipCode = "4a",
			PatientLocationCode = "2",
			EmploymentStatusCode = "d6",
			StudentStatusCode = "D",
			DateTimePeriodFormatQualifier = "lO",
			DateTimePeriod = "1",
			UnitOrBasisForMeasurementCode = "gR",
			Weight = 6,
			YesNoConditionOrResponseCode = "3",
		};

		var actual = Map.MapObject<PAT_PatientInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lO", "1", true)]
	[InlineData("lO", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PAT_PatientInformation();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Weight > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "gR";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("gR", 6, true)]
	[InlineData("gR", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal weight, bool isValidExpected)
	{
		var subject = new PAT_PatientInformation();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "lO";
			subject.DateTimePeriod = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
