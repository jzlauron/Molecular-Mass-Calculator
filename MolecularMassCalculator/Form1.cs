/*********************************************************************************************************
 * Project: Molecular Mass Calculator
 * Class: Main form class, the heart of the operation
 * This class interacts directly with the user and makes use of the various other classes to do so
 * Use of LINQ, calls to multiple classes, Datagrids, binding sources, button operations, textbox stuff
 * Authors: Kieran Lambert, Juan Carlos Lauron
 * Course: CMPE 2800
 * Date: Feb 03, 2020
 * Submission Code: 1202_CMPE2800_MMC
 ********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MolecularMassCalculator
{
    /// <summary>
    /// Main form class, shared responsibility
    /// </summary>
    public partial class Form1 : Form
    {
        //New textbox parsing class
        private InputParse eParse = new InputParse();
        //New Binding source for the DataGrid
        private BindingSource bs = new BindingSource();
        //New dictionary to store our collection parsed from textbox
        private Dictionary<Element, int> elementDc = new Dictionary<Element, int>();
        public Form1()
        {
            InitializeComponent();
            UI_dgvElements.DataSource = bs;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var allElements = Table.GetElements();
            bs.DataSource = allElements;
        }
        /// <summary>
        /// Basic LINQ to order periodic collection by atomic number
        /// </summary>
        private void UI_btnSortAtomic_Click(object sender, EventArgs e)
        {
            //Clear textboxes
            UI_tbFormula.Text = "";
            UI_tbMolarMass.Text = "";

            //Order Element collection by Atomic mass
            var newElements = from element in Table.GetElements()
                              orderby element.AtomicMass
                              select element;
            bs.DataSource = newElements;
        }
        /// <summary>
        /// Basic LINQ to order periodic collection by symbol
        /// </summary>
        private void UI_btnSymbol_Click(object sender, EventArgs e)
        {
            //Clear textboxes
            UI_tbFormula.Text = "";
            UI_tbMolarMass.Text = "";

            //Order element collection by Symbol
            var symElements = from r in Table.GetElements() where r.Symbol.Length is 1
                              
                              orderby r.Symbol
                              select r;
            bs.DataSource = symElements;
        }
        /// <summary>
        /// Basic LINQ to order periodic collection by element name
        /// </summary>
        private void UI_btnSortName_Click(object sender, EventArgs e)
        {
            //Clear textboxes
            UI_tbFormula.Text = "";
            UI_tbMolarMass.Text = "";

            //Order element collection by Name
            var namElements = from s in Table.GetElements()
                              orderby s.Name
                              select s;
            bs.DataSource = namElements;
        }
        /// <summary>
        /// This method will be the main form's point of interaction between text entered by the user and
        /// data returned from the parsing class. It will "scan" for updates to the text in the box,
        /// and update various fields accordingly with help from the specialized parser class
        /// </summary>
        private void UI_tbFormula_TextChanged(object sender, EventArgs e)
        {
            //If there is nothing in the textbox, wait for input
            if(UI_tbFormula.TextLength == 0)
            {
                UI_tbMolarMass.Text = "Awaiting formula";
                UI_tbMolarMass.BackColor = Color.White;
                UI_tbFormula.BackColor = Color.White;
                var allElements = Table.GetElements();
                bs.DataSource = allElements;
            }
            //If there is text in the box, attempt to do things with it
            else
            {
                //Send contents of textbox to parsing unit
                eParse.SetData = UI_tbFormula.Text;
                //Set dictionary to return value
                elementDc = eParse.GetValidElements();
                if (eParse.Invalid)
                    UI_tbFormula.BackColor = Color.Yellow;
                else
                    UI_tbFormula.BackColor = Color.White;
                //Assign the contents of the dictionary to an anonymous type, calculate out the total valid atomic mass
                var parsElements = from t in elementDc
                                   select new
                                   { Element = t.Key.Name, Count = t.Value, t.Key.AtomicMass, ApproxTotalMass = t.Value * t.Key.AtomicMass };
                //Show results in data grid view
                bs.DataSource = parsElements;
                UI_tbMolarMass.Text = eParse.GetValidElements().Count > 0 ? parsElements.Sum(x => x.ApproxTotalMass).ToString() + " g/mol" : "No valid element found";  //invalid element check
                UI_tbMolarMass.BackColor = eParse.GetValidElements().Count > 0 ? Color.LightGreen : Color.Salmon;
            }
        }

        
    }
}
