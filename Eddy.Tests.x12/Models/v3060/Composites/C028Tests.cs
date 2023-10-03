using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Tests.Models.v3060.Composites;

public class C028Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "U9*J*V0*o*LX*E*ob*c*AO*7*34*t*Ht*r*9u*z*rb*l*NU*Z";

		var expected = new C028_AssuranceTokenParameters()
		{
			AssuranceTokenParameterCode = "U9",
			AssuranceTokenParameterValue = "J",
			AssuranceTokenParameterCode2 = "V0",
			AssuranceTokenParameterValue2 = "o",
			AssuranceTokenParameterCode3 = "LX",
			AssuranceTokenParameterValue3 = "E",
			AssuranceTokenParameterCode4 = "ob",
			AssuranceTokenParameterValue4 = "c",
			AssuranceTokenParameterCode5 = "AO",
			AssuranceTokenParameterValue5 = "7",
			AssuranceTokenParameterCode6 = "34",
			AssuranceTokenParameterValue6 = "t",
			AssuranceTokenParameterCode7 = "Ht",
			AssuranceTokenParameterValue7 = "r",
			AssuranceTokenParameterCode8 = "9u",
			AssuranceTokenParameterValue8 = "z",
			AssuranceTokenParameterCode9 = "rb",
			AssuranceTokenParameterValue9 = "l",
			AssuranceTokenParameterCode10 = "NU",
			AssuranceTokenParameterValue10 = "Z",
		};

		var actual = Map.MapObject<C028_AssuranceTokenParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U9", true)]
	public void Validation_RequiredAssuranceTokenParameterCode(string assuranceTokenParameterCode, bool isValidExpected)
	{
		var subject = new C028_AssuranceTokenParameters();
		//Required fields
		subject.AssuranceTokenParameterValue = "J";
		//Test Parameters
		subject.AssuranceTokenParameterCode = assuranceTokenParameterCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredAssuranceTokenParameterValue(string assuranceTokenParameterValue, bool isValidExpected)
	{
		var subject = new C028_AssuranceTokenParameters();
		//Required fields
		subject.AssuranceTokenParameterCode = "U9";
		//Test Parameters
		subject.AssuranceTokenParameterValue = assuranceTokenParameterValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "V0", true)]
	[InlineData("o", "", false)]
	[InlineData("", "V0", true)]
	public void Validation_ARequiresBAssuranceTokenParameterValue2(string assuranceTokenParameterValue2, string assuranceTokenParameterCode2, bool isValidExpected)
	{
		var subject = new C028_AssuranceTokenParameters();
		//Required fields
		subject.AssuranceTokenParameterCode = "U9";
		subject.AssuranceTokenParameterValue = "J";
		//Test Parameters
		subject.AssuranceTokenParameterValue2 = assuranceTokenParameterValue2;
		subject.AssuranceTokenParameterCode2 = assuranceTokenParameterCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "LX", true)]
	[InlineData("E", "", false)]
	[InlineData("", "LX", true)]
	public void Validation_ARequiresBAssuranceTokenParameterValue3(string assuranceTokenParameterValue3, string assuranceTokenParameterCode3, bool isValidExpected)
	{
		var subject = new C028_AssuranceTokenParameters();
		//Required fields
		subject.AssuranceTokenParameterCode = "U9";
		subject.AssuranceTokenParameterValue = "J";
		//Test Parameters
		subject.AssuranceTokenParameterValue3 = assuranceTokenParameterValue3;
		subject.AssuranceTokenParameterCode3 = assuranceTokenParameterCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "ob", true)]
	[InlineData("c", "", false)]
	[InlineData("", "ob", true)]
	public void Validation_ARequiresBAssuranceTokenParameterValue4(string assuranceTokenParameterValue4, string assuranceTokenParameterCode4, bool isValidExpected)
	{
		var subject = new C028_AssuranceTokenParameters();
		//Required fields
		subject.AssuranceTokenParameterCode = "U9";
		subject.AssuranceTokenParameterValue = "J";
		//Test Parameters
		subject.AssuranceTokenParameterValue4 = assuranceTokenParameterValue4;
		subject.AssuranceTokenParameterCode4 = assuranceTokenParameterCode4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "AO", true)]
	[InlineData("7", "", false)]
	[InlineData("", "AO", true)]
	public void Validation_ARequiresBAssuranceTokenParameterValue5(string assuranceTokenParameterValue5, string assuranceTokenParameterCode5, bool isValidExpected)
	{
		var subject = new C028_AssuranceTokenParameters();
		//Required fields
		subject.AssuranceTokenParameterCode = "U9";
		subject.AssuranceTokenParameterValue = "J";
		//Test Parameters
		subject.AssuranceTokenParameterValue5 = assuranceTokenParameterValue5;
		subject.AssuranceTokenParameterCode5 = assuranceTokenParameterCode5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "34", true)]
	[InlineData("t", "", false)]
	[InlineData("", "34", true)]
	public void Validation_ARequiresBAssuranceTokenParameterValue6(string assuranceTokenParameterValue6, string assuranceTokenParameterCode6, bool isValidExpected)
	{
		var subject = new C028_AssuranceTokenParameters();
		//Required fields
		subject.AssuranceTokenParameterCode = "U9";
		subject.AssuranceTokenParameterValue = "J";
		//Test Parameters
		subject.AssuranceTokenParameterValue6 = assuranceTokenParameterValue6;
		subject.AssuranceTokenParameterCode6 = assuranceTokenParameterCode6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "Ht", true)]
	[InlineData("r", "", false)]
	[InlineData("", "Ht", true)]
	public void Validation_ARequiresBAssuranceTokenParameterValue7(string assuranceTokenParameterValue7, string assuranceTokenParameterCode7, bool isValidExpected)
	{
		var subject = new C028_AssuranceTokenParameters();
		//Required fields
		subject.AssuranceTokenParameterCode = "U9";
		subject.AssuranceTokenParameterValue = "J";
		//Test Parameters
		subject.AssuranceTokenParameterValue7 = assuranceTokenParameterValue7;
		subject.AssuranceTokenParameterCode7 = assuranceTokenParameterCode7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "9u", true)]
	[InlineData("z", "", false)]
	[InlineData("", "9u", true)]
	public void Validation_ARequiresBAssuranceTokenParameterValue8(string assuranceTokenParameterValue8, string assuranceTokenParameterCode8, bool isValidExpected)
	{
		var subject = new C028_AssuranceTokenParameters();
		//Required fields
		subject.AssuranceTokenParameterCode = "U9";
		subject.AssuranceTokenParameterValue = "J";
		//Test Parameters
		subject.AssuranceTokenParameterValue8 = assuranceTokenParameterValue8;
		subject.AssuranceTokenParameterCode8 = assuranceTokenParameterCode8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "rb", true)]
	[InlineData("l", "", false)]
	[InlineData("", "rb", true)]
	public void Validation_ARequiresBAssuranceTokenParameterValue9(string assuranceTokenParameterValue9, string assuranceTokenParameterCode9, bool isValidExpected)
	{
		var subject = new C028_AssuranceTokenParameters();
		//Required fields
		subject.AssuranceTokenParameterCode = "U9";
		subject.AssuranceTokenParameterValue = "J";
		//Test Parameters
		subject.AssuranceTokenParameterValue9 = assuranceTokenParameterValue9;
		subject.AssuranceTokenParameterCode9 = assuranceTokenParameterCode9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z", "NU", true)]
	[InlineData("Z", "", false)]
	[InlineData("", "NU", true)]
	public void Validation_ARequiresBAssuranceTokenParameterValue10(string assuranceTokenParameterValue10, string assuranceTokenParameterCode10, bool isValidExpected)
	{
		var subject = new C028_AssuranceTokenParameters();
		//Required fields
		subject.AssuranceTokenParameterCode = "U9";
		subject.AssuranceTokenParameterValue = "J";
		//Test Parameters
		subject.AssuranceTokenParameterValue10 = assuranceTokenParameterValue10;
		subject.AssuranceTokenParameterCode10 = assuranceTokenParameterCode10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
