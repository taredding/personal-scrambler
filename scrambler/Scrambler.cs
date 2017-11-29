using System;

 /// <summary>
 ///   This program scrambles or unscrambles a file using a given key
 /// <summary>
namespace scrambler
{
    class Scrambler
    {
        /// <summary>
        ///   This is the main method that launches the scrambler progam
        /// </summary>
        /// <param name="args">
        ///   The list of command line arguments
        /// </param>
        static void Main(string[] args)
        {
            getSubstitutionTable("myKey");
            if (args.Length != 3) {
                usagePrint();
                return;
            }
            byte[] input = new byte[0];
            try
            {
                input = System.IO.File.ReadAllBytes(args[1]);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error retrieving input file.");
                return;
            }

            if (args[0].Equals("-s") ) {
                scramble(ref input, args[2]);
            }
            else if (args[0].Equals("-u")) {
                unscramble(ref input, args[2]);
            }
            else {
                usagePrint();
            }

        }
        /// <summary>
        ///   Prints out a usage statement to the console,
        ///   to be used when the user doesn't launch scrambler
        ///   via command line properly
        /// </summary>
        private static void usagePrint(){
            Console.WriteLine("usage: dotnet run [task] [filename] [key]\n task:\n -s to scramble a file\n -u to unscramble");
            Console.WriteLine("filename: the input file to read");
            Console.WriteLine("key: the key used to scramble or unscramble your file contents.");
        }
        /// <summary>
        ///   Writes an array of bytes to a file
        /// </summary>
        /// <param name="toWrite">
        ///   The bytes to write to the output file
        /// </param>
        /// <param name="fileName">
        ///   The name of the output file
        /// </param>
        private static void writeChar(byte[] toWrite, String fileName) {

        }
        /// <summary>
        ///   This method unscrambles a file given a key
        /// </summary>
        /// <param name="bytes">
        ///   The bytes from the file to unscramble, passed by reference
        /// </param>
        /// <param name="key">
        ///   The key used to unscramble the file
        /// </param>
        private static void unscramble(ref byte[] bytes, String key) {
            
        }
        /// <summary>
        ///   This method scrambles a file using a given key
        /// </summary>
        /// <param name="bytes">
        ///   The bytes from the file to scramble, passed by reference
        /// </param>
        /// <param name="key">
        ///   The key used to scramble the file
        /// </param> 

        private static void scramble(ref byte[] bytes, String key) {

        }
        /// <summary>
        ///   Generates a byte substitution table based on a key.
        /// </summary>
        /// <param name="keyVal">
        ///   The key to generate the table based off of.
        /// </param>
        private static byte[] getSubstitutionTable(String keyVal) {
            char[] key = keyVal.ToCharArray();
            byte[] subTable = new byte[256];
            
            byte i = 0x00;
            //this do while loop is used to prevent an infinite loop while also initializing all values from 0-255
            do {
                //creates the substitution table using a Vigenere Cipher
                subTable[i] = (byte)(i + key[(int)(i%key.Length)]);
                Console.Write((char)subTable[i]);
                i++;
            } while (i != 0x00);

            System.IO.File.WriteAllBytes("output.txt", bytes: subTable);
            return subTable;
        }
    }
}
