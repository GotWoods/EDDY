using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class TDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TDT+x+t++++D+++x";

		var expected = new TDT_DetailsOfTransport()
		{
			TransportStageQualifier = "x",
			ConveyanceReferenceNumber = "t",
			ModeOfTransport = null,
			TransportMeans = null,
			Carrier = null,
			TransitDirectionCoded = "D",
			ExcessTransportationInformation = null,
			TransportIdentification = null,
			TransportOwnershipCoded = "x",
		};

		var actual = Map.MapObject<TDT_DetailsOfTransport>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredTransportStageQualifier(string transportStageQualifier, bool isValidExpected)
	{
		var subject = new TDT_DetailsOfTransport();
		//Required fields
		//Test Parameters
		subject.TransportStageQualifier = transportStageQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
