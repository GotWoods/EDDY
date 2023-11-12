using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SV3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV3*VZ*C*4*h*2*9*N*k*2*4*q*6";

		var expected = new SV3_DentalService()
		{
			ProductServiceIDQualifier = "VZ",
			ProductServiceID = "C",
			MonetaryAmount = 4,
			FacilityCode = "h",
			ReferenceNumber = "2",
			ToothSurfaceCode = "9",
			DentalQuadrantCode = "N",
			ProsthesisCrownOrInlayCode = "k",
			Quantity = 2,
			Description = "4",
			CopayStatusCode = "q",
			ProviderAgreementCode = "6",
		};

		var actual = Map.MapObject<SV3_DentalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VZ", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new SV3_DentalService();
		//Required fields
		subject.ProductServiceID = "C";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SV3_DentalService();
		//Required fields
		subject.ProductServiceIDQualifier = "VZ";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
