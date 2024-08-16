using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C950Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:Y:q:n:N";

		var expected = new C950_QualificationClassification()
		{
			QualificationClassificationDescriptionCode = "a",
			CodeListIdentificationCode = "Y",
			CodeListResponsibleAgencyCode = "q",
			QualificationClassificationDescription = "n",
			QualificationClassificationDescription2 = "N",
		};

		var actual = Map.MapComposite<C950_QualificationClassification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
