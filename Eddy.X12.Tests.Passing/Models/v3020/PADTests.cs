using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAD*8*Q1*BA*2K3*3";

		var expected = new PAD_ProductAdjustmentDetail()
		{
			AssignedIdentification = "8",
			ProductTransferTypeCode = "Q1",
			ChangeOrResponseTypeCode = "BA",
			PriceMultiplierQualifier = "2K3",
			Multiplier = 3,
		};

		var actual = Map.MapObject<PAD_ProductAdjustmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("8", "Q1", true)]
	[InlineData("8", "", true)]
	[InlineData("", "Q1", true)]
	public void Validation_AtLeastOneAssignedIdentification(string assignedIdentification, string productTransferTypeCode, bool isValidExpected)
	{
		var subject = new PAD_ProductAdjustmentDetail();
		subject.AssignedIdentification = assignedIdentification;
		subject.ProductTransferTypeCode = productTransferTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || !string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || subject.Multiplier > 0)
		{
			subject.PriceMultiplierQualifier = "2K3";
			subject.Multiplier = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2K3", 3, true)]
	[InlineData("2K3", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
	{
		var subject = new PAD_ProductAdjustmentDetail();
		subject.PriceMultiplierQualifier = priceMultiplierQualifier;
		if (multiplier > 0)
			subject.Multiplier = multiplier;
			subject.AssignedIdentification = "8";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
