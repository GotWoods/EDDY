using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIS*TX*BKCbh8*57*t6*J";

		var expected = new TIS_TitleInsuranceServices()
		{
			TitleInsuranceServicesCode = "TX",
			Date = "BKCbh8",
			Century = 57,
			ProductServiceIDQualifier = "t6",
			ProductServiceID = "J",
		};

		var actual = Map.MapObject<TIS_TitleInsuranceServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TX", true)]
	public void Validation_RequiredTitleInsuranceServicesCode(string titleInsuranceServicesCode, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		//Required fields
		//Test Parameters
		subject.TitleInsuranceServicesCode = titleInsuranceServicesCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "t6";
			subject.ProductServiceID = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(57, "BKCbh8", true)]
	[InlineData(57, "", false)]
	[InlineData(0, "BKCbh8", true)]
	public void Validation_ARequiresBCentury(int century, string date, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		//Required fields
		subject.TitleInsuranceServicesCode = "TX";
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "t6";
			subject.ProductServiceID = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t6", "J", true)]
	[InlineData("t6", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		//Required fields
		subject.TitleInsuranceServicesCode = "TX";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
