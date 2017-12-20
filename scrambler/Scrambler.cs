using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


 /// <summary>
 ///   This program scrambles or unscrambles a file using a given key
 /// <summary>
namespace Scrambler
{   
    /// <summary>
    /// This class handles basic (weak) encryption and decryption of files using keys (strings of letters)
    /// </summary>
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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScramblerGUI());
        }
        /// <summary>
        /// Reads a file and returns all the bytes in the file
        /// </summary>
        /// <param name="fileName">The name of the file to read.</param>
        /// <returns> All the bytes from the file.</returns>
        private static byte[] readFile(String fileName) {
            if (fileName == null || fileName.Equals("")) {
                throw new IOException("Please enter an input file name.");
            }
            byte[] bytes;
            try
            {
                bytes = System.IO.File.ReadAllBytes(fileName);
            }
            catch (IOException)
            {
                throw new IOException("Input file could not be found/read.");
            }
            return bytes;
        }
        /// <summary>
        /// Writes a file with the given file name and bytes
        /// </summary>
        /// <param name="fileName"> The name of the file to write. </param>
        /// <param name="bytes"> The contents of the file that will be written. </param>
        private static void writeFile(String fileName, byte[] bytes)
        {
            if (fileName == null || fileName.Equals("")) {
                throw new IOException("Please enter an output file name.");
            }
            try
            {
                System.IO.File.WriteAllBytes(fileName, bytes);
            }
            catch (IOException)
            {
                throw new IOException("The output file could not be created, please try a different name or location.");
            }
        }
        /// <summary>
        ///   This method scrambles a file using a given key
        /// </summary>
        /// <param name="inFile">
        ///   The name of the file to scramble
        /// </param>
        /// <param name="outFile">
        ///   The name of the scrambled file to output
        /// </param>
        /// <param name="keyStr">
        ///   The key used to scramble the file
        /// </param> 

        public static void scramble(String inFile, String outFile, String keyStr)
        {
            validateKey(keyStr);
            byte[] bytes = readFile(inFile);
            char[] key = keyStr.ToCharArray();

            byte[] subTable = getSubstitutionTable(key);

            for (int i = 0; i < bytes.Length; i++)
            {
                //substitute out each byte with the value from the substitution table
                bytes[i] = subTable[bytes[i]];
                //Using key to encrypt file's bytes using Vigenere Cipher
                bytes[i] += (byte)key[i % key.Length];

            }
            rotateBits(key, ref bytes);
            writeFile(outFile, bytes);
        }
        /// <summary>
        /// Unscrambles the contents of a file
        /// </summary>
        /// <param name="inFile">The name of the file to scramble. </param>
        /// <param name="outFile">The name of the output file to create. </param>
        /// <param name="keyStr">The key to be used to unscramble the file with. </param>
        public static void unscramble(String inFile, String outFile, String keyStr)
        {
            validateKey(keyStr);
            byte[] bytes = readFile(inFile);

            char[] key = keyStr.ToCharArray();
            byte[] subTable = getReverseSubstitutionTable(key);

            unRotateBits(key, ref bytes);


            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] -= (byte)key[i % key.Length];
                bytes[i] = subTable[bytes[i]];
            }
            writeFile(outFile, bytes);
        }
        /// <summary>
        /// Validates that a given key is valid to use in the scrambling/unscrambling process
        /// </summary>
        /// <param name="key">The key to validate</param>
        private static void validateKey(String key) {
            if (key.Length == 0) {
                throw new ArgumentException("Please enter a key.");
            }
        }
        /// <summary>
        ///   Returns a small, byte sized key based on a full key to be used for a couple sub processes.!--
        /// </summary>
        /// <param name="key">
        ///   The key to generate the small key based off of.
        /// </param>
        private static byte getSmallKey(char[] key)
        {
            byte i = 0x00;
            byte smallKey = 0x00;
            for (byte c = 1; c <= key.Length; c++)
            {
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
        private static byte[] getSubstitutionTable(char[] key)
        {
            byte[] subTable = new byte[256];

            byte i = 0x00;
            byte smallKey = 0x00;
            for (byte c = 1; c <= key.Length; c++)
            {
                smallKey += (byte)(key[c - 1] ^ c);
            }


            i = 0x00;
            //this do while loop is used to prevent an infinite loop while also initializing all values from 0-255
            do
            {
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
        private static byte[] getReverseSubstitutionTable(char[] key)
        {
            byte[] subTable = getSubstitutionTable(key);
            byte[] revTable = new byte[subTable.Length];
            byte smallKey = getSmallKey(key);
            byte i = 0x00;
            do
            {
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
        private static void rotateBits(char[] key, ref byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < key[i % key.Length]; j++)
                {
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
        private static void unRotateBits(char[] key, ref byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < key[i % key.Length]; j++)
                {
                    bytes[i] = (byte)((bytes[i] << 7) | ((bytes[i] & 0xfe) >> 1));
                }
            }
        }

    }
}

