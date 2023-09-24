using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAD*9*Oq*QL*cgV*9";

		var expected = new PAD_ProductAdjustmentDetail()
		{
			AssignedIdentification = "9",
			ProductTransferTypeCode = "Oq",
			ChangeOrResponseTypeCode = "QL",
			PriceMultiplierQualifier = "cgV",
			Multiplier = 9,
		};

		var actual = Map.MapObject<PAD_ProductAdjustmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("9", "Oq", true)]
	[InlineData("9", "", true)]
	[InlineData("", "Oq", true)]
	public void Validation_AtLeastOneAssignedIdentification(string assignedIdentification, string productTransferTypeCode, bool isValidExpected)
	{
		var subject = new PAD_ProductAdjustmentDetail();
		subject.AssignedIdentification = assignedIdentification;
		subject.ProductTransferTypeCode = productTransferTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || !string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || subject.Multiplier > 0)
		{
			subject.PriceMultiplierQualifier = "cgV";
			subject.Multiplier = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("cgV", 9, true)]
	[InlineData("cgV", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
	{
		var subject = new PAD_ProductAdjustmentDetail();
		subject.PriceMultiplierQualifier = priceMultiplierQualifier;
		if (multiplier > 0)
			subject.Multiplier = multiplier;
			subject.AssignedIdentification = "9";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
