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
    public static System.Drawing.Imaging.ImageFormat GetExt(string MIME)
    {
        switch (MIME.ToLower().Trim())
        {
            case "image/gif": return System.Drawing.Imaging.ImageFormat.Gif;
            case "image/jpeg": return System.Drawing.Imaging.ImageFormat.Jpeg;
            case "image/png": return System.Drawing.Imaging.ImageFormat.Png;
            case "application/x-ms-bmp":
            case "image/nbmp": return System.Drawing.Imaging.ImageFormat.Bmp;
            default: return null;
        }
    }
    public static string GetFormat(string MIME)
    {
        switch (MIME.ToLower().Trim())
        {
            case "image/gif": return ".gif";
            case "image/jpeg": return ".Jpeg";
            case "image/png": return ".Png";
            case "application/x-ms-bmp":
            case "image/nbmp": return ".Bmp";
            default: return null;
        }
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
    public static int GetReplyNum(int eid)
    {
        CommentDataContext ctx = new CommentDataContext();
        var quary=(from entry in ctx.Event_Comments
                  where entry.Comment_EventId==eid
                       select entry.id).Count();
        return quary;

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
    public static String[] GetRaiser(int id)
    {
        var ctx = new Darili_LinqDataContext();
        var quary = from entry in ctx.Host
                    where entry.Event_id == id
                    select entry.Name;
        return quary.ToArray();
    }
}
public class Extra_Lecture
{
    public string Brand;
    public string speakerinfo;
    public static Extra_Lecture GetExtraInfo(int id)
    {
        Darili_LinqDataContext ctx = new Darili_LinqDataContext();
        var quary = (from entry in ctx.Event_LectureEx
                    where entry.event_id == id
                    select entry).First();
        if (quary != null)
        {
            return new Extra_Lecture
            {
                Brand = quary.Brand,
                speakerinfo = quary.speakerinf
            };

        }
        else return null;
    }
    
}