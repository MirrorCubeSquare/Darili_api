using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using  Newtonsoft.Json;
using Darili_api;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

/// <summary>
///Darili_Extra 的摘要说明
/// </summary>
public class Darili_Extra
{
	public Darili_Extra()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static int GetSubscriptionNum(int id)
    {
        return 0;
    }
    public static int GetLikeNum(int id)
    {
        return 0;
    }
    public static string GetTag(int id)
    {
        return "测试";
    }
    public static int GetReplyNum(int id)
    {
        return 0;
    }
    public static int GetShareNum(int id)
    {
        return 0;
    }

    public static Tuple<int, int, int> TimeLeft(Event eve)
    {
        TimeSpan span = eve.StartTime - DateTime.Now;
        return new Tuple<int, int, int>(span.Days, span.Hours, span.Minutes);

    }
    public static string GetAlbum_test(int id,string FatherPath)
    {
        List<FileInfo> result = new List<FileInfo>();
        string path = FatherPath+"images/" + id.ToString();
      
        if (Directory.Exists(path))
        {
            DirectoryInfo dir=new DirectoryInfo(path);
            FileInfo[] files=dir.GetFiles();
            if (files.Length > 0) result.AddRange(files);
        }
        XElement root = new XElement("root");
        foreach (var elements in result)
        {
            root.Add(new XElement("Album",path+"/"+elements));

        }
        return JsonConvert.SerializeXNode(root);
    }
    public static XElement[] GetAlbum(int id, string FatherPath)
    {
        List<FileInfo> result = new List<FileInfo>();
        string path = FatherPath + "images/" + id.ToString();

        if (Directory.Exists(path))
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            if (files.Length > 0) result.AddRange(files);
        }
        XElement root = new XElement("root");
        foreach (var elements in result)
        {
            root.Add(new XElement("Album", path + "/" + elements));

        }
        return root.Elements().ToArray();
    }
}