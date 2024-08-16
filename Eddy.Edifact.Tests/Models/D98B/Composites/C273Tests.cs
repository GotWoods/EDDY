using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C273Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "B:2:l:3:2:l";

		var expected = new C273_ItemDescription()
		{
			ItemDescriptionIdentification = "B",
			CodeListQualifier = "2",
			CodeListResponsibleAgencyCoded = "l",
			ItemDescription = "3",
			ItemDescription2 = "2",
			LanguageCoded = "l",
		};

		var actual = Map.MapComposite<C273_ItemDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
