using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C004Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "5:L:b:r";

		var expected = new C004_EventCategory()
		{
			EventCategoryCode = "5",
			CodeListIdentificationCode = "L",
			CodeListResponsibleAgencyCode = "b",
			EventCategoryDescription = "r",
		};

		var actual = Map.MapComposite<C004_EventCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
