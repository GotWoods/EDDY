using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DSBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DSB*A*2*pcnP*m*t*1*6D*u";

		var expected = new DSB_DisabilityInformation()
		{
			DisabilityTypeCode = "A",
			Quantity = 2,
			OccupationCode = "pcnP",
			WorkIntensityCode = "m",
			ProductOptionCode = "t",
			MonetaryAmount = 1,
			ProductServiceIDQualifier = "6D",
			MedicalCodeValue = "u",
		};

		var actual = Map.MapObject<DSB_DisabilityInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validatation_RequiredDisabilityTypeCode(string disabilityTypeCode, bool isValidExpected)
	{
		var subject = new DSB_DisabilityInformation();
		subject.DisabilityTypeCode = disabilityTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("6D", "u", true)]
	[InlineData("", "u", false)]
	[InlineData("6D", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string medicalCodeValue, bool isValidExpected)
	{
		var subject = new DSB_DisabilityInformation();
		subject.DisabilityTypeCode = "A";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.MedicalCodeValue = medicalCodeValue;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
