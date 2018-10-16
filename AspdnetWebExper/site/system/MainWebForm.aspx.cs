using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace AspdnetWebExper {
    public partial class MainWebForm : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                this.CID.Text = GetUId();
                this.CSystem.Text = GetUserSystem(Page.Request.Headers["User-Agent"]);
                this.CBrowserProperty.Text = GetUserBrowserInfo(Page.Request.Browser);
            }
        }

        private string GetUId() {
            if(Request.Cookies["uinfo"] != null) {
                return Request.Cookies["uinfo"].Values["uname"].ToString();
            } else {
                Response.Write("<script type=\"text/javascript\">alert(\"你无权访问此页面!\")</script>");
                ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script type=\"text/javascript\">document.body.setAttribute(\"hidden\",\"hidden\");" +
                    "let time = setTimeout(\"BackToLogin()\", 3000); function BackToLogin() {window.location.href=\"../user/LoginWeb.aspx\";" +
                    " clearTimeout(time);}</script>");
                Session.Clear();
                Application.Clear();
                return null;
            }
        }

        private string GetUserSystem(string req_context) {
            string WindowsPlatform = "Windows ";
            string UnixPlatform = "Unix";
            string LinuxPlatform = "Linux";
            string SunOSPlatform = "SunOS";
            string MacPlatform = "Mac";
            
            if(req_context.Contains("NT 10.0") || req_context.Contains("NT 6.4")) {
                return WindowsPlatform + "10";
            } else if (req_context.Contains("NT 6.3")) {
                return WindowsPlatform + "8.1";
            } else if (req_context.Contains("NT 6.2")) {
                return WindowsPlatform + "8";
            } else if (req_context.Contains("NT 6.1")) {
                return WindowsPlatform + "7";
            } else if (req_context.Contains("NT 6.0")) {
                return WindowsPlatform + "Vista";
            } else if (req_context.Contains("NT 5.2") || req_context.Contains("NT 5.1")) {
                return WindowsPlatform + "XP";
            } else if (req_context.Contains("NT 5.0")) {
                return WindowsPlatform + "2000";
            } else if (req_context.Contains("NT 4.0")) {
                return WindowsPlatform + "NT 4.0";
            } else if (req_context.Contains("NT 3.51")) {
                return WindowsPlatform + "NT 3.51";
            } else if (req_context.Contains("NT 3.5")) {
                return WindowsPlatform + "3.5";
            } else if (req_context.Contains("NT 3.1")) {
                return WindowsPlatform + "NT 3.1";
            } else if (req_context.Contains("Mac")) {
                return MacPlatform;
            } else if (req_context.Contains("Unix")) {
                return UnixPlatform;
            } else if (req_context.Contains("Linux")) {
                return LinuxPlatform;
            } else if (req_context.Contains("SunOS")) {
                return SunOSPlatform;
            }

            return req_context;
        }
        
        private string GetUserBrowserInfo(HttpBrowserCapabilities req_context) {
            string all_info = "";

            all_info += "浏览器: " + req_context.Type + "</br>";
            all_info += "浏览器名称: " + req_context.Browser + "</br>";
            all_info += "浏览器版本号: " + req_context.Version + "</br>";
            all_info += "浏览器平台: " + req_context.Platform + "</br>";
            all_info += "是否支持框架: " + req_context.Frames + "</br>";
            all_info += "是否支持表格: " + req_context.Tables + "</br>";
            all_info += "是否支持Cookie: " + req_context.Cookies;

            return all_info;
        }
    }
}