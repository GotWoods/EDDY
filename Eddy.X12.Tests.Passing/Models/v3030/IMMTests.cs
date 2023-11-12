using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class IMMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMM*qhx*AX*H*o";

		var expected = new IMM_ImmunizationStatusCode()
		{
			ImmunizationTypeCode = "qhx",
			DateTimePeriodFormatQualifier = "AX",
			DateTimePeriod = "H",
			ImmunizationStatusCode = "o",
		};

		var actual = Map.MapObject<IMM_ImmunizationStatusCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qhx", true)]
	public void Validation_RequiredImmunizationTypeCode(string immunizationTypeCode, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatusCode();
		//Required fields
		//Test Parameters
		subject.ImmunizationTypeCode = immunizationTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "AX";
			subject.DateTimePeriod = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AX", "H", true)]
	[InlineData("AX", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatusCode();
		//Required fields
		subject.ImmunizationTypeCode = "qhx";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//A Requires B
		if (dateTimePeriod != "")
			subject.ImmunizationStatusCode = "o";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "o", true)]
	[InlineData("H", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string immunizationStatusCode, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatusCode();
		//Required fields
		subject.ImmunizationTypeCode = "qhx";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.ImmunizationStatusCode = immunizationStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "AX";
			subject.DateTimePeriod = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
