using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class TDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TDT+n+L++++r+++k";

		var expected = new TDT_DetailsOfTransport()
		{
			TransportStageCodeQualifier = "n",
			MeansOfTransportJourneyIdentifier = "L",
			ModeOfTransport = null,
			TransportMeans = null,
			Carrier = null,
			TransitDirectionIndicatorCode = "r",
			ExcessTransportationInformation = null,
			TransportIdentification = null,
			TransportMeansOwnershipIndicatorCode = "k",
		};

		var actual = Map.MapObject<TDT_DetailsOfTransport>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredTransportStageCodeQualifier(string transportStageCodeQualifier, bool isValidExpected)
	{
		var subject = new TDT_DetailsOfTransport();
		//Required fields
		//Test Parameters
		subject.TransportStageCodeQualifier = transportStageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
