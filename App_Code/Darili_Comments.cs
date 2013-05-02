using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Darili_api;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
///Darili_Comments 的摘要说明
/// </summary>
/// 
public class Comment
{
    public int id { get; set; }
    public int Event_id{get;set;}
    public string name;
    public string content;
    public DateTime time;
    #region 构造函数
    public static implicit operator Comment(Event_Comments value)
    {
        return new Comment(value.id, value.Comment_EventId, value.Comment_Maker, value.Comment_Detail);
    }
    public static implicit operator Event_Comments(Comment value)
    {
        return new Event_Comments
        {
            Comment_EventId = value.Event_id,
            Comment_Detail = value.content,
            Comment_Maker = value.name,
            id=value.id,
      Comment_Publishtime=value.time

        };
    }
    public Comment()
    {
    }
    public Comment(int _id, int _Event_id, string _Comment_Maker, string _Comment_Detail)
    {
        id = _id;
        Event_id = _Event_id;
        name = _Comment_Maker;
        content = _Comment_Detail;
        time = DateTime.Now;
    }
    public Comment( int _Event_id, string _Comment_Maker, string _Comment_Detail)
    {
        
        Event_id = _Event_id;
        name = _Comment_Maker;
        content = _Comment_Detail;
        time = DateTime.Now;
    }

    #endregion
}
public class Darili_Comments
{
	public Darili_Comments()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static Comment[] GetCommentsById(int id)
    {
        CommentDataContext ctx = new CommentDataContext();
        var quary = from entry in ctx.Event_Comments
                    where entry.Comment_EventId==id
                    select entry;
        var list = quary.ToList();
        List<Comment> result = new List<Comment>();
        foreach (var e in list)
            result.Add(e);
        return result.ToArray();



    }
    public static int MakeComment(string Maker, int Event_Id, string Detail)
    {
         Event_Comments comm = new Comment(Event_Id, Maker, Detail);
        try
        {
            CommentDataContext ctx = new CommentDataContext();

            ctx.Event_Comments.InsertOnSubmit(comm);
            ctx.SubmitChanges();
        }
        catch (Exception e)
        {
            return 0;

        }
        return comm.id;
    }
    public static bool DeleteComment(int id)
    {
        try
        {
            CommentDataContext ctx = new CommentDataContext();
            var quary = from entry in ctx.Event_Comments
                        where entry.id == id
                        select entry;
            foreach (var entry in quary)
            {
                ctx.Event_Comments.DeleteOnSubmit(entry);
            }
            return true;
        }
        catch (Exception e)
        {
            return false;
        }

    }
    
}