using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class U5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "U5*XJ*w*2M*aB9kTP";

		var expected = new U5_PriorOriginName()
		{
			Name30CharacterFormat = "XJ",
			IdentificationCodeQualifier = "w",
			IdentificationCode = "2M",
			ImportLicenseExpirationDate = "aB9kTP",
		};

		var actual = Map.MapObject<U5_PriorOriginName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XJ", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new U5_PriorOriginName();
		subject.Name30CharacterFormat = name30CharacterFormat;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "w";
			subject.IdentificationCode = "2M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "2M", true)]
	[InlineData("w", "", false)]
	[InlineData("", "2M", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new U5_PriorOriginName();
		subject.Name30CharacterFormat = "XJ";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
