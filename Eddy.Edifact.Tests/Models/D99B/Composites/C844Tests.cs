using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C844Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "T:P:1:2";

		var expected = new C844_OrganisationClassificationDetail()
		{
			OrganisationalClassIdentification = "T",
			CodeListIdentificationCode = "P",
			CodeListResponsibleAgencyCode = "1",
			OrganisationalClass = "2",
		};

		var actual = Map.MapComposite<C844_OrganisationClassificationDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
