using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAD*y*P*T*rJ*S*Nh*7h*c";

		var expected = new CAD_CarrierDetail()
		{
			TransportationMethodTypeCode = "y",
			EquipmentInitial = "P",
			EquipmentNumber = "T",
			StandardCarrierAlphaCode = "rJ",
			Routing = "S",
			ShipmentOrderStatusCode = "Nh",
			ReferenceNumberQualifier = "7h",
			ReferenceNumber = "c",
		};

		var actual = Map.MapObject<CAD_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("S", "rJ", true)]
	[InlineData("S", "", true)]
	[InlineData("", "rJ", true)]
	public void Validation_AtLeastOneRouting(string routing, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetail();
		subject.Routing = routing;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7h", "c", true)]
	[InlineData("7h", "", false)]
	[InlineData("", "c", true)]
	public void Validation_ARequiresBReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetail();
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
			subject.Routing = "S";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
