using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PTDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PTD*Z8*36b*3*oA*O*1N";

		var expected = new PTD_ProductTransferAndResaleDetail()
		{
			ProductTransferTypeCode = "Z8",
			PriceMultiplierQualifier = "36b",
			Multiplier = 3,
			ReferenceIdentificationQualifier = "oA",
			ReferenceIdentification = "O",
			ProductTransferMovementTypeCode = "1N",
		};

		var actual = Map.MapObject<PTD_ProductTransferAndResaleDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z8", true)]
	public void Validation_RequiredProductTransferTypeCode(string productTransferTypeCode, bool isValidExpected)
	{
		var subject = new PTD_ProductTransferAndResaleDetail();
		subject.ProductTransferTypeCode = productTransferTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("36b", 3, true)]
	[InlineData("", 3, false)]
	[InlineData("36b", 0, false)]
	public void Validation_AllAreRequiredPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
	{
		var subject = new PTD_ProductTransferAndResaleDetail();
		subject.ProductTransferTypeCode = "Z8";
		subject.PriceMultiplierQualifier = priceMultiplierQualifier;
		if (multiplier > 0)
		subject.Multiplier = multiplier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("oA", "O", true)]
	[InlineData("", "O", false)]
	[InlineData("oA", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PTD_ProductTransferAndResaleDetail();
		subject.ProductTransferTypeCode = "Z8";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
