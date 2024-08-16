using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D11A;
using Eddy.Edifact.Models.D11A.Composites;

namespace Eddy.Edifact.Tests.Models.D11A;

public class TDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TDT+y+4++++H+++O+";

		var expected = new TDT_TransportInformation()
		{
			TransportStageCodeQualifier = "y",
			MeansOfTransportJourneyIdentifier = "4",
			ModeOfTransport = null,
			TransportMeans = null,
			Carrier = null,
			TransitDirectionIndicatorCode = "H",
			ExcessTransportationInformation = null,
			TransportIdentification = null,
			TransportMeansOwnershipIndicatorCode = "O",
			PowerType = null,
		};

		var actual = Map.MapObject<TDT_TransportInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredTransportStageCodeQualifier(string transportStageCodeQualifier, bool isValidExpected)
	{
		var subject = new TDT_TransportInformation();
		//Required fields
		//Test Parameters
		subject.TransportStageCodeQualifier = transportStageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
