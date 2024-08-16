using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C974Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "d:4:v:k";

		var expected = new C974_BasisType()
		{
			BasisTypeDescriptionCode = "d",
			CodeListIdentificationCode = "4",
			CodeListResponsibleAgencyCode = "v",
			BasisTypeDescription = "k",
		};

		var actual = Map.MapComposite<C974_BasisType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
