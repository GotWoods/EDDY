using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class NX1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NX1*y2*q1*kJ*CS*ZM";

		var expected = new NX1_PropertyOrEntityIdentification()
		{
			EntityIdentifierCode = "y2",
			EntityIdentifierCode2 = "q1",
			EntityIdentifierCode3 = "kJ",
			EntityIdentifierCode4 = "CS",
			EntityIdentifierCode5 = "ZM",
		};

		var actual = Map.MapObject<NX1_PropertyOrEntityIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y2", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new NX1_PropertyOrEntityIdentification();
		//Required fields
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
