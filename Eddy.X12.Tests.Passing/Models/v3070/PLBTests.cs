using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070.Composites;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PLBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLB*a*sBQYo4**8**3**3**8**2**7";

		var expected = new PLB_ProviderLevelAdjustment()
		{
			ReferenceIdentification = "a",
			Date = "sBQYo4",
			AdjustmentIdentifier = null,
			MonetaryAmount = 8,
			AdjustmentIdentifier2 = null,
			MonetaryAmount2 = 3,
			AdjustmentIdentifier3 = null,
			MonetaryAmount3 = 3,
			AdjustmentIdentifier4 = null,
			MonetaryAmount4 = 8,
			AdjustmentIdentifier5 = null,
			MonetaryAmount5 = 2,
			AdjustmentIdentifier6 = null,
			MonetaryAmount6 = 7,
		};

		var actual = Map.MapObject<PLB_ProviderLevelAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.Date = "sBQYo4";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sBQYo4", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "a";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		subject.MonetaryAmount = 8;
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
		subject.ReferenceIdentification = "a";
		subject.Date = "sBQYo4";
		subject.MonetaryAmount = 8;
		//Test Parameters
		if (adjustmentIdentifier != "") 
			subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "a";
		subject.Date = "sBQYo4";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
