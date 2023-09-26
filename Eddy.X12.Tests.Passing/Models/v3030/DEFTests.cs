using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DEFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEF*j*wW*I*k";

		var expected = new DEF_DefermentInformation()
		{
			DefermentTypeCode = "j",
			DateTimePeriodFormatQualifier = "wW",
			DateTimePeriod = "I",
			InterestPaymentCode = "k",
		};

		var actual = Map.MapObject<DEF_DefermentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredDefermentTypeCode(string defermentTypeCode, bool isValidExpected)
	{
		var subject = new DEF_DefermentInformation();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "wW";
		subject.DateTimePeriod = "I";
		//Test Parameters
		subject.DefermentTypeCode = defermentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wW", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new DEF_DefermentInformation();
		//Required fields
		subject.DefermentTypeCode = "j";
		subject.DateTimePeriod = "I";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DEF_DefermentInformation();
		//Required fields
		subject.DefermentTypeCode = "j";
		subject.DateTimePeriodFormatQualifier = "wW";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
