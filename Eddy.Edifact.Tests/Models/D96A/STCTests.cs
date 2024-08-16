using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class STCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "STC+++l+B";

		var expected = new STC_StatisticalConcept()
		{
			StatisticalConceptIdentification = null,
			PartyIdentificationDetails = null,
			StatusCoded = "l",
			MaintenanceOperationCoded = "B",
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
