using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsoulFollower.utils
{
    public class HttpRequest
    {
        private String url;
        private ParamsGenerate paramsGenerate;
        public static StringBuilder cookie = new StringBuilder("");
        public static StringBuilder csrf = new StringBuilder("");

        public HttpRequest(String url)
        {
            this.url = url;
            if (ConfigLoader.Config.Cookie != "") cookie = new StringBuilder(ConfigLoader.Config.Cookie);
            if (ConfigLoader.Config.Csrf != "") csrf = new StringBuilder(ConfigLoader.Config.Csrf);
        }
        public HttpRequest(String url, ParamsGenerate paramsgenerate)
        {
            this.url = url;
            this.paramsGenerate = paramsgenerate;
        }

        public async Task<String> postResultAsync()
        {
            HttpContent postcontent = null;
            if (paramsGenerate != null)
            {
                postcontent = new FormUrlEncodedContent(paramsGenerate.GetPairAsync());
                System.Diagnostics.Debug.WriteLine(postcontent.Headers);
            }
            try
            {
                if(cookie.ToString() != "") //只有cookie不为空时才执行post
                {
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36 Edg/110.0.1587.63");
                    client.DefaultRequestHeaders.Add("Cookie", cookie.ToString());
                    var response = await client.PostAsync(url,postcontent);
                    System.Diagnostics.Debug.WriteLine(client.DefaultRequestHeaders.ToString());
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(result);
                    return result;
                }
                else
                {
                    MessageBox.Show("Login Failed", "登录失效", MessageBoxButton.OK);
                    await MainWindow.log.Logger(LoggerType.Error, "登录失效！");
                    Environment.Exit(0);
                    return String.Empty;
                }
            }
            catch
            {
                MessageBox.Show("PostFailed",url, MessageBoxButton.OK);
                Environment.Exit(0);
                return String.Empty;
            }
        }
        /// <summary>
        /// 异步执行get-http访问
        /// 若头中有SetCookie字段则自动读取Cookie
        /// </summary>
        /// <returns>返回内容</returns>
        public async Task<String> getContentAsync()
        {
            if(paramsGenerate != null)
            {
                url += paramsGenerate.generate();
            }
            try
            {
                if(cookie.ToString() == "")
                {
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36 Edg/110.0.1587.63");
                    client.Timeout = TimeSpan.FromSeconds(5);
                    var response = await client.GetAsync(this.url);
                    if(response.Headers.Contains("SET-COOKIE"))
                    {
                        var cookies = response.Headers.GetValues("SET-COOKIE");
                        foreach(var cookie1 in cookies)
                        {
                            var para = cookie1.Split(";")[0];
                            cookie.Append(para);
                            cookie.Append(';');
                            var parakey = para.Split("=")[0];
                            var paravalue = para.Split("=")[1];
                            if (parakey.Equals("bili_jct"))
                            {
                                csrf.Append(paravalue);
                            }
                        }
                    }
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36 Edg/110.0.1587.63");
                    client.DefaultRequestHeaders.Add("Cookie",cookie.ToString());
                    client.Timeout = TimeSpan.FromSeconds(5);
                    var response = await client.GetAsync(this.url);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Bad Internet", "网络不可用", MessageBoxButton.OK);
                Environment.Exit(0);
                return String.Empty;
            }
        }
    }
}
