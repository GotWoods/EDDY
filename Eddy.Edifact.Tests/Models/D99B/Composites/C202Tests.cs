using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C202Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "R:F:s:w";

		var expected = new C202_PackageType()
		{
			PackageTypeDescriptionCode = "R",
			CodeListIdentificationCode = "F",
			CodeListResponsibleAgencyCode = "s",
			TypeOfPackages = "w",
		};

		var actual = Map.MapComposite<C202_PackageType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
