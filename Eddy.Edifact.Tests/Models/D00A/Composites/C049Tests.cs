using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C049Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:V:z:g:b";

		var expected = new C049_RemunerationTypeIdentification()
		{
			RemunerationTypeNameCode = "9",
			CodeListIdentificationCode = "V",
			CodeListResponsibleAgencyCode = "z",
			RemunerationTypeName = "g",
			RemunerationTypeName2 = "b",
		};

		var actual = Map.MapComposite<C049_RemunerationTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
