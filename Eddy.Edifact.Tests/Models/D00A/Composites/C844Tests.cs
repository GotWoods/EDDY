using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C844Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Q:t:m:Z";

		var expected = new C844_OrganisationClassificationDetail()
		{
			OrganisationalClassNameCode = "Q",
			CodeListIdentificationCode = "t",
			CodeListResponsibleAgencyCode = "m",
			OrganisationalClassName = "Z",
		};

		var actual = Map.MapComposite<C844_OrganisationClassificationDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
