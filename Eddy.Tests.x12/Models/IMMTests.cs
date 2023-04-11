using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IMMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMM*K*sF*M*v*iN*8";

		var expected = new IMM_ImmunizationStatus()
		{
			IndustryCode = "K",
			DateTimePeriodFormatQualifier = "sF",
			DateTimePeriod = "M",
			ImmunizationStatusCode = "v",
			ReportTypeCode = "iN",
			CodeListQualifierCode = "8",
		};

		var actual = Map.MapObject<IMM_ImmunizationStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatus();
		subject.CodeListQualifierCode = "8";
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("sF", "M", true)]
	[InlineData("", "M", false)]
	[InlineData("sF", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatus();
		subject.IndustryCode = "K";
		subject.CodeListQualifierCode = "8";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "v", true)]
	[InlineData("M", "", false)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string immunizationStatusCode, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatus();
		subject.IndustryCode = "K";
		subject.CodeListQualifierCode = "8";
		subject.DateTimePeriod = dateTimePeriod;
		subject.ImmunizationStatusCode = immunizationStatusCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatus();
		subject.IndustryCode = "K";
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
