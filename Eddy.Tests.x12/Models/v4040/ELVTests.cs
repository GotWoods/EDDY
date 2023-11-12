using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class ELVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ELV*Wd*H*8*3*4*6";

		var expected = new ELV_EmployeeLeaveSummary()
		{
			EmploymentStatusCode = "Wd",
			YesNoConditionOrResponseCode = "H",
			Quantity = 8,
			Quantity2 = 3,
			Quantity3 = 4,
			Quantity4 = 6,
		};

		var actual = Map.MapObject<ELV_EmployeeLeaveSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wd", true)]
	public void Validation_RequiredEmploymentStatusCode(string employmentStatusCode, bool isValidExpected)
	{
		var subject = new ELV_EmployeeLeaveSummary();
		//Required fields
		//Test Parameters
		subject.EmploymentStatusCode = employmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
