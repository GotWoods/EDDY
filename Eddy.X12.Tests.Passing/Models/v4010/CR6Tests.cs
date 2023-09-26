using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CR6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR6*A*iBp38uzo*Kw*4*AlNfLPFD*Q*f*V*Q4HCvXO4*od*w*UXyqOneR*0OeykAvY*GJ5PBmP6*WY*B*B*OPmFHSA5*oAKdlczt*kIyO1Y1S*RGt7gfgQ";

		var expected = new CR6_HomeHealthCareCertification()
		{
			PrognosisCode = "A",
			Date = "iBp38uzo",
			DateTimePeriodFormatQualifier = "Kw",
			DateTimePeriod = "4",
			Date2 = "AlNfLPFD",
			YesNoConditionOrResponseCode = "Q",
			YesNoConditionOrResponseCode2 = "f",
			CertificationTypeCode = "V",
			Date3 = "Q4HCvXO4",
			ProductServiceIDQualifier = "od",
			MedicalCodeValue = "w",
			Date4 = "UXyqOneR",
			Date5 = "0OeykAvY",
			Date6 = "GJ5PBmP6",
			DateTimePeriodFormatQualifier2 = "WY",
			DateTimePeriod2 = "B",
			PatientLocationCode = "B",
			Date7 = "OPmFHSA5",
			Date8 = "oAKdlczt",
			Date9 = "kIyO1Y1S",
			Date10 = "RGt7gfgQ",
		};

		var actual = Map.MapObject<CR6_HomeHealthCareCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPrognosisCode(string prognosisCode, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.Date = "iBp38uzo";
		subject.YesNoConditionOrResponseCode2 = "f";
		subject.CertificationTypeCode = "V";
		//Test Parameters
		subject.PrognosisCode = prognosisCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Kw";
			subject.DateTimePeriod = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iBp38uzo", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.PrognosisCode = "A";
		subject.YesNoConditionOrResponseCode2 = "f";
		subject.CertificationTypeCode = "V";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Kw";
			subject.DateTimePeriod = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Kw", "4", true)]
	[InlineData("Kw", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.PrognosisCode = "A";
		subject.Date = "iBp38uzo";
		subject.YesNoConditionOrResponseCode2 = "f";
		subject.CertificationTypeCode = "V";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.PrognosisCode = "A";
		subject.Date = "iBp38uzo";
		subject.CertificationTypeCode = "V";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Kw";
			subject.DateTimePeriod = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredCertificationTypeCode(string certificationTypeCode, bool isValidExpected)
	{
		var subject = new CR6_HomeHealthCareCertification();
		//Required fields
		subject.PrognosisCode = "A";
		subject.Date = "iBp38uzo";
		subject.YesNoConditionOrResponseCode2 = "f";
		//Test Parameters
		subject.CertificationTypeCode = certificationTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Kw";
			subject.DateTimePeriod = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
