using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C273Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "m:q:J:P:Y:V";

		var expected = new C273_ItemDescription()
		{
			ItemDescriptionCode = "m",
			CodeListIdentificationCode = "q",
			CodeListResponsibleAgencyCode = "J",
			ItemDescription = "P",
			ItemDescription2 = "Y",
			LanguageNameCode = "V",
		};

		var actual = Map.MapComposite<C273_ItemDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
