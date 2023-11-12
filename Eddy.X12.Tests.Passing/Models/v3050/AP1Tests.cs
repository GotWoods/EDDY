using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class AP1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AP1*MM*oV*DMe*9*1*MmF*9RP*8Y*1*2*d*4*T";

		var expected = new AP1_AlternateParts()
		{
			StatusCode = "MM",
			StateOrProvinceCode = "oV",
			PriceIdentifierCode = "DMe",
			Percent = 9,
			MonetaryAmount = 1,
			PostalCode = "MmF",
			PostalCode2 = "9RP",
			PrintOptionCode = "8Y",
			Number = 1,
			Quantity = 2,
			FreeFormMessage = "d",
			ProductServiceID = "4",
			Description = "T",
		};

		var actual = Map.MapObject<AP1_AlternateParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MM", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		//Test Parameters
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9RP", "MmF", true)]
	[InlineData("9RP", "", false)]
	[InlineData("", "MmF", true)]
	public void Validation_ARequiresBPostalCode2(string postalCode2, string postalCode, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		subject.StatusCode = "MM";
		//Test Parameters
		subject.PostalCode2 = postalCode2;
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
