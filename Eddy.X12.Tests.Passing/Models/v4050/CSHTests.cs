using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CSHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSH*Q*M*M*u*gfiQ92no*lP*Ds*t*3*U";

		var expected = new CSH_SalesRequirements()
		{
			SalesRequirementCode = "Q",
			ActionCode = "M",
			Amount = "M",
			AccountNumber = "u",
			Date = "gfiQ92no",
			AgencyQualifierCode = "lP",
			SpecialServicesCode = "Ds",
			ProductServiceSubstitutionCode = "t",
			PercentageAsDecimal = 3,
			PercentQualifier = "U",
		};

		var actual = Map.MapObject<CSH_SalesRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "M", true)]
	[InlineData("M", "", false)]
	[InlineData("", "M", true)]
	public void Validation_ARequiresBActionCode(string actionCode, string amount, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		subject.ActionCode = actionCode;
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode))
		{
			subject.AgencyQualifierCode = "lP";
			subject.SpecialServicesCode = "Ds";
		}
		//If one is filled, all are required
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || !string.IsNullOrEmpty(subject.PercentQualifier))
		{
			subject.PercentageAsDecimal = 3;
			subject.PercentQualifier = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lP", "Ds", true)]
	[InlineData("lP", "", false)]
	[InlineData("", "Ds", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		//If one is filled, all are required
		if(subject.PercentageAsDecimal > 0 || subject.PercentageAsDecimal > 0 || !string.IsNullOrEmpty(subject.PercentQualifier))
		{
			subject.PercentageAsDecimal = 3;
			subject.PercentQualifier = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "U", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "U", false)]
	public void Validation_AllAreRequiredPercentageAsDecimal(decimal percentageAsDecimal, string percentQualifier, bool isValidExpected)
	{
		var subject = new CSH_SalesRequirements();
		if (percentageAsDecimal > 0)
			subject.PercentageAsDecimal = percentageAsDecimal;
		subject.PercentQualifier = percentQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode))
		{
			subject.AgencyQualifierCode = "lP";
			subject.SpecialServicesCode = "Ds";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
