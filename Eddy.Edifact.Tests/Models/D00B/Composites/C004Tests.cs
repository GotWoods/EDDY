using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C004Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "x:p:Q:7";

		var expected = new C004_EventCategory()
		{
			EventCategoryDescriptionCode = "x",
			CodeListIdentificationCode = "p",
			CodeListResponsibleAgencyCode = "Q",
			EventCategoryDescription = "7",
		};

		var actual = Map.MapComposite<C004_EventCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
