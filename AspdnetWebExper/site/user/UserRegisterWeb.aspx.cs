using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;
using System.IO;

namespace AspdnetWebExper.site.user {
    public partial class UserRegisterWeb : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void SubmitBtn_Click(object sender, EventArgs e) {
            if(!this.uPwdText.Text.Equals(this.uPwdAlfirmText.Text)) {
                Response.Write("<script type=\"text/javascript\">alert(\"两次输入密码不一致!\")</script>");
            } else {
                Modules.MyConfigFile.WriteInDoc(Server.MapPath(this.Page.AppRelativeVirtualPath), this.uNameText.Text.ToString(), this.uPwdText.Text.ToString());
                Response.Write("<script type=\"text/javascript\">alert(\"注册成功!\")</script>");
                GravatarUploadBtn_Click(sender, e);
                Response.Redirect("./LoginWeb.aspx?regiter_name=" + this.uNameText.Text.ToString());
            }
        }

        protected void GravatarUploadBtn_Click(object sender, EventArgs e) {
            if(this.ImageFileUpload.HasFile) {
                string uploadFileContext = this.ImageFileUpload.FileName;
                string fileExtension = Path.GetExtension(uploadFileContext).ToLower();
                if(IsIcon(fileExtension)) {
                    string uploadPath = Server.MapPath(this.Page.AppRelativeVirtualPath);
                    uploadPath = uploadPath.Remove(uploadPath.LastIndexOf("\\site")) + "\\gravatar";

                    if(!Directory.Exists(uploadPath)) {
                        Directory.CreateDirectory(uploadPath);
                    }
                    string virFilePath = uploadPath + "\\" + uploadFileContext;
                    this.ImageFileUpload.PostedFile.SaveAs(virFilePath);

                    this.PreviewImage.ImageUrl = "~\\gravatar\\" + uploadFileContext;
                }
            } else {
                Response.Write("<script type=\"text/javascript\">alert(\"请选择头像上传!\")</script>");
            }
        }

        private bool IsIcon(string extension) {
            string icoExt = ".ico";
            if(extension == icoExt) {
                return true;
            }

            return false;
        }
    }
}