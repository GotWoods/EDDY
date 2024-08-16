using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C852Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "X:b:a:v";

		var expected = new C852_RiskObjectSubType()
		{
			RiskObjectSubTypeDescriptionIdentifier = "X",
			CodeListIdentificationCode = "b",
			CodeListResponsibleAgencyCode = "a",
			RiskObjectSubTypeDescription = "v",
		};

		var actual = Map.MapComposite<C852_RiskObjectSubType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
