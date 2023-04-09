using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models
{
    [Segment("B2")]
    public class B2_BeginningSegmentForShipmentInformationTransaction : EdiX12Segment
    {
        [Position(1)]
        public string TariffServiceCode { get; set; }


        /// <summary>
        /// The SCAC code of the carrier
        /// </summary>
        [Position(2)]
        public string StandardCarrierAlphaCode { get; set; }

        /// <summary>
        /// Code defined by the National Motor Freight Tariff Association or the Canadian Transportation Agency. Can be assigned to a city or point and is used for ratings purposes
        /// </summary>
        [Position(3)]
        public string StandardPointLocationCode { get; set; }

        /// <summary>
        /// Unique identifier for this shipment, set by the shipper
        /// </summary>
        [Position(4)]
        public string ShipmentIdentificationNumber { get; set; }

        /// <summary>
        /// Code to describe the unit of measure used for the weight (e.g. L for pounds and K for kilograms)
        /// </summary>
        [Position(5)]
        public char WeightUnitCode { get; set; }


        /// <summary>
        /// Code that sets payment information on the shipments (e.g. CD Collect on Delivery, PS paid by seller)
        /// </summary>
        [Position(6)]
        public string ShipmentMethodOfPaymentCode { get; set; }

        /// <summary>
        /// Code that communicates the relationship of this shipment with other shipments for the carrier (e.g. (B) Bill Of Lading for Individual Shipment, (C) Consolidated Shipment
        /// </summary>
        [Position(7)]
        public string ShipmentQualifier { get; set; }

        /// <summary>
        /// The count of equipment
        /// </summary>
        [Position(8)]
        public int? TotalEquipment { get; set; }

        /// <summary>
        /// How the weight is to be determined (e.g. (A) Shippers Weight Agreement, (E) Estimated Weight), etc.)
        /// </summary>
        [Position(9)]
        public string ShipmentWeightCode { get; set; }

        /// <summary>
        /// Code on how to handle documentation (e.g. (40) Customs Cleared, (10) Proforma Entered)
        /// </summary>
        [Position(10)]
        public string CustomsDocumentationHandlingCode { get; set; }

        /// <summary>
        /// Code for the terms which apply to the transportation (e.g. (CFR) Cost and Freight, (CIF) Cost Insurance and Freight)
        /// </summary>
        [Position(11)]
        public string TransportationTermsCode { get; set; }

        /// <summary>
        /// Code on how to do payments (e.g. (CAS) Cash, (CCC) Credit Card, etc)
        /// </summary>
        [Position(12)]
        public string PaymentMethodCode { get; set; }


        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<B2_BeginningSegmentForShipmentInformationTransaction>(this);
            validator.Length(x => x.TariffServiceCode, 2);
            validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
            validator.Length(x => x.StandardPointLocationCode, 6, 9);
            validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
            validator.Length(x => x.WeightUnitCode, 1);
            validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
            validator.Length(x => x.ShipmentQualifier, 1);
            validator.Length(x => x.TotalEquipment, 1, 3);
            validator.Length(x => x.ShipmentWeightCode, 1);
            validator.Length(x => x.CustomsDocumentationHandlingCode, 2);
            validator.Length(x => x.TransportationTermsCode, 3);
            validator.Length(x => x.PaymentMethodCode, 3);

            validator.Required(x => x.ShipmentMethodOfPaymentCode);

            return validator.Results;
        }


    }
}

