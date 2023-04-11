using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E1*G*j*to";

		var expected = new E1_EmptyCarDispositionPendedDestinationConsignee()
		{
			Name = "G",
			IdentificationCodeQualifier = "j",
			IdentificationCode = "to",
		};

		var actual = Map.MapObject<E1_EmptyCarDispositionPendedDestinationConsignee>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validatation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new E1_EmptyCarDispositionPendedDestinationConsignee();
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("j", "to", true)]
	[InlineData("", "to", false)]
	[InlineData("j", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new E1_EmptyCarDispositionPendedDestinationConsignee();
		subject.Name = "G";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
