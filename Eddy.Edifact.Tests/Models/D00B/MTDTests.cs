using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class MTDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MTD+9+c+r+L";

		var expected = new MTD_MaintenanceOperationDetails()
		{
			ObjectTypeCodeQualifier = "9",
			MaintenanceOperationCode = "c",
			MaintenanceOperationOperatorCode = "r",
			MaintenanceOperationPayerCode = "L",
		};

		var actual = Map.MapObject<MTD_MaintenanceOperationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredObjectTypeCodeQualifier(string objectTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new MTD_MaintenanceOperationDetails();
		//Required fields
		//Test Parameters
		subject.ObjectTypeCodeQualifier = objectTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
