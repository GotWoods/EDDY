using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class GIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GID*9*F*E";

		var expected = new GID_GroupIdentification()
		{
			Name = "9",
			GenderCode = "F",
			Name2 = "E",
		};

		var actual = Map.MapObject<GID_GroupIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new GID_GroupIdentification();
		subject.GenderCode = "F";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredGenderCode(string genderCode, bool isValidExpected)
	{
		var subject = new GID_GroupIdentification();
		subject.Name = "9";
		subject.GenderCode = genderCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
