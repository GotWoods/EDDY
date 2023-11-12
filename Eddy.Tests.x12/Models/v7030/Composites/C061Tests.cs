using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7030;
using Eddy.x12.Models.v7030.Composites;

namespace Eddy.x12.Tests.Models.v7030.Composites;

public class C061Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "T*o*WLQ*vhwT3nNq*7xet69MM";

		var expected = new C061_MemberHealthAndTreatmentInformation()
		{
			HealthRelatedCode = "T",
			YesNoConditionOrResponseCode = "o",
			DateTimeQualifier = "WLQ",
			Date = "vhwT3nNq",
			Date2 = "7xet69MM",
		};

		var actual = Map.MapObject<C061_MemberHealthAndTreatmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("WLQ", "vhwT3nNq", "7xet69MM", true)]
	[InlineData("WLQ", "", "", false)]
	[InlineData("", "vhwT3nNq", "7xet69MM", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier(string dateTimeQualifier, string date, string date2, bool isValidExpected)
	{
		var subject = new C061_MemberHealthAndTreatmentInformation();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		subject.Date2 = date2;
		//A Requires B
		if (date != "")
			subject.DateTimeQualifier = "WLQ";
		if (date2 != "")
			subject.DateTimeQualifier = "WLQ";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vhwT3nNq", "WLQ", true)]
	[InlineData("vhwT3nNq", "", false)]
	[InlineData("", "WLQ", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new C061_MemberHealthAndTreatmentInformation();
		//Required fields
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.Date2 = "7xet69MM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7xet69MM", "WLQ", true)]
	[InlineData("7xet69MM", "", false)]
	[InlineData("", "WLQ", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new C061_MemberHealthAndTreatmentInformation();
		//Required fields
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier = dateTimeQualifier;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.Date = "vhwT3nNq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
