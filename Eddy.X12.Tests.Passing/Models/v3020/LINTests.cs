using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIN*b*Es*N*Fe*P*2B*l*IK*I*dX*H*jU*m*Br*a*dl*R*0T*F*FL*q*Ud*F*3T*l*CM*K*VO*4*NO*r";

		var expected = new LIN_ItemIdentification()
		{
			AssignedIdentification = "b",
			ProductServiceIDQualifier = "Es",
			ProductServiceID = "N",
			ProductServiceIDQualifier2 = "Fe",
			ProductServiceID2 = "P",
			ProductServiceIDQualifier3 = "2B",
			ProductServiceID3 = "l",
			ProductServiceIDQualifier4 = "IK",
			ProductServiceID4 = "I",
			ProductServiceIDQualifier5 = "dX",
			ProductServiceID5 = "H",
			ProductServiceIDQualifier6 = "jU",
			ProductServiceID6 = "m",
			ProductServiceIDQualifier7 = "Br",
			ProductServiceID7 = "a",
			ProductServiceIDQualifier8 = "dl",
			ProductServiceID8 = "R",
			ProductServiceIDQualifier9 = "0T",
			ProductServiceID9 = "F",
			ProductServiceIDQualifier10 = "FL",
			ProductServiceID10 = "q",
			ProductServiceIDQualifier11 = "Ud",
			ProductServiceID11 = "F",
			ProductServiceIDQualifier12 = "3T",
			ProductServiceID12 = "l",
			ProductServiceIDQualifier13 = "CM",
			ProductServiceID13 = "K",
			ProductServiceIDQualifier14 = "VO",
			ProductServiceID14 = "4",
			ProductServiceIDQualifier15 = "NO",
			ProductServiceID15 = "r",
		};

		var actual = Map.MapObject<LIN_ItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Es", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fe", "P", true)]
	[InlineData("Fe", "", false)]
	[InlineData("", "P", true)]
	public void Validation_ARequiresBProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2B", "l", true)]
	[InlineData("2B", "", false)]
	[InlineData("", "l", true)]
	public void Validation_ARequiresBProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("IK", "I", true)]
	[InlineData("IK", "", false)]
	[InlineData("", "I", true)]
	public void Validation_ARequiresBProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dX", "H", true)]
	[InlineData("dX", "", false)]
	[InlineData("", "H", true)]
	public void Validation_ARequiresBProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jU", "m", true)]
	[InlineData("jU", "", false)]
	[InlineData("", "m", true)]
	public void Validation_ARequiresBProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Br", "a", true)]
	[InlineData("Br", "", false)]
	[InlineData("", "a", true)]
	public void Validation_ARequiresBProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dl", "R", true)]
	[InlineData("dl", "", false)]
	[InlineData("", "R", true)]
	public void Validation_ARequiresBProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0T", "F", true)]
	[InlineData("0T", "", false)]
	[InlineData("", "F", true)]
	public void Validation_ARequiresBProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("FL", "q", true)]
	[InlineData("FL", "", false)]
	[InlineData("", "q", true)]
	public void Validation_ARequiresBProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ud", "F", true)]
	[InlineData("Ud", "", false)]
	[InlineData("", "F", true)]
	public void Validation_ARequiresBProductServiceIDQualifier11(string productServiceIDQualifier11, string productServiceID11, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier11 = productServiceIDQualifier11;
		subject.ProductServiceID11 = productServiceID11;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3T", "l", true)]
	[InlineData("3T", "", false)]
	[InlineData("", "l", true)]
	public void Validation_ARequiresBProductServiceIDQualifier12(string productServiceIDQualifier12, string productServiceID12, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier12 = productServiceIDQualifier12;
		subject.ProductServiceID12 = productServiceID12;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CM", "K", true)]
	[InlineData("CM", "", false)]
	[InlineData("", "K", true)]
	public void Validation_ARequiresBProductServiceIDQualifier13(string productServiceIDQualifier13, string productServiceID13, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier13 = productServiceIDQualifier13;
		subject.ProductServiceID13 = productServiceID13;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VO", "4", true)]
	[InlineData("VO", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBProductServiceIDQualifier14(string productServiceIDQualifier14, string productServiceID14, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier14 = productServiceIDQualifier14;
		subject.ProductServiceID14 = productServiceID14;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NO", "r", true)]
	[InlineData("NO", "", false)]
	[InlineData("", "r", true)]
	public void Validation_ARequiresBProductServiceIDQualifier15(string productServiceIDQualifier15, string productServiceID15, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "Es";
		subject.ProductServiceID = "N";
		subject.ProductServiceIDQualifier15 = productServiceIDQualifier15;
		subject.ProductServiceID15 = productServiceID15;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
