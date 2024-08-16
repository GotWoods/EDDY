using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C272Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "F:C:x";

		var expected = new C272_ItemCharacteristic()
		{
			ItemCharacteristicCode = "F",
			CodeListIdentificationCode = "C",
			CodeListResponsibleAgencyCode = "x",
		};

		var actual = Map.MapComposite<C272_ItemCharacteristic>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
