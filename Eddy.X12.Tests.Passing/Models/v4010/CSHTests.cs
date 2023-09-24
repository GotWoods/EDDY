using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CSHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSH*g*n*A*G*5w56yLYR*3x*ZE*b*6*f";

		var expected = new CSH_SalesRequirements()
		{
			SalesRequirementCode = "g",
			ActionCode = "n",
			Amount = "A",
			AccountNumber = "G",
			Date = "5w56yLYR",
			AgencyQualifierCode = "3x",
			SpecialServicesCode = "ZE",
			ProductServiceSubstitutionCode = "b",
			Percent = 6,
			PercentQualifier = "f",
		};

		var actual = Map.MapObject<CSH_SalesRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "A", true)]
	[InlineData("n", "", false)]
	[InlineData("", "A", true)]
	public void Validation_ARequiresBActionCode(string actionCode, string amount, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		subject.ActionCode = actionCode;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode))
		{
			subject.AgencyQualifierCode = "3x";
			subject.SpecialServicesCode = "ZE";
		}
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.PercentQualifier))
		{
			subject.Percent = 6;
			subject.PercentQualifier = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3x", "ZE", true)]
	[InlineData("3x", "", false)]
	[InlineData("", "ZE", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.PercentQualifier))
		{
			subject.Percent = 6;
			subject.PercentQualifier = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "f", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "f", false)]
	public void Validation_AllAreRequiredPercent(decimal percent, string percentQualifier, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		if (percent > 0)
			subject.Percent = percent;
		subject.PercentQualifier = percentQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode))
		{
			subject.AgencyQualifierCode = "3x";
			subject.SpecialServicesCode = "ZE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
