using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C837Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "P:7:G:L";

		var expected = new C837_CertaintyDetails()
		{
			CertaintyDescriptionCode = "P",
			CodeListIdentificationCode = "7",
			CodeListResponsibleAgencyCode = "G",
			CertaintyDescription = "L",
		};

		var actual = Map.MapComposite<C837_CertaintyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
