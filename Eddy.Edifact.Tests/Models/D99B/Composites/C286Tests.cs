using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C286Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "e:A:x:I";

		var expected = new C286_SequenceInformation()
		{
			SequenceNumber = "e",
			SequenceNumberSourceCoded = "A",
			CodeListIdentificationCode = "x",
			CodeListResponsibleAgencyCode = "I",
		};

		var actual = Map.MapComposite<C286_SequenceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredSequenceNumber(string sequenceNumber, bool isValidExpected)
	{
		var subject = new C286_SequenceInformation();
		//Required fields
		//Test Parameters
		subject.SequenceNumber = sequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
