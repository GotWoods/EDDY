using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C040Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "E:9:4:o";

		var expected = new C040_Carrier()
		{
			CarrierIdentification = "E",
			CodeListIdentificationCode = "9",
			CodeListResponsibleAgencyCode = "4",
			CarrierName = "o",
		};

		var actual = Map.MapComposite<C040_Carrier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
