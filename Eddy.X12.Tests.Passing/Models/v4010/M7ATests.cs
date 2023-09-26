using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class M7ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M7A*gB*3M*hD1VDXYI*Sa*Y*V";

		var expected = new M7A_SealNumberReplacement()
		{
			SealNumber = "gB",
			SealNumber2 = "3M",
			Date = "hD1VDXYI",
			EntityIdentifierCode = "Sa",
			Name = "Y",
			Description = "V",
		};

		var actual = Map.MapObject<M7A_SealNumberReplacement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gB", true)]
	public void Validation_RequiredSealNumber(string sealNumber, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber2 = "3M";
		//Test Parameters
		subject.SealNumber = sealNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "Sa";
			subject.Name = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3M", true)]
	public void Validation_RequiredSealNumber2(string sealNumber2, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber = "gB";
		//Test Parameters
		subject.SealNumber2 = sealNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "Sa";
			subject.Name = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Sa", "Y", true)]
	[InlineData("Sa", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber = "gB";
		subject.SealNumber2 = "3M";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
