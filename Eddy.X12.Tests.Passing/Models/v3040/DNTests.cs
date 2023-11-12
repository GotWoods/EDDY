using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class DNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DN*XN*C145EI*28l*2Qr";

		var expected = new DN_DealerEffectivity()
		{
			DateQualifier = "XN",
			Date = "C145EI",
			DemandArea = "28l",
			FinancialStatus = "2Qr",
		};

		var actual = Map.MapObject<DN_DealerEffectivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XN", true)]
	public void Validation_RequiredDateQualifier(string dateQualifier, bool isValidExpected)
	{
		var subject = new DN_DealerEffectivity();
		//Required fields
		subject.Date = "C145EI";
		//Test Parameters
		subject.DateQualifier = dateQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C145EI", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DN_DealerEffectivity();
		//Required fields
		subject.DateQualifier = "XN";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
