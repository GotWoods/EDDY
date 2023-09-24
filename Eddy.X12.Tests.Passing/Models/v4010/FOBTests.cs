using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class FOBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FOB*pP*C*a*y1*rre*G*j*1n*a";

		var expected = new FOB_FOBRelatedInstructions()
		{
			ShipmentMethodOfPayment = "pP",
			LocationQualifier = "C",
			Description = "a",
			TransportationTermsQualifierCode = "y1",
			TransportationTermsCode = "rre",
			LocationQualifier2 = "G",
			Description2 = "j",
			RiskOfLossCode = "1n",
			Description3 = "a",
		};

		var actual = Map.MapObject<FOB_FOBRelatedInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pP", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "C", true)]
	[InlineData("a", "", false)]
	[InlineData("", "C", true)]
	public void Validation_ARequiresBDescription(string description, string locationQualifier, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPayment = "pP";
		subject.Description = description;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y1", "rre", true)]
	[InlineData("y1", "", false)]
	[InlineData("", "rre", true)]
	public void Validation_ARequiresBTransportationTermsQualifierCode(string transportationTermsQualifierCode, string transportationTermsCode, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPayment = "pP";
		subject.TransportationTermsQualifierCode = transportationTermsQualifierCode;
		subject.TransportationTermsCode = transportationTermsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "G", true)]
	[InlineData("j", "", false)]
	[InlineData("", "G", true)]
	public void Validation_ARequiresBDescription2(string description2, string locationQualifier2, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPayment = "pP";
		subject.Description2 = description2;
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1n", "a", true)]
	[InlineData("1n", "", false)]
	[InlineData("", "a", true)]
	public void Validation_ARequiresBRiskOfLossCode(string riskOfLossCode, string description3, bool isValidExpected)
	{
		var subject = new FOB_FOBRelatedInstructions();
		subject.ShipmentMethodOfPayment = "pP";
		subject.RiskOfLossCode = riskOfLossCode;
		subject.Description3 = description3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
