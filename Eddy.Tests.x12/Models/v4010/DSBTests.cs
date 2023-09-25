using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DSBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DSB*l*4*fD92*x*s*7*14*v";

		var expected = new DSB_DisabilityInformation()
		{
			DisabilityTypeCode = "l",
			Quantity = 4,
			OccupationCode = "fD92",
			WorkIntensityCode = "x",
			ProductOptionCode = "s",
			MonetaryAmount = 7,
			ProductServiceIDQualifier = "14",
			MedicalCodeValue = "v",
		};

		var actual = Map.MapObject<DSB_DisabilityInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredDisabilityTypeCode(string disabilityTypeCode, bool isValidExpected)
	{
		var subject = new DSB_DisabilityInformation();
		//Required fields
		//Test Parameters
		subject.DisabilityTypeCode = disabilityTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.MedicalCodeValue))
		{
			subject.ProductServiceIDQualifier = "14";
			subject.MedicalCodeValue = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("14", "v", true)]
	[InlineData("14", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string medicalCodeValue, bool isValidExpected)
	{
		var subject = new DSB_DisabilityInformation();
		//Required fields
		subject.DisabilityTypeCode = "l";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.MedicalCodeValue = medicalCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
