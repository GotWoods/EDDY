using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C213Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:k:3:x:2";

		var expected = new C213_NumberAndTypeOfPackages()
		{
			NumberOfPackages = "u",
			TypeOfPackagesIdentification = "k",
			CodeListQualifier = "3",
			CodeListResponsibleAgencyCoded = "x",
			TypeOfPackages = "2",
		};

		var actual = Map.MapComposite<C213_NumberAndTypeOfPackages>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
