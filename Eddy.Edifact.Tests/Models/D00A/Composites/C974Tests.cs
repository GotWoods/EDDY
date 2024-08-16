using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C974Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "t:2:t:3";

		var expected = new C974_BasisType()
		{
			BasisTypeDescriptionCode = "t",
			CodeListIdentificationCode = "2",
			CodeListResponsibleAgencyCode = "t",
			BasisTypeDescription = "3",
		};

		var actual = Map.MapComposite<C974_BasisType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
