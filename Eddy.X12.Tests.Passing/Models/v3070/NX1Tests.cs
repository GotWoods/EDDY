using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class NX1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NX1*FN*Us*FI*eF*KO";

		var expected = new NX1_PropertyOrEntityIdentification()
		{
			EntityIdentifierCode = "FN",
			EntityIdentifierCode2 = "Us",
			EntityIdentifierCode3 = "FI",
			EntityIdentifierCode4 = "eF",
			EntityIdentifierCode5 = "KO",
		};

		var actual = Map.MapObject<NX1_PropertyOrEntityIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FN", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new NX1_PropertyOrEntityIdentification();
		//Required fields
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
