using System;
using System.IO;

namespace Code_Generator_Business_Layer
{
    public class clsExport
    {
        static private void CreateFile(string content, string fileName,string type, string folderPath = null)
        {
            if (folderPath != null) folderPath += "\\";

            string filePath = folderPath + fileName + "." + type;
            System.IO.File.WriteAllText(filePath, content);
        }
        static private bool CreateFolder(string FolderPath)
        {
            try
            {
                if (!Directory.Exists(FolderPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(FolderPath);
                    return true;
                }
            }
            catch(Exception ex)
            { return false; }

            return false;
        }
        static public void CreateClassWithContent(string content, string fileName, string folderName,string path)
        {
            string FolderPath = path + folderName;            
            CreateFolder(FolderPath);
            CreateFile(content, fileName, "cs",FolderPath);            
        }
    }
}
