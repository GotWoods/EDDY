using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class CADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAD*s*e*7*YC*s*No*vk*g*Hu";

		var expected = new CAD_CarrierDetails()
		{
			TransportationMethodTypeCode = "s",
			EquipmentInitial = "e",
			EquipmentNumber = "7",
			StandardCarrierAlphaCode = "YC",
			Routing = "s",
			ShipmentOrderStatusCode = "No",
			ReferenceIdentificationQualifier = "vk",
			ReferenceIdentification = "g",
			ServiceLevelCode = "Hu",
		};

		var actual = Map.MapObject<CAD_CarrierDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetails();
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.Routing = "s";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("s", "YC", true)]
	[InlineData("s", "", true)]
	[InlineData("", "YC", true)]
	public void Validation_AtLeastOneRouting(string routing, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetails();
		subject.TransportationMethodTypeCode = "s";
		subject.Routing = routing;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vk", "g", true)]
	[InlineData("vk", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetails();
		subject.TransportationMethodTypeCode = "s";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
			subject.Routing = "s";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
