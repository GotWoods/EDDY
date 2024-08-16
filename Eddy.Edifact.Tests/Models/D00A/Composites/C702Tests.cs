using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C702Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "j:r:o";

		var expected = new C702_CodeSetIdentification()
		{
			SimpleDataElementTagIdentifier = "j",
			CodeListIdentificationCode = "r",
			CodeListResponsibleAgencyCode = "o",
		};

		var actual = Map.MapComposite<C702_CodeSetIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
