using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class OOITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OOI*T*v*g*d";

		var expected = new OOI_AssociatedObjectTypeIdentification()
		{
			ObjectIdentificationGroup = "T",
			ObjectTypeQualifier = "v",
			ObjectAttributeIdentification = "g",
			ControllingAgencyCode = "d",
		};

		var actual = Map.MapObject<OOI_AssociatedObjectTypeIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredObjectIdentificationGroup(string objectIdentificationGroup, bool isValidExpected)
	{
		var subject = new OOI_AssociatedObjectTypeIdentification();
		subject.ObjectTypeQualifier = "v";
		subject.ObjectAttributeIdentification = "g";
		subject.ObjectIdentificationGroup = objectIdentificationGroup;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredObjectTypeQualifier(string objectTypeQualifier, bool isValidExpected)
	{
		var subject = new OOI_AssociatedObjectTypeIdentification();
		subject.ObjectIdentificationGroup = "T";
		subject.ObjectAttributeIdentification = "g";
		subject.ObjectTypeQualifier = objectTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredObjectAttributeIdentification(string objectAttributeIdentification, bool isValidExpected)
	{
		var subject = new OOI_AssociatedObjectTypeIdentification();
		subject.ObjectIdentificationGroup = "T";
		subject.ObjectTypeQualifier = "v";
		subject.ObjectAttributeIdentification = objectAttributeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
