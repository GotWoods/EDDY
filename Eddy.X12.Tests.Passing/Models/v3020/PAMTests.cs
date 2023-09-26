using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAM*yl*8*jc*O*9*CG*TaF*ZnX6SJ*5mbt*Vfd*Na9Sof*RVjM*g*6";

		var expected = new PAM_PeriodAmount()
		{
			QuantityQualifier = "yl",
			Quantity = 8,
			UnitOfMeasurementCode = "jc",
			AmountQualifierCode = "O",
			MonetaryAmount = 9,
			UnitOfTimePeriodCode = "CG",
			DateTimeQualifier = "TaF",
			Date = "ZnX6SJ",
			Time = "5mbt",
			DateTimeQualifier2 = "Vfd",
			Date2 = "Na9Sof",
			Time2 = "RVjM",
			PercentQualifier = "g",
			Percent = 6,
		};

		var actual = Map.MapObject<PAM_PeriodAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(8, 9, true)]
	[InlineData(8, 0, true)]
	[InlineData(0, 9, true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodCode = "CG";
			subject.DateTimeQualifier = "TaF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "g";
			subject.Percent = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "TaF";
			subject.Date = "ZnX6SJ";
			subject.Time = "5mbt";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "Vfd";
			subject.Date2 = "Na9Sof";
			subject.Time2 = "RVjM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("O", 9, true)]
	[InlineData("O", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//At Least one
		subject.Quantity = 8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodCode = "CG";
			subject.DateTimeQualifier = "TaF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "g";
			subject.Percent = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "TaF";
			subject.Date = "ZnX6SJ";
			subject.Time = "5mbt";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "Vfd";
			subject.Date2 = "Na9Sof";
			subject.Time2 = "RVjM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CG", "TaF", true)]
	[InlineData("CG", "", false)]
	[InlineData("", "TaF", false)]
	public void Validation_AllAreRequiredUnitOfTimePeriodCode(string unitOfTimePeriodCode, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.UnitOfTimePeriodCode = unitOfTimePeriodCode;
		subject.DateTimeQualifier = dateTimeQualifier;
		//At Least one
		subject.Quantity = 8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "g";
			subject.Percent = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Date = "ZnX6SJ";
			subject.Time = "5mbt";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "Vfd";
			subject.Date2 = "Na9Sof";
			subject.Time2 = "RVjM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("TaF", "ZnX6SJ", "5mbt", true)]
	[InlineData("TaF", "", "", false)]
	[InlineData("", "ZnX6SJ", "5mbt", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier(string dateTimeQualifier, string date, string time, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		subject.Time = time;
		//A Requires B
		if (date != "")
			subject.DateTimeQualifier = "TaF";
		if (time != "")
			subject.DateTimeQualifier = "TaF";
		//At Least one
		subject.Quantity = 8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodCode = "CG";
			subject.DateTimeQualifier = "TaF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "g";
			subject.Percent = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "Vfd";
			subject.Date2 = "Na9Sof";
			subject.Time2 = "RVjM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZnX6SJ", "TaF", true)]
	[InlineData("ZnX6SJ", "", false)]
	[InlineData("", "TaF", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		//At Least one
		subject.Quantity = 8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodCode = "CG";
			subject.DateTimeQualifier = "TaF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "g";
			subject.Percent = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Time = "5mbt";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "Vfd";
			subject.Date2 = "Na9Sof";
			subject.Time2 = "RVjM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5mbt", "TaF", true)]
	[InlineData("5mbt", "", false)]
	[InlineData("", "TaF", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		//At Least one
		subject.Quantity = 8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodCode = "CG";
			subject.DateTimeQualifier = "TaF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "g";
			subject.Percent = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.Date = "ZnX6SJ";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "Vfd";
			subject.Date2 = "Na9Sof";
			subject.Time2 = "RVjM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("Vfd", "Na9Sof", "RVjM", true)]
	[InlineData("Vfd", "", "", false)]
	[InlineData("", "Na9Sof", "RVjM", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_DateTimeQualifier2(string dateTimeQualifier2, string date2, string time2, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;
		subject.Time2 = time2;
		//A Requires B
		if (date2 != "")
			subject.DateTimeQualifier2 = "Vfd";
		//At Least one
		subject.Quantity = 8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodCode = "CG";
			subject.DateTimeQualifier = "TaF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "g";
			subject.Percent = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "TaF";
			subject.Date = "ZnX6SJ";
			subject.Time = "5mbt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Na9Sof", "Vfd", true)]
	[InlineData("Na9Sof", "", false)]
	[InlineData("", "Vfd", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//At Least one
		subject.Quantity = 8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodCode = "CG";
			subject.DateTimeQualifier = "TaF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "g";
			subject.Percent = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "TaF";
			subject.Date = "ZnX6SJ";
			subject.Time = "5mbt";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "RVjM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("g", 6, true)]
	[InlineData("g", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.PercentQualifier = percentQualifier;
		if (percent > 0) 
			subject.Percent = percent;
		//At Least one
		subject.Quantity = 8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "O";
			subject.MonetaryAmount = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodCode) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodCode = "CG";
			subject.DateTimeQualifier = "TaF";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "TaF";
			subject.Date = "ZnX6SJ";
			subject.Time = "5mbt";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "Vfd";
			subject.Date2 = "Na9Sof";
			subject.Time2 = "RVjM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
