using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DriverLocatorFormsPortable.Common
{
    public class ClientSettingsHelper
    {
        private const string fileName = "client_settings.xml";
        public string ReadKey(string key)
        {
            //var type = typeof(ClientSettingsHelper).GetType().Assembly;
            //var resource = type.Namespace + "." + Device.OnPlatform("iOS", "Droid", "WinPhone") + "."+fileName;
            //using (var stream = type.Assembly.GetManifestResourceStream(resource))
            //using (var reader = new StreamReader(stream))
            //{
            //    var doc = XDocument.Parse(reader.ReadToEnd());
            //    return doc.Element("config").Element("google-api-key").Value;
            //}
            throw new NotImplementedException();
        }
    }
}
