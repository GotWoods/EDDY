using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DN*Pc*Y3Yp5GMa*NVE*OYZ";

		var expected = new DN_DealerEffectivity()
		{
			DateQualifier = "Pc",
			Date = "Y3Yp5GMa",
			DemandArea = "NVE",
			FinancialStatus = "OYZ",
		};

		var actual = Map.MapObject<DN_DealerEffectivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pc", true)]
	public void Validation_RequiredDateQualifier(string dateQualifier, bool isValidExpected)
	{
		var subject = new DN_DealerEffectivity();
		//Required fields
		subject.Date = "Y3Yp5GMa";
		//Test Parameters
		subject.DateQualifier = dateQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y3Yp5GMa", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DN_DealerEffectivity();
		//Required fields
		subject.DateQualifier = "Pc";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
