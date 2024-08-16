using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C049Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "1:3:i:9:G";

		var expected = new C049_RemunerationTypeIdentification()
		{
			RemunerationTypeNameCode = "1",
			CodeListIdentificationCode = "3",
			CodeListResponsibleAgencyCode = "i",
			RemunerationTypeName = "9",
			RemunerationTypeName2 = "G",
		};

		var actual = Map.MapComposite<C049_RemunerationTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
