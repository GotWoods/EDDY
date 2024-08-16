using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C085Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "y:7:T:h";

		var expected = new C085_MaritalStatusDetails()
		{
			MaritalStatusDescriptionCode = "y",
			CodeListIdentificationCode = "7",
			CodeListResponsibleAgencyCode = "T",
			MaritalStatusDescription = "h",
		};

		var actual = Map.MapComposite<C085_MaritalStatusDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
