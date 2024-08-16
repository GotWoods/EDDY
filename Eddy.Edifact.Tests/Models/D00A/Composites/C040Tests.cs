using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C040Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "A:i:x:M";

		var expected = new C040_Carrier()
		{
			CarrierIdentifier = "A",
			CodeListIdentificationCode = "i",
			CodeListResponsibleAgencyCode = "x",
			CarrierName = "M",
		};

		var actual = Map.MapComposite<C040_Carrier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
