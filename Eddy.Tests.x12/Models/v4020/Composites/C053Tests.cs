using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4020;
using Eddy.x12.Models.v4020.Composites;

namespace Eddy.x12.Tests.Models.v4020.Composites;

public class C053Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "R*l*d*b*M";

		var expected = new C053_StandardsInformation()
		{
			ElectronicFormStandardsTypeCode = "R",
			ElectronicFormStandardsIdentifier = "l",
			ImplementationConventionReference = "d",
			VersionIdentifier = "b",
			RevisionValue = "M",
		};

		var actual = Map.MapObject<C053_StandardsInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredElectronicFormStandardsTypeCode(string electronicFormStandardsTypeCode, bool isValidExpected)
	{
		var subject = new C053_StandardsInformation();
		//Required fields
		subject.ElectronicFormStandardsIdentifier = "l";
		subject.ImplementationConventionReference = "d";
		//Test Parameters
		subject.ElectronicFormStandardsTypeCode = electronicFormStandardsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredElectronicFormStandardsIdentifier(string electronicFormStandardsIdentifier, bool isValidExpected)
	{
		var subject = new C053_StandardsInformation();
		//Required fields
		subject.ElectronicFormStandardsTypeCode = "R";
		subject.ImplementationConventionReference = "d";
		//Test Parameters
		subject.ElectronicFormStandardsIdentifier = electronicFormStandardsIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredImplementationConventionReference(string implementationConventionReference, bool isValidExpected)
	{
		var subject = new C053_StandardsInformation();
		//Required fields
		subject.ElectronicFormStandardsTypeCode = "R";
		subject.ElectronicFormStandardsIdentifier = "l";
		//Test Parameters
		subject.ImplementationConventionReference = implementationConventionReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
