using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class CMNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CMN+";

		var expected = new CMN_CommissionInformation()
		{
			CommissionDetails = null,
		};

		var actual = Map.MapObject<CMN_CommissionInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCommissionDetails(string commissionDetails, bool isValidExpected)
	{
		var subject = new CMN_CommissionInformation();
		//Required fields
		//Test Parameters
		if (commissionDetails != "") 
			subject.CommissionDetails = new E002_CommissionDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
