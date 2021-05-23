/*********************************************************************************************************
 * Project: Molecular Mass Calculator
 * Class: Table class converts text file to an array of Elements
 * This class operates entirely behind the scenes, is used to check the text file's contents against
 * text input by the user and is the source of data displayed on button clicks
 * Periodic data downloaded, with minor edits, from 
 * https://raw.githubusercontent.com/frictionlessdata/example-data-packages/d2b96aaed6ab12db41d73022a2988eeb292116e9/periodic-table/data.csv
 * Data checked against multiple sources for accuracy, as github is not exactly
 * A paragon of scientific accuracy. The file is acceptably accurate, and has had some unnecessary information removed
 * Authors: Kieran Lambert, Juan Carlos Lauron
 * Course: CMPE 2800
 * Date: Feb 03, 2020
 * Submission Code: 1202_CMPE2800_MMC
 ********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
namespace MolecularMassCalculator
{
    /// <summary>
    /// Periodic table class created by JCL, commented by KL
    /// </summary>
    class Table
    {
        private static Element[] _elements = new Element[100];                  //collection for 100 elements
        /// <summary>
        /// Converts the .txt file into a usable format at runtime
        /// </summary>
        static Table()
        {
            //Locate the periodic table text file in resources
            string[] path = Properties.Resources.PeriodicTable.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            //This list of string arrays stores the lines of text as individual array elements
            List<string[]> rows = new List<string[]>();
            //Populate the above list, splitting out the commas separating individual pieces of data
            for (int i = 0; i < path.Length; i++)
            {
                rows.Add(path[i].Split(','));
                
            }
            //Assign the newly parsed and created Elements to the static array of Elements
            _elements = (from input in rows select new Element(int.Parse(input[0]), input[1], input[2], float.Parse(input[3]))).ToArray();
        }
        /// <summary>
        /// Public get function for the array of Element class objects
        /// </summary>
        /// <returns>The collection of elements in the periodic table provided by parsing the .txt file</returns>
        public static Element[] GetElements()
        {
            return _elements;
        }

        

    }
}
