using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CR6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR6*U*VGeVK8*hc*Z*g3nliJ*e*a*k*pS3pNC*qH*8*1QYa1l*N19qmg*8VOWfv*Os*q*T*shFkHk*I7DYD0*59tSCG*0GdXz2";

		var expected = new CR6_HomeHealthCareCertification()
		{
			PrognosisCode = "U",
			Date = "VGeVK8",
			DateTimePeriodFormatQualifier = "hc",
			DateTimePeriod = "Z",
			Date2 = "g3nliJ",
			YesNoConditionOrResponseCode = "e",
			YesNoConditionOrResponseCode2 = "a",
			CertificationTypeCode = "k",
			Date3 = "pS3pNC",
			ProductServiceIDQualifier = "qH",
			MedicalCodeValue = "8",
			Date4 = "1QYa1l",
			Date5 = "N19qmg",
			Date6 = "8VOWfv",
			DateTimePeriodFormatQualifier2 = "Os",
			DateTimePeriod2 = "q",
			PatientLocationCode = "T",
			Date7 = "shFkHk",
			Date8 = "I7DYD0",
			Date9 = "59tSCG",
			Date10 = "0GdXz2",
		};

		var actual = Map.MapObject<CR6_HomeHealthCareCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredPrognosisCode(string prognosisCode, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.Date = "VGeVK8";
		subject.YesNoConditionOrResponseCode2 = "a";
		subject.CertificationTypeCode = "k";
		//Test Parameters
		subject.PrognosisCode = prognosisCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "hc";
			subject.DateTimePeriod = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VGeVK8", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.PrognosisCode = "U";
		subject.YesNoConditionOrResponseCode2 = "a";
		subject.CertificationTypeCode = "k";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "hc";
			subject.DateTimePeriod = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hc", "Z", true)]
	[InlineData("hc", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.PrognosisCode = "U";
		subject.Date = "VGeVK8";
		subject.YesNoConditionOrResponseCode2 = "a";
		subject.CertificationTypeCode = "k";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.PrognosisCode = "U";
		subject.Date = "VGeVK8";
		subject.CertificationTypeCode = "k";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "hc";
			subject.DateTimePeriod = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredCertificationTypeCode(string certificationTypeCode, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.PrognosisCode = "U";
		subject.Date = "VGeVK8";
		subject.YesNoConditionOrResponseCode2 = "a";
		//Test Parameters
		subject.CertificationTypeCode = certificationTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "hc";
			subject.DateTimePeriod = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
