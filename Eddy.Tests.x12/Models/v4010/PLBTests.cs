using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PLBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLB*h*GLCKWwbX**8**5**5**4**7**9";

		var expected = new PLB_ProviderLevelAdjustment()
		{
			ReferenceIdentification = "h",
			Date = "GLCKWwbX",
			AdjustmentIdentifier = null,
			MonetaryAmount = 8,
			AdjustmentIdentifier2 = null,
			MonetaryAmount2 = 5,
			AdjustmentIdentifier3 = null,
			MonetaryAmount3 = 5,
			AdjustmentIdentifier4 = null,
			MonetaryAmount4 = 4,
			AdjustmentIdentifier5 = null,
			MonetaryAmount5 = 7,
			AdjustmentIdentifier6 = null,
			MonetaryAmount6 = 9,
		};

		var actual = Map.MapObject<PLB_ProviderLevelAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.Date = "GLCKWwbX";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GLCKWwbX", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PLB_ProviderLevelAdjustment();
		//Required fields
		subject.ReferenceIdentification = "h";
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
		subject.ReferenceIdentification = "h";
		subject.Date = "GLCKWwbX";
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
		subject.ReferenceIdentification = "h";
		subject.Date = "GLCKWwbX";
		subject.AdjustmentIdentifier = new C042_AdjustmentIdentifier();
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
