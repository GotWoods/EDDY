using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIS*i2*MepPA1*83*5H*l";

		var expected = new TIS_TitleInsuranceServices()
		{
			TitleInsuranceServicesCode = "i2",
			Date = "MepPA1",
			Century = 83,
			ProductServiceIDQualifier = "5H",
			ProductServiceID = "l",
		};

		var actual = Map.MapObject<TIS_TitleInsuranceServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i2", true)]
	public void Validation_RequiredTitleInsuranceServicesCode(string titleInsuranceServicesCode, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		//Required fields
		//Test Parameters
		subject.TitleInsuranceServicesCode = titleInsuranceServicesCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "5H";
			subject.ProductServiceID = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(83, "MepPA1", true)]
	[InlineData(83, "", false)]
	[InlineData(0, "MepPA1", true)]
	public void Validation_ARequiresBCentury(int century, string date, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		//Required fields
		subject.TitleInsuranceServicesCode = "i2";
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "5H";
			subject.ProductServiceID = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5H", "l", true)]
	[InlineData("5H", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		//Required fields
		subject.TitleInsuranceServicesCode = "i2";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
