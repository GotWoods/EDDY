using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D19B;
using Eddy.Edifact.Models.D19B.Composites;

namespace Eddy.Edifact.Tests.Models.D19B;

public class TDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TDT+Z+p++++I+++b++";

		var expected = new TDT_TransportInformation()
		{
			TransportStageCodeQualifier = "Z",
			MeansOfTransportJourneyIdentifier = "p",
			ModeOfTransport = null,
			TransportMeans = null,
			Carrier = null,
			TransitDirectionIndicatorCode = "I",
			ExcessTransportationInformation = null,
			TransportIdentification = null,
			TransportMeansOwnershipIndicatorCode = "b",
			PowerType = null,
			TransportService = null,
		};

		var actual = Map.MapObject<TDT_TransportInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredTransportStageCodeQualifier(string transportStageCodeQualifier, bool isValidExpected)
	{
		var subject = new TDT_TransportInformation();
		//Required fields
		//Test Parameters
		subject.TransportStageCodeQualifier = transportStageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
