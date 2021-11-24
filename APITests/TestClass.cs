// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using NUnit.Framework;
using RestSharp;
using APITests.Classes;
using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace APITests
{
    [TestFixture]
    public class TestClass
    {

        [Test]
        public void StatusCodeTest()
        {
            RestHelper helper = new RestHelper();
            helper.SetUrl("api/users?page=2");
            IRestResponse response = helper.GetRequest();
            UserName answer = helper.GetContent<UserName>(response);

            List<int> identificators = helper.GetListOfId(answer);
            CollectionAssert.AllItemsAreUnique(identificators);
            
            List<string> emails = helper.GetListOfEmails(answer);
            CollectionAssert.AllItemsAreUnique(emails);

            string regex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

            Match checkedMail;
            string actualEmail;
            
            for (int i = 0; i < emails.Count; i++) {
                actualEmail = emails.ElementAt(i);
                checkedMail = Regex.Match(actualEmail, regex);
                Assert.AreEqual(true, checkedMail.Success);
            };

        }


    }
}