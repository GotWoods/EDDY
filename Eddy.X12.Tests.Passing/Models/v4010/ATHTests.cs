using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ATHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATH*3S*DHzB0YRD*2*3*i0BicPWn";

		var expected = new ATH_ResourceAuthorization()
		{
			ResourceAuthorizationCode = "3S",
			Date = "DHzB0YRD",
			Quantity = 2,
			Quantity2 = 3,
			Date2 = "i0BicPWn",
		};

		var actual = Map.MapObject<ATH_ResourceAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3S", true)]
	public void Validation_RequiredResourceAuthorizationCode(string resourceAuthorizationCode, bool isValidExpected)
	{
		var subject = new ATH_ResourceAuthorization();
		subject.ResourceAuthorizationCode = resourceAuthorizationCode;
			subject.Date = "DHzB0YRD";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("DHzB0YRD", 2, true)]
	[InlineData("DHzB0YRD", 0, true)]
	[InlineData("", 2, true)]
	public void Validation_AtLeastOneDate(string date, decimal quantity, bool isValidExpected)
	{
		var subject = new ATH_ResourceAuthorization();
		subject.ResourceAuthorizationCode = "3S";
		subject.Date = date;
		if (quantity > 0)
			subject.Quantity = quantity;
		if (quantity > 0)
			subject.Date2 = "i0BicPWn";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "i0BicPWn", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "i0BicPWn", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string date2, bool isValidExpected)
	{
		var subject = new ATH_ResourceAuthorization();
		subject.ResourceAuthorizationCode = "3S";
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.Date2 = date2;
			subject.Date = "DHzB0YRD";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "i0BicPWn", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "i0BicPWn", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string date2, bool isValidExpected)
	{
		var subject = new ATH_ResourceAuthorization();
		subject.ResourceAuthorizationCode = "3S";
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		subject.Date2 = date2;
			subject.Date = "DHzB0YRD";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
