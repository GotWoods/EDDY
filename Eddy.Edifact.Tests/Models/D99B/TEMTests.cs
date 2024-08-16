using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class TEMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TEM++V+h+i+b+";

		var expected = new TEM_TestMethod()
		{
			TestMethod = null,
			TestRouteOfAdministeringCoded = "V",
			TestMediumCoded = "h",
			MeasurementAttributeCode = "i",
			TestRevisionNumber = "b",
			TestReason = null,
		};

		var actual = Map.MapObject<TEM_TestMethod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
