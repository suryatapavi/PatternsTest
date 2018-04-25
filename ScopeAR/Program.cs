// This is a Program for Pattern generation.
// It constains an abstract Class extendable to different Patterns to be printed on a Console Application.
// Two default implementations (a) Chrismas Tree and (b) Cross Patterns have been implemented.
// The Main method of this Namespace takes user inputs and interactively outputs the 2 default pattern implementations based on the inputs.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScopeAR
{
    //helper Class for pattern generation: Required Characters can be changed with other Draw/Renderer libraries without affecting the functionality of the program.
    public class Characters
    {
        public Characters()
        { }

        // Function to return a sting composed of "*" character.
        public string Star(int freq)
        {
            string star = "";
            for (int i = 0; i < freq; i++)
            {
                star += "*";
            }
            return star;
        }

        // Function to return a sting composed of SPACE character.
        public string Space(int freq)
        {
            string space = "";
            for (int i = 0; i < freq; i++)
            {
                space += " ";
            }
            return space;
        }

        // Function to return a sting composed of NEWLINE character.
        public string Newline(int freq)
        {
            string newln = "";
            for (int i = 0; i < freq; i++)
            {
                newln += "\n";
            }
            return newln;
        }
    }

    //An abstract class that embodies characteristic parameters of Patterns and methods to set and print Patterns
    public abstract class Pattern
    {
        public int _height;                            // height of a Pattern
        public int _width;                            // line width of a Pattern
        public StringBuilder _pattern;               // a StringBuilder object as the Pattern
        public Pattern(){}                     
        public Pattern(int height)                  //Constructor to set the height of the Pattern; _height is an arbitary parameter. _width is a dependent parameter based on the Pattern logic in implementation classes.
        {
            this._height = height;
        }
        public abstract void SetPattern();        //Logic to be overriden in implementation child classes to set the Patterns.

        // method to print pattern
        public void printPattern()
        {
            Console.WriteLine(this._pattern.ToString());
        }
    }

    // Class that implements the logic for (a) Christmas Tree pattern generation.
    public class treePattern : Pattern
    {
        public treePattern(int Height):base(Height){ _width = 2 * _height - 1; } //The Tree Pattern has a logical relation from _height to _width as set in the custom constructor.
        public override void SetPattern()
        {
            _pattern = new StringBuilder();                                      // Pattern is initialized.
            Characters dr = new Characters();                                    // Helper object created.

            for (int i = _height; i > 0; i--)                                    // for each row from top of the tree
            {
                _pattern.Append(dr.Space(i - 1));                                // SPACE is appended to a row in the Pattern depending on the row number.
                _pattern.Append(dr.Star(_width - 2*(i - 1)));                    // "*" is appended to a row in the Pattern depending on the row number.
                _pattern.Append(dr.Space(i - 1));                                // SPACE is appended to a row in the Pattern depending on the row number.
                _pattern.Append(dr.Newline(1));                                  // NEWLINE is appended to a row in the Pattern depending on the row number.
            }
        }

    }

    // Class that implements the logic for (a) Cross pattern generation.
    public class crossPattern : Pattern
    {
        public crossPattern(int Height) : base(Height) { _width = 2*_height-1; }  //The Cross Pattern has a logical relation from _height to _width as set in the custom constructor.
        public override void SetPattern()
        {
            _pattern = new StringBuilder();                                       // Pattern is initialized.
            Characters dr = new Characters();                                     // Helper object created.

            int range = (_height - 1) / 2;                                        //range is the middle row of the Cross Pattern which is considered the center of the pattern.
            for (int i = -range; i <= range; i++)                                 //from the bottom to the top with respect to the middle row the pattern is generated using its symmetricity.
            {
                StringBuilder linePattern = new StringBuilder();                  //a temporary row pattern is initialized.     
                linePattern.Append(dr.Space(_width));                             //the entire row width is filled with SPACE characters.
                linePattern.Remove(2*(range-i),1);                                //depending on the row number space is removed at suitable positions.
                linePattern.Insert(2*(range-i),dr.Star(1));                       //and a "*" character is inserted.
                linePattern.Remove(2*(range + i), 1);                             //depending on the row number space is removed at suitable positions.
                linePattern.Insert(2*(range + i), dr.Star(1));                    //and a "*" character is inserted.
                _pattern.Append(linePattern);                                     //temporary row pattern is the appended to the Pattern.
                _pattern.Append(dr.Newline(1));                                   //a new line is initialized for the next temporary row pattern.
              
            }

        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            int[] PatternChoices = new int[] { 1, 2, 3 };                                          //Pattern Choices given to a User
            bool Exited = false;                                                                   //the console application will continue to run till the User exits.
            while (!Exited)
            {
                List<Pattern> toDraw = new List<Pattern>();                                        //initialize list of patterns to be drawn.
                int PatternChoice = 0;                                                             //initialize the Pattern choice as 0.                                       
                int Height = 0;                                                                    //initialize the arbitary pattern height to be 0.
                bool PatternSelected = false;                                                      //a bool to indicate proper selection of Pattern by user.
                bool HeightEntered = false;                                                        //a bool to indicate proper height entered by user.

                while (!PatternSelected)                                                           //till a proper Pattern selection is not made 
                {
                    Console.WriteLine("Please Make a Selection:");                                 //User is asked to make a selection/
                    Console.Write("Enter 1 to View a Christmas Tree");
                    Console.Write(" or Enter 2 to View a Cross");
                    Console.WriteLine(" or Enter 3 to View Both.");
                    Console.Write("Selection:");
                    try
                    {
                        PatternChoice = int.Parse(Console.ReadLine());                            //if proper integer selection is entered bool is set to true else user is asked to retry.
                        if (PatternChoices.Contains(PatternChoice))
                        {
                            PatternSelected = true;
                        }
                        else
                        {
                            Console.WriteLine("Select from given options.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please make a proper selection");
                    }
                }

                while (!HeightEntered)                                                                   //till a proper integer height is entered
                {                                     
                    try
                    {
                        switch (PatternChoice)                                                          //based on user input Patterns to be drawn are intialized.
                        {
                            case 1:
                                Console.Write("Please Enter Tree Height (Any integer above 1):");
                                Height = int.Parse(Console.ReadLine());                                 //if proper integer height is entered bool is set to true else user is asked to retry.
                                toDraw.Add(new treePattern(Height));
                                break;
                            case 2:
                                Console.Write("Please Enter Cross Height (Any odd integer above 2):");
                                Height = int.Parse(Console.ReadLine());                                 //if proper integer height is entered bool is set to true else user is asked to retry.
                                toDraw.Add(new crossPattern(Height));
                                break;
                            case 3:
                                Console.Write("Please Enter Tree Height (Any integer above 1):");
                                Height = int.Parse(Console.ReadLine());
                                toDraw.Add(new treePattern(Height));
                                Console.Write("Please Enter Cross Height (Any odd integer above 2):");
                                Height = int.Parse(Console.ReadLine());
                                toDraw.Add(new crossPattern(Height));
                                break;

                        }
                        HeightEntered = true;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter an integer value!");
                    }
                }

                foreach (Pattern p in toDraw)                                                   //for each Pattern to be drawn pattern is generated and printed.
                {
                    p.SetPattern();
                    p.printPattern();
                }
                
            }
        }
    }
}
