using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;

public partial class test_addevent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            //以下为测试用代码
            
            Response.AddHeader("Access-Control-Allow-Origin", "*");
            //以上为测试用代码
            Darili_LinqDataContext ctx = new Darili_LinqDataContext();
            string input = "";
            //试验中，改变方式为POST
            if (Request.HttpMethod == "POST")
            {
                var inputStream = Request.InputStream;
                var strLen = Convert.ToInt32(inputStream.Length);
                var strArr = new byte[strLen];
                inputStream.Read(strArr, 0, strLen);
                input = System.Text.Encoding.UTF8.GetString(strArr);
                inputStream.Flush();
                inputStream.Close();
             
            }
            else
            {
                input = Request.QueryString[0];
            }
            JObject obj = JObject.Parse(input);
            #region 处理基础信息
            EventMain data = new EventMain
            {
                Title = (string)obj["Title"],
                Subtitle = (string)obj["SubTitle"],
                Location = (string)obj["Location"],
                Type = (string)obj["Type"],
                SubType = (string)obj["Subtype"],
                Context = (string)obj["Context"],
                PublishTime = DateTime.Now,
                LastModified = DateTime.Now,
                Publisher=HttpContext.Current.User.Identity.Name,
                ViewFlag = (string)obj["EventType"] == "0" ? (short)1 : (short)-1,
                Series = (string)obj["series"]
            };
            #endregion
            #region 处理speaker,class
            foreach (var element in obj["speaker"].ToList())
            {
                string raw = element.ToString();
                raw=System.Text.RegularExpressions.Regex.Replace(raw,@"\s{4}","|");
                string[]speaker=raw.Split('|');
                data.Lecture.Add(new Lecture
                {
                    Speaker = speaker[0],
                    Class = speaker[1]
                }
                );
            }
            foreach (var element in obj["Raiser"].ToList())
            {
                data.Host.Add(new Host
                {
                    Name = element.ToString()

                });
                
            }
            #endregion
            #region 处理多时段
            foreach (var element in obj["multipletime"].ToList())
            {
                Event_MultipleTime multi = new Event_MultipleTime
                {
                    IsRoutine = element["isroutine"].ToString() == "1" ? true : false
                };
                if (multi.IsRoutine == false)
                {
                    string[] st = element["StartTime"].ToString().Split('/');
                    if (st.Length == 3)
                    {
                        multi.StartDate = DateTime.Parse(st[0]) + TimeSpan.Parse(st[1]);
                        multi.EndDate = DateTime.Parse(st[0]) + TimeSpan.Parse(st[2]);
                        data.Event_MultipleTime.Add(multi);
                    }

                    else
                    {

                    }
                }
                else
                {
                    string[] t = element["StartTime"].ToString().Split('/');
                    if (t.Length == 3)
                    {
                        multi.StartDate = DateTime.Parse(t[0]) + TimeSpan.Parse(t[1]);
                        multi.EndDate = DateTime.Parse(element["EndTime"].ToString()) + TimeSpan.Parse(t[2]);
                        multi.routine = element["routine"].ToString();
                        data.Event_MultipleTime.Add(multi);
                    }
                }




            }
            #endregion
            #region 处理讲座信息
            if (data.Type == "讲座")
            {
                data.Event_LectureEx = new Event_LectureEx
                {
                    Brand = obj["brand"].ToString(),
                    speakerinf = obj["speakerinf"].ToString()
                };
            } 
            
            #endregion

            #region 处理报名时间
            var event_bm = new Event_BM();
            string time_s = obj["PublishTime"]["StartTime"].ToString().Replace('/', ' ');
            string time_r = obj["PublishTime"]["EndTime"].ToString().Replace('/', ' ');
            event_bm.StartTime = DateTime.Parse(time_s);
            event_bm.EndTime = DateTime.Parse(time_r);
            event_bm.numlimit = int.Parse(obj["numlimit"].ToString()); 
            #endregion
            data.StartTime = (from entry in data.Event_MultipleTime
                              orderby entry.StartDate ascending
                              select entry.StartDate).First();
            data.EndTime = (from entry in data.Event_MultipleTime
                            orderby entry.EndDate descending
                            select entry.EndDate).First();
            #region 插入记录，返回
            if (data.Publisher == null || data.Publisher.Trim() == "")
            {
                data.Publisher = "佚名";
            }
            ctx.EventMain.InsertOnSubmit(data);
            ctx.SubmitChanges();
            Session["post_id"] = data.Id;
            JObject response = new JObject(new JProperty("success", 1),
                new JProperty("id", data.Id));
           
            Response.Write(response.ToString()); 
            #endregion
        }
        catch (Exception exp)
        {
            JObject obj = new JObject(new JProperty("success", 0),
                new JProperty("err", exp.Message));
            Response.Write(obj);
        }
    }
    
}