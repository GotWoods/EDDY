using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class E1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E1*AA*k*IN";

		var expected = new E1_EmptyCarDispositionPendedDestinationConsignee()
		{
			Name30CharacterFormat = "AA",
			IdentificationCodeQualifier = "k",
			IdentificationCode = "IN",
		};

		var actual = Map.MapObject<E1_EmptyCarDispositionPendedDestinationConsignee>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new E1_EmptyCarDispositionPendedDestinationConsignee();
		subject.Name30CharacterFormat = name30CharacterFormat;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "k";
			subject.IdentificationCode = "IN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "IN", true)]
	[InlineData("k", "", false)]
	[InlineData("", "IN", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new E1_EmptyCarDispositionPendedDestinationConsignee();
		subject.Name30CharacterFormat = "AA";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
