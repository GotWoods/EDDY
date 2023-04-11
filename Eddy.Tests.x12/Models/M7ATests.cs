using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M7ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M7A*y*M*14lIeYh0*wi*f*o*Q";

		var expected = new M7A_SealNumberReplacement()
		{
			SealNumber = "y",
			SealNumber2 = "M",
			Date = "14lIeYh0",
			EntityIdentifierCode = "wi",
			Name = "f",
			Description = "o",
			LocationOnEquipmentCode = "Q",
		};

		var actual = Map.MapObject<M7A_SealNumberReplacement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredSealNumber(string sealNumber, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		subject.SealNumber2 = "M";
		subject.SealNumber = sealNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredSealNumber2(string sealNumber2, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		subject.SealNumber = "y";
		subject.SealNumber2 = sealNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("wi", "f", true)]
	[InlineData("", "f", false)]
	[InlineData("wi", "", false)]
	public void Validation_AllAreRequiredEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		subject.SealNumber = "y";
		subject.SealNumber2 = "M";
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
