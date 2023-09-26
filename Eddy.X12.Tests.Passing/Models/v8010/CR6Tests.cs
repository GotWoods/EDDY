using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class CR6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR6*j*evEAqY30*gf*8*lDKPcZpg*q*M*V*3xwBT3KC*p4*H*Dk95OgG0*h1Wo1vVK*hJDiqN4r*7y*f*U*Y9tzmWtH*pKwJdINz*WJnhCjGC*MAJmJQyO";

		var expected = new CR6_HomeHealthCareCertification()
		{
			PrognosisCode = "j",
			Date = "evEAqY30",
			DateTimePeriodFormatQualifier = "gf",
			DateTimePeriod = "8",
			Date2 = "lDKPcZpg",
			YesNoConditionOrResponseCode = "q",
			YesNoConditionOrResponseCode2 = "M",
			CertificationTypeCode = "V",
			Date3 = "3xwBT3KC",
			ProductServiceIDQualifier = "p4",
			MedicalCodeValue = "H",
			Date4 = "Dk95OgG0",
			Date5 = "h1Wo1vVK",
			Date6 = "hJDiqN4r",
			DateTimePeriodFormatQualifier2 = "7y",
			DateTimePeriod2 = "f",
			PatientLocationCode = "U",
			Date7 = "Y9tzmWtH",
			Date8 = "pKwJdINz",
			Date9 = "WJnhCjGC",
			Date10 = "MAJmJQyO",
		};

		var actual = Map.MapObject<CR6_HomeHealthCareCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredPrognosisCode(string prognosisCode, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.Date = "evEAqY30";
		//Test Parameters
		subject.PrognosisCode = prognosisCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "gf";
			subject.DateTimePeriod = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("evEAqY30", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.PrognosisCode = "j";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "gf";
			subject.DateTimePeriod = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gf", "8", true)]
	[InlineData("gf", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.PrognosisCode = "j";
		subject.Date = "evEAqY30";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
