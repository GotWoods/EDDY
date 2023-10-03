using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4030.Composites;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class PLBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLB*Y*hIq6ThiO**2**9**4**8**1**2";

		var expected = new PLB_ProviderLevelAdjustment()
		{
			ReferenceIdentification = "Y",
			Date = "hIq6ThiO",
			AdjustmentIdentifier = null,
			MonetaryAmount = 2,
			AdjustmentIdentifier2 = null,
			MonetaryAmount2 = 9,
			AdjustmentIdentifier3 = null,
			MonetaryAmount3 = 4,
			AdjustmentIdentifier4 = null,
			MonetaryAmount4 = 8,
			AdjustmentIdentifier5 = null,
			MonetaryAmount5 = 1,
			AdjustmentIdentifier6 = null,
			MonetaryAmount6 = 2,
		};

		var actual = Map.MapObject<PLB_ProviderLevelAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.Date = "hIq6ThiO";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hIq6ThiO", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "Y";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		subject.MonetaryAmount = 2;
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
		subject.ReferenceIdentification = "Y";
		subject.Date = "hIq6ThiO";
		subject.MonetaryAmount = 2;
		//Test Parameters
		if (adjustmentIdentifier != "") 
			subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "Y";
		subject.Date = "hIq6ThiO";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
