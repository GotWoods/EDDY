using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C852Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:I:g:W";

		var expected = new C852_RiskObjectSubType()
		{
			RiskObjectSubTypeDescriptionIdentifier = "l",
			CodeListIdentificationCode = "I",
			CodeListResponsibleAgencyCode = "g",
			RiskObjectSubTypeDescription = "W",
		};

		var actual = Map.MapComposite<C852_RiskObjectSubType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
