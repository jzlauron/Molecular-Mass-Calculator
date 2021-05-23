/*********************************************************************************************************
 * Project: Molecular Mass Calculator
 * Class: Input parser for the textbox accepting input formulae from user
 * This class uses mostly Regex to parse data and convert it to readable string format
 * Authors: Kieran Lambert, Juan Carlos Lauron
 * Course: CMPE 2800
 * Date: Feb 02, 2020
 * Submission Code: 1202_CMPE2800_MMC
 ********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MolecularMassCalculator
{
    /// <summary>
    /// Class for parsing the data provided by user
    /// Isolated to clean up main form code, this class handles all Regex functions
    /// Shared responsibility
    /// KL - Initial creation, page formatting to prevent destructive editing, Regex.Split/Replace, v/_inputData/vData/w/Properties
    /// JCL - vParsed, bugfixing in w, initial non-join concept which laid a great groundwork for conversion to LINQ, Regex.Match
    /// </summary>
    class InputParse
    {
        //Input data collected from the textbox
        private string _inputData;
        /// <summary>
        /// Initializes data text string so it's not null
        /// </summary>
        /// <param name="inputText">Default blank placeholder text</param>
        public InputParse(string inputText = "")
        {
            //Initially sets text data to blank by default, also accepts a placeholder
            _inputData = inputText;
        }
        /// <summary>
        /// Return a list of the valid data input to the textbox by user
        /// </summary>
        public List<string> GetValid { get; } = new List<string>();
        /// <summary>
        /// Returns a list of invalid data input to the textbox by user
        /// </summary>
        public bool Invalid { get; private set; } = false;
        /// <summary>
        /// Set the data string to the contents of the textbox externally
        /// </summary>
        public string SetData
        {
            set
            {
                //Remove white space (\s)(Extra backslash because it's c# escape character),
                //"greedy" + to signify removal of all white space found, "" to replace with nothing
                _inputData = Regex.Replace(value, "\\s+", "");
            }
        }
        /// <summary>
        /// Sorts valid data into a dictionary of elements suitable for display in the Data Grid
        /// </summary>
        /// <returns>A dictionary collection of all valid elemtns in textbox</returns>
        public Dictionary<Element, int> GetValidElements()
        {
            
            Dictionary<Element, int> validElements = new Dictionary<Element, int>();
            ///////////////////////////////////////////////////////////////////////////////////////
            //Split input string into valid matches via Regex Split
            //Valid matches consist of a minimum of one upper case letter with optional lowercase letter/1-2 digit number
            var vData = from x in Regex.Split(_inputData, "([A-Z][a-z]\\d+)|([A-Z]\\d+)|([A-Z][a-z])|([A-Z])")
                        where x.Length > 0
                        select x;

            ///////////////////////////////////////////////////////////////////////////////////////
            //Process valid matches from the above into seperate parts via Regex Match
            //No number defaults to a count of 1
            var vParsed = from elm in vData
                          select new { elmSymbol = Regex.Match(elm, "([A-Z][a-z]|[A-Z])").Value,
                              elmCount = string.IsNullOrWhiteSpace(Regex.Match(elm, "\\d+").Value) ? 1 : int.Parse(Regex.Match(elm, "\\d+").Value)};


            //Clear the list of accepted values before adding more to it
            Invalid = false;
            GetValid.Clear();
            //////////////////////////////////////////////////////////////////////////////////////
            //Perform a LINQ join on the above result with the periodic dictionary
            var v = from e in vParsed
                    join e2 in Table.GetElements() on e.elmSymbol equals e2.Symbol              //e2.Symbol key comparison
                    select new { e2, e.elmCount};
            //Check if invalid elements were found and removed
            if (v.Count() < vParsed.Count())
                Invalid = true;
            //Iterate through v and add/update dictionary of valid elements
            foreach (var w in v)
            {
                int i = w.elmCount;
                if (!validElements.TryGetValue(w.e2, out int j))
                    validElements.Add(w.e2, w.elmCount);
                else
                    validElements[w.e2] += i;
            }
            //Return dictionary of valid elements
            return validElements;
        }
    }
}
