using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class APITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "API*HL*s*7be*oPw*Z*P*O*Z";

		var expected = new API_ActivityOrProcessInformation()
		{
			CodeCategory = "HL",
			ActionCode = "s",
			MaintenanceTypeCode = "7be",
			StatusReasonCode = "oPw",
			AffectedAreaOrSectionCode = "Z",
			InsuranceTypeCode = "P",
			LoanTypeCode = "O",
			InformationStatusCode = "Z",
		};

		var actual = Map.MapObject<API_ActivityOrProcessInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HL", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new API_ActivityOrProcessInformation();
		//Required fields
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
