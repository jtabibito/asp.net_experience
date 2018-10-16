using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace AspdnetWebExper {
    public partial class LoginWeb : System.Web.UI.Page {
        private object sender;
        private EventArgs e;
        protected void Page_Load(object sender, EventArgs e) {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if(!Page.IsPostBack) {
                if(Request.Cookies["uinfo"] != null) {
                    this.uNameText.Text = Request.Cookies["uinfo"].Values["uname"];
                    this.uPwdText.Text = Request.Cookies["uinfo"].Values["pwd"];
                    if(Request.Cookies["uinfo"].Values["auto_login"] != null &&
                        Request.Cookies["uinfo"].Values["auto_login"].Equals("true")) {
                        this.AutoLoginCB.Checked = true;
                    }
                    this.sender = sender;
                    this.e = e;
                }
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "auto_click", "<script type=\"text/javascript\"> let time = null;" +
                    "window.onload = auto_click;" +
                    "function auto_click() { if(document.readyState == \"complete\") { " +
                    "if(document.getElementById(\"uNameText\").innerText != null && document.getElementById(\"uPwdText\").innerText != null && document.getElementById(\"AutoLoginCB\").checked == true) {" +
                    "time = setTimeout(\"btn_event()\", 3000); return;} } }" +
                    "function btn_event() { document.getElementById(\"uLoginBtn\").click(); clearTimeout(time); return; }" +
                "</script>");
            }
        }

        protected void uLoginBtn_Click(object sender, EventArgs e) {
            string name = this.uNameText.Text.ToString();
            string pwd = this.uPwdText.Text.ToString();
            if(FormsAuthentication.Authenticate(name, pwd) == true) {
                FormsAuthentication.RedirectFromLoginPage(name, true);
                // FormsAuthentication.SetAuthCookie(name, false);
                if(Response.Cookies["uinfo"] == null) {
                    HttpCookie cookies = new HttpCookie("uinfo");
                    cookies["uname"] = name;
                    cookies["pwd"] = pwd;
                    if (this.AutoLoginCB.Checked == true) {
                        cookies["auto_login"] = "true";
                    }
                    cookies.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookies);
                } else {
                    Response.Cookies["uinfo"].Expires = DateTime.Now.AddHours(-1);
                    HttpCookie cookies = new HttpCookie("uinfo");
                    cookies["uname"] = name;
                    cookies["pwd"] = pwd;
                    if (this.AutoLoginCB.Checked == true) {
                        cookies["auto_login"] = "true";
                    }
                    cookies.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookies);
                }
            } else if(this.uNameText.Text.ToString() == "" || this.uPwdText.Text.ToString() == "") {
                Response.Write("<script type=\"text/javascript\">alert(\"账号或密码不能为空，请检查!\")</script>");
            } else {
                Response.Write("<script type=\"text/javascript\">alert(\"账号信息错误!\")</script>");
            }
        }

        protected void userRegistingAccount_Click(object sender, EventArgs e) {
            Response.Redirect("./UserRegisterWeb.aspx");
        }
    }
}