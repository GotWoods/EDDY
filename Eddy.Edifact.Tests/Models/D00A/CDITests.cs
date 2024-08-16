using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CDI+w+";

		var expected = new CDI_PhysicalOrLogicalState()
		{
			PhysicalOrLogicalStateTypeCodeQualifier = "w",
			PhysicalOrLogicalStateInformation = null,
		};

		var actual = Map.MapObject<CDI_PhysicalOrLogicalState>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredPhysicalOrLogicalStateTypeCodeQualifier(string physicalOrLogicalStateTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new CDI_PhysicalOrLogicalState();
		//Required fields
		subject.PhysicalOrLogicalStateInformation = new C564_PhysicalOrLogicalStateInformation();
		//Test Parameters
		subject.PhysicalOrLogicalStateTypeCodeQualifier = physicalOrLogicalStateTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPhysicalOrLogicalStateInformation(string physicalOrLogicalStateInformation, bool isValidExpected)
	{
		var subject = new CDI_PhysicalOrLogicalState();
		//Required fields
		subject.PhysicalOrLogicalStateTypeCodeQualifier = "w";
		//Test Parameters
		if (physicalOrLogicalStateInformation != "") 
			subject.PhysicalOrLogicalStateInformation = new C564_PhysicalOrLogicalStateInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
