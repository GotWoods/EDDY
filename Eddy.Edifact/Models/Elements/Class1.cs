using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.Elements
{
	public class E017_MonetaryAmount : IElement
    {
        [Position(1)]
        public string MonetaryAmountTypeCodeQualifier { get; set; }

        [Position(2)]
        public string MonetaryAmount { get; set; }

        [Position(3)]
        public string CurrencyIdentificationCode { get; set; }

        [Position(4)]
        public string CurrencyTypeCodeQualifier { get; set; }

        [Position(5)]
        public string StatusDescriptionCode { get; set; }

        public void Validate()
        {
            var validator = new BasicValidator<E017_MonetaryAmount>(this);
            validator.Length(x => x.MonetaryAmountTypeCodeQualifier, 1, 3);
            validator.Length(x => x.MonetaryAmount, 1, 35);
            validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
            validator.Length(x => x.CurrencyTypeCodeQualifier, 1, 3);
            validator.Length(x => x.StatusDescriptionCode, 1, 3);
        }
    }

}
