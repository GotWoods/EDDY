using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class HSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HS*VZR*Hl*E*DVI";

		var expected = new HS_HealthScreening()
		{
			HealthScreeningTypeCode = "VZR",
			DateTimePeriodFormatQualifier = "Hl",
			DateTimePeriod = "E",
			StatusReasonCode = "DVI",
		};

		var actual = Map.MapObject<HS_HealthScreening>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VZR", true)]
	public void Validation_RequiredHealthScreeningTypeCode(string healthScreeningTypeCode, bool isValidExpected)
	{
		var subject = new HS_HealthScreening();
		//Required fields
		//Test Parameters
		subject.HealthScreeningTypeCode = healthScreeningTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Hl";
			subject.DateTimePeriod = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hl", "E", true)]
	[InlineData("Hl", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new HS_HealthScreening();
		//Required fields
		subject.HealthScreeningTypeCode = "VZR";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
