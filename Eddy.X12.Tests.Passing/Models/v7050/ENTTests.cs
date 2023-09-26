using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class ENTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENT*2*Na*H*qB*Hg*i*iw*M2*0";

		var expected = new ENT_Entity()
		{
			AssignedNumber = 2,
			EntityIdentifierCode = "Na",
			IdentificationCodeQualifier = "H",
			IdentificationCode = "qB",
			EntityIdentifierCode2 = "Hg",
			IdentificationCodeQualifier2 = "i",
			IdentificationCode2 = "iw",
			ReferenceIdentificationQualifier = "M2",
			ReferenceIdentification = "0",
		};

		var actual = Map.MapObject<ENT_Entity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M2", "0", true)]
	[InlineData("M2", "", false)]
	[InlineData("", "0", false)]
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
