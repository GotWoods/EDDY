using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C950Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "v:b:v:a:2";

		var expected = new C950_QualificationClassification()
		{
			QualificationClassificationDescriptionCode = "v",
			CodeListIdentificationCode = "b",
			CodeListResponsibleAgencyCode = "v",
			QualificationClassificationDescription = "a",
			QualificationClassificationDescription2 = "2",
		};

		var actual = Map.MapComposite<C950_QualificationClassification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
