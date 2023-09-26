using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ENTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENT*4*eJ*l*x6*38*q*Qh*B6*k";

		var expected = new ENT_Entity()
		{
			AssignedNumber = 4,
			EntityIdentifierCode = "eJ",
			IdentificationCodeQualifier = "l",
			IdentificationCode = "x6",
			EntityIdentifierCode2 = "38",
			IdentificationCodeQualifier2 = "q",
			IdentificationCode2 = "Qh",
			ReferenceIdentificationQualifier = "B6",
			ReferenceIdentification = "k",
		};

		var actual = Map.MapObject<ENT_Entity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B6", "k", true)]
	[InlineData("B6", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ENT_Entity();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
