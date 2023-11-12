using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class ENTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENT*3*o0*A*7C*NA*7*x3*Sy*k";

		var expected = new ENT_Entity()
		{
			AssignedNumber = 3,
			EntityIdentifierCode = "o0",
			IdentificationCodeQualifier = "A",
			IdentificationCode = "7C",
			EntityIdentifierCode2 = "NA",
			IdentificationCodeQualifier2 = "7",
			IdentificationCode2 = "x3",
			ReferenceIdentificationQualifier = "Sy",
			ReferenceIdentification = "k",
		};

		var actual = Map.MapObject<ENT_Entity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Sy", "k", true)]
	[InlineData("Sy", "", false)]
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
