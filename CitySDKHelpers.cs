using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace TrafficPlusService.Common
{
    public class CitySDKHelpers
    {
        public string GetSession()
        {
            var request = WebRequest.Create("http://apicitysdk.ibb.gov.tr/get_session?e=team1@hackathonist.com&p=Team1.hackathonist");
            request.ContentType = "application/json; charset=utf-8";
            var response = (HttpWebResponse)request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                Common.Objects.CitySDKSession myojb = (Common.Objects.CitySDKSession)js.Deserialize(objText, typeof(Common.Objects.CitySDKSession));
                return myojb.results[0];
            }
        }
        private string GetHighway(Common.Objects.GPS Location)
        {

            var request = WebRequest.Create("http://apicitysdk.ibb.gov.tr/nodes?lat={0}&lon{1}&radius=10&per_page=1&osm::highway=motorway");
            request.ContentType = "application/json; charset=utf-8";
            var response = (HttpWebResponse)request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();

                objText = objText.Substring(objText.IndexOf("\"cdk_id\":\"") + 10);

                return objText.Substring(0, objText.IndexOf("\""));
            }
            
        }
        public string PutDataToHighway(Common.Objects.GPS Location, double Speed)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://apiURL");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = **// Need to put data here to pass to the API.**

                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                //Now you have your response.
                //or false depending on information in the response
                return true;
            }
        }
    }
}
