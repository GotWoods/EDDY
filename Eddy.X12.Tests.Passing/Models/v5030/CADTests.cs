using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAD*N*h*P*He*v*iW*zn*u*LJ";

		var expected = new CAD_CarrierDetails()
		{
			TransportationMethodTypeCode = "N",
			EquipmentInitial = "h",
			EquipmentNumber = "P",
			StandardCarrierAlphaCode = "He",
			Routing = "v",
			ShipmentOrderStatusCode = "iW",
			ReferenceIdentificationQualifier = "zn",
			ReferenceIdentification = "u",
			ServiceLevelCode = "LJ",
		};

		var actual = Map.MapObject<CAD_CarrierDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetails();
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
			subject.Routing = "v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("v", "He", true)]
	[InlineData("v", "", true)]
	[InlineData("", "He", true)]
	public void Validation_AtLeastOneRouting(string routing, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetails();
		subject.TransportationMethodTypeCode = "N";
		subject.Routing = routing;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zn", "u", true)]
	[InlineData("zn", "", false)]
	[InlineData("", "u", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetails();
		subject.TransportationMethodTypeCode = "N";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
			subject.Routing = "v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
