using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C818Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "o:V:x:K";

		var expected = new C818_PersonInheritedCharacteristicDetails()
		{
			PersonInheritedCharacteristicIdentification = "o",
			CodeListQualifier = "V",
			CodeListResponsibleAgencyCoded = "x",
			PersonInheritedCharacteristic = "K",
		};

		var actual = Map.MapComposite<C818_PersonInheritedCharacteristicDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
