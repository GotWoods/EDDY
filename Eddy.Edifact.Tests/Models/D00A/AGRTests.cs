using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class AGRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "AGR++M";

		var expected = new AGR_AgreementIdentification()
		{
			AgreementTypeIdentification = null,
			ServiceLayerCode = "M",
		};

		var actual = Map.MapObject<AGR_AgreementIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
