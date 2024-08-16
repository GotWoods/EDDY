using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class TDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TDT+P+F++++b+++H";

		var expected = new TDT_DetailsOfTransport()
		{
			TransportStageCodeQualifier = "P",
			ConveyanceReferenceNumber = "F",
			ModeOfTransport = null,
			TransportMeans = null,
			Carrier = null,
			TransitDirectionIndicatorCode = "b",
			ExcessTransportationInformation = null,
			TransportIdentification = null,
			TransportOwnershipCoded = "H",
		};

		var actual = Map.MapObject<TDT_DetailsOfTransport>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredTransportStageCodeQualifier(string transportStageCodeQualifier, bool isValidExpected)
	{
		var subject = new TDT_DetailsOfTransport();
		//Required fields
		//Test Parameters
		subject.TransportStageCodeQualifier = transportStageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
