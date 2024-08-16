using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C501Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "B:d:U:x:f";

		var expected = new C501_PercentageDetails()
		{
			PercentageTypeCodeQualifier = "B",
			Percentage = "d",
			PercentageBasisIdentificationCode = "U",
			CodeListIdentificationCode = "x",
			CodeListResponsibleAgencyCode = "f",
		};

		var actual = Map.MapComposite<C501_PercentageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredPercentageTypeCodeQualifier(string percentageTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C501_PercentageDetails();
		//Required fields
		//Test Parameters
		subject.PercentageTypeCodeQualifier = percentageTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
