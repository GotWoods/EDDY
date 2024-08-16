using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C011Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "i:3:w:Y";

		var expected = new C011_InformationDetail()
		{
			InformationDetailDescriptionCode = "i",
			CodeListIdentificationCode = "3",
			CodeListResponsibleAgencyCode = "w",
			InformationDetailDescription = "Y",
		};

		var actual = Map.MapComposite<C011_InformationDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
