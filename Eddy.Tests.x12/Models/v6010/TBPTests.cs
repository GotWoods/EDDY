using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class TBPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBP*e6*B*Z";

		var expected = new TBP_FrequencyBasis()
		{
			ProductProcessCharacteristicCode = "e6",
			FrequencyCode = "B",
			Description = "Z",
		};

		var actual = Map.MapObject<TBP_FrequencyBasis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e6", true)]
	public void Validation_RequiredProductProcessCharacteristicCode(string productProcessCharacteristicCode, bool isValidExpected)
	{
		var subject = new TBP_FrequencyBasis();
		//Required fields
		//Test Parameters
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		//At Least one
		subject.FrequencyCode = "B";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("B", "Z", true)]
	[InlineData("B", "", true)]
	[InlineData("", "Z", true)]
	public void Validation_AtLeastOneFrequencyCode(string frequencyCode, string description, bool isValidExpected)
	{
		var subject = new TBP_FrequencyBasis();
		//Required fields
		subject.ProductProcessCharacteristicCode = "e6";
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
