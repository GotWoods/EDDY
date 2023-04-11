using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ELVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ELV*9q*y*7*7*9*3";

		var expected = new ELV_EmployeeLeaveSummary()
		{
			EmploymentStatusCode = "9q",
			YesNoConditionOrResponseCode = "y",
			Quantity = 7,
			Quantity2 = 7,
			Quantity3 = 9,
			Quantity4 = 3,
		};

		var actual = Map.MapObject<ELV_EmployeeLeaveSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9q", true)]
	public void Validatation_RequiredEmploymentStatusCode(string employmentStatusCode, bool isValidExpected)
	{
		var subject = new ELV_EmployeeLeaveSummary();
		subject.EmploymentStatusCode = employmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
