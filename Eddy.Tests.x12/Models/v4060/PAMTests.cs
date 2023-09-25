using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class PAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAM*aY*8**n*8*Qw*zH1*16pWt4jy*wHQW*yPy*KOfdjGdA*z6ty*D*6*z";

		var expected = new PAM_PeriodAmount()
		{
			QuantityQualifier = "aY",
			Quantity = 8,
			CompositeUnitOfMeasure = null,
			AmountQualifierCode = "n",
			MonetaryAmount = 8,
			UnitOfTimePeriodOrInterval = "Qw",
			DateTimeQualifier = "zH1",
			Date = "16pWt4jy",
			Time = "wHQW",
			DateTimeQualifier2 = "yPy",
			Date2 = "KOfdjGdA",
			Time2 = "z6ty",
			PercentQualifier = "D",
			PercentageAsDecimal = 6,
			YesNoConditionOrResponseCode = "z",
		};

		var actual = Map.MapObject<PAM_PeriodAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("n", 8, true)]
	[InlineData("n", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "D";
			subject.PercentageAsDecimal = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "zH1";
			subject.Date = "16pWt4jy";
			subject.Time = "wHQW";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "yPy";
			subject.Date2 = "KOfdjGdA";
			subject.Time2 = "z6ty";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zH1", "Qw", true)]
	[InlineData("zH1", "", false)]
	[InlineData("", "Qw", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "D";
			subject.PercentageAsDecimal = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "yPy";
			subject.Date2 = "KOfdjGdA";
			subject.Time2 = "z6ty";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("zH1", "16pWt4jy", "wHQW", true)]
	[InlineData("zH1", "", "", false)]
	[InlineData("", "16pWt4jy", "wHQW", true)]
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
			subject.DateTimeQualifier = "zH1";
		if (time != "")
			subject.DateTimeQualifier = "zH1";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "D";
			subject.PercentageAsDecimal = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "yPy";
			subject.Date2 = "KOfdjGdA";
			subject.Time2 = "z6ty";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("16pWt4jy", "zH1", true)]
	[InlineData("16pWt4jy", "", false)]
	[InlineData("", "zH1", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		//A Requires B
		if (dateTimeQualifier != "")
			subject.UnitOfTimePeriodOrInterval = "Qw";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "D";
			subject.PercentageAsDecimal = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Time = "wHQW";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "yPy";
			subject.Date2 = "KOfdjGdA";
			subject.Time2 = "z6ty";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wHQW", "zH1", true)]
	[InlineData("wHQW", "", false)]
	[InlineData("", "zH1", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		//A Requires B
		if (dateTimeQualifier != "")
			subject.UnitOfTimePeriodOrInterval = "Qw";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "D";
			subject.PercentageAsDecimal = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.Date = "16pWt4jy";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "yPy";
			subject.Date2 = "KOfdjGdA";
			subject.Time2 = "z6ty";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yPy", "zH1", true)]
	[InlineData("yPy", "", false)]
	[InlineData("", "zH1", true)]
	public void Validation_ARequiresBDateTimeQualifier2(string dateTimeQualifier2, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.DateTimeQualifier = dateTimeQualifier;
		//A Requires B
		if (dateTimeQualifier != "")
			subject.UnitOfTimePeriodOrInterval = "Qw";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "D";
			subject.PercentageAsDecimal = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Date = "16pWt4jy";
			subject.Time = "wHQW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("yPy", "KOfdjGdA", "z6ty", true)]
	[InlineData("yPy", "", "", false)]
	[InlineData("", "KOfdjGdA", "z6ty", true)]
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
			subject.DateTimeQualifier2 = "yPy";
		if (time2 != "")
			subject.DateTimeQualifier2 = "yPy";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "D";
			subject.PercentageAsDecimal = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "zH1";
			subject.Date = "16pWt4jy";
			subject.Time = "wHQW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KOfdjGdA", "yPy", true)]
	[InlineData("KOfdjGdA", "", false)]
	[InlineData("", "yPy", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
	
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "D";
			subject.PercentageAsDecimal = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "zH1";
			subject.Date = "16pWt4jy";
			subject.Time = "wHQW";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "z6ty";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z6ty", "yPy", true)]
	[InlineData("z6ty", "", false)]
	[InlineData("", "yPy", true)]
	public void Validation_ARequiresBTime2(string time2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Time2 = time2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//A Requires B
		if (dateTimeQualifier2 != "")
			subject.DateTimeQualifier = "zH1";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "D";
			subject.PercentageAsDecimal = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "zH1";
			subject.Date = "16pWt4jy";
			subject.Time = "wHQW";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.Date2 = "KOfdjGdA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("D", 6, true)]
	[InlineData("D", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.PercentQualifier = percentQualifier;
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 8;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "zH1";
			subject.Date = "16pWt4jy";
			subject.Time = "wHQW";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "yPy";
			subject.Date2 = "KOfdjGdA";
			subject.Time2 = "z6ty";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("z", 8, true)]
	[InlineData("z", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "n";
			subject.MonetaryAmount = 8;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "D";
			subject.PercentageAsDecimal = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "zH1";
			subject.Date = "16pWt4jy";
			subject.Time = "wHQW";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "yPy";
			subject.Date2 = "KOfdjGdA";
			subject.Time2 = "z6ty";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
