using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAM*rN*2*Va*N*2*Xh*iFF*Cz3jBM*5dtz*KpP*pg7oh0*RqA8*L*2";

		var expected = new PAM_PeriodAmount()
		{
			QuantityQualifier = "rN",
			Quantity = 2,
			UnitOrBasisForMeasurementCode = "Va",
			AmountQualifierCode = "N",
			MonetaryAmount = 2,
			UnitOfTimePeriodOrInterval = "Xh",
			DateTimeQualifier = "iFF",
			Date = "Cz3jBM",
			Time = "5dtz",
			DateTimeQualifier2 = "KpP",
			Date2 = "pg7oh0",
			Time2 = "RqA8",
			PercentQualifier = "L",
			Percent = 2,
		};

		var actual = Map.MapObject<PAM_PeriodAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(2, 2, true)]
	[InlineData(2, 0, true)]
	[InlineData(0, 2, true)]
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
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "Xh";
			subject.DateTimeQualifier = "iFF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "L";
			subject.Percent = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "iFF";
			subject.Date = "Cz3jBM";
			subject.Time = "5dtz";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "KpP";
			subject.Date2 = "pg7oh0";
			subject.Time2 = "RqA8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("N", 2, true)]
	[InlineData("N", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "Xh";
			subject.DateTimeQualifier = "iFF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "L";
			subject.Percent = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "iFF";
			subject.Date = "Cz3jBM";
			subject.Time = "5dtz";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "KpP";
			subject.Date2 = "pg7oh0";
			subject.Time2 = "RqA8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xh", "iFF", true)]
	[InlineData("Xh", "", false)]
	[InlineData("", "iFF", false)]
	public void Validation_AllAreRequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.DateTimeQualifier = dateTimeQualifier;
		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "L";
			subject.Percent = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Date = "Cz3jBM";
			subject.Time = "5dtz";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "KpP";
			subject.Date2 = "pg7oh0";
			subject.Time2 = "RqA8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("iFF", "Cz3jBM", "5dtz", true)]
	[InlineData("iFF", "", "", false)]
	[InlineData("", "Cz3jBM", "5dtz", true)]
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
			subject.DateTimeQualifier = "iFF";
		if (time != "")
			subject.DateTimeQualifier = "iFF";
		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "Xh";
			subject.DateTimeQualifier = "iFF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "L";
			subject.Percent = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "KpP";
			subject.Date2 = "pg7oh0";
			subject.Time2 = "RqA8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Cz3jBM", "iFF", true)]
	[InlineData("Cz3jBM", "", false)]
	[InlineData("", "iFF", true)]
	public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Date = date;
		subject.DateTimeQualifier = dateTimeQualifier;
		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "Xh";
			subject.DateTimeQualifier = "iFF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "L";
			subject.Percent = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.Time = "5dtz";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "KpP";
			subject.Date2 = "pg7oh0";
			subject.Time2 = "RqA8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5dtz", "iFF", true)]
	[InlineData("5dtz", "", false)]
	[InlineData("", "iFF", true)]
	public void Validation_ARequiresBTime(string time, string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Time = time;
		subject.DateTimeQualifier = dateTimeQualifier;
		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "Xh";
			subject.DateTimeQualifier = "iFF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "L";
			subject.Percent = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.Date = "Cz3jBM";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "KpP";
			subject.Date2 = "pg7oh0";
			subject.Time2 = "RqA8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("KpP", "pg7oh0", "RqA8", true)]
	[InlineData("KpP", "", "", false)]
	[InlineData("", "pg7oh0", "RqA8", true)]
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
			subject.DateTimeQualifier2 = "KpP";
		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "Xh";
			subject.DateTimeQualifier = "iFF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "L";
			subject.Percent = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "iFF";
			subject.Date = "Cz3jBM";
			subject.Time = "5dtz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pg7oh0", "KpP", true)]
	[InlineData("pg7oh0", "", false)]
	[InlineData("", "KpP", true)]
	public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier2, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.Date2 = date2;
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "Xh";
			subject.DateTimeQualifier = "iFF";
		}
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "L";
			subject.Percent = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "iFF";
			subject.Date = "Cz3jBM";
			subject.Time = "5dtz";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.Time2 = "RqA8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("L", 2, true)]
	[InlineData("L", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new PAM_PeriodAmount();
		//Required fields
		//Test Parameters
		subject.PercentQualifier = percentQualifier;
		if (percent > 0) 
			subject.Percent = percent;
		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "N";
			subject.MonetaryAmount = 2;
		}
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.DateTimeQualifier))
		{
			subject.UnitOfTimePeriodOrInterval = "Xh";
			subject.DateTimeQualifier = "iFF";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.DateTimeQualifier = "iFF";
			subject.Date = "Cz3jBM";
			subject.Time = "5dtz";
		}
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.DateTimeQualifier2) || !string.IsNullOrEmpty(subject.Date2) || !string.IsNullOrEmpty(subject.Time2))
		{
			subject.DateTimeQualifier2 = "KpP";
			subject.Date2 = "pg7oh0";
			subject.Time2 = "RqA8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
