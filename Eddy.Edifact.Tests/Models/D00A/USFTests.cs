using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USF+U++Q+z+8";

		var expected = new USF_KeyManagementFunction()
		{
			KeyManagementFunctionQualifier = "U",
			ListParameter = null,
			SecurityStatusCoded = "Q",
			CertificateSequenceNumber = "z",
			FilterFunctionCoded = "8",
		};

		var actual = Map.MapObject<USF_KeyManagementFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
