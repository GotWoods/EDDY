using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class FOBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FOB*Cz*P*r*jM*SCz*D*9*5B*L";

		var expected = new FOB_FOBRelatedInstructions()
		{
			ShipmentMethodOfPaymentCode = "Cz",
			LocationQualifier = "P",
			Description = "r",
			TransportationTermsQualifierCode = "jM",
			TransportationTermsCode = "SCz",
			LocationQualifier2 = "D",
			Description2 = "9",
			RiskOfLossCode = "5B",
			Description3 = "L",
		};

		var actual = Map.MapObject<FOB_FOBRelatedInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cz", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "P", true)]
	[InlineData("r", "", false)]
	[InlineData("", "P", true)]
	public void Validation_ARequiresBDescription(string description, string locationQualifier, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPaymentCode = "Cz";
		subject.Description = description;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jM", "SCz", true)]
	[InlineData("jM", "", false)]
	[InlineData("", "SCz", true)]
	public void Validation_ARequiresBTransportationTermsQualifierCode(string transportationTermsQualifierCode, string transportationTermsCode, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPaymentCode = "Cz";
		subject.TransportationTermsQualifierCode = transportationTermsQualifierCode;
		subject.TransportationTermsCode = transportationTermsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "D", true)]
	[InlineData("9", "", false)]
	[InlineData("", "D", true)]
	public void Validation_ARequiresBDescription2(string description2, string locationQualifier2, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPaymentCode = "Cz";
		subject.Description2 = description2;
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5B", "L", true)]
	[InlineData("5B", "", false)]
	[InlineData("", "L", true)]
	public void Validation_ARequiresBRiskOfLossCode(string riskOfLossCode, string description3, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPaymentCode = "Cz";
		subject.RiskOfLossCode = riskOfLossCode;
		subject.Description3 = description3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
