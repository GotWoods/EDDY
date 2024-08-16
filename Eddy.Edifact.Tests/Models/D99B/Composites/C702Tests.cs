using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C702Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "5:8:u";

		var expected = new C702_CodeSetIdentification()
		{
			SimpleDataElementTag = "5",
			CodeListIdentificationCode = "8",
			CodeListResponsibleAgencyCode = "u",
		};

		var actual = Map.MapComposite<C702_CodeSetIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
