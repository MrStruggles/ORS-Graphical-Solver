using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GraphicalSolver
{
    //Class used to manage file access
    class FileHandler
    {
        static FileStream fs;
        static StreamReader sr;

        public void CheckFile(string filename)
        {
            if (!File.Exists(filename))
            {
                fs = new FileStream(filename, FileMode.Create);
                fs.Close();
            }

        }

        //Read text from a selected file
        public static List<string> Read(string filename)
        {
            fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);
            List<string> output = new List<string>();
            try
            {
                while (!sr.EndOfStream)
                {
                    output.Add(sr.ReadLine());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return output;
        }

        //Splits a given line into a list of seperate values according to the regular expression
        public static List<string> SplitLine(string line)
        {
            List<string> values = new List<string>();

            foreach (var match in Regex.Matches(line, @"([*+/\-<>=)(])|([0-9]+)"))
            {
                values.Add(match.ToString());
            }

            return values;
        }

    }

    
}
