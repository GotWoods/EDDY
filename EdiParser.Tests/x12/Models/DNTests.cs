using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DN*iv*hfqOZoCE*7De*AyZ";

		var expected = new DN_DealerEffectivity()
		{
			DateQualifier = "iv",
			Date = "hfqOZoCE",
			DemandArea = "7De",
			FinancialStatus = "AyZ",
		};

		var actual = Map.MapObject<DN_DealerEffectivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iv", true)]
	public void Validatation_RequiredDateQualifier(string dateQualifier, bool isValidExpected)
	{
		var subject = new DN_DealerEffectivity();
		subject.Date = "hfqOZoCE";
		subject.DateQualifier = dateQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hfqOZoCE", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DN_DealerEffectivity();
		subject.DateQualifier = "iv";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
