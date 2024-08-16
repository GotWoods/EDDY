using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class SFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SFI+E+++O";

		var expected = new SFI_SafetyInformation()
		{
			HierarchicalIdNumber = "E",
			SafetySection = null,
			AdditionalSafetyInformation = null,
			MaintenanceOperationCoded = "O",
		};

		var actual = Map.MapObject<SFI_SafetyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredHierarchicalIdNumber(string hierarchicalIdNumber, bool isValidExpected)
	{
		var subject = new SFI_SafetyInformation();
		//Required fields
		//Test Parameters
		subject.HierarchicalIdNumber = hierarchicalIdNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
