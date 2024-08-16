using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class C010Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:L:g:c";

		var expected = new C010_InformationType()
		{
			InformationTypeCode = "k",
			CodeListIdentificationCode = "L",
			CodeListResponsibleAgencyCode = "g",
			InformationType = "c",
		};

		var actual = Map.MapComposite<C010_InformationType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
