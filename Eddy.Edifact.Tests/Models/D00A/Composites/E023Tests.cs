using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E023Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "H:T:G:U:y:G";

		var expected = new E023_PartyDemographicInformation()
		{
			RelationshipDescriptionCode = "H",
			GenderCode = "T",
			EmploymentCategoryDescriptionCode = "G",
			MaritalStatusDescriptionCode = "U",
			StatusDescriptionCode = "y",
			YesOrNoIndicatorCode = "G",
		};

		var actual = Map.MapComposite<E023_PartyDemographicInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
