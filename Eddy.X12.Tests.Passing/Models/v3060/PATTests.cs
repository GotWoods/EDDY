using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAT*zy*m*5u*h*UQ*W*rx*2";

		var expected = new PAT_PatientInformation()
		{
			IndividualRelationshipCode = "zy",
			PatientLocationCode = "m",
			EmploymentStatusCode = "5u",
			StudentStatusCode = "h",
			DateTimePeriodFormatQualifier = "UQ",
			DateTimePeriod = "W",
			UnitOrBasisForMeasurementCode = "rx",
			Weight = 2,
		};

		var actual = Map.MapObject<PAT_PatientInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("UQ", "W", true)]
	[InlineData("UQ", "", false)]
	[InlineData("", "W", false)]
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
			subject.UnitOrBasisForMeasurementCode = "rx";
			subject.Weight = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("rx", 2, true)]
	[InlineData("rx", 0, false)]
	[InlineData("", 2, false)]
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
			subject.DateTimePeriodFormatQualifier = "UQ";
			subject.DateTimePeriod = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
