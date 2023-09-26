using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SVCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SVC*vG*r*3*5*B*mH*aA*U5";

		var expected = new SVC_ServiceInformation()
		{
			ProductServiceIDQualifier = "vG",
			ProductServiceID = "r",
			MonetaryAmount = 3,
			MonetaryAmount2 = 5,
			ProductServiceID2 = "B",
			ProcedureModifier = "mH",
			ProcedureModifier2 = "aA",
			ProcedureModifier3 = "U5",
		};

		var actual = Map.MapObject<SVC_ServiceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vG", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new SVC_ServiceInformation();
		//Required fields
		subject.ProductServiceID = "r";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 5;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SVC_ServiceInformation();
		//Required fields
		subject.ProductServiceIDQualifier = "vG";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 5;
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new SVC_ServiceInformation();
		//Required fields
		subject.ProductServiceIDQualifier = "vG";
		subject.ProductServiceID = "r";
		subject.MonetaryAmount2 = 5;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SVC_ServiceInformation();
		//Required fields
		subject.ProductServiceIDQualifier = "vG";
		subject.ProductServiceID = "r";
		subject.MonetaryAmount = 3;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
