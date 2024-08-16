using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C049Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "2:l:D:m:2";

		var expected = new C049_RemunerationTypeIdentification()
		{
			RemunerationTypeCoded = "2",
			CodeListIdentificationCode = "l",
			CodeListResponsibleAgencyCode = "D",
			RemunerationType = "m",
			RemunerationType2 = "2",
		};

		var actual = Map.MapComposite<C049_RemunerationTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
