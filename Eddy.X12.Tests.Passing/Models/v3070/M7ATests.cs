using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class M7ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M7A*g8*SF*7DJieX*sQ*B*A";

		var expected = new M7A_SealNumberReplacement()
		{
			SealNumber = "g8",
			SealNumber2 = "SF",
			Date = "7DJieX",
			EntityIdentifierCode = "sQ",
			Name = "B",
			Description = "A",
		};

		var actual = Map.MapObject<M7A_SealNumberReplacement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g8", true)]
	public void Validation_RequiredSealNumber(string sealNumber, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber2 = "SF";
		//Test Parameters
		subject.SealNumber = sealNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "sQ";
			subject.Name = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SF", true)]
	public void Validation_RequiredSealNumber2(string sealNumber2, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber = "g8";
		//Test Parameters
		subject.SealNumber2 = sealNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "sQ";
			subject.Name = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sQ", "B", true)]
	[InlineData("sQ", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber = "g8";
		subject.SealNumber2 = "SF";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
