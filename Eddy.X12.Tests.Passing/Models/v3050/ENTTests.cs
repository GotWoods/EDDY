using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ENTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENT*8*Qz*V*ku*wy*E*Bl*qK*G";

		var expected = new ENT_Entity()
		{
			AssignedNumber = 8,
			EntityIdentifierCode = "Qz",
			IdentificationCodeQualifier = "V",
			IdentificationCode = "ku",
			EntityIdentifierCode2 = "wy",
			IdentificationCodeQualifier2 = "E",
			IdentificationCode2 = "Bl",
			ReferenceNumberQualifier = "qK",
			ReferenceNumber = "G",
		};

		var actual = Map.MapObject<ENT_Entity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qK", "G", true)]
	[InlineData("qK", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new ENT_Entity();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
