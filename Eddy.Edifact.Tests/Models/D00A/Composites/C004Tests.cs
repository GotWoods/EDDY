using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C004Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "q:6:r:A";

		var expected = new C004_EventCategory()
		{
			EventCategoryDescriptionCode = "q",
			CodeListIdentificationCode = "6",
			CodeListResponsibleAgencyCode = "r",
			EventCategoryDescription = "A",
		};

		var actual = Map.MapComposite<C004_EventCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
