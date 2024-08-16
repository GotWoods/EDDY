using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C010Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "X:b:v:D";

		var expected = new C010_InformationType()
		{
			InformationTypeDescriptionCode = "X",
			CodeListIdentificationCode = "b",
			CodeListResponsibleAgencyCode = "v",
			InformationTypeDescription = "D",
		};

		var actual = Map.MapComposite<C010_InformationType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
