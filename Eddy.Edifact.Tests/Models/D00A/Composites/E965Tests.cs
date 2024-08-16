using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E965Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "a:p:M:n";

		var expected = new E965_Facilities()
		{
			FacilityTypeDescriptionCode = "a",
			FacilityTypeDescription = "p",
			ProductDetailsTypeCodeQualifier = "M",
			CharacteristicDescriptionCode = "n",
		};

		var actual = Map.MapComposite<E965_Facilities>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
