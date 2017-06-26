using System;

namespace CaesarCipher
{
    class Caesar
    {
        // Create an array, alphabet, to store every char in the alphabet 
        static char[] alphabet = {'a','b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
            'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        static void Main(string[] args)
        {
            // Prompt the user to enter a string to be encoded do decoded 
            Console.WriteLine("Please enter a string: ");
            // Read and store that string userInput
            string userInput = Console.ReadLine();
            // Change userInput to all lower case letters
            string userInputLower = userInput.ToLower();

            int typeOfCipher = 0;

            // Deals with user potentially entered an unreigested type of cipher
            while (typeOfCipher != 1 || typeOfCipher != 2)
            {

                // Ask the user if they want to encrypt of decypt the string
                Console.WriteLine("Press 1 for Encypt and 2 for Decrypt: ");

                // What if the user enters a letter or other character?
                try
                {
                    typeOfCipher = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    continue;
                }
                
                // Encypting
                if (typeOfCipher == 1)
                {
                    //Generate a random number by which to shift the alphabet by
                    Random randomNumber = new Random();
                    int shift = randomNumber.Next(1, 26);

                    string encrypted = "";

                    // For each letter in the user input
                    foreach (char letter in userInputLower)
                    {
                        // Case to deal with spaces being entered
                        if (letter == ' ')
                        {
                            encrypted += " ";
                        }
                        // Shift each individual letter by the random shift and add that char to the encrypted string
                        else
                        {
                            // What does Array.IndexOf() do?
                            int curIndex = Array.IndexOf(alphabet, letter);
                            int shiftedIndex = (curIndex + shift) % alphabet.Length;
                            char encryptedChar = alphabet[shiftedIndex];
                            encrypted += encryptedChar;
                        }
                    }

                    // Print out the encrypted 
                    Console.WriteLine(encrypted);
                    Console.ReadKey();
                    return;
                }


                // Decrypting
                else if (typeOfCipher == 2)
                {
                    int isKeyProvided = 0;
                    string decrypted = " ";

                    // Deals with user potentially entering a wrong answer to the prompt
                    while (isKeyProvided != 1 || isKeyProvided != 2)
                    {
                        // Ask the user if the key is provided or not
                        Console.WriteLine("Is the Key Provided? Press 1 for YES and 2 for NO");
                        // What if the user enters a letter or other character?
                        try
                        {
                            isKeyProvided = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            continue;
                        }

                        // If the key is provided
                        if (isKeyProvided == 1)
                        {
                            Console.WriteLine("What is the key: ");
                            int key = Convert.ToInt32(Console.ReadLine());


                            foreach (char letter in userInput)
                            {
                                // Case to deal with spaces being entered
                                if (letter == ' ')
                                {
                                    decrypted += " ";
                                }
                                else
                                // Shift each individual character to the unshifted index and add it to decrypted
                                {
                                    int curIndex = Array.IndexOf(alphabet, letter);
                                    int unShiftedIndex = (curIndex - key) % 26;

                                    char decryptedChar = alphabet[unShiftedIndex];
                                    decrypted += decryptedChar;
                                }
                            }

                            // Print out Decrypted 
                            Console.WriteLine(decrypted);
                            Console.ReadKey();
                            return;
                        }

                        // If the key is not provided
                        else if (isKeyProvided == 2)
                        {
                            // Check every potential decryption
                            for (int i = 26; i >= 0; i--)
                            {
                                decrypted = "";
                                foreach (char letter in userInput)

                                {
                                    // Case to deal with spaces being entered
                                    if (letter == ' ')
                                    {
                                        decrypted += " ";
                                    }
                                    else
                                    {
                                        // Shift each individual character to the unshifted index and add it to potential decrypted
                                        int curIndex = Array.IndexOf(alphabet, letter);
                                        int unShiftedIndex = (curIndex - i) % 26;
                                        char decryptedChar = alphabet[unShiftedIndex];
                                        decrypted += decryptedChar;
                                    }
                                }
                                // Display Potential cipher
                                Console.WriteLine(decrypted);   
                            }
                            Console.ReadKey();
                            return;
                        }
                    }
                }
            }
        } 
    }
}
