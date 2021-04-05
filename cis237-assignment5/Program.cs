﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Set Console Window Size
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WindowHeight = 40;
            Console.WindowWidth = 120;

            // Set a constant for the size of the collection
            //const int beverageCollectionSize = 4000;

            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            // Create an instance of the BeverageRepository class
            BeverageRepository beverageRepository = new BeverageRepository();

            // Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            // Display the Menu and get the response. Store the response in the choice integer
            // This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            // While the choice is not exit program
            while (choice != 7)
            {
                switch (choice)
                {
                    case 1:
                    // Load the CSV File
                    //bool success = csvProcessor.ImportCSV(beverageCollection, pathToCSVFile);
                    //if (success)
                    //{
                    //    // Display Success Message
                    //    userInterface.DisplayImportSuccess();
                    //}
                    //else
                    //{
                    //    // Display Fail Message
                    //    userInterface.DisplayImportError();
                    //}
                    //break;

                    case 2:
                        // Print Entire List Of Items
                        userInterface.DisplayAllItems();
                        break;

                    //case 2:
                    //    // Print Entire List Of Items
                    //    string allItemsString = beverageRepository.ToString();
                    //    if (!String.IsNullOrWhiteSpace(allItemsString))
                    //    {
                    //        // Display all of the items
                    //        userInterface.DisplayAllItems(allItemsString);
                    //        //beverageRepository.PrintList();
                    //    }
                    //    else
                    //    {
                    //        // Display error message for all items
                    //        userInterface.DisplayAllItemsError();
                    //    }
                    //    break;

                    case 3:
                        // Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = beverageRepository.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 4:
                        // Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (beverageRepository.FindById(newItemInformation[0]) == null)
                        {
                            beverageRepository.AddNewItem(
                                newItemInformation[0],
                                newItemInformation[1],
                                newItemInformation[2],
                                decimal.Parse(newItemInformation[3]),
                                (newItemInformation[4] == "True")
                            );
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 5:
                        // Update an item from the list
                        string[] updateItemInformation = userInterface.GetNewItemInformation();
                        if (beverageRepository.FindById(updateItemInformation[0]) != null)
                        {
                            beverageRepository.UpdateItem(
                                updateItemInformation[0],
                                updateItemInformation[1],
                                updateItemInformation[2],
                                decimal.Parse(updateItemInformation[3]),
                                (updateItemInformation[4] == "True")
                            );
                            userInterface.DisplayUpdateItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 6:
                        // Delete an item from the list
                        userInterface.DisplayDeleteItem();
                        string input = Console.ReadLine();
                        if (beverageRepository.FindById(input) != null)
                        {
                            beverageRepository.DeleteItem(input);
                            userInterface.DisplayDeleteItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;
                }

                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }
        }
    }
}
