using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SLNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLN*j*7*Y*5**7*gn*P*Wu*J*1W*7*tl*l*8O*s*un*Q*Y1*D*ES*D*SR*E*g3*S*By*1";

		var expected = new SLN_SublineItemDetail()
		{
			AssignedIdentification = "j",
			AssignedIdentification2 = "7",
			RelationshipCode = "Y",
			Quantity = 5,
			CompositeUnitOfMeasure = "",
			UnitPrice = 7,
			BasisOfUnitPriceCode = "gn",
			RelationshipCode2 = "P",
			ProductServiceIDQualifier = "Wu",
			ProductServiceID = "J",
			ProductServiceIDQualifier2 = "1W",
			ProductServiceID2 = "7",
			ProductServiceIDQualifier3 = "tl",
			ProductServiceID3 = "l",
			ProductServiceIDQualifier4 = "8O",
			ProductServiceID4 = "s",
			ProductServiceIDQualifier5 = "un",
			ProductServiceID5 = "Q",
			ProductServiceIDQualifier6 = "Y1",
			ProductServiceID6 = "D",
			ProductServiceIDQualifier7 = "ES",
			ProductServiceID7 = "D",
			ProductServiceIDQualifier8 = "SR",
			ProductServiceID8 = "E",
			ProductServiceIDQualifier9 = "g3",
			ProductServiceID9 = "S",
			ProductServiceIDQualifier10 = "By",
			ProductServiceID10 = "1",
		};

		var actual = Map.MapObject<SLN_SublineItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.RelationshipCode = "Y";
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredRelationshipCode(string relationshipCode, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = relationshipCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(5, "", true)]
	[InlineData(0, "", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, C001_CompositeUnitOfMeasure compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.CompositeUnitOfMeasure = compositeUnitOfMeasure;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 7, true)]
	[InlineData("gn", 0, false)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0)
		subject.UnitPrice = unitPrice;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 7, true)]
	[InlineData("P", 0, false)]
	public void Validation_ARequiresBRelationshipCode2(string relationshipCode2, decimal unitPrice, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.RelationshipCode2 = relationshipCode2;
		if (unitPrice > 0)
		subject.UnitPrice = unitPrice;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Wu", "J", true)]
	[InlineData("", "J", false)]
	[InlineData("Wu", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("1W", "7", true)]
	[InlineData("", "7", false)]
	[InlineData("1W", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("tl", "l", true)]
	[InlineData("", "l", false)]
	[InlineData("tl", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("8O", "s", true)]
	[InlineData("", "s", false)]
	[InlineData("8O", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("un", "Q", true)]
	[InlineData("", "Q", false)]
	[InlineData("un", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Y1", "D", true)]
	[InlineData("", "D", false)]
	[InlineData("Y1", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ES", "D", true)]
	[InlineData("", "D", false)]
	[InlineData("ES", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("SR", "E", true)]
	[InlineData("", "E", false)]
	[InlineData("SR", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("g3", "S", true)]
	[InlineData("", "S", false)]
	[InlineData("g3", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("By", "1", true)]
	[InlineData("", "1", false)]
	[InlineData("By", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		subject.AssignedIdentification = "j";
		subject.RelationshipCode = "Y";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
