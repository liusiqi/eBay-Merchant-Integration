using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace ebay0
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // set up the request url for access code, this could be built up by using query string or string builder.
            // 1. This is the request url using query string:
            //string FirstHandShake = "https://signin.ebay.com/authorize?client_id=SiqiLiua0-bc89-44e6-8f93-455d81605fb&redirect_uri=SiqiLiu-SiqiLiua0-bc89--igcwpflau&response_type=code";

            //string FirstHandShake = "https://signin.ebay.com/authorize?client_id=SiqiLiu29-7c39-4997-bf07-f3ba0504f63&redirect_uri=SiqiLiu-SiqiLiu29-7c39--drgipp&response_type=code";

            // 2. Here is using string builder.
            //const string BaseURL = "https://signin.ebay.com";
            //const string Resource = "/authorize";
            //const string QueryString = "?client_id=SiqiLiua0-bc89-44e6-8f93-455d81605fb&redirect_uri=SiqiLiu-SiqiLiua0-bc89--igcwpflau&response_type=code";
            //StringBuilder FirstHandShake = new StringBuilder();
            //FirstHandShake.Append(BaseURL).Append(Resource).Append(QueryString);

            //Server.ClearError();
            //Response.Redirect(FirstHandShake.ToString(), false);
            //Context.ApplicationInstance.CompleteRequest();

            // send box access token
            //string AccessToken = "AgAAAA**AQAAAA**aAAAAA**hrD4VA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wFk4GhDZSAoQidj6x9nY+seQ**3U4DAA**AAMAAA**WmOtIgNEsP4WnNcrcZYpmZq8PL5PM9gkDsYXztOX3XYsEoZY6xFn0hmiyeLP9bMokBdPqAa3LMDYwXqtN9ZhPT5FC3IQ/99tBugOifR8EYj+HI/fGEhqAQUZBPUpqotZadRvUGXhEY0X9LSa7kRXZqfmvf/AFbJrpoj5S42xQK6sVrkoaz2yxDot8SSUFe2h5tBPaLW9uH52JIIbnIEX1wdY3Ytf7AOEWx/+nyMLRB1KJxBjjYhR9zY8e7NI60vm2T8Y0rz2r4OZTtm03PT1B3zm+BC85rOQ6YlJi66lZK1gZYcKqj5O+EKeQVA7A08sK2aph82ZHMLVYUQ83mzvmzUnHx8rwDnqUPgztXnwafPfZYf9owvY5Qx6jDSHf0QV5/8umkBMenRRT848u2CZEewsZfzVzutlJrFKmRxHQYzjezxewxC/cYHUcai6jxTUijtPMzwbyWaDckFLc2nc0sKPsDfovlZkMCE+U5JlR3/f4hLvf+q/QAuZvk10y6BmJEjemmYVdtNWDUDweU+Tx/OMpkLGNuZr6L82EQh6n8F2Ugc0J8rFiYjEfQCi1DaShvqU2D6mRZZXv2G4+B6DVnSaw67FhrkFhxOYSMv5eZzxUIDjRYIY/k4IRWjAhRQniIaequHDJY6R6FF4rqcemAMhQbWz4oICyhA9ClDwf0BHXHl8Iv0fD6jUksJ7bgvQc5hcd6uJluQodbsCpmbXJOKWv2EXmnaG4C6gFcfuvqEo4abQ1O5nH+UVkgITpuYq";
            
            // production access token with an user without items selling
            //string AccessToken = "AgAAAA**AQAAAA**aAAAAA**spf4VA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AHlYKoCpiHowqdj6x9nY+seQ**B7sCAA**AAMAAA**EePn6+mnWFCTRBnQptZyjgE14slp8vUtaPs8ltQApFfV8l72pnEnLT4+st0mlOLsexV+hHwhrGH6BfHhFwBtJ0pwLhszDSArBCNxUvv3Vwfb1xWzITOqi++sBEUqKdaR58ZDz3NOaZd9yYPCl0oefCDIro1MaCiETfJS9cCf0wcaXewoRULbwGTF3+PfAzHDL4oULfB0FYXPv1Ji2/iGaAal/DUHwHAJVP0NDPMQ1KysSIJtZXgquzm4eVy/aHvioNOr7m9EMa122MDaM6BN1iosVn/t0sTnGLHL3oK+VvhJQ+9CP9+1h/f4rIvGXid8eJTX8mxoMMQitTkbqwxhG90RxjIHv3Ps3h7gpursioqze1m7/dV+e//EiTPNnBUMYSZroS6yY2NDGTsB8cPnjnK3zlVIwANovF5p5Cr3XFlOqig/Q99iYwCfupqbZkzNknOeUGvJSSz4UVZCgN3cmkdZ5o/gEbKYNjfEayQoED9I+FbXS+kBYC6MbLDwOF0OoDIJB7Itzf/m1TfqTU8TadHKC6t7BkOHgMGZRH6MflYBHZ4WJJstsc8IwIoiaDdmt3TSjSWpxmb8pu2sCt2xDTFchehqFTaPAeBJ/OduNxYKT5p0RYXDbTrc6WDVyRgDp/7RGraDaFibr1LQGdQAeCe2i5G4M6wXnXZWJAQLvb37krTsEHRDjutiPX7dHBhnBxbahOFwOtEflUPdC5FZxO2nAGuHkaEKEoTYPXHdVS8GyJU/vDMauv7t//Oo5Z+n";

            // production access token with an user with items selling
            string AccessToken = "AgAAAA**AQAAAA**aAAAAA**At8BVQ**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AFkYqhCpSKpASdj6x9nY+seQ**B7sCAA**AAMAAA**z4jMptn1LfZrZ697VjrAFxV6kvFn6p3pxPX3IB/dUCx7GREf4GOI9cGl0+n/84mjSxjGtL5yYXcASokE3Vk0RdYWMvk3D9W1BME+mZZnQ947LEH5fd8QpwMoPsMhMrEg/sjolkq8eJLauAG8BLrCv4/Wq57y4FhL+VAXm7zfRPrIG5wYTu0J9lO/qf9SMebFlyIoNNBtu3ISijuSIyRLRp+BJrzzjKRInLVXcCh0ivc8qwO5ZNZx/wV77/XO/MdBIn0ETACIQKccUmTDbml3QG4UKA7HD9kBxfJ6Ci2ep9fg14zVN4m21oP3JDavJZa3LW0hy31yq3lKOgaFz+NVQjjlqc5X80WCCT+ab9Hj2qY3wWUhduXLzWYo+nrbLjoL+99d5zKE4lPtd251KwEdju5rYWC380gMzEj5ORWL8rWnQ1yahpocDKoQls9lFaKSW/hqMJgy3uofnbd5L8/A9vBn9kHCH4jmooiS0IDbxgJZWaUY8nonMVRFgTRKVUsAV9SUcN5RFxhQoRm7aRiqYYumu0uOIvcZTApGci3Cm9Hh2Q+i6xQ2H2/LELbxlFcDqbI4p1ikpsHKuBt48ZZL1YOb3LAzS6UUsvvGasdWuAedeYv6N/Q+q8VcwGMhT7sFyTzHITVVCJ4ZNB1IjxlctN8dQjwkMfVe1fcswfW6xAj00tpirlYaFQNHFzUyxAM10KwYBtIXw7DWvRo7pA/J8nxjmyZiVVbgh+zWwo9As3xcgiiHOjQYlwZjZTgNwime";

            string url = "http://svcs.ebay.com/MerchandisingService?OPERATION-NAME=getMostWatchedItems&SERVICE-NAME=MerchandisingService&SERVICE-VERSION=1.1.0&CONSUMER-ID=SiqiLiu29-7c39-4997-bf07-f3ba0504f63&RESPONSE-DATA-FORMAT=JSON&REST-PAYLOAD&categoryId=267";
            //Response.Redirect(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            //request.ContentType = "application/json; charset=UTF-8";
            request.Headers.Add("Authorization", "Bearer " + AccessToken);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamResponse = response.GetResponseStream();
            StreamReader sReader = new StreamReader(streamResponse);
            string userInfo = sReader.ReadToEnd();
            sReader.Close();
            response.Close();

            var deserializer = new JavaScriptSerializer();
            DataModelRecommend.RootObject data = deserializer.Deserialize<DataModelRecommend.RootObject>(userInfo);
            //Response.Write(data.getMostWatchedItemsResponse.itemRecommendations.item[0].title);
            for (int i = 0; i < data.getMostWatchedItemsResponse.itemRecommendations.item.Count; i++)
            {
                Response.Write(data.getMostWatchedItemsResponse.itemRecommendations.item[i].itemId);
                Response.Write("<br>");
            }
        }
    }
}