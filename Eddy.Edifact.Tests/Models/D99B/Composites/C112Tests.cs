using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C112Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "I:y:N:6";

		var expected = new C112_TermsTimeInformation()
		{
			TimeReferenceCode = "I",
			TermsTimeRelationCode = "y",
			PeriodTypeCode = "N",
			PeriodCountQuantity = "6",
		};

		var actual = Map.MapComposite<C112_TermsTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredTimeReferenceCode(string timeReferenceCode, bool isValidExpected)
	{
		var subject = new C112_TermsTimeInformation();
		//Required fields
		//Test Parameters
		subject.TimeReferenceCode = timeReferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
