using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CSHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSH*3*M*U*j*YPL8hm*OH*aD*k*9";

		var expected = new CSH_HeaderSaleCondition()
		{
			SalesRequirementCode = "3",
			DoNotExceedActionCode = "M",
			Amount = "U",
			AccountNumber = "j",
			Date = "YPL8hm",
			AgencyQualifierCode = "OH",
			SpecialServicesCode = "aD",
			ProductServiceSubstitutionCode = "k",
			Percent = 9,
		};

		var actual = Map.MapObject<CSH_HeaderSaleCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "U", true)]
	[InlineData("M", "", false)]
	[InlineData("", "U", true)]
	public void Validation_ARequiresBDoNotExceedActionCode(string doNotExceedActionCode, string amount, bool isValidExpected)
	{
		var subject = new CSH_HeaderSaleCondition();
		subject.DoNotExceedActionCode = doNotExceedActionCode;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode))
		{
			subject.AgencyQualifierCode = "OH";
			subject.SpecialServicesCode = "aD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("OH", "aD", true)]
	[InlineData("OH", "", false)]
	[InlineData("", "aD", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, bool isValidExpected)
	{
		var subject = new CSH_HeaderSaleCondition();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
