using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ENTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENT*1*uF*N*Uy*4h*5*sw*zM*8";

		var expected = new ENT_Entity()
		{
			AssignedNumber = 1,
			EntityIdentifierCode = "uF",
			IdentificationCodeQualifier = "N",
			IdentificationCode = "Uy",
			EntityIdentifierCode2 = "4h",
			IdentificationCodeQualifier2 = "5",
			IdentificationCode2 = "sw",
			ReferenceIdentificationQualifier = "zM",
			ReferenceIdentification = "8",
		};

		var actual = Map.MapObject<ENT_Entity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zM", "8", true)]
	[InlineData("zM", "", false)]
	[InlineData("", "8", false)]
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
