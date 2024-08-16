using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C785Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:h";

		var expected = new C785_StatisticalConceptIdentification()
		{
			StatisticalConceptIdentifier = "T",
			ObjectIdentificationCodeQualifier = "h",
		};

		var actual = Map.MapComposite<C785_StatisticalConceptIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredStatisticalConceptIdentifier(string statisticalConceptIdentifier, bool isValidExpected)
	{
		var subject = new C785_StatisticalConceptIdentification();
		//Required fields
		//Test Parameters
		subject.StatisticalConceptIdentifier = statisticalConceptIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
