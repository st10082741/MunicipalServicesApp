using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Class_Objects
{
    public class Issue
    {
        /// <summary>
        /// Properties to store issue data
        /// </summary>
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MediaPath { get; set; }

        /// <summary>
        /// Constructor to initialize the issue
        /// </summary>
        /// <param name="location"></param>
        /// <param name="category"></param>
        /// <param name="description"></param>
        /// <param name="mediaPath"></param>
        public Issue(string location, string category, string description, string mediaPath)
        {
            Location = location;
            Category = category;
            Description = description;
            MediaPath = mediaPath;
        }

        /// <summary>
        /// Method to format the issue details for display
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Location: {Location}, Category: {Category}";
        }

        //----------------------------------**End**------------------------------------//
    }
}
