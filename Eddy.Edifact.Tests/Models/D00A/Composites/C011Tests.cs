using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C011Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "2:j:i:t";

		var expected = new C011_InformationDetail()
		{
			InformationDetailDescriptionCode = "2",
			CodeListIdentificationCode = "j",
			CodeListResponsibleAgencyCode = "i",
			InformationDetailDescription = "t",
		};

		var actual = Map.MapComposite<C011_InformationDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
