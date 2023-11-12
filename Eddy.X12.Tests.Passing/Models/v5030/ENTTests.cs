using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ENTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENT*1*Hs*p*Bx*db*2*3F*qd*d";

		var expected = new ENT_Entity()
		{
			AssignedNumber = 1,
			EntityIdentifierCode = "Hs",
			IdentificationCodeQualifier = "p",
			IdentificationCode = "Bx",
			EntityIdentifierCode2 = "db",
			IdentificationCodeQualifier2 = "2",
			IdentificationCode2 = "3F",
			ReferenceIdentificationQualifier = "qd",
			ReferenceIdentification = "d",
		};

		var actual = Map.MapObject<ENT_Entity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qd", "d", true)]
	[InlineData("qd", "", false)]
	[InlineData("", "d", false)]
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
