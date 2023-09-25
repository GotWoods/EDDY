using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ENTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENT*8*98*G*TF*lc*v*my*tw*h";

		var expected = new ENT_Entity()
		{
			AssignedNumber = 8,
			EntityIdentifierCode = "98",
			IdentificationCodeQualifier = "G",
			IdentificationCode = "TF",
			EntityIdentifierCode2 = "lc",
			IdentificationCodeQualifier2 = "v",
			IdentificationCode2 = "my",
			ReferenceIdentificationQualifier = "tw",
			ReferenceIdentification = "h",
		};

		var actual = Map.MapObject<ENT_Entity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("tw", "h", true)]
	[InlineData("tw", "", false)]
	[InlineData("", "h", false)]
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
