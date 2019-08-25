using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi.Common
{
    public class Helper
    {
        Dictionary<string, string> dictionary = null;

        public Helper()
        {
            dictionary = new Dictionary<string, string>();
        }
        public Dictionary<string, string> SetResponse(string resultStatus, string errorType)
        {
            var splitValue = errorType.Split(':');
            var errorcode = splitValue[0];
            var description = splitValue[1];
            dictionary.Clear();
            dictionary.Add("Success", resultStatus);
            dictionary.Add("ErrorCode", errorcode);
            if (errorType != "success")
            {
                dictionary.Add("Result", description);
            }

            return dictionary;
        }
    }
}