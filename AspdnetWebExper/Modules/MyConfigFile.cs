using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;
using System.IO;

namespace AspdnetWebExper.Modules {
    public class MyConfigFile {
        private static MyConfigFile instance = new MyConfigFile();
        private static MyConfigFile Instance {
            get { return instance; }
        }
        
        public static void WriteInDoc(string mapPath, string nameText, string pwdText) {
            // 获取配置文件
            string file_path = mapPath;
            string configuration_filename = "\\Web.config";
            int idx = file_path.IndexOf("\\site");
            file_path = file_path.Remove(idx) + configuration_filename;
            if (!Directory.Exists(file_path.Remove(idx))) {
                Directory.CreateDirectory(file_path.Remove(idx));
            }

            // 当前关键字所在行号(加密)
            int[] row = new int[2];
            row[0] = CodeSecurity.EasyEncodeRowIndex(Instance.GetCriticalKeyPos(file_path, "<credentials passwordFormat=\"MD5\">"));
            row[1] = CodeSecurity.EasyEncodeRowIndex(Instance.GetCriticalKeyPos(file_path, "<location path=\"site/system\">") + 2);

            Instance.ReplaceConfigurationFile(file_path, CodeSecurity.EasyDecodeRowIndex(row[0]), "\n          <user name=\"" + nameText + "\" password=\"" + FormsAuthentication.HashPasswordForStoringInConfigFile(pwdText, "MD5") + "\"/>");
            Instance.ReplaceConfigurationFile(file_path, CodeSecurity.EasyDecodeRowIndex(row[1]), "\n        <allow users=\"" + nameText + " \" />");
        }

        /// <summary>
        /// 获取关键字在文件中的位置
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="key"></param>
        /// <returns>返回0表示没有当前关键字</returns>
        private int GetCriticalKeyPos(string file_path, string key) {
            // 读取文件内容
            StreamReader strR = File.OpenText(file_path);
            string file_content = strR.ReadToEnd();
            strR.Close();

            // 分割文件内容
            string[] temp = file_content.Split('\n');
            for (int i = 0; i < temp.Length; i++) {
                if (temp[i].Contains(key)) {
                    return i + 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// 更新配置文件
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="row"></param>
        /// <param name="discrpitReplaceString"></param>
        /// <returns></returns>
        private bool ReplaceConfigurationFile(string file_path, int row, string discrpitReplaceString) {
            StreamReader reader = new StreamReader(file_path);
            string oldString = null;
            int row_idx = 0;
            while (row_idx < row + 1) {
                if (row_idx == row) {
                    reader.Close();

                    string newString = oldString;
                    newString += discrpitReplaceString;
                    File.WriteAllText(file_path, File.ReadAllText(file_path).Replace(oldString, newString));
                    return true;
                }
                oldString = reader.ReadLine();
                row_idx++;
            }
            return false;
        }
    }
}