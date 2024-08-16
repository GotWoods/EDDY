using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CDI+a+";

		var expected = new CDI_PhysicalOrLogicalState()
		{
			PhysicalOrLogicalStateQualifier = "a",
			PhysicalOrLogicalStateInformation = null,
		};

		var actual = Map.MapObject<CDI_PhysicalOrLogicalState>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredPhysicalOrLogicalStateQualifier(string physicalOrLogicalStateQualifier, bool isValidExpected)
	{
		var subject = new CDI_PhysicalOrLogicalState();
		//Required fields
		subject.PhysicalOrLogicalStateInformation = new C564_PhysicalOrLogicalStateInformation();
		//Test Parameters
		subject.PhysicalOrLogicalStateQualifier = physicalOrLogicalStateQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPhysicalOrLogicalStateInformation(string physicalOrLogicalStateInformation, bool isValidExpected)
	{
		var subject = new CDI_PhysicalOrLogicalState();
		//Required fields
		subject.PhysicalOrLogicalStateQualifier = "a";
		//Test Parameters
		if (physicalOrLogicalStateInformation != "") 
			subject.PhysicalOrLogicalStateInformation = new C564_PhysicalOrLogicalStateInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
