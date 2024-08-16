using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C040Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "k:H:z:1";

		var expected = new C040_Carrier()
		{
			CarrierIdentifier = "k",
			CodeListIdentificationCode = "H",
			CodeListResponsibleAgencyCode = "z",
			CarrierName = "1",
		};

		var actual = Map.MapComposite<C040_Carrier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
