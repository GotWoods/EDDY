using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DSBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DSB*Z*2*LmyY*K*P*7*yK*w";

		var expected = new DSB_DisabilityInformation()
		{
			DisabilityTypeCode = "Z",
			Quantity = 2,
			OccupationCode = "LmyY",
			WorkIntensityCode = "K",
			ProductOptionCode = "P",
			MonetaryAmount = 7,
			ProductServiceIDQualifier = "yK",
			MedicalCodeValue = "w",
		};

		var actual = Map.MapObject<DSB_DisabilityInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredDisabilityTypeCode(string disabilityTypeCode, bool isValidExpected)
	{
		var subject = new DSB_DisabilityInformation();
		//Required fields
		//Test Parameters
		subject.DisabilityTypeCode = disabilityTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.MedicalCodeValue))
		{
			subject.ProductServiceIDQualifier = "yK";
			subject.MedicalCodeValue = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yK", "w", true)]
	[InlineData("yK", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string medicalCodeValue, bool isValidExpected)
	{
		var subject = new DSB_DisabilityInformation();
		//Required fields
		subject.DisabilityTypeCode = "Z";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.MedicalCodeValue = medicalCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
