using BL.interfaces;
using BL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.managers
{
    public class CycleManager
    {
        private IFileProcessor fileprocessor;

        public CycleManager(IFileProcessor fileprocessor)
        {
            this.fileprocessor = fileprocessor;
        }

        public List<CycleData> MaakData(List<string> data)
        {
            List<CycleData> cycleData = new List<CycleData>();

            foreach (string record in data)
            {
                string[] split = record.Split(',');

                CycleData cycle = new CycleData(DateTime.Parse(split[0].Trim('\'')), int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3]), int.Parse(split[4]), int.Parse(split[5]), split[6].Trim('\''), split[7].Trim('\''), int.Parse(split[8]));

                cycleData.Add(cycle);
            }
            return cycleData;
        }
    }
}
