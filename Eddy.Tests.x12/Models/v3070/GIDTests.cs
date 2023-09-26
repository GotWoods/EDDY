using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class GIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GID*g*l*u";

		var expected = new GID_GroupIdentification()
		{
			Name = "g",
			GenderCode = "l",
			Name2 = "u",
		};

		var actual = Map.MapObject<GID_GroupIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new GID_GroupIdentification();
		//Required fields
		subject.GenderCode = "l";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredGenderCode(string genderCode, bool isValidExpected)
	{
		var subject = new GID_GroupIdentification();
		//Required fields
		subject.Name = "g";
		//Test Parameters
		subject.GenderCode = genderCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
