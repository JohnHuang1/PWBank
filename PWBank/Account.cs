using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;

namespace PWBank
{
    class Account
    {
        public struct Info
        {
            public string account { get; set; }
            public string userName { get; set; }
            public string password { get; set; }
            /*
            public List<string> addInfoCategory { get; set; }
            public List<string> addInfoData { get; set; } */

            public Info(string[] info)
            {
                account = info[0];
                userName = info[1];
                password = info[2];
                /*
                addInfoCategory = new List<string>();
                addInfoData = new List<string>();
                for(int z = 0; z < info.Length; z ++)
                {
                    if (z > 2)
                    {
                        if (z % 2 == 1)
                        {
                            addInfoCategory.Add(info[z]);
                        }
                        else
                        {
                            addInfoData.Add(info[z]);
                        }
                    }
                } */
            }
            public Info(string account, string userName, string password)
            {
                this.account = account;
                this.userName = userName;
                this.password = password;
                /*
                addInfoCategory = new List<string>();
                addInfoData = new List<string>(); */
            }
        }

        public string folderPath = Directory.GetCurrentDirectory() + @"\userFiles";
        public string filePath;
        public string accountPassword;

        List<Info> lstInfoArr = new List<Info>();


        public Account(string username)
        {
            filePath = folderPath + @"\" + username + ".userInfo";

            SetInfo();
        }
        public Account() { }

        public void SetInfo()
        {
            StreamReader reader = new StreamReader(filePath);
            accountPassword = reader.ReadLine();
            string[] strArr = reader.ReadToEnd().Split('§');
            int counter = 0;
            lstInfoArr.Clear();
            foreach (string set in strArr)
            {
                if (set != "")
                {
                    Info info = new Info(set.Split('☼'));
                    lstInfoArr.Insert(counter++, info);
                }
            }
            reader.Close();
        }

        public string[] GetAccountNames()
        {
            string[] accNames = new string[lstInfoArr.Count];
            int counter = 0;
            foreach(Info i in lstInfoArr)
            {
                accNames[counter++] = i.account;
            }
            return accNames;
        }

        public Info GetInfoAtIndex(int i)
        {
            return lstInfoArr[i];
        }

        public string[] GetFilesArr()
        {
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] filesArr = dir.GetFiles("*.userInfo");
            string[] fileNames = new string[filesArr.Length];
            int counter = 0;
            foreach(FileInfo f in filesArr)
            {
                fileNames[counter] = f.Name;
                counter++;
            }
            return fileNames;
        }

        public bool Unique(string name)
        {
            string inputFile = name + ".userInfo";
            string[] fileNames = GetFilesArr();
            if (fileNames.Length > 0)
            {
                foreach (string file in fileNames)
                {
                    if (inputFile.ToLower() == file.ToLower())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void DeleteInfoAtIndex(int i)
        {
            lstInfoArr.Remove(lstInfoArr[i]);
            ReWriteInfo();
        }

        private void ReWriteInfo()
        {
            StreamWriter writer = new StreamWriter(filePath, false);
            writer.WriteLine(accountPassword);
            foreach (Info i in lstInfoArr)
            {
                writer.Write('§' + i.account + '☼' + i.userName + '☼' + i.password);
                /*
                if (i.addInfoCategory.Count != 0)
                {
                    for (int a = 0; a < i.addInfoCategory.Count; a++)
                    {
                        writer.Write('☼' + i.addInfoCategory[a] + '☼' + i.addInfoData[a]);
                    }
                } */
            }
            writer.Close();
        }

        public void ReplaceInfo(Info oldInfo, Info newInfo)
        {
            foreach(Info i in lstInfoArr)
            {
                if (i.account == oldInfo.account && i.userName == oldInfo.userName && i.password == oldInfo.password)
                {
                    lstInfoArr.Insert(lstInfoArr.IndexOf(i), newInfo);
                    lstInfoArr.Remove(i);
                    break;
                }
            }
            ReWriteInfo();
        }

        public bool UniqueInfo(Info info)
        {
            foreach(Info i in lstInfoArr)
            {
                if(i.account == info.account && i.userName == info.userName && i.password == info.password)
                {
                    return false;
                }
            }
            return true;
        }

        public void AddInfo(Info info)
        {
            lstInfoArr.Add(info);
            ReWriteInfo();
        }
    }
}
