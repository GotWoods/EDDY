using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C011Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "F:7:m:Z";

		var expected = new C011_InformationDetail()
		{
			InformationDetailCode = "F",
			CodeListIdentificationCode = "7",
			CodeListResponsibleAgencyCode = "m",
			InformationDetailDescription = "Z",
		};

		var actual = Map.MapComposite<C011_InformationDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
