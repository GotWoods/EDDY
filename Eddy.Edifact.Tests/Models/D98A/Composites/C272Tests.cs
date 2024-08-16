using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class C272Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "P:o:r";

		var expected = new C272_ItemCharacteristic()
		{
			ItemCharacteristicCoded = "P",
			CodeListQualifier = "o",
			CodeListResponsibleAgencyCoded = "r",
		};

		var actual = Map.MapComposite<C272_ItemCharacteristic>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
