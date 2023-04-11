//TODO: fix these tests

// using EdiParser.Validation;
// using EdiParser.x12.Mapping;
// using EdiParser.x12.Models;
//
// namespace EdiParser.Tests.x12.Models;
//
// public class ADJTests
// {
//     [Fact]
//     public void Parse_ShouldReturnCorrectObject()
//     {
//         var x12Line = "ADJ*4*4*4*0pQaXwqU*c4BNM00h*4*n*LU*9*V*d*g*6*8*6*QL*Z";
//
//         var expected = new ADJ_AdjustmentsToBalancesOrServices
//         {
//             AdjustmentApplicationCode = "4",
//             MonetaryAmount = 4,
//             MonetaryAmount2 = 4,
//             Date = "0pQaXwqU",
//             Date2 = "c4BNM00h",
//             Number = 4,
//             Description = "n",
//             ProductServiceIDQualifier = "LU",
//             ProductServiceID = "9",
//             Amount = "V",
//             Amount2 = "d",
//             Amount3 = "g",
//             Quantity = 6,
//             Quantity2 = 8,
//             Quantity3 = 6,
//             ReferenceIdentificationQualifier = "QL",
//             ReferenceIdentification = "Z"
//         };
//
//         var actual = Map.MapObject<ADJ_AdjustmentsToBalancesOrServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
//         Assert.Equivalent(expected, actual);
//     }
//
//     [Theory]
//     [InlineData("", false)]
//     [InlineData("4", true)]
//     public void Validation_RequiredAdjustmentApplicationCode(string adjustmentApplicationCode, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         subject.AdjustmentApplicationCode = adjustmentApplicationCode;
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
//     }
//
//     [Theory]
//     [InlineData("", false)]
//     [InlineData("4", true)]
//     public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         if (monetaryAmount > 0)
//             subject.MonetaryAmount = monetaryAmount;
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
//     }
//
//     [Theory]
//     [InlineData("", false)]
//     [InlineData("0pQaXwqU", true)]
//     public void Validation_RequiredDate(string date, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date2 = "c4BNM00h";
//         subject.Date = date;
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
//     }
//
//     [Theory]
//     [InlineData("", false)]
//     [InlineData("c4BNM00h", true)]
//     public void Validation_RequiredDate2(string date2, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = date2;
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
//     }
//
//     [Theory]
//     [InlineData("", "", true)]
//     [InlineData("LU", "9", true)]
//     [InlineData("", "9", false)]
//     [InlineData("LU", "", false)]
//     public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         subject.ProductServiceIDQualifier = productServiceIDQualifier;
//         subject.ProductServiceID = productServiceID;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
//     }
//
//     [Theory]
//     [InlineData("", "", true)]
//     [InlineData("", "9", true)]
//     [InlineData("V", "", false)]
//     public void Validation_ARequiresBAmount(string amount, string productServiceID, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         subject.Amount = amount;
//         subject.ProductServiceID = productServiceID;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
//     }
//
//     [Theory]
//     [InlineData("", "", true)]
//     [InlineData("V", "d", false)]
//     [InlineData("", "d", true)]
//     [InlineData("V", "", true)]
//     public void Validation_NEWAmount(string amount, string amount2, string amount3, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         subject.Amount = amount;
//         subject.Amount2 = amount2;
//         subject.Amount3 = amount3;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
//     }
//
//     [Theory]
//     [InlineData("", "", true)]
//     [InlineData("", "9", true)]
//     [InlineData("d", "", false)]
//     public void Validation_ARequiresBAmount2(string amount2, string productServiceID, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         subject.Amount2 = amount2;
//         subject.ProductServiceID = productServiceID;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
//     }
//
//     [Theory]
//     [InlineData("", "", true)]
//     [InlineData("d", "V", false)]
//     [InlineData("", "V", true)]
//     [InlineData("d", "", true)]
//     public void Validation_NEWAmount2(string amount2, string amount, string amount3, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         subject.Amount2 = amount2;
//         subject.Amount = amount;
//         subject.Amount3 = amount3;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
//     }
//
//     [Theory]
//     [InlineData("", "", true)]
//     [InlineData("", "9", true)]
//     [InlineData("g", "", false)]
//     public void Validation_ARequiresBAmount3(string amount3, string productServiceID, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         subject.Amount3 = amount3;
//         subject.ProductServiceID = productServiceID;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
//     }
//
//     [Theory]
//     [InlineData("", "", true)]
//     [InlineData("g", "V", false)]
//     [InlineData("", "V", true)]
//     [InlineData("g", "", true)]
//     public void Validation_NEWAmount3(string amount3, string amount, string amount2, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         subject.Amount3 = amount3;
//         subject.Amount = amount;
//         subject.Amount2 = amount2;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
//     }
//
//     [Theory]
//     [InlineData(0, "", true)]
//     [InlineData(0, "9", true)]
//     [InlineData(6, "", false)]
//     public void Validation_ARequiresBQuantity(decimal quantity, string productServiceID, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         if (quantity > 0)
//             subject.Quantity = quantity;
//         subject.ProductServiceID = productServiceID;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
//     }
//
//     [Theory]
//     [InlineData(0, 0, true)]
//     [InlineData(6, 8, false)]
//     [InlineData(0, 8, true)]
//     [InlineData(6, 0, true)]
//     public void Validation_NEWQuantity(decimal quantity, decimal quantity2, decimal quantity3, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         if (quantity > 0)
//             subject.Quantity = quantity;
//         if (quantity2 > 0)
//             subject.Quantity2 = quantity2;
//         if (quantity3 > 0)
//             subject.Quantity3 = quantity3;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
//     }
//
//     [Theory]
//     [InlineData(0, "", true)]
//     [InlineData(0, "9", true)]
//     [InlineData(8, "", false)]
//     public void Validation_ARequiresBQuantity2(decimal quantity2, string productServiceID, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         if (quantity2 > 0)
//             subject.Quantity2 = quantity2;
//         subject.ProductServiceID = productServiceID;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
//     }
//
//     [Theory]
//     [InlineData(0, 0, true)]
//     [InlineData(8, 6, false)]
//     [InlineData(0, 6, true)]
//     [InlineData(8, 0, true)]
//     public void Validation_NEWQuantity2(decimal quantity2, decimal quantity, decimal quantity3, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         if (quantity2 > 0)
//             subject.Quantity2 = quantity2;
//         if (quantity > 0)
//             subject.Quantity = quantity;
//         if (quantity3 > 0)
//             subject.Quantity3 = quantity3;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
//     }
//
//     [Theory]
//     [InlineData(0, "", true)]
//     [InlineData(0, "9", true)]
//     [InlineData(6, "", false)]
//     public void Validation_ARequiresBQuantity3(decimal quantity3, string productServiceID, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         if (quantity3 > 0)
//             subject.Quantity3 = quantity3;
//         subject.ProductServiceID = productServiceID;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
//     }
//
//     [Theory]
//     [InlineData(0, 0, true)]
//     [InlineData(6, 6, false)]
//     [InlineData(0, 6, true)]
//     [InlineData(6, 0, true)]
//     public void Validation_NEWQuantity3(decimal quantity3, decimal quantity, decimal quantity2, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         if (quantity3 > 0)
//             subject.Quantity3 = quantity3;
//         if (quantity > 0)
//             subject.Quantity = quantity;
//         if (quantity2 > 0)
//             subject.Quantity2 = quantity2;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
//     }
//
//     [Theory]
//     [InlineData("", "", true)]
//     [InlineData("QL", "Z", true)]
//     [InlineData("", "Z", false)]
//     [InlineData("QL", "", false)]
//     public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
//         subject.ReferenceIdentification = referenceIdentification;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
//     }
//
//     [Theory]
//     [InlineData("", "", true)]
//     [InlineData("", "9", true)]
//     [InlineData("Z", "", false)]
//     public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string productServiceID, bool isValidExpected)
//     {
//         var subject = new ADJ_AdjustmentsToBalancesOrServices();
//         subject.AdjustmentApplicationCode = "4";
//         subject.MonetaryAmount = 4;
//         subject.Date = "0pQaXwqU";
//         subject.Date2 = "c4BNM00h";
//         subject.ReferenceIdentification = referenceIdentification;
//         subject.ProductServiceID = productServiceID;
//
//         TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
//     }
// }