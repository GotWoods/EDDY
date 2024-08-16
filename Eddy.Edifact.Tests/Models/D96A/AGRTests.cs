using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class AGRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "AGR++n";

		var expected = new AGR_AgreementIdentification()
		{
			AgreementTypeIdentification = null,
			ServiceLayerCoded = "n",
		};

		var actual = Map.MapObject<AGR_AgreementIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
