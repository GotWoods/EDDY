using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C950Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "2:K:k:e:J";

		var expected = new C950_QualificationClassification()
		{
			QualificationClassificationCoded = "2",
			CodeListQualifier = "K",
			CodeListResponsibleAgencyCoded = "k",
			QualificationClassification = "e",
			QualificationClassification2 = "J",
		};

		var actual = Map.MapComposite<C950_QualificationClassification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
