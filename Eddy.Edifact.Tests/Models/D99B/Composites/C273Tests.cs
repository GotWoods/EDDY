using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C273Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:s:h:i:w:C";

		var expected = new C273_ItemDescription()
		{
			ItemDescriptionIdentification = "7",
			CodeListIdentificationCode = "s",
			CodeListResponsibleAgencyCode = "h",
			ItemDescription = "i",
			ItemDescription2 = "w",
			LanguageNameCode = "C",
		};

		var actual = Map.MapComposite<C273_ItemDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
