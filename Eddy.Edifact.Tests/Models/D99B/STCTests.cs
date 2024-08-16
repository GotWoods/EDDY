using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class STCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "STC+++A+n";

		var expected = new STC_StatisticalConcept()
		{
			StatisticalConceptIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "A",
			MaintenanceOperationCoded = "n",
		};

		var actual = Map.MapObject<STC_StatisticalConcept>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredStatisticalConceptIdentification(string statisticalConceptIdentification, bool isValidExpected)
	{
		var subject = new STC_StatisticalConcept();
		//Required fields
		//Test Parameters
		if (statisticalConceptIdentification != "") 
			subject.StatisticalConceptIdentification = new C785_StatisticalConceptIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
