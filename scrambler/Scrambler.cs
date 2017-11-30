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
            byte[] temp = System.IO.File.ReadAllBytes("input.txt");
            scramble(ref temp, "myKey");
            System.IO.File.WriteAllBytes("output.txt", temp);
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
            Console.WriteLine("key: the key used to scramble or unscramble your file contents (maximum length of 256).");
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

        private static void scramble(ref byte[] bytes, String keyVal) {
            char[] key = keyVal.ToCharArray();

            byte[] subTable = getSubstitutionTable(key);

            for (int i = 0; i < bytes.Length; i++) {
                //substitute out each byte with the value from the substitution table
                bytes[i] = subTable[bytes[i]];
                //Using key to encrypt file's bytes using Vigenere Cipher
                bytes[i] += (byte)key[i%key.Length];
                
            }
        }
        /// <summary>
        ///   Generates a byte substitution table based on a key.
        /// </summary>
        /// <param name="keyVal">
        ///   The key to generate the table based off of.
        /// </param>
        private static byte[] getSubstitutionTable(char[] key) {
            byte[] subTable = new byte[256];
            
            byte i = 0x00;
            byte smallKey = 0x00;
            for (byte c = 1; c <= key.Length; c++) {
                smallKey += (byte)(key[c - 1] ^ c);
            }


            i = 0x00;
            //this do while loop is used to prevent an infinite loop while also initializing all values from 0-255
            do {
                //creates the substitution table using the additive method
                subTable[i] = (byte)(i + smallKey);
                i++;
            } while (i != 0x00);
            return subTable;
        }

    }
}
