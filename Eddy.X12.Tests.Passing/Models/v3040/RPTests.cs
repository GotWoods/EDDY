using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RP*NHl*f4*eP*K*z*U*9*A";

		var expected = new RP_RetirementProduct()
		{
			MaintenanceTypeCode = "NHl",
			InsuranceLineCode = "f4",
			MaintenanceReasonCode = "eP",
			Description = "K",
			ParticipantStatusCode = "z",
			YesNoConditionOrResponseCode = "U",
			SpecialProcessingType = "9",
			Authority = "A",
		};

		var actual = Map.MapObject<RP_RetirementProduct>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NHl", true)]
	public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new RP_RetirementProduct();
		//Required fields
		//Test Parameters
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
