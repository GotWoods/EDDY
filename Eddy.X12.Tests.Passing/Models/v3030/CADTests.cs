using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAD*3*Y*m*OA*Q*1s*fZ*A*eq";

		var expected = new CAD_CarrierDetail()
		{
			TransportationMethodTypeCode = "3",
			EquipmentInitial = "Y",
			EquipmentNumber = "m",
			StandardCarrierAlphaCode = "OA",
			Routing = "Q",
			ShipmentOrderStatusCode = "1s",
			ReferenceNumberQualifier = "fZ",
			ReferenceNumber = "A",
			ServiceLevelCode = "eq",
		};

		var actual = Map.MapObject<CAD_CarrierDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Q", "OA", true)]
	[InlineData("Q", "", true)]
	[InlineData("", "OA", true)]
	public void Validation_AtLeastOneRouting(string routing, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetail();
		subject.Routing = routing;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fZ", "A", true)]
	[InlineData("fZ", "", false)]
	[InlineData("", "A", true)]
	public void Validation_ARequiresBReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new CAD_CarrierDetail();
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
			subject.Routing = "Q";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
