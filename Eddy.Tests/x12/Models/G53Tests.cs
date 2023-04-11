using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G53Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G53*bkS";

		var expected = new G53_MaintenanceType()
		{
			MaintenanceTypeCode = "bkS",
		};

		var actual = Map.MapObject<G53_MaintenanceType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bkS", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new G53_MaintenanceType();
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
