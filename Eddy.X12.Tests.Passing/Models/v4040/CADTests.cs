using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class CADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAD*A*R*B*P2*u*fT*U6*F*9I";

		var expected = new CAD_CarrierDetail()
		{
			TransportationMethodTypeCode = "A",
			EquipmentInitial = "R",
			EquipmentNumber = "B",
			StandardCarrierAlphaCode = "P2",
			Routing = "u",
			ShipmentOrderStatusCode = "fT",
			ReferenceIdentificationQualifier = "U6",
			ReferenceIdentification = "F",
			ServiceLevelCode = "9I",
		};

		var actual = Map.MapObject<CAD_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("u", "P2", true)]
	[InlineData("u", "", true)]
	[InlineData("", "P2", true)]
	public void Validation_AtLeastOneRouting(string routing, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetail();
		subject.Routing = routing;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U6", "F", true)]
	[InlineData("U6", "", false)]
	[InlineData("", "F", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetail();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
			subject.Routing = "u";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
