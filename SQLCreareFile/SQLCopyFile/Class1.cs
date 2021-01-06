using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.IO;
using System.Text;

public static class AssemmbleCreateFile
{
    [SqlFunction(IsDeterministic = true)]
    //public static SqlBoolean IsCopyFile(SqlString path, SqlString text, SqlString sqlencoding)
    //{
    //    Encoding encoding;
    //    switch (sqlencoding.ToString().ToUpper())
    //    {
    //        case "UTF-8":
    //            encoding  = Encoding.UTF8;
    //            break;
    //        case "WINDOWS-1251":
    //            encoding = Encoding.ASCII;
    //            break;
    //        default:
    //            encoding = Encoding.UTF8;
    //            break;
    //    }

    //    try
    //    {

    //        File.WriteAllText(path.ToString(), text.ToString(),encoding);
    //        return (SqlBoolean)true;
    //    }
    //    catch (Exception ex)
    //    {
    //        return (SqlBoolean)false; 

    //    }

    //}

    /*
public static SqlBoolean IsCopyFile(SqlString path, SqlString text)
{
    Encoding encoding = Encoding.UTF8;
    try
    {

        File.WriteAllText(path.ToString(), text.ToString(), encoding);
        return (SqlBoolean)true;
    }
    catch (Exception ex)
    {
       return (SqlBoolean)false;

    }

}

*/


    public static SqlString IsCopyFile(SqlString path, SqlString text, SqlString? encod)
    {
        
        Encoding encoding;
        switch (encod.ToString().ToUpper())
        {
            case "UTF-8":
                encoding = Encoding.UTF8;
                break;
            case "WINDOWS-1251":
                encoding = Encoding.ASCII;
                break;
            default:
                encoding = Encoding.UTF8;
                break;
        }

            
        try
        {

            File.WriteAllText(path.ToString(), text.ToString(), encoding);
            return "1";
        }
        catch (Exception ex)
        {
            return ex.Message;

        }

    }
}