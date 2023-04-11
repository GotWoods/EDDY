using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ENTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENT*7*mm*K*Nj*3l*z*Id*an*I";

		var expected = new ENT_Entity()
		{
			AssignedNumber = 7,
			EntityIdentifierCode = "mm",
			IdentificationCodeQualifier = "K",
			IdentificationCode = "Nj",
			EntityIdentifierCode2 = "3l",
			IdentificationCodeQualifier2 = "z",
			IdentificationCode2 = "Id",
			ReferenceIdentificationQualifier = "an",
			ReferenceIdentification = "I",
		};

		var actual = Map.MapObject<ENT_Entity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("an", "I", true)]
	[InlineData("", "I", false)]
	[InlineData("an", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ENT_Entity();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
