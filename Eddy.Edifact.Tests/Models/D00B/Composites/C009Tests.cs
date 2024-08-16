using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C009Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:9:g:z";

		var expected = new C009_InformationCategory()
		{
			InformationCategoryDescriptionCode = "S",
			CodeListIdentificationCode = "9",
			CodeListResponsibleAgencyCode = "g",
			InformationCategoryDescription = "z",
		};

		var actual = Map.MapComposite<C009_InformationCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
