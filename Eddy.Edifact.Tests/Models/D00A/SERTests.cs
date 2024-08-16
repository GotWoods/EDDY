using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class SERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SER++g+6++V";

		var expected = new SER_FacilityInformation()
		{
			Facilities = null,
			ActionRequestNotificationDescriptionCode = "g",
			UnitsQuantity = "6",
			DateAndTimeInformation = null,
			DaysOfWeekSetIdentifier = "V",
		};

		var actual = Map.MapObject<SER_FacilityInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
