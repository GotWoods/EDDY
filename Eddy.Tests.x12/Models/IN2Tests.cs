using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IN2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IN2*LJ*Y*E";

		var expected = new IN2_IndividualNameStructureComponents()
		{
			NameComponentQualifier = "LJ",
			Name = "Y",
			Name2 = "E",
		};

		var actual = Map.MapObject<IN2_IndividualNameStructureComponents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LJ", true)]
	public void Validation_RequiredNameComponentQualifier(string nameComponentQualifier, bool isValidExpected)
	{
		var subject = new IN2_IndividualNameStructureComponents();
		subject.Name = "Y";
		subject.NameComponentQualifier = nameComponentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new IN2_IndividualNameStructureComponents();
		subject.NameComponentQualifier = "LJ";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
