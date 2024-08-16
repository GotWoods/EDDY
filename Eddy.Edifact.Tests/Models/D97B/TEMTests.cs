using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class TEMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TEM++B+6+u+8+";

		var expected = new TEM_TestMethod()
		{
			TestMethod = null,
			TestRouteOfAdministeringCoded = "B",
			TestMediumCoded = "6",
			MeasurementPurposeQualifier = "u",
			TestRevisionNumber = "8",
			TestReason = null,
		};

		var actual = Map.MapObject<TEM_TestMethod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
