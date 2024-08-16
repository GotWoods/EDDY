using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C200Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "n:a:e:b:H:m";

		var expected = new C200_Charge()
		{
			FreightAndChargesIdentification = "n",
			CodeListIdentificationCode = "a",
			CodeListResponsibleAgencyCode = "e",
			FreightAndCharges = "b",
			PrepaidCollectIndicatorCoded = "H",
			ItemNumber = "m",
		};

		var actual = Map.MapComposite<C200_Charge>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
