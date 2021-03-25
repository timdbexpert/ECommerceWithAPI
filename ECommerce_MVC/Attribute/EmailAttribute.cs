using ECommerce_MVC.Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce_MVC.Attribute
{
    public class EmailAttribute: ValidationAttribute
    {
        //private readonly IConfiguration _configuration;
        //public EmailAttribute(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public override bool IsValid(object value)
        {
            var aaaaaa = value.ToString();
            var ssssss = value.ToString();
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61174/api/Account/admin";

            var Responce =  client.Execute(request);
            string context = Responce.Content;

            string user = JsonConvert.DeserializeObject<string>(context);
            //string email = _configuration["User:email"];
            //if (user == email)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }
    }
}
