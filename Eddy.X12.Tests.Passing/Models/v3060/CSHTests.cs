using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CSHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSH*s*6*u*a*uuG0Nz*U0*GN*6*9*a";

		var expected = new CSH_SalesRequirements()
		{
			SalesRequirementCode = "s",
			DoNotExceedActionCode = "6",
			Amount = "u",
			AccountNumber = "a",
			Date = "uuG0Nz",
			AgencyQualifierCode = "U0",
			SpecialServicesCode = "GN",
			ProductServiceSubstitutionCode = "6",
			Percent = 9,
			PercentQualifier = "a",
		};

		var actual = Map.MapObject<CSH_SalesRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "u", true)]
	[InlineData("6", "", false)]
	[InlineData("", "u", true)]
	public void Validation_ARequiresBDoNotExceedActionCode(string doNotExceedActionCode, string amount, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		subject.DoNotExceedActionCode = doNotExceedActionCode;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode))
		{
			subject.AgencyQualifierCode = "U0";
			subject.SpecialServicesCode = "GN";
		}
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.PercentQualifier))
		{
			subject.Percent = 9;
			subject.PercentQualifier = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U0", "GN", true)]
	[InlineData("U0", "", false)]
	[InlineData("", "GN", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		//If one is filled, all are required
		if(subject.Percent > 0 || subject.Percent > 0 || !string.IsNullOrEmpty(subject.PercentQualifier))
		{
			subject.Percent = 9;
			subject.PercentQualifier = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "a", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "a", false)]
	public void Validation_AllAreRequiredPercent(decimal percent, string percentQualifier, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		if (percent > 0)
			subject.Percent = percent;
		subject.PercentQualifier = percentQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode))
		{
			subject.AgencyQualifierCode = "U0";
			subject.SpecialServicesCode = "GN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
