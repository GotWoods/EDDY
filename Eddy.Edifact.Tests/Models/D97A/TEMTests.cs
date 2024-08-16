using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class TEMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TEM++R+c+j+e+";

		var expected = new TEM_TestMethod()
		{
			TestMethod = null,
			TestRouteOfAdministeringCoded = "R",
			TestMediaCoded = "c",
			MeasurementPurposeQualifier = "j",
			TestRevisionNumber = "e",
			TestReason = null,
		};

		var actual = Map.MapObject<TEM_TestMethod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
