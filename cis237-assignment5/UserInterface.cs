// Skylar Peters
// CIS 237
// 4/5/2021

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment5
{
    class UserInterface
    {
        const int MAX_MENU_CHOICES = 6;

        // Create an instance of the BeverageRepository class
        BeverageRepository beverageRepository = new BeverageRepository();

        /*
        |----------------------------------------------------------------------
        | Public Methods
        |----------------------------------------------------------------------
        */

        // Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the wine program!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            // Declare variable to hold the selection
            string selection;

            // Display menu, and prompt
            this.DisplayMenu();
            this.DisplayPrompt();

            // Get the selection they enter
            selection = this.GetSelection();

            // While the response is not valid
            while (!this.VerifySelectionIsValid(selection))
            {
                // Display error message
                this.DisplayErrorMessage();

                // Display the prompt again
                this.DisplayPrompt();

                // Get the selection again
                selection = this.GetSelection();
            }
            // Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        // Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        // Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {
            string id = this.GetStringField("Id");
            string name = this.GetStringField("Name");
            string pack = this.GetStringField("Pack");
            string price = this.GetDecimalField("Price");
            string active = this.GetBoolField("Active");

            return new string[] { id, name, pack, price, active };
        }

        public string[] UpdateItemInformation()
        {
            string id = this.GetStringField("Id");
            string name = this.UpdateStringField("Name");
            string pack = this.UpdateStringField("Pack");
            string price = this.UpdateDecimalField("Price");
            string active = this.GetBoolField("Active");

            return new string[] { id, name, pack, price, active };
        }
            // Display All Items
            public void DisplayAllItems()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Printing List");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            beverageRepository.PrintList();
        }

        // Display Item Found Success
        public void DisplayItemFound(string itemInformation)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Item Found!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(itemInformation);
        }

        // Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A Match was not found");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Item was successfully added");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Update Beverage Success
        public void DisplayUpdateItemSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Item was successfully updated");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An Item With That Id Already Exists");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display to get Id
        public void DisplayDeleteItem()
        {
            Console.WriteLine();
            Console.WriteLine("Enter ID of item to delete.");
        }

        // Display Delete Beverage Success
        public void DisplayDeleteItemSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Item was successfully deleted");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        /*
        |----------------------------------------------------------------------
        | Private Methods
        |----------------------------------------------------------------------
        */

        // Display the Menu
        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Print The Entire List Of Items");
            Console.WriteLine("2. Search For An Item");
            Console.WriteLine("3. Add New Item To The List");
            Console.WriteLine("4. Update An Item On The List");
            Console.WriteLine("5. Delete An Item From The List");
            Console.WriteLine("6. Exit Program");
        }

        // Display the Prompt
        private void DisplayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        // Display the Error Message
        private void DisplayErrorMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That is not a valid option. Please make a valid choice");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Get the selection from the user
        private string GetSelection()
        {
            return Console.ReadLine();
        }

        // Verify that a selection from the main menu is valid
        private bool VerifySelectionIsValid(string selection)
        {
            // Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                // Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                // If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= MAX_MENU_CHOICES)
                {
                    // Set the return value to true
                    returnValue = true;
                }
            }
            // If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                // Set return value to false even though it should already be false
                returnValue = false;
            }

            // Return the reutrnValue
            return returnValue;
        }

        // Get a valid string field from the console
        private string GetStringField(string fieldName)
        {
            Console.WriteLine("What is the Item's {0}", fieldName);
            string value = null;
            bool valid = false;
            while (!valid)
            {
                value = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(value))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must provide a value.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the Item's {0}", fieldName);
                    Console.Write("> ");
                }
            }
            return value;
        }

        // Get an updated string field from the console
        private string UpdateStringField(string fieldName)
        {
            Console.WriteLine("What is the Item's Updated {0}", fieldName);
            string value = null;
            bool valid = false;
            while (!valid)
            {
                value = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(value))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must provide a value.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the Item's Updated {0}", fieldName);
                    Console.Write("> ");
                }
            }
            return value;
        }

        // Get a valid decimal field from the console
        private string GetDecimalField(string fieldName)
        {
            Console.WriteLine("What is the Item's {0}", fieldName);
            decimal value = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    value = decimal.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Decimal. Please enter a valid Decimal.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the Item's {0}", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        // Get an updated decimal from the console
        private string UpdateDecimalField(string fieldName)
        {
            Console.WriteLine("What is the Item's Updated {0}", fieldName);
            decimal value = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    value = decimal.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Decimal. Please enter a valid Decimal.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the Item's Updated {0}", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        // Get a valid bool field from the console
        private string GetBoolField(string fieldName)
        {
            Console.WriteLine("Should the Item be {0} (y/n)", fieldName);
            string input = null;
            bool value = false;
            bool valid = false;
            while (!valid)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "n")
                {
                    valid = true;
                    value = (input.ToLower() == "y");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("Should the Item be {0} (y/n)", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }
    }
}
