﻿using Magenic.BadgeApplication.Common.DTO;
using Magenic.BadgeApplication.Common.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Linq;

namespace Magenic.BadgeApplication.Authorization
{
    public class AuthorizeLogOn : IAuthorizeLogOn
    {
        public bool ValidateLogin(string userName, string password, string domainName = "")
        {
            bool valid;
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                valid = context.ValidateCredentials(userName, password);
            }
            return valid;
        }

        public AuthorizeLogOnDTO RetrieveUserInformation(string userName, string domainName = "")
        {
            var aDPath = ConfigurationManager.AppSettings["EmployeeADPath"];
            var searchString = ConfigurationManager.AppSettings["EmployeeSearchString"];

            AuthorizeLogOnDTO returnValue = null;
            var results = SearchForADUserInfo(string.Format(CultureInfo.CurrentCulture, searchString, userName), aDPath);
            if (results.Count > 0)
            {
                var result = results[0];
                returnValue = new AuthorizeLogOnDTO();
                returnValue.LastName = GetPropertyString(result, "sn");
                returnValue.FirstName = GetPropertyString(result, "givenname");
                returnValue.UserName = userName;
                returnValue.Location = GetPropertyString(result, "physicalDeliveryOfficeName");
                returnValue.Department = GetPropertyString(result, "department");
                returnValue.EmailAddress = GetPropertyString(result, "mail");
                var managerDistinguishedName = GetPropertyString(result, "manager");
                if (managerDistinguishedName != string.Empty)
                {
                    var managerResults = SearchForADUserInfo(string.Format(CultureInfo.CurrentCulture, "(&(objectCategory=Person)(objectClass=user)(distinguishedname={0}))", managerDistinguishedName), aDPath);
                    if (managerResults.Count > 0)
                    {
                        returnValue.Manager1ADName = GetPropertyString(managerResults[0], "samaccountname");
                    }
                }
            }
            return returnValue;
        }

        private static string GetPropertyString(SearchResult result, string propertyName)
        {
            var returnValue = string.Empty;
            if (result.Properties[propertyName].Count > 0)
            {
                returnValue = result.Properties[propertyName][0].ToString();
            }
            return returnValue;
        }

        private static byte[] GetPropertyByteArray(SearchResult result, string propertyName)
        {
            byte[] returnValue = null;
            if (result.Properties[propertyName].Count > 0)
            {
                returnValue = result.Properties[propertyName][0] as byte[];
            }
            return returnValue;
        }

        private static SearchResultCollection SearchForADUserInfo(string searchString, string aDPath)
        {
            var entry = new DirectoryEntry(aDPath);
            var searcher =
                new DirectorySearcher(searchString);
            searcher.SearchRoot = entry;
            searcher.SearchScope = SearchScope.Subtree;
            searcher.PropertiesToLoad.Add("ou");
            searcher.PropertiesToLoad.Add("samaccountname");
            searcher.PropertiesToLoad.Add("sn");
            searcher.PropertiesToLoad.Add("givenname");
            searcher.PropertiesToLoad.Add("mail");
            searcher.PropertiesToLoad.Add("manager");
            searcher.PropertiesToLoad.Add("thumbnailPhoto");
            searcher.PropertiesToLoad.Add("physicalDeliveryOfficeName");
            searcher.PropertiesToLoad.Add("department");
            var results = searcher.FindAll();
            return results;
        }

        public IDictionary<string, byte[]> RetrieveUsersAndPhotos()
        {
            var aDPath = ConfigurationManager.AppSettings["EmployeeListADPath"];
            var searchString = ConfigurationManager.AppSettings["EmployeeListSearchString"];
            var results = SearchForADUserInfo(searchString, aDPath);

            var returnValue = new Dictionary<string, byte[]>();
            foreach (SearchResult result in results)
            {
                var adName = GetPropertyString(result, "samaccountname");
                var photo = GetPropertyByteArray(result, "thumbnailPhoto");

                if (photo != null)
                {
                    returnValue.Add(adName, photo);
                }
            }

            return returnValue;
        }

        public IEnumerable<string> RetrieveActiveUsers()
        {
            var aDPath = ConfigurationManager.AppSettings["EmployeeListADPath"];
            var searchString = ConfigurationManager.AppSettings["EmployeeListSearchString"];
            var results = SearchForADUserInfo(searchString, aDPath);

            var returnValue = (from SearchResult result in results select GetPropertyString(result, "samaccountname")).ToList();
            return returnValue;
        }
    }
}