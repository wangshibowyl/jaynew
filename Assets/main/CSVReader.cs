using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CSVReader
{
    private static Dictionary<string, Dictionary<string, Dictionary<string, string>>> csvfiles = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

    //public static void OnInitCSV()
    //{
    //    if (csvfiles == null)
    //    {
    //        csvfiles = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

    //        foreach (TextAsset asset in Resources.LoadAll("csv"))
    //        {
    //            readCSV(asset);
     //       }
     //   }
    //}

    public static void readCSV(TextAsset asset)
    {
        string texts = asset.text;
        Dictionary<string, Dictionary<string, string>> csvfile = new Dictionary<string, Dictionary<string, string>>();

        string[] lines = texts.Split('\n');
        string[] colname = lines[0].Split('\t');			//ÓÃÀ´´¢´æÁÐÃû

        bool bFirstLine = true;
        foreach (string line in lines)
        {
            if (bFirstLine)
            {
                bFirstLine = !bFirstLine;
            }
            else
            {
                Dictionary<string, string> colmap = new Dictionary<string, string>();
                if (line.Length > 0)
                {
                    string[] col = line.Split('\t');
                    for (int i = 1; i != colname.Length; ++i)
                    {
                        colmap.Add(colname[i].Trim(), col[i].Trim());
                    }
                    csvfile.Add(col[0].Trim(), colmap);
                }
            }
        }
		
        csvfiles.Add(asset.name.Trim(), csvfile);
    }

    public static bool hasRow(string filename, string row)
    {
        if (csvfiles.ContainsKey(filename))
        {
            if (csvfiles[filename].ContainsKey(row))
                return true;
        }
        return false;
    }
	
	public static int getRowCount(string file)
	{
		if (!csvfiles.ContainsKey(file))
		{
			readCSV((TextAsset)Resources.Load("csv/"+file));
		}
		return csvfiles[file].Count;
	}

    public static string[] getRowNames(string filename)
    {
        string[] rownames = new string[csvfiles[filename].Count];
        csvfiles[filename].Keys.CopyTo(rownames, 0);
        return rownames;
    }
	
	private static Dictionary<string, Dictionary<string, string>> getFile(string file)
	{
		if (!csvfiles.ContainsKey(file))
		{
			readCSV((TextAsset)Resources.Load("csv/"+file));
		}
		return csvfiles[file];
	}

    public static int getInt(string filename, string row, string col)
    {
        try
        {
            return Int32.Parse(getFile(filename)[row][col]);
        }
        catch
        {
            return 0;
        }
    }

    public static double getDouble(string filename, string row, string col)
    {
        try
        {
            return Double.Parse(getFile(filename)[row][col]);
        }
        catch
        {
            return 0;
        }
    }

    public static float getFloat(string filename, string row, string col)
    {
        try
        {
            return Single.Parse(csvfiles[filename][row][col]);
        }
        catch
        {
            return 0;
        }
    }

    public static string getString(string filename, string row, string col)
    {
        try
        {
            return getFile(filename)[row][col];
        }
        catch
        {
            return "";
        }
    }

    public static bool getBoolean(string filename, string row, string col)
    {
        try
        {
            return getFile(filename)[row][col] == "0" ? false : true;
        }
        catch
        {
            return false;
        }
    }

    public static byte getByte(string filename, string row, string col)
    {
        try
        {
            return Byte.Parse(getFile(filename)[row][col]);
        }
        catch
        {
            return 0;
        }
    }
}
