using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class E1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E1*Ec*0*9K";

		var expected = new E1_EmptyCarDispositionPendedDestinationConsignee()
		{
			Name30CharacterFormat = "Ec",
			IdentificationCodeQualifier = "0",
			IdentificationCode = "9K",
		};

		var actual = Map.MapObject<E1_EmptyCarDispositionPendedDestinationConsignee>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ec", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new E1_EmptyCarDispositionPendedDestinationConsignee();
		subject.Name30CharacterFormat = name30CharacterFormat;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "0";
			subject.IdentificationCode = "9K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "9K", true)]
	[InlineData("0", "", false)]
	[InlineData("", "9K", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new E1_EmptyCarDispositionPendedDestinationConsignee();
		subject.Name30CharacterFormat = "Ec";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
