using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C901Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "K:A:V";

		var expected = new C901_ApplicationErrorDetail()
		{
			ApplicationErrorIdentification = "K",
			CodeListIdentificationCode = "A",
			CodeListResponsibleAgencyCode = "V",
		};

		var actual = Map.MapComposite<C901_ApplicationErrorDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredApplicationErrorIdentification(string applicationErrorIdentification, bool isValidExpected)
	{
		var subject = new C901_ApplicationErrorDetail();
		//Required fields
		//Test Parameters
		subject.ApplicationErrorIdentification = applicationErrorIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
