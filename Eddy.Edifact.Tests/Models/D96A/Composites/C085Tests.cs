using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C085Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "t:5:f:h";

		var expected = new C085_MaritalStatusDetails()
		{
			MaritalStatusCoded = "t",
			CodeListQualifier = "5",
			CodeListResponsibleAgencyCoded = "f",
			MaritalStatus = "h",
		};

		var actual = Map.MapComposite<C085_MaritalStatusDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
