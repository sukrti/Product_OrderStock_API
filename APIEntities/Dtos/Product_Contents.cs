﻿using APIEntities.Enums;
using System;
using System.Collections.Generic;

namespace APIEntities.OrdersEntity
{
    /// <summary>
    /// This class is a part of CollectionOfMerchantResponses JSON data 
    /// </summary>
    public class Product_Contents
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int? ChannelId { get; set; }
        public string GlobalChannelName { get; set; }
        public int? GlobalChannelId { get; set; }
        public Product_ChannelSupport? ChannelOrderSupport { get; set; }
        public string ChannelOrderNo { get; set; }
        public Product_Statuses Status { get; set; }
        public bool IsBusinessOrder { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string MerchantComment { get; set; }
        public Product_Address BillingAddress { get; set; }
        public Product_Address ShippingAddress { get; set; }
        public decimal? SubTotalInclVat { get; set; }
        public decimal? SubTotalVat { get; set; }
        public decimal? ShippingCostsVat { get; set; }
        public decimal TotalInclVat { get; set; }
        public decimal? TotalVat { get; set; }
        public decimal? OriginalSubTotalInclVat { get; set; }
        public decimal? OriginalSubTotalVat { get; set; }
        public decimal? OriginalShippingCostsInclVat { get; set; }
        public decimal? OriginalShippingCostsVat { get; set; }
        public decimal? OriginalTotalInclVat { get; set; }
        public decimal? OriginalTotalVat { get; set; }
        public List<Products_LineDetails> Lines { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CompanyRegistrationNo { get; set; }
        public string VatNo { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentReferenceNo { get; set; }
        public decimal ShippingCostsInclVat { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string ChannelCustomerNo { get; set; }
        public Dictionary<string, string> ExtraData { get; set; }
    }
}
