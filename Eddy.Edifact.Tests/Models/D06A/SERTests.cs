using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class SERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SER++k+G++g";

		var expected = new SER_FacilityInformation()
		{
			Facilities = null,
			ActionCode = "k",
			UnitsQuantity = "G",
			DateAndTimeInformation = null,
			DaysOfWeekSetIdentifier = "g",
		};

		var actual = Map.MapObject<SER_FacilityInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
