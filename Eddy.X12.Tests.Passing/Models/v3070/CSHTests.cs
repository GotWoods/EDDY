using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CSHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSH*U*O*0*P*59yfyW*mQ*DZ*w*8*J";

		var expected = new CSH_SalesRequirements()
		{
			SalesRequirementCode = "U",
			ActionCode = "O",
			Amount = "0",
			AccountNumber = "P",
			Date = "59yfyW",
			AgencyQualifierCode = "mQ",
			SpecialServicesCode = "DZ",
			ProductServiceSubstitutionCode = "w",
			Percent = 8,
			PercentQualifier = "J",
		};

		var actual = Map.MapObject<CSH_SalesRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "0", true)]
	[InlineData("O", "", false)]
	[InlineData("", "0", true)]
	public void Validation_ARequiresBActionCode(string actionCode, string amount, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		subject.ActionCode = actionCode;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode))
		{
			subject.AgencyQualifierCode = "mQ";
			subject.SpecialServicesCode = "DZ";
		}
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.PercentQualifier))
		{
			subject.Percent = 8;
			subject.PercentQualifier = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mQ", "DZ", true)]
	[InlineData("mQ", "", false)]
	[InlineData("", "DZ", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.PercentQualifier))
		{
			subject.Percent = 8;
			subject.PercentQualifier = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "J", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "J", false)]
	public void Validation_AllAreRequiredPercent(decimal percent, string percentQualifier, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		if (percent > 0)
			subject.Percent = percent;
		subject.PercentQualifier = percentQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode))
		{
			subject.AgencyQualifierCode = "mQ";
			subject.SpecialServicesCode = "DZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
