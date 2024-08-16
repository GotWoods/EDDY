using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C200Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "3:3:2:j:e:B";

		var expected = new C200_Charge()
		{
			FreightAndChargesIdentification = "3",
			CodeListQualifier = "3",
			CodeListResponsibleAgencyCoded = "2",
			FreightAndCharges = "j",
			PrepaidCollectIndicatorCoded = "e",
			ItemNumber = "B",
		};

		var actual = Map.MapComposite<C200_Charge>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
