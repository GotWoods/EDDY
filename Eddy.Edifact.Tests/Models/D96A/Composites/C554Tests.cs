using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C554Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "F:7:8";

		var expected = new C554_RateTariffClassDetail()
		{
			RateTariffClassIdentification = "F",
			CodeListQualifier = "7",
			CodeListResponsibleAgencyCoded = "8",
		};

		var actual = Map.MapComposite<C554_RateTariffClassDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
