using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class PLBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLB*F*4lIsbbVG**4**8**8**3**3**5";

		var expected = new PLB_ProviderLevelAdjustment()
		{
			ReferenceIdentification = "F",
			Date = "4lIsbbVG",
			AdjustmentIdentifier = null,
			MonetaryAmount = 4,
			AdjustmentIdentifier2 = null,
			MonetaryAmount2 = 8,
			AdjustmentIdentifier3 = null,
			MonetaryAmount3 = 8,
			AdjustmentIdentifier4 = null,
			MonetaryAmount4 = 3,
			AdjustmentIdentifier5 = null,
			MonetaryAmount5 = 3,
			AdjustmentIdentifier6 = null,
			MonetaryAmount6 = 5,
		};

		var actual = Map.MapObject<PLB_ProviderLevelAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		subject.Date = "4lIsbbVG";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		subject.MonetaryAmount = 4;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4lIsbbVG", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		subject.ReferenceIdentification = "F";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		subject.MonetaryAmount = 4;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredAdjustmentIdentifier(string adjustmentIdentifier, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		subject.ReferenceIdentification = "F";
		subject.Date = "4lIsbbVG";
		subject.MonetaryAmount = 4;

        if (adjustmentIdentifier != "")
            subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier() { IndustryCode = adjustmentIdentifier };
        
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		subject.ReferenceIdentification = "F";
		subject.Date = "4lIsbbVG";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
