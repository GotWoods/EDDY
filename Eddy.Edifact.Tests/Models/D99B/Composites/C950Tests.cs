using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C950Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "6:8:d:F:M";

		var expected = new C950_QualificationClassification()
		{
			QualificationClassificationCoded = "6",
			CodeListIdentificationCode = "8",
			CodeListResponsibleAgencyCode = "d",
			QualificationClassification = "F",
			QualificationClassification2 = "M",
		};

		var actual = Map.MapComposite<C950_QualificationClassification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
