using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAD*A*7*7*Ar*C*bc*0i*6*XU";

		var expected = new CAD_CarrierDetail()
		{
			TransportationMethodTypeCode = "A",
			EquipmentInitial = "7",
			EquipmentNumber = "7",
			StandardCarrierAlphaCode = "Ar",
			Routing = "C",
			ShipmentOrderStatusCode = "bc",
			ReferenceIdentificationQualifier = "0i",
			ReferenceIdentification = "6",
			ServiceLevelCode = "XU",
		};

		var actual = Map.MapObject<CAD_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("C", "Ar", true)]
	[InlineData("C", "", true)]
	[InlineData("", "Ar", true)]
	public void Validation_AtLeastOneRouting(string routing, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetail();
		subject.Routing = routing;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0i", "6", true)]
	[InlineData("0i", "", false)]
	[InlineData("", "6", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetail();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
			subject.Routing = "C";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
