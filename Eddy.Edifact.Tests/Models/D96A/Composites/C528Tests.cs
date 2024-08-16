using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C528Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "6:P:y";

		var expected = new C528_CommodityRateDetail()
		{
			CommodityRateIdentification = "6",
			CodeListQualifier = "P",
			CodeListResponsibleAgencyCoded = "y",
		};

		var actual = Map.MapComposite<C528_CommodityRateDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
