using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

public class RequestTool  {


    public static string prefixHttpRequest = "http://localhost:8080/";

    private Strategy strategy;

    public Strategy getStrategy()
    {
        return this.strategy;

    }
    public void setStrategy(Strategy _strategy)
    {

        this.strategy = _strategy;

    }

    public HttpWebResponse CreateGetHttpResponse(string url, IDictionary<string, string> paraDic)
    {
        HttpWebRequest request = WebRequest.Create(prefixHttpRequest + url) as HttpWebRequest;
        request.Method = "GET";
        request.ContentType = "application/x-www-form-urlencoded";
        string buffer = "";
        foreach (string key in paraDic.Keys)
        {
            buffer += key + "=" + paraDic[key] + "&";
        }
        byte[] data = Encoding.UTF8.GetBytes(buffer);
        Stream stream = request.GetRequestStream();
        stream.Write(data, 0, data.Length);
        stream.Close();
        return request.GetResponse() as HttpWebResponse;
    }
    public HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> paraDic)
    {
        HttpWebRequest request = WebRequest.Create(prefixHttpRequest + url) as HttpWebRequest;
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        string buffer = "";
        foreach (string key in paraDic.Keys)
        {
            buffer += key + "=" + paraDic[key] + "&";
        }
        byte[] data = Encoding.UTF8.GetBytes(buffer);
        Stream stream = request.GetRequestStream();
        stream.Write(data, 0, data.Length);
        stream.Close();
        return request.GetResponse() as HttpWebResponse;
    }



    public void CreatePostHttpResponseForGetFile(string url)
    {
        WebClient client = new WebClient();


        string URLAddress = prefixHttpRequest + url;

        string receivePath = @"d:\ADSystem\tempImage.nii";

        client.DownloadFile(URLAddress, receivePath);
    }
    public void CreatePostHttpResponseForGetFile(string url, Dictionary<string, string> dataDic)
    {
        WebClient client = new WebClient();

        string urlPlus = "?";
        foreach (string key in dataDic.Keys)
        {
            urlPlus += key + "=" + dataDic[key] + "&";
        }

        urlPlus.Remove(urlPlus.Length - 1, 1);
        string URLAddress = prefixHttpRequest + url + urlPlus;
        Debug.Log(URLAddress);
        string receivePath = @"d:\ADSystem\tempImage.nii";

        client.DownloadFile(URLAddress, receivePath);

    }
    /// <summary>
    ///   
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="wr"></param>
    /// <returns></returns>
    public T getResult<T>(HttpWebResponse wr)
    {
        string content = "";
        using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
        {
            content = sr.ReadToEnd();
        }

        T result = JsonUtility.FromJson<T>(content);

        return result;
    }
    public string getResult(HttpWebResponse wr)
    {
        string content = "";
        using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
        {
            content = sr.ReadToEnd();
        }

      
        return content;
    }

    public string UploadImage(string imgPath, string uploadUrl)
    {

        HttpWebRequest request = WebRequest.Create(prefixHttpRequest + uploadUrl) as HttpWebRequest;
        request.AllowAutoRedirect = true;
        request.Method = "POST";

        string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
        request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
        byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
        byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

        int pos = imgPath.LastIndexOf("\\");
        string fileName = imgPath.Substring(pos + 1);

        //请求头部信息 
        StringBuilder sbHeader = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"rawPicFile\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));
        byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());

        FileStream fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
        byte[] bArr = new byte[fs.Length];
        fs.Read(bArr, 0, bArr.Length);
        fs.Close();

        Stream postStream = request.GetRequestStream();
        postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
        postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
        postStream.Write(bArr, 0, bArr.Length);
        postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
        postStream.Close();

        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        Stream instream = response.GetResponseStream();
        StreamReader sr = new StreamReader(instream, Encoding.UTF8);
        string content = sr.ReadToEnd();
        return content;

    }

}
