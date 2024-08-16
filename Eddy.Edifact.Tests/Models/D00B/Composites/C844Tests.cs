using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C844Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "h:6:8:8";

		var expected = new C844_OrganisationClassificationDetail()
		{
			OrganisationalClassNameCode = "h",
			CodeListIdentificationCode = "6",
			CodeListResponsibleAgencyCode = "8",
			OrganisationalClassName = "8",
		};

		var actual = Map.MapComposite<C844_OrganisationClassificationDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
