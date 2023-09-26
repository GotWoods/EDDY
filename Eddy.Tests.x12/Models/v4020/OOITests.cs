using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class OOITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OOI*H*Q*R*L";

		var expected = new OOI_AssociatedObjectTypeIdentification()
		{
			ObjectIdentificationGroup = "H",
			ObjectTypeQualifier = "Q",
			ObjectAttributeIdentification = "R",
			ControllingAgency = "L",
		};

		var actual = Map.MapObject<OOI_AssociatedObjectTypeIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredObjectIdentificationGroup(string objectIdentificationGroup, bool isValidExpected)
	{
		var subject = new OOI_AssociatedObjectTypeIdentification();
		//Required fields
		subject.ObjectTypeQualifier = "Q";
		subject.ObjectAttributeIdentification = "R";
		//Test Parameters
		subject.ObjectIdentificationGroup = objectIdentificationGroup;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredObjectTypeQualifier(string objectTypeQualifier, bool isValidExpected)
	{
		var subject = new OOI_AssociatedObjectTypeIdentification();
		//Required fields
		subject.ObjectIdentificationGroup = "H";
		subject.ObjectAttributeIdentification = "R";
		//Test Parameters
		subject.ObjectTypeQualifier = objectTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredObjectAttributeIdentification(string objectAttributeIdentification, bool isValidExpected)
	{
		var subject = new OOI_AssociatedObjectTypeIdentification();
		//Required fields
		subject.ObjectIdentificationGroup = "H";
		subject.ObjectTypeQualifier = "Q";
		//Test Parameters
		subject.ObjectAttributeIdentification = objectAttributeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
