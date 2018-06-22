using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DLL.DataGenerator
{
    public class RootObject
    {
        public List<Result> results { get; set; }
        public Info info { get; set; }
    }

    public class Result
    {
        private int _registered;

        private static bool IsNumeric(object Expression)
        {
            return Double.TryParse(Convert.ToString(Expression),
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out double retNum);
        }

        public string gender { get; set; }
        public Name name { get; set; }
        public Location location { get; set; }
        public string email { get; set; }
        public Login login { get; set; }

        public int registered
        {
            get => _registered;
            set {
                if (IsNumeric(value)) _registered = Convert.ToInt32(value);
                else _registered = 0;
            }
        }

        public Dob dob { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public Id id { get; set; }
        public Picture picture { get; set; }
        public string nat { get; set; }
    }

    public class Info
    {
        private static bool IsNumeric(object Expression)
        {
            return Double.TryParse(Convert.ToString(Expression),
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out double retNum);
        }

        private int _results;
        private int _page;

        public string seed { get; set; }

        public int results
        {
            get => _results;
            set {
                _results = value;
                if (IsNumeric(value)) _results = Convert.ToInt32(value);
                else _results = 0;
            }
        }

        public int page
        {
            get => _page;
            set {
                _page = value;
                if (IsNumeric(value)) _page = Convert.ToInt32(value);
                else _page = 0;
            }
        }

        public string version { get; set; }
    }

    #region Result

    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }

    public class Dob
    {
        public string date { get; set; }
        public string age { get; set; }
    }

    public class Location
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
    }

    public class Login
    {
        public string uuid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string sha256 { get; set; }
    }

    public class Id
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Picture
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }
    }

    #endregion Result

    public class JsonDeserialize
    {
        // Random user data API - http://randomuser.me/
        private string url = "http://api.randomuser.me/?results=";

        private static async Task<RootObject> DeserializeAsync(string putUrl)
        {
            using (WebClient wb = new WebClient())
            {
                dynamic data = new System.Collections.Specialized.NameValueCollection();
                dynamic responseStringJson =
                    await Task.Run(() => Encoding.Default.GetString(wb.UploadValues(putUrl, "POST", data)));
                var jsSerializer = new JavaScriptSerializer();
                return await Task.Run(() => jsSerializer.Deserialize<RootObject>(responseStringJson));
            }
        }

        public async Task<RootObject> GetSingleDiffUser()
        {
            return await Task.Run(() => DeserializeAsync(url + 1 + "&nat=us,gb"));
        }

        public async Task<RootObject> GetManyDiffUser(int take)
        {
            return await Task.Run(() => DeserializeAsync(url + take + "&nat=us,gb"));
        }
    }
}