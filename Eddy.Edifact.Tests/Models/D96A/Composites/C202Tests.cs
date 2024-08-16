using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C202Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "2:G:p:C";

		var expected = new C202_PackageType()
		{
			TypeOfPackagesIdentification = "2",
			CodeListQualifier = "G",
			CodeListResponsibleAgencyCoded = "p",
			TypeOfPackages = "C",
		};

		var actual = Map.MapComposite<C202_PackageType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
