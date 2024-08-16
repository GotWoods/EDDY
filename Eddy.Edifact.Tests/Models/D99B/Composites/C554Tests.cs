using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C554Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "C:d:6";

		var expected = new C554_RateTariffClassDetail()
		{
			RateTariffClassIdentification = "C",
			CodeListIdentificationCode = "d",
			CodeListResponsibleAgencyCode = "6",
		};

		var actual = Map.MapComposite<C554_RateTariffClassDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
