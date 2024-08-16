using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C702Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "6:h:m";

		var expected = new C702_CodeSetIdentification()
		{
			SimpleDataElementTagIdentifier = "6",
			CodeListIdentificationCode = "h",
			CodeListResponsibleAgencyCode = "m",
		};

		var actual = Map.MapComposite<C702_CodeSetIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
