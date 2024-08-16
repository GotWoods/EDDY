using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C501Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "8:q:o:Z:u";

		var expected = new C501_PercentageDetails()
		{
			PercentageTypeCodeQualifier = "8",
			Percentage = "q",
			PercentageBasisIdentificationCode = "o",
			CodeListIdentificationCode = "Z",
			CodeListResponsibleAgencyCode = "u",
		};

		var actual = Map.MapComposite<C501_PercentageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredPercentageTypeCodeQualifier(string percentageTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C501_PercentageDetails();
		//Required fields
		//Test Parameters
		subject.PercentageTypeCodeQualifier = percentageTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
