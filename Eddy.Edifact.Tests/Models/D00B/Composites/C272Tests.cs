using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C272Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "s:y:5";

		var expected = new C272_ItemCharacteristic()
		{
			ItemCharacteristicCode = "s",
			CodeListIdentificationCode = "y",
			CodeListResponsibleAgencyCode = "5",
		};

		var actual = Map.MapComposite<C272_ItemCharacteristic>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
