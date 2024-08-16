using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D11A;
using Eddy.Edifact.Models.D11A.Composites;

namespace Eddy.Edifact.Tests.Models.D11A.Composites;

public class C003Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "f:A:x:H";

		var expected = new C003_PowerType()
		{
			PowerTypeCode = "f",
			CodeListIdentificationCode = "A",
			CodeListResponsibleAgencyCode = "x",
			PowerTypeDescription = "H",
		};

		var actual = Map.MapComposite<C003_PowerType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
