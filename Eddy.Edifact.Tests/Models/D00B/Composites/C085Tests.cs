using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C085Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "k:l:N:I";

		var expected = new C085_MaritalStatusDetails()
		{
			MaritalStatusDescriptionCode = "k",
			CodeListIdentificationCode = "l",
			CodeListResponsibleAgencyCode = "N",
			MaritalStatusDescription = "I",
		};

		var actual = Map.MapComposite<C085_MaritalStatusDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
