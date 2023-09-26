using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class M7ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M7A*N*s*LWskUy57*gA*b*C*l";

		var expected = new M7A_SealNumberReplacement()
		{
			SealNumber = "N",
			SealNumber2 = "s",
			Date = "LWskUy57",
			EntityIdentifierCode = "gA",
			Name = "b",
			Description = "C",
			LocationOnEquipmentCode = "l",
		};

		var actual = Map.MapObject<M7A_SealNumberReplacement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredSealNumber(string sealNumber, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber2 = "s";
		//Test Parameters
		subject.SealNumber = sealNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "gA";
			subject.Name = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredSealNumber2(string sealNumber2, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber = "N";
		//Test Parameters
		subject.SealNumber2 = sealNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode) || !string.IsNullOrEmpty(subject.Name))
		{
			subject.EntityIdentifierCode = "gA";
			subject.Name = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gA", "b", true)]
	[InlineData("gA", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new M7A_SealNumberReplacement();
		//Required fields
		subject.SealNumber = "N";
		subject.SealNumber2 = "s";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
