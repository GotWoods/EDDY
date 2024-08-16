using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E023Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "c:3:k:T:X:Q";

		var expected = new E023_PartyDemographicInformation()
		{
			RelationshipDescriptionCode = "c",
			GenderCode = "3",
			EmploymentCategoryDescriptionCode = "k",
			MaritalStatusDescriptionCode = "T",
			StatusDescriptionCode = "X",
			YesNoCode = "Q",
		};

		var actual = Map.MapComposite<E023_PartyDemographicInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
