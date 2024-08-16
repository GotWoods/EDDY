using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class APDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "APD+++++";

		var expected = new APD_AdditionalTransportDetails()
		{
			TransportDetails = null,
			TerminalInformation = null,
			DistanceOrTimeDetails = null,
			TravellerTimeDetails = null,
			SpecialTravelFacilities = null,
		};

		var actual = Map.MapObject<APD_AdditionalTransportDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
