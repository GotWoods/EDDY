using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C273Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "v:1:S:N:b:c";

		var expected = new C273_ItemDescription()
		{
			ItemDescriptionCode = "v",
			CodeListIdentificationCode = "1",
			CodeListResponsibleAgencyCode = "S",
			ItemDescription = "N",
			ItemDescription2 = "b",
			LanguageNameCode = "c",
		};

		var actual = Map.MapComposite<C273_ItemDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
