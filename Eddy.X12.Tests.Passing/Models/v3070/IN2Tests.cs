using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class IN2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IN2*xR*V";

		var expected = new IN2_IndividualNameStructureComponents()
		{
			NameComponentQualifier = "xR",
			Name = "V",
		};

		var actual = Map.MapObject<IN2_IndividualNameStructureComponents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xR", true)]
	public void Validation_RequiredNameComponentQualifier(string nameComponentQualifier, bool isValidExpected)
	{
		var subject = new IN2_IndividualNameStructureComponents();
		//Required fields
		subject.Name = "V";
		//Test Parameters
		subject.NameComponentQualifier = nameComponentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new IN2_IndividualNameStructureComponents();
		//Required fields
		subject.NameComponentQualifier = "xR";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
