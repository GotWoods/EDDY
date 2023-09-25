using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ENTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ENT*3*hm*r*9I*8C*N*fm*YL*E";

		var expected = new ENT_Entity()
		{
			AssignedNumber = 3,
			EntityIdentifierCode = "hm",
			IdentificationCodeQualifier = "r",
			IdentificationCode = "9I",
			EntityIdentifierCode2 = "8C",
			IdentificationCodeQualifier2 = "N",
			IdentificationCode2 = "fm",
			ReferenceNumberQualifier = "YL",
			ReferenceNumber = "E",
		};

		var actual = Map.MapObject<ENT_Entity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("YL", "E", true)]
	[InlineData("YL", "", false)]
	[InlineData("", "E", false)]
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
