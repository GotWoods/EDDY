using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C528Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "c:7:V";

		var expected = new C528_CommodityRateDetail()
		{
			CommodityIdentificationCode = "c",
			CodeListIdentificationCode = "7",
			CodeListResponsibleAgencyCode = "V",
		};

		var actual = Map.MapComposite<C528_CommodityRateDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
