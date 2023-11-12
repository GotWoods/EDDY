using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class IN2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IN2*Jb*w*l";

		var expected = new IN2_IndividualNameStructureComponents()
		{
			NameComponentQualifier = "Jb",
			Name = "w",
			Name2 = "l",
		};

		var actual = Map.MapObject<IN2_IndividualNameStructureComponents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jb", true)]
	public void Validation_RequiredNameComponentQualifier(string nameComponentQualifier, bool isValidExpected)
	{
		var subject = new IN2_IndividualNameStructureComponents();
		//Required fields
		subject.Name = "w";
		//Test Parameters
		subject.NameComponentQualifier = nameComponentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new IN2_IndividualNameStructureComponents();
		//Required fields
		subject.NameComponentQualifier = "Jb";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
