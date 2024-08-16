using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class SFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SFI+g+++F";

		var expected = new SFI_SafetyInformation()
		{
			HierarchicalIdNumber = "g",
			SafetySection = null,
			AdditionalSafetyInformation = null,
			MaintenanceOperationCoded = "F",
		};

		var actual = Map.MapObject<SFI_SafetyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredHierarchicalIdNumber(string hierarchicalIdNumber, bool isValidExpected)
	{
		var subject = new SFI_SafetyInformation();
		//Required fields
		//Test Parameters
		subject.HierarchicalIdNumber = hierarchicalIdNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
