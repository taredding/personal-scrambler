using System;
using System.Text;

 /// <summary>
 ///   This program scrambles or unscrambles a file using a given key
 /// <summary>
namespace scrambler
{
    class Scrambler
    {
        //number of times to repeat scrambling process
        public const int NUM_ITERATIONS = 10;
        /// <summary>
        ///   This is the main method that launches the scrambler progam
        /// </summary>
        /// <param name="args">
        ///   The list of command line arguments
        /// </param>
        static void Main(string[] args)
        {
            if (args.Length != 4) {
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
                for (int i = 0; i < NUM_ITERATIONS; i++) {
                    scramble(ref input, args[2]);
                }
                System.IO.File.WriteAllBytes(args[3], input);
            }
            else if (args[0].Equals("-u")) {
                for (int i = 0; i < NUM_ITERATIONS; i++) {
                    unscramble(ref input, args[2]);
                }
                System.IO.File.WriteAllBytes(args[3], input);
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
            Console.WriteLine("usage: dotnet run [task] [infilename] [key] [outfilename]\n task:\n -s to scramble a file\n -u to unscramble");
            Console.WriteLine("infilename: the input file to read");
            Console.WriteLine("key: the key used to scramble or unscramble your file contents (maximum length of 256).");
            Console.WriteLine("outfilename: the key used to scramble or unscramble your file contents (maximum length of 256).");
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
        private static void unscramble(ref byte[] bytes, String keyStr) {
            char[] key = keyStr.ToCharArray();
            byte[] subTable = getReverseSubstitutionTable(key);

                unRotateBits(key, ref bytes);
                

                for (int i = 0; i < bytes.Length; i++) {
                    bytes[i] -= (byte)key[i%key.Length];
                    bytes[i] = subTable[bytes[i]];
                }
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
            rotateBits(key, ref bytes);
        }
        /// <summary>
        ///   Returns a small, byte sized key based on a full key to be used for a couple sub processes.!--
        /// </summary>
        /// <param name="key">
        ///   The key to generate the small key based off of.
        /// </param>
        private static byte getSmallKey (char[] key) {
            byte i = 0x00;
            byte smallKey = 0x00;
            for (byte c = 1; c <= key.Length; c++) {
                smallKey += (byte)(key[c - 1] ^ c);
            }
            return i;
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
        /// <summary>
        ///   Generates a table to reverse a substituition.
        /// </summary>
        /// <param name="keyVal">
        ///   The key to generate the table based off of.
        /// </param>
        private static byte[] getReverseSubstitutionTable(char[] key) {
            byte[] subTable = getSubstitutionTable(key);
            byte [] revTable = new byte[subTable.Length];
            byte smallKey = getSmallKey(key);
            byte i = 0x00;
            do {
                //swap the position and value of everything in array
                revTable[subTable[i]] = i;
                i++;
            } while (i != 0x00);
            return revTable;
        }
        /// <summary>
        ///   Rotates bits in the bytes to the right in a similar manner to the Vigenere Cipher, to the left
        /// </summary>
        /// <param name="key">
        ///   The key used to base rotations off of
        /// </param>
        /// <param name="bytes">
        ///   The bytes to manipulate
        /// </param>
        private static void rotateBits(char[] key, ref byte[] bytes) {
            for (int i = 0; i < bytes.Length; i++) {
                for (int j = 0; j < key[i%key.Length]; j++) {
                    bytes[i] = (byte)((bytes[i] >> 7) | ((bytes[i] & 0x7f) << 1));
                }
            }
        }

        /// <summary>
        ///   Rotates bits in the bytes in a similar manner to the Vigenere Cipher, to the right
        /// </summary>
        /// <param name="key">
        ///   The key used to base rotations off of
        /// </param>
        /// <param name="bytes">
        ///   The bytes to manipulate
        /// </param>
        private static void unRotateBits(char[] key, ref byte[] bytes) {
            for (int i = 0; i < bytes.Length; i++) {
                for (int j = 0; j < key[i%key.Length]; j++) {
                    bytes[i] = (byte)((bytes[i] << 7) | ((bytes[i] & 0xfe) >> 1));
                }
            }
        }

    }
}
