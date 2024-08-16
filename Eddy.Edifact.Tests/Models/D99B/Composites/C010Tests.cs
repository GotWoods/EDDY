using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C010Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "R:f:F:P";

		var expected = new C010_InformationType()
		{
			InformationTypeCode = "R",
			CodeListIdentificationCode = "f",
			CodeListResponsibleAgencyCode = "F",
			InformationTypeDescription = "P",
		};

		var actual = Map.MapComposite<C010_InformationType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
