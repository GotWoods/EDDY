using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class POSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "POS++";

		var expected = new POS_PointOfSaleInformation()
		{
			PartyIdentification = null,
			Location = null,
		};

		var actual = Map.MapObject<POS_PointOfSaleInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
