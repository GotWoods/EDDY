using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C844Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "J:Q:Z:B";

		var expected = new C844_OrganisationClassificationDetail()
		{
			OrganisationalClassIdentification = "J",
			CodeListQualifier = "Q",
			CodeListResponsibleAgencyCoded = "Z",
			OrganisationalClass = "B",
		};

		var actual = Map.MapComposite<C844_OrganisationClassificationDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
