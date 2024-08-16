using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C554Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:g:s";

		var expected = new C554_RateTariffClassDetail()
		{
			RateOrTariffClassDescriptionCode = "G",
			CodeListIdentificationCode = "g",
			CodeListResponsibleAgencyCode = "s",
		};

		var actual = Map.MapComposite<C554_RateTariffClassDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
