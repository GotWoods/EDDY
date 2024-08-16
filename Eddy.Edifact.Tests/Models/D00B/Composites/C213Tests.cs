using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C213Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "n:G:w:t:Z:n";

		var expected = new C213_NumberAndTypeOfPackages()
		{
			PackageQuantity = "n",
			PackageTypeDescriptionCode = "G",
			CodeListIdentificationCode = "w",
			CodeListResponsibleAgencyCode = "t",
			TypeOfPackages = "Z",
			PackagingRelatedDescriptionCode = "n",
		};

		var actual = Map.MapComposite<C213_NumberAndTypeOfPackages>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
