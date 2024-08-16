using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class TEMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TEM++K+5+V+p+";

		var expected = new TEM_TestMethod()
		{
			TestMethod = null,
			TestAdministrationMethodCode = "K",
			TestMediumCode = "5",
			MeasurementAttributeCode = "V",
			TestMethodRevisionIdentifier = "p",
			TestReason = null,
		};

		var actual = Map.MapObject<TEM_TestMethod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
