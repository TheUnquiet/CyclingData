using BL.exceptions;
using BL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class FileProcessor : IFileProcessor
    {
        public List<string> LeesData(string filename)
        {
            try
            {
                List<string> data = new List<string>();
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        data.Add(line);
                    }
                }
                return data;
            } catch(Exception ex) { throw new DomeinException("", ex); }
        }
    }
}
