using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C213Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:v:0:h:p:5";

		var expected = new C213_NumberAndTypeOfPackages()
		{
			NumberOfPackages = "d",
			PackageTypeDescriptionCode = "v",
			CodeListIdentificationCode = "0",
			CodeListResponsibleAgencyCode = "h",
			TypeOfPackages = "p",
			PackagingRelatedDescriptionCode = "5",
		};

		var actual = Map.MapComposite<C213_NumberAndTypeOfPackages>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
