using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C333Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "i:y:G:R";

		var expected = new C333_InformationRequest()
		{
			RequestedInformationCoded = "i",
			CodeListQualifier = "y",
			CodeListResponsibleAgencyCoded = "G",
			RequestedInformation = "R",
		};

		var actual = Map.MapComposite<C333_InformationRequest>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
