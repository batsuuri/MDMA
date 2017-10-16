using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMA.Core
{
    public class OneC
    {
        public class Customer
        {
            public string register_no { get; set; }
            public string cif_name { get; set; }
            public string cif_middle_name { get; set; }
            public string cif_address { get; set; }
            public int cif_non_resident { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public int zipcode { get; set; }
            public string other_contacts { get; set; }
            public int legal_entity_individual { get; set; }
        }

        public class Product
        {
            public string id { get; set; }
            public string name { get; set; }
            public Item[] item{get;set;}
        }
        public class Item
        {
            public string type { get; set; }
            public string valuation { get; set; }
            public string fee { get; set; }
            public Features[] features {get; set;}
        }
        public class Features
        {
            public string code { get; set; }
            public string value { get; set; }
            public string text { get; set; }

        }
        public class Contract : Customer
        {
            public string branchname { get; set; }
            public string branchno { get; set; }
            public string transfer_date { get; set; }
            public string begdate { get; set; }
            public string enddate { get; set; }
            public string mobile_contract_no { get; set; }
            public string guarentee_no { get; set; }
            public string board_number { get; set; }
            public string valuation { get; set; }
            public string fee { get; set; }
            public string journal_no { get; set; }
            public string create_user_id { get; set; }
            public string transfer_amount { get; set; }
            public string service_name { get; set; }
            public Product product { get; set; }
        }
    }
}
