using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class FOBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FOB*Wv*e*o*10*s9T*M*v*jG*p";

		var expected = new FOB_FOBRelatedInstructions()
		{
			ShipmentMethodOfPayment = "Wv",
			LocationQualifier = "e",
			Description = "o",
			TransportationTermsQualifierCode = "10",
			TransportationTermsCode = "s9T",
			LocationQualifier2 = "M",
			Description2 = "v",
			RiskOfLossQualifier = "jG",
			Description3 = "p",
		};

		var actual = Map.MapObject<FOB_FOBRelatedInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wv", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "e", true)]
	[InlineData("o", "", false)]
	[InlineData("", "e", true)]
	public void Validation_ARequiresBDescription(string description, string locationQualifier, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPayment = "Wv";
		subject.Description = description;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("10", "s9T", true)]
	[InlineData("10", "", false)]
	[InlineData("", "s9T", true)]
	public void Validation_ARequiresBTransportationTermsQualifierCode(string transportationTermsQualifierCode, string transportationTermsCode, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPayment = "Wv";
		subject.TransportationTermsQualifierCode = transportationTermsQualifierCode;
		subject.TransportationTermsCode = transportationTermsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "M", true)]
	[InlineData("v", "", false)]
	[InlineData("", "M", true)]
	public void Validation_ARequiresBDescription2(string description2, string locationQualifier2, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPayment = "Wv";
		subject.Description2 = description2;
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jG", "p", true)]
	[InlineData("jG", "", false)]
	[InlineData("", "p", true)]
	public void Validation_ARequiresBRiskOfLossQualifier(string riskOfLossQualifier, string description3, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPayment = "Wv";
		subject.RiskOfLossQualifier = riskOfLossQualifier;
		subject.Description3 = description3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
