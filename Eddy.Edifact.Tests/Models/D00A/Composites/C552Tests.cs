using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C552Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "1:P";

		var expected = new C552_AllowanceChargeInformation()
		{
			AllowanceOrChargeIdentifier = "1",
			AllowanceOrChargeIdentificationCode = "P",
		};

		var actual = Map.MapComposite<C552_AllowanceChargeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
