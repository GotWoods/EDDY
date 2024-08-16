using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C552Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "X:D";

		var expected = new C552_AllowanceChargeInformation()
		{
			AllowanceOrChargeNumber = "X",
			ChargeAllowanceDescriptionCoded = "D",
		};

		var actual = Map.MapComposite<C552_AllowanceChargeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
