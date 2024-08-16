using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C973Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "C:H:B:f";

		var expected = new C973_ApplicabilityType()
		{
			ApplicabilityTypeDescriptionCode = "C",
			CodeListIdentificationCode = "H",
			CodeListResponsibleAgencyCode = "B",
			ApplicabilityTypeDescription = "f",
		};

		var actual = Map.MapComposite<C973_ApplicabilityType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
