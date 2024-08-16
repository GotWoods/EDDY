using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C202Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "s:2:b:A";

		var expected = new C202_PackageType()
		{
			PackageTypeDescriptionCode = "s",
			CodeListIdentificationCode = "2",
			CodeListResponsibleAgencyCode = "b",
			TypeOfPackages = "A",
		};

		var actual = Map.MapComposite<C202_PackageType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
