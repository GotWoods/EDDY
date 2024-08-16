using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C818Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "e:r:u:w";

		var expected = new C818_PersonInheritedCharacteristicDetails()
		{
			PersonInheritedCharacteristicIdentification = "e",
			CodeListIdentificationCode = "r",
			CodeListResponsibleAgencyCode = "u",
			PersonInheritedCharacteristic = "w",
		};

		var actual = Map.MapComposite<C818_PersonInheritedCharacteristicDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
