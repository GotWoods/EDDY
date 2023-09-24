using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ATHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATH*Yk*b098MM*1*8*ooXbO1";

		var expected = new ATH_ResourceAuthorization()
		{
			ResourceAuthorizationCode = "Yk",
			Date = "b098MM",
			Quantity = 1,
			Quantity2 = 8,
			Date2 = "ooXbO1",
		};

		var actual = Map.MapObject<ATH_ResourceAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yk", true)]
	public void Validation_RequiredResourceAuthorizationCode(string resourceAuthorizationCode, bool isValidExpected)
	{
		var subject = new ATH_ResourceAuthorization();
		subject.ResourceAuthorizationCode = resourceAuthorizationCode;
			subject.Date = "b098MM";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("b098MM", 1, true)]
	[InlineData("b098MM", 0, true)]
	[InlineData("", 1, true)]
	public void Validation_AtLeastOneDate(string date, decimal quantity, bool isValidExpected)
	{
		var subject = new ATH_ResourceAuthorization();
		subject.ResourceAuthorizationCode = "Yk";
		subject.Date = date;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity > 0)
			subject.Date2 = "ooXbO1";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "ooXbO1", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "ooXbO1", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string date2, bool isValidExpected)
	{
		var subject = new ATH_ResourceAuthorization();
		subject.ResourceAuthorizationCode = "Yk";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.Date2 = date2;
			subject.Date = "b098MM";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "ooXbO1", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "ooXbO1", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string date2, bool isValidExpected)
	{
		var subject = new ATH_ResourceAuthorization();
		subject.ResourceAuthorizationCode = "Yk";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		subject.Date2 = date2;
			subject.Date = "b098MM";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
