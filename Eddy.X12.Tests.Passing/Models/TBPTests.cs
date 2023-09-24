using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TBPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBP*qy*y*L";

		var expected = new TBP_FrequencyBasis()
		{
			ProductProcessCharacteristicCode = "qy",
			FrequencyCode = "y",
			Description = "L",
		};

		var actual = Map.MapObject<TBP_FrequencyBasis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qy", true)]
	public void Validation_RequiredProductProcessCharacteristicCode(string productProcessCharacteristicCode, bool isValidExpected)
	{
		var subject = new TBP_FrequencyBasis();
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("y","L", true)]
	[InlineData("", "L", true)]
	[InlineData("y", "", true)]
	public void Validation_AtLeastOneFrequencyCode(string frequencyCode, string description, bool isValidExpected)
	{
		var subject = new TBP_FrequencyBasis();
		subject.ProductProcessCharacteristicCode = "qy";
		subject.FrequencyCode = frequencyCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
