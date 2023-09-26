using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PLBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLB*p*wVJZaUC4**4**1**6**7**6**2";

		var expected = new PLB_ProviderLevelAdjustment()
		{
			ReferenceIdentification = "p",
			Date = "wVJZaUC4",
			AdjustmentIdentifier = null,
			MonetaryAmount = 4,
			AdjustmentIdentifier2 = null,
			MonetaryAmount2 = 1,
			AdjustmentIdentifier3 = null,
			MonetaryAmount3 = 6,
			AdjustmentIdentifier4 = null,
			MonetaryAmount4 = 7,
			AdjustmentIdentifier5 = null,
			MonetaryAmount5 = 6,
			AdjustmentIdentifier6 = null,
			MonetaryAmount6 = 2,
		};

		var actual = Map.MapObject<PLB_ProviderLevelAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.Date = "wVJZaUC4";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wVJZaUC4", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "p";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAdjustmentIdentifier(string adjustmentIdentifier, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "p";
		subject.Date = "wVJZaUC4";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (adjustmentIdentifier != "") 
			subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "p";
		subject.Date = "wVJZaUC4";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
