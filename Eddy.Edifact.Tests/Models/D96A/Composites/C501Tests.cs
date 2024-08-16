using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C501Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "P:n:Y:c:z";

		var expected = new C501_PercentageDetails()
		{
			PercentageQualifier = "P",
			Percentage = "n",
			PercentageBasisCoded = "Y",
			CodeListQualifier = "c",
			CodeListResponsibleAgencyCoded = "z",
		};

		var actual = Map.MapComposite<C501_PercentageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredPercentageQualifier(string percentageQualifier, bool isValidExpected)
	{
		var subject = new C501_PercentageDetails();
		//Required fields
		//Test Parameters
		subject.PercentageQualifier = percentageQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
