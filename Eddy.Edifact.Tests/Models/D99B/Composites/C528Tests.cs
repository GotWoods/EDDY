using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C528Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "l:p:l";

		var expected = new C528_CommodityRateDetail()
		{
			CommodityRateIdentification = "l",
			CodeListIdentificationCode = "p",
			CodeListResponsibleAgencyCode = "l",
		};

		var actual = Map.MapComposite<C528_CommodityRateDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
