using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C009Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "O:A:h:C";

		var expected = new C009_InformationCategory()
		{
			InformationCategoryDescriptionCode = "O",
			CodeListIdentificationCode = "A",
			CodeListResponsibleAgencyCode = "h",
			InformationCategoryDescription = "C",
		};

		var actual = Map.MapComposite<C009_InformationCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
