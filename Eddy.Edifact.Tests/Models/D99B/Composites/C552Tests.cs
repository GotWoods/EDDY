using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C552Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:7";

		var expected = new C552_AllowanceChargeInformation()
		{
			AllowanceOrChargeNumber = "u",
			AllowanceOrChargeIdentificationCode = "7",
		};

		var actual = Map.MapComposite<C552_AllowanceChargeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
