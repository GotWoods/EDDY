using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C973Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "y:6:C:z";

		var expected = new C973_ApplicabilityType()
		{
			ApplicabilityTypeDescriptionCode = "y",
			CodeListIdentificationCode = "6",
			CodeListResponsibleAgencyCode = "C",
			ApplicabilityTypeDescription = "z",
		};

		var actual = Map.MapComposite<C973_ApplicabilityType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
