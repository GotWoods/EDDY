using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02B;
using Eddy.Edifact.Models.D02B.Composites;

namespace Eddy.Edifact.Tests.Models.D02B;

public class TDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TDT+G+Y++++I+++8";

		var expected = new TDT_TransportInformation()
		{
			TransportStageCodeQualifier = "G",
			MeansOfTransportJourneyIdentifier = "Y",
			ModeOfTransport = null,
			TransportMeans = null,
			Carrier = null,
			TransitDirectionIndicatorCode = "I",
			ExcessTransportationInformation = null,
			TransportIdentification = null,
			TransportMeansOwnershipIndicatorCode = "8",
		};

		var actual = Map.MapObject<TDT_TransportInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredTransportStageCodeQualifier(string transportStageCodeQualifier, bool isValidExpected)
	{
		var subject = new TDT_TransportInformation();
		//Required fields
		//Test Parameters
		subject.TransportStageCodeQualifier = transportStageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
