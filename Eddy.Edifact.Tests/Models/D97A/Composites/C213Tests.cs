using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class C213Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "s:m:D:S:e:a";

		var expected = new C213_NumberAndTypeOfPackages()
		{
			NumberOfPackages = "s",
			TypeOfPackagesIdentification = "m",
			CodeListQualifier = "D",
			CodeListResponsibleAgencyCoded = "S",
			TypeOfPackages = "e",
			PackagingRelatedInformationCoded = "a",
		};

		var actual = Map.MapComposite<C213_NumberAndTypeOfPackages>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
