using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSS*t*RU*5M*v*3*4*S";

		var expected = new SSS_SpecialServices()
		{
			AllowanceOrChargeIndicator = "t",
			AssociationQualifierCode = "RU",
			SpecialServicesCode = "5M",
			ServiceMarksAndNumbers = "v",
			AllowanceOrChargeRate = 3,
			AllowanceOrChargeTotalAmount = "4",
			Description = "S",
		};

		var actual = Map.MapObject<SSS_SpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AssociationQualifierCode = "RU";
		subject.SpecialServicesCode = "5M";
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RU", true)]
	public void Validation_RequiredAssociationQualifierCode(string associationQualifierCode, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AllowanceOrChargeIndicator = "t";
		subject.SpecialServicesCode = "5M";
		subject.AssociationQualifierCode = associationQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5M", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AllowanceOrChargeIndicator = "t";
		subject.AssociationQualifierCode = "RU";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
