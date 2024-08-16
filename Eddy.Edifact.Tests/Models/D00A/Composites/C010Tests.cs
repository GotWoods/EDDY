using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C010Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:4:w:R";

		var expected = new C010_InformationType()
		{
			InformationTypeDescriptionCode = "n",
			CodeListIdentificationCode = "4",
			CodeListResponsibleAgencyCode = "w",
			InformationTypeDescription = "R",
		};

		var actual = Map.MapComposite<C010_InformationType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
