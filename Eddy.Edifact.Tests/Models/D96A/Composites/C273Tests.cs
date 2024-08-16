using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C273Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:r:Z:Y:p:w";

		var expected = new C273_ItemDescription()
		{
			ItemDescriptionIdentification = "d",
			CodeListQualifier = "r",
			CodeListResponsibleAgencyCoded = "Z",
			ItemDescription = "Y",
			ItemDescription2 = "p",
			LanguageCoded = "w",
		};

		var actual = Map.MapComposite<C273_ItemDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
