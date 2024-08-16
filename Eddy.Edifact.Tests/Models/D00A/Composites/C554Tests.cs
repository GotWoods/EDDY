using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C554Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "W:n:M";

		var expected = new C554_RateTariffClassDetail()
		{
			RateOrTariffClassDescriptionCode = "W",
			CodeListIdentificationCode = "n",
			CodeListResponsibleAgencyCode = "M",
		};

		var actual = Map.MapComposite<C554_RateTariffClassDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
