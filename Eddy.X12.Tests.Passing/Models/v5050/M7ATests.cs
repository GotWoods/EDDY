using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class M7ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M7A*2v*et*v7STaMUX*rA*a*s*o";

		var expected = new M7A_SealNumberReplacement()
		{
			SealNumber = "2v",
			SealNumber2 = "et",
			Date = "v7STaMUX",
			EntityIdentifierCode = "rA",
			Name = "a",
			Description = "s",
			LocationOnEquipment = "o",
		};

		var actual = Map.MapObject<M7A_SealNumberReplacement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2v", true)]
	public void Validation_RequiredSealNumber(string sealNumber, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber2 = "et";
		//Test Parameters
		subject.SealNumber = sealNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "rA";
			subject.Name = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("et", true)]
	public void Validation_RequiredSealNumber2(string sealNumber2, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber = "2v";
		//Test Parameters
		subject.SealNumber2 = sealNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "rA";
			subject.Name = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rA", "a", true)]
	[InlineData("rA", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber = "2v";
		subject.SealNumber2 = "et";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
