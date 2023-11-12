using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AT5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT5*QS*4c*R8";

		var expected = new AT5_BillOfLadingHandlingRequirements()
		{
			SpecialHandlingCode = "QS",
			SpecialServicesCode = "4c",
			SpecialHandlingDescription = "R8",
		};

		var actual = Map.MapObject<AT5_BillOfLadingHandlingRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QS", "R8", false)]
	[InlineData("QS", "", true)]
	[InlineData("", "R8", true)]
	public void Validation_OnlyOneOfSpecialHandlingCode(string specialHandlingCode, string specialHandlingDescription, bool isValidExpected)
	{
		var subject = new AT5_BillOfLadingHandlingRequirements();
		//Required fields
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		subject.SpecialHandlingDescription = specialHandlingDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4c", "R8", false)]
	[InlineData("4c", "", true)]
	[InlineData("", "R8", true)]
	public void Validation_OnlyOneOfSpecialServicesCode(string specialServicesCode, string specialHandlingDescription, bool isValidExpected)
	{
		var subject = new AT5_BillOfLadingHandlingRequirements();
		//Required fields
		//Test Parameters
		subject.SpecialServicesCode = specialServicesCode;
		subject.SpecialHandlingDescription = specialHandlingDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
