using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class APITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "API*Dr*1*7sv*oxQ*d*m*b";

		var expected = new API_ActivityOrProcessInformation()
		{
			CodeCategory = "Dr",
			ActionCode = "1",
			MaintenanceTypeCode = "7sv",
			StatusReasonCode = "oxQ",
			AffectedAreaOrSectionCode = "d",
			InsuranceTypeCode = "m",
			LoanTypeCode = "b",
		};

		var actual = Map.MapObject<API_ActivityOrProcessInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dr", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new API_ActivityOrProcessInformation();
		//Required fields
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
