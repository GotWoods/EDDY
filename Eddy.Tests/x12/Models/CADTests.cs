using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAD*d*m*A*Kn*p*Pp*gl*U*aO";

		var expected = new CAD_CarrierDetails()
		{
			TransportationMethodTypeCode = "d",
			EquipmentInitial = "m",
			EquipmentNumber = "A",
			StandardCarrierAlphaCode = "Kn",
			Routing = "p",
			ShipmentOrderStatusCode = "Pp",
			ReferenceIdentificationQualifier = "gl",
			ReferenceIdentification = "U",
			ServiceLevelCode = "aO",
		};

		var actual = Map.MapObject<CAD_CarrierDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validatation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetails();
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;

		subject.StandardCarrierAlphaCode = "ABCD";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("p","Kn", true)]
	[InlineData("", "Kn", true)]
	[InlineData("p", "", true)]
	public void Validation_AtLeastOneRouting(string routing, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetails();
		subject.TransportationMethodTypeCode = "d";
		subject.Routing = routing;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "U", true)]
	[InlineData("gl", "", false)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetails();
		subject.TransportationMethodTypeCode = "d";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
        
        subject.StandardCarrierAlphaCode = "ABCD";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
