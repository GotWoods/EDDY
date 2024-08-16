using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C213Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "S:t:O:r:n:1";

		var expected = new C213_NumberAndTypeOfPackages()
		{
			PackageQuantity = "S",
			PackageTypeDescriptionCode = "t",
			CodeListIdentificationCode = "O",
			CodeListResponsibleAgencyCode = "r",
			TypeOfPackages = "n",
			PackagingRelatedDescriptionCode = "1",
		};

		var actual = Map.MapComposite<C213_NumberAndTypeOfPackages>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
