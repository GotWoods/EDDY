using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class NTETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NTE*RZG*8";

		var expected = new NTE_NoteSpecialInstruction()
		{
			NoteReferenceCode = "RZG",
			Description = "8",
		};

		var actual = Map.MapObject<NTE_NoteSpecialInstruction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new NTE_NoteSpecialInstruction();
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
