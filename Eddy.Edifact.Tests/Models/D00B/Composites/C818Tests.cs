using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C818Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:U:l:J";

		var expected = new C818_PersonInheritedCharacteristicDetails()
		{
			InheritedCharacteristicDescriptionCode = "9",
			CodeListIdentificationCode = "U",
			CodeListResponsibleAgencyCode = "l",
			InheritedCharacteristicDescription = "J",
		};

		var actual = Map.MapComposite<C818_PersonInheritedCharacteristicDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
