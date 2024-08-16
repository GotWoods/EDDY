using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class TEMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TEM++s+7+L+i+";

		var expected = new TEM_TestMethod()
		{
			TestMethod = null,
			TestAdministrationMethodCode = "s",
			TestMediumCode = "7",
			MeasurementPurposeCodeQualifier = "L",
			TestMethodRevisionIdentifier = "i",
			TestReason = null,
		};

		var actual = Map.MapObject<TEM_TestMethod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
