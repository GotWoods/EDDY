using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NX1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NX1*Pz*oZ*1p*AT*7w";

		var expected = new NX1_PropertyOrEntityIdentification()
		{
			EntityIdentifierCode = "Pz",
			EntityIdentifierCode2 = "oZ",
			EntityIdentifierCode3 = "1p",
			EntityIdentifierCode4 = "AT",
			EntityIdentifierCode5 = "7w",
		};

		var actual = Map.MapObject<NX1_PropertyOrEntityIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pz", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new NX1_PropertyOrEntityIdentification();
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
