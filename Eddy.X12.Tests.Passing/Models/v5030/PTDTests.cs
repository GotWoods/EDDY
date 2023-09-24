using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PTDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PTD*7t*drP*4*KD*7*bl";

		var expected = new PTD_ProductTransferAndResaleDetail()
		{
			ProductTransferTypeCode = "7t",
			PriceMultiplierQualifier = "drP",
			Multiplier = 4,
			ReferenceIdentificationQualifier = "KD",
			ReferenceIdentification = "7",
			ProductTransferMovementTypeCode = "bl",
		};

		var actual = Map.MapObject<PTD_ProductTransferAndResaleDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7t", true)]
	public void Validation_RequiredProductTransferTypeCode(string productTransferTypeCode, bool isValidExpected)
	{
		var subject = new PTD_ProductTransferAndResaleDetail();
		subject.ProductTransferTypeCode = productTransferTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || !string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || subject.Multiplier > 0)
		{
			subject.PriceMultiplierQualifier = "drP";
			subject.Multiplier = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "KD";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("drP", 4, true)]
	[InlineData("drP", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
	{
		var subject = new PTD_ProductTransferAndResaleDetail();
		subject.ProductTransferTypeCode = "7t";
		subject.PriceMultiplierQualifier = priceMultiplierQualifier;
		if (multiplier > 0)
			subject.Multiplier = multiplier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "KD";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KD", "7", true)]
	[InlineData("KD", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PTD_ProductTransferAndResaleDetail();
		subject.ProductTransferTypeCode = "7t";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || !string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || subject.Multiplier > 0)
		{
			subject.PriceMultiplierQualifier = "drP";
			subject.Multiplier = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
