using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C785Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:l";

		var expected = new C785_StatisticalConceptIdentification()
		{
			StatisticalConceptIdentifier = "r",
			IdentityNumberQualifier = "l",
		};

		var actual = Map.MapComposite<C785_StatisticalConceptIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredStatisticalConceptIdentifier(string statisticalConceptIdentifier, bool isValidExpected)
	{
		var subject = new C785_StatisticalConceptIdentification();
		//Required fields
		//Test Parameters
		subject.StatisticalConceptIdentifier = statisticalConceptIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
