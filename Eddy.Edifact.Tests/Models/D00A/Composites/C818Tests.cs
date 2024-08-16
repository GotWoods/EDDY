using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C818Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "A:p:8:v";

		var expected = new C818_PersonInheritedCharacteristicDetails()
		{
			InheritedCharacteristicDescriptionCode = "A",
			CodeListIdentificationCode = "p",
			CodeListResponsibleAgencyCode = "8",
			InheritedCharacteristicDescription = "v",
		};

		var actual = Map.MapComposite<C818_PersonInheritedCharacteristicDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
