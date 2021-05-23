//Project : Molecular Mass Calculator
// Course : CMPE 2800
// Date January 29 2021
// Instructor: Simon Walker
// Authors : Kieran Lambert, Juan Carlos Lauron
// LINQ, Regex Assignment
//  
// Submission code : 1202_CMPE2800_MMC
///////////////////////////////////////////////////
using System;
using System.Linq;


namespace MolecularMassCalculator
{
    /// <summary>
    /// Element class 90% created/commented by JCL, override for comparison added by KL
    /// </summary>
    class Element
    {
        private int _iAtomicNum;                //element's atomic number based 
        private string _sName;                  //element name
        private string _sSymbol;                //element symbol
        private float _fAtomicMass;             //element molar mass
        /// <summary>
        /// Element Constructor 
        /// </summary>
        /// <param name="atomicNumber">Element's atomic number</param>
        /// <param name="name">Element's name</param>
        /// <param name="symbol">Element's symbol</param>
        /// <param name="atomicWeight">Element's atomic weight</param>
        public Element(int atomicNumber, string symbol, string name, float atomicWeight)
        {
            _iAtomicNum = atomicNumber;
            _sName = name;
            _sSymbol = symbol;
            _fAtomicMass = atomicWeight;
        }
        public Element(string sym)
        {
            _sSymbol = sym;
        }
        //atomic number property
        public int AtomicNumber
        {
            get { return _iAtomicNum; }
            set { if (value <= 0)
                    throw new Exception("Atomic number value must be a natural number");
                 _iAtomicNum = value;
            } 
        }
        //name property 
        public string Name
        {
            get { return _sName; }
            set { if (value.Count() == 0)
                    throw new Exception();
            }
        }
        //symbol property
        public string Symbol
        {
            get { return _sSymbol; }
            set
            {
                if (value.Count() == 0)
                    throw new Exception();
            }
        }
        //atomic mass property
        public float AtomicMass
        {
            get { return _fAtomicMass; }
            set
            {
                if (value <= 0)
                    throw new Exception("Atomic mass value must be a natural number");
                _fAtomicMass = value;
            }

        }
        /// <summary>
        /// Override equals to compare by atomic symbol as a unique identifier
        /// </summary>
        public override bool Equals(object obj)
        {
            //Type check/null check
            if (!(obj is Element) || obj is null)
                return false;
            //Cast
            Element e = obj as Element;
            //Return comparison
            return _sSymbol.Equals(e._sSymbol);
        }
        /// <summary>
        /// Hashcode is meaningless here
        /// </summary>
        public override int GetHashCode()
        {
            return 1;
        }
    }
}
