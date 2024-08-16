using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class SFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SFI+O+++o";

		var expected = new SFI_SafetyInformation()
		{
			HierarchicalStructureLevelIdentifier = "O",
			SafetySection = null,
			AdditionalSafetyInformation = null,
			MaintenanceOperationCode = "o",
		};

		var actual = Map.MapObject<SFI_SafetyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredHierarchicalStructureLevelIdentifier(string hierarchicalStructureLevelIdentifier, bool isValidExpected)
	{
		var subject = new SFI_SafetyInformation();
		//Required fields
		//Test Parameters
		subject.HierarchicalStructureLevelIdentifier = hierarchicalStructureLevelIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
