using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C009Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:7:C:Z";

		var expected = new C009_InformationCategory()
		{
			InformationCategoryCode = "l",
			CodeListIdentificationCode = "7",
			CodeListResponsibleAgencyCode = "C",
			InformationCategoryDescription = "Z",
		};

		var actual = Map.MapComposite<C009_InformationCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
