//TODO: this test
// using EdiParser.Validation;
// using EdiParser.x12.Mapping;
// using EdiParser.x12.Models;
//
// namespace EdiParser.Tests.x12.Models;
//
// public class CURTests
// {
// 	[Fact]
// 	public void Parse_ShouldReturnCorrectObject()
// 	{
// 		string x12Line = "CUR*kg*yzQ*6155*kK*52d*yXy*zJ9*Sr0tJrQX*2478*AVF*6Y64VtU9*WNGh*Uk3*yASQLllo*mQfo*RnA*gzd909tf*RCqJ*cnV*SOKDRMWs*BAgY";
//
// 		var expected = new CUR_Currency()
// 		{
// 			EntityIdentifierCode = "kg",
// 			CurrencyCode = "yzQ",
// 			ExchangeRate = 6155,
// 			EntityIdentifierCode2 = "kK",
// 			CurrencyCode2 = "52d",
// 			CurrencyMarketExchangeCode = "yXy",
// 			DateTimeQualifier = "zJ9",
// 			Date = "Sr0tJrQX",
// 			Time = "2478",
// 			DateTimeQualifier2 = "AVF",
// 			Date2 = "6Y64VtU9",
// 			Time2 = "WNGh",
// 			DateTimeQualifier3 = "Uk3",
// 			Date3 = "yASQLllo",
// 			Time3 = "mQfo",
// 			DateTimeQualifier4 = "RnA",
// 			Date4 = "gzd909tf",
// 			Time4 = "RCqJ",
// 			DateTimeQualifier5 = "cnV",
// 			Date5 = "SOKDRMWs",
// 			Time5 = "BAgY",
// 		};
//
// 		var actual = Map.MapObject<CUR_Currency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
// 		Assert.Equivalent(expected, actual);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("kg", true)]
// 	public void Validatation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.CurrencyCode = "yzQ";
// 		subject.EntityIdentifierCode = entityIdentifierCode;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("yzQ", true)]
// 	public void Validatation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = currencyCode;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", "", true)]
// 	[InlineData("", "zJ9", true)]
// 	[InlineData("Sr0tJrQX", "", false)]
// 	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.Date = date;
// 		subject.DateTimeQualifier = dateTimeQualifier;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("", "", true)]
// 	[InlineData("", "zJ9", true)]
// 	[InlineData("2478", "", false)]
// 	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.Time = time;
// 		subject.DateTimeQualifier = dateTimeQualifier;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("","", "", true)]
// 	[InlineData("AVF", "6Y64VtU9", false)]
// 	[InlineData("","6Y64VtU9", true)]
// 	[InlineData("AVF", "", true)]
// 	public void Validation_NEWDateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.DateTimeQualifier2 = dateTimeQualifier2;
// 		subject.Date2 = date2;
// 		subject.Time2 = time2;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
// 	}
//
// 	[Theory]
// 	[InlineData("", "", true)]
// 	[InlineData("", "AVF", true)]
// 	[InlineData("6Y64VtU9", "", false)]
// 	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.Date2 = date2;
// 		subject.DateTimeQualifier2 = dateTimeQualifier2;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("", "", true)]
// 	[InlineData("", "AVF", true)]
// 	[InlineData("WNGh", "", false)]
// 	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.Time2 = time2;
// 		subject.DateTimeQualifier2 = dateTimeQualifier2;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("","", true)]
// 	[InlineData("Uk3", "yASQLllo", false)]
// 	[InlineData("","yASQLllo", true)]
// 	[InlineData("Uk3", "", true)]
// 	public void Validation_NEWDateTimeQualifier3(string dateTimeQualifier3, string date3, string time3, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.DateTimeQualifier3 = dateTimeQualifier3;
// 		subject.Date3 = date3;
// 		subject.Time3 = time3;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
// 	}
//
// 	[Theory]
// 	[InlineData("", "", true)]
// 	[InlineData("", "Uk3", true)]
// 	[InlineData("yASQLllo", "", false)]
// 	public void Validation_ARequiresBDate3(string date3, string dateTimeQualifier3, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.Date3 = date3;
// 		subject.DateTimeQualifier3 = dateTimeQualifier3;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("", "", true)]
// 	[InlineData("", "Uk3", true)]
// 	[InlineData("mQfo", "", false)]
// 	public void Validation_ARequiresBTime3(string time3, string dateTimeQualifier3, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.Time3 = time3;
// 		subject.DateTimeQualifier3 = dateTimeQualifier3;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("","", true)]
// 	[InlineData("RnA", "gzd909tf", false)]
// 	[InlineData("","gzd909tf", true)]
// 	[InlineData("RnA", "", true)]
// 	public void Validation_NEWDateTimeQualifier4(string dateTimeQualifier4, string date4, string time4, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.DateTimeQualifier4 = dateTimeQualifier4;
// 		subject.Date4 = date4;
// 		subject.Time4 = time4;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
// 	}
//
// 	[Theory]
// 	[InlineData("", "", true)]
// 	[InlineData("", "RnA", true)]
// 	[InlineData("gzd909tf", "", false)]
// 	public void Validation_ARequiresBDate4(string date4, string dateTimeQualifier4, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.Date4 = date4;
// 		subject.DateTimeQualifier4 = dateTimeQualifier4;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("", "", true)]
// 	[InlineData("", "RnA", true)]
// 	[InlineData("RCqJ", "", false)]
// 	public void Validation_ARequiresBTime4(string time4, string dateTimeQualifier4, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.Time4 = time4;
// 		subject.DateTimeQualifier4 = dateTimeQualifier4;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("","", true)]
// 	[InlineData("cnV", "SOKDRMWs", false)]
// 	[InlineData("","SOKDRMWs", true)]
// 	[InlineData("cnV", "", true)]
// 	public void Validation_NEWDateTimeQualifier5(string dateTimeQualifier5, string date5, string time5, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.DateTimeQualifier5 = dateTimeQualifier5;
// 		subject.Date5 = date5;
// 		subject.Time5 = time5;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
// 	}
//
// 	[Theory]
// 	[InlineData("", "", true)]
// 	[InlineData("", "cnV", true)]
// 	[InlineData("SOKDRMWs", "", false)]
// 	public void Validation_ARequiresBDate5(string date5, string dateTimeQualifier5, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.Date5 = date5;
// 		subject.DateTimeQualifier5 = dateTimeQualifier5;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// 	[Theory]
// 	[InlineData("", "", true)]
// 	[InlineData("", "cnV", true)]
// 	[InlineData("BAgY", "", false)]
// 	public void Validation_ARequiresBTime5(string time5, string dateTimeQualifier5, bool isValidExpected)
// 	{
// 		var subject = new CUR_Currency();
// 		subject.EntityIdentifierCode = "kg";
// 		subject.CurrencyCode = "yzQ";
// 		subject.Time5 = time5;
// 		subject.DateTimeQualifier5 = dateTimeQualifier5;
//
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
// 	}
//
// }
