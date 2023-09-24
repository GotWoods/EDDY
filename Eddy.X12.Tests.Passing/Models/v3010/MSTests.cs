using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class MSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS*7S*0x*H*tp*1*9";

		var expected = new MS_MiscellaneousServices()
		{
			AssociationQualifierCode = "7S",
			SpecialServicesCode = "0x",
			Charge = "H",
			RateValueQualifier = "tp",
			Charge2 = "1",
			AssignedNumber = 9,
		};

		var actual = Map.MapObject<MS_MiscellaneousServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7S", true)]
	public void Validation_RequiredAssociationQualifierCode(string associationQualifierCode, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.SpecialServicesCode = "0x";
		subject.Charge = "H";
		subject.AssociationQualifierCode = associationQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0x", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.AssociationQualifierCode = "7S";
		subject.Charge = "H";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.AssociationQualifierCode = "7S";
		subject.SpecialServicesCode = "0x";
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
