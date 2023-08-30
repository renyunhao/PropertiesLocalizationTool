using System;
using System.IO;
using System.Net;
using System.Text;
using SimpleJson;

internal static class Translator
{
    public class TranslateData
    {
        public string sourceText;
        public string resultText;
        public Action<bool, TranslateData> callback;
        public HttpWebRequest requset;
        public object developerPayload;
    }

    public static event Action<bool, TranslateData> Event_TranslateFinish;

    private static StringBuilder sb = new StringBuilder(100);
    private static string domain = "com";

    public static void Translate(string sourceText, string targetLanguageCode, Action<bool, TranslateData> callback = null, object developerPayload = null)
    {
        if (string.IsNullOrEmpty(sourceText))
        {
            return;
        }

        string queryURL = string.Format("https://translate.google.{0}/translate_a/single?client=gtx&sl=auto&tl={1}&dt=t&q={2}", domain, targetLanguageCode, sourceText);

        try
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(queryURL);
            req.UseDefaultCredentials = true;
            req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            req.Method = "GET";
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            req.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            req.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.9,zh-CN;q=0.8,zh;q=0.7,zh-TW;q=0.6,ko;q=0.5,ja;q=0.4");
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            TranslateData data = new TranslateData();
            data.sourceText = sourceText;
            data.callback = callback;
            data.requset = req;
            data.developerPayload = developerPayload;

            req.BeginGetResponse(new AsyncCallback(HttpCallback), data);
        }
        catch (WebException ex)
        {
            string result = ex.ToString();
            var data = new TranslateData() { resultText = result };
            if (callback != null)
            {
                callback(false, data);
            }
            if (Event_TranslateFinish != null)
            {
                Event_TranslateFinish(false, data);
            }
        }
    }

    static void HttpCallback(IAsyncResult asynchronousResult)
    {
        TranslateData data = asynchronousResult.AsyncState as TranslateData;
        try
        {
            HttpWebRequest req = data.requset;
            HttpWebResponse response = req.EndGetResponse(asynchronousResult) as HttpWebResponse;
            string responseText = string.Empty;
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                responseText = sr.ReadToEnd();
                JsonArray jsonArray = SimpleJson.SimpleJson.DeserializeObject<JsonArray>(responseText);
                JsonArray jsonArray1 = jsonArray[0] as JsonArray;
                sb.Remove(0, sb.Length);
                for (int i = 0; i < jsonArray1.Count; i++)
                {
                    JsonArray jsonObject2 = jsonArray1[i] as JsonArray;
                    sb.Append(jsonObject2[0]);
                }
            }
            string result = sb.ToString();
            data.resultText = result;
            Console.WriteLine("翻译完成：{0} --> {1}", data.sourceText, result);
            if (data.callback != null)
            {
                data.callback(true, data);
            }
            if (Event_TranslateFinish != null)
            {
                Event_TranslateFinish(true, data);
            }

        }
        catch (Exception ex)
        {
            string result = ex.ToString();
            Console.WriteLine("RYH", "Translator", "翻译URL：" + data.requset.RequestUri);
            Console.WriteLine("RYH", "Translator", "自动翻译出错：" + result);
            data.resultText = result;
            if (data.callback != null)
            {
                data.callback(false, data);
            }
            if (Event_TranslateFinish != null)
            {
                Event_TranslateFinish(false, data);
            }
        }
    }
}
