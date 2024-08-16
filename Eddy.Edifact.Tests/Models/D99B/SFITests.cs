using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class SFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SFI+t+++i";

		var expected = new SFI_SafetyInformation()
		{
			HierarchicalStructureLevelIdentifier = "t",
			SafetySection = null,
			AdditionalSafetyInformation = null,
			MaintenanceOperationCoded = "i",
		};

		var actual = Map.MapObject<SFI_SafetyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredHierarchicalStructureLevelIdentifier(string hierarchicalStructureLevelIdentifier, bool isValidExpected)
	{
		var subject = new SFI_SafetyInformation();
		//Required fields
		//Test Parameters
		subject.HierarchicalStructureLevelIdentifier = hierarchicalStructureLevelIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
