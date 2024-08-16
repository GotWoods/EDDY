using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class TEMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TEM++B+Y+V+W+";

		var expected = new TEM_TestMethod()
		{
			TestMethod = null,
			TestRouteOfAdministeringCoded = "B",
			TestMediaCoded = "Y",
			MeasurementApplicationQualifier = "V",
			TestRevisionNumber = "W",
			TestReason = null,
		};

		var actual = Map.MapObject<TEM_TestMethod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
