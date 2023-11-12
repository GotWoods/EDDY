using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class NTETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NTE*qbY*p";

		var expected = new NTE_NoteSpecialInstruction()
		{
			NoteReferenceCode = "qbY",
			FreeFormMessage = "p",
		};

		var actual = Map.MapObject<NTE_NoteSpecialInstruction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredFreeFormMessage(string freeFormMessage, bool isValidExpected)
	{
		var subject = new NTE_NoteSpecialInstruction();
		subject.FreeFormMessage = freeFormMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
