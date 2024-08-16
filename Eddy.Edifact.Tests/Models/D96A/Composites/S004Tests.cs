using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class S004Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Jcej8s:HlsI";

		var expected = new S004_DateTimeOfPreparation()
		{
			DateOfPreparation = "Jcej8s",
			TimeOfPreparation = "HlsI",
		};

		var actual = Map.MapComposite<S004_DateTimeOfPreparation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jcej8s", true)]
	public void Validation_RequiredDateOfPreparation(string dateOfPreparation, bool isValidExpected)
	{
		var subject = new S004_DateTimeOfPreparation();
		//Required fields
		subject.TimeOfPreparation = "HlsI";
		//Test Parameters
		subject.DateOfPreparation = dateOfPreparation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HlsI", true)]
	public void Validation_RequiredTimeOfPreparation(string timeOfPreparation, bool isValidExpected)
	{
		var subject = new S004_DateTimeOfPreparation();
		//Required fields
		subject.DateOfPreparation = "Jcej8s";
		//Test Parameters
		subject.TimeOfPreparation = timeOfPreparation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
