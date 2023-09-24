using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAD*i*e*e*Pc*n*Y8*Rg*H*8U";

		var expected = new CAD_CarrierDetail()
		{
			TransportationMethodTypeCode = "i",
			EquipmentInitial = "e",
			EquipmentNumber = "e",
			StandardCarrierAlphaCode = "Pc",
			Routing = "n",
			ShipmentOrderStatusCode = "Y8",
			ReferenceIdentificationQualifier = "Rg",
			ReferenceIdentification = "H",
			ServiceLevelCode = "8U",
		};

		var actual = Map.MapObject<CAD_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("n", "Pc", true)]
	[InlineData("n", "", true)]
	[InlineData("", "Pc", true)]
	public void Validation_AtLeastOneRouting(string routing, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetail();
		subject.Routing = routing;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Rg", "H", true)]
	[InlineData("Rg", "", false)]
	[InlineData("", "H", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetail();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
			subject.Routing = "n";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
