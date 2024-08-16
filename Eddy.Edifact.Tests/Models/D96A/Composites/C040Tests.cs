using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C040Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:k:4:X";

		var expected = new C040_Carrier()
		{
			CarrierIdentification = "r",
			CodeListQualifier = "k",
			CodeListResponsibleAgencyCoded = "4",
			CarrierName = "X",
		};

		var actual = Map.MapComposite<C040_Carrier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
