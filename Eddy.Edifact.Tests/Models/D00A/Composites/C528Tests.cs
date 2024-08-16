using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C528Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:j:G";

		var expected = new C528_CommodityRateDetail()
		{
			CommodityIdentificationCode = "r",
			CodeListIdentificationCode = "j",
			CodeListResponsibleAgencyCode = "G",
		};

		var actual = Map.MapComposite<C528_CommodityRateDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
