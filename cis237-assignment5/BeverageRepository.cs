using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace cis237_assignment5
{
    class BeverageRepository
    {
        // Private Variables
        //private Beverage[] beverages;
        //private int beverageLength;

        // Constructor. Must pass the size of the collection.
        //public BeverageRepository(int size)
        //{
        //    this.beverages = new Beverage[size];
        //    this.beverageLength = 0;
        //}


        // New instance of the BeverageContext
        BeverageContext _beverageContext = new BeverageContext();

        // Add a new item to the collection
        public void AddNewItem(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
        )
        {
            // New instance of beverage
            Beverage newBeverageToAdd = new Beverage();

            // Assign properties to the parts of the beverage
            newBeverageToAdd.id = id;
            newBeverageToAdd.name = name;
            newBeverageToAdd.pack = pack;
            newBeverageToAdd.price = price;
            newBeverageToAdd.active = active;

            // Try catch to make sure id of beverage doesn't already exist
            try
            {
                // Add new beverage to the collection
                _beverageContext.Beverages.Add(newBeverageToAdd);

                // Save changes to database
                _beverageContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                // Remove the new beverage from the Database since we can't save it.
                _beverageContext.Beverages.Remove(newBeverageToAdd);
                // Write to Console that there was an error.
                Console.WriteLine("Can't add the record. Already have one with the same ID.");
            }
            catch (Exception e)
            {
                // Remove the new beverage from the Database since we can't save it.
                _beverageContext.Beverages.Remove(newBeverageToAdd);
                // Write to Console that there was an error.
                Console.WriteLine("Can't add the record. Unknown error occured");
            }
        }

        // Method to update a beverage in the list
        public void UpdateItem(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
            )
        {
            // New instance of beverage
            Beverage beverageToUpdate = _beverageContext.Beverages.Find(id);

            // Assign properties to the parts of the beverage
            beverageToUpdate.name = name;
            beverageToUpdate.pack = pack;
            beverageToUpdate.price = price;
            beverageToUpdate.active = active;

            // Save the changes to database
            _beverageContext.SaveChanges();
        }

        // Method to delete a beverage from the list
        public void DeleteItem(string id)
        {
            // Get a beverage out of the database that we want to delete
            Beverage beverageToDelete = _beverageContext.Beverages.Find(id);

            // Remove the beverage from the database
            _beverageContext.Beverages.Remove(beverageToDelete);

            // Save the changes to the database
            _beverageContext.SaveChanges();
        }

        // ToString override method to convert the collection to a string
        //public override string ToString()
        //{
        //    // Declare a return string
        //    string returnString = "";

        //    // Loop through all of the beverages
        //    foreach (Beverage beverage in _beverageContext.Beverages)
        //    {
        //        // If the current beverage is not null, concat it to the return string
        //        if (beverage != null)
        //        {
        //            returnString += beverage.ToString() + Environment.NewLine;
        //        }
        //    }
        //    // Return the return string
        //    return returnString;
        //}

        // Find an item by it's Id
        public string FindById(string id)
        {
            // Declare return string for the possible found item
            string returnString = null;

            // For each Beverage in beverages
            foreach (Beverage beverage in _beverageContext.Beverages)
            {
                // If the beverage is not null
                if (beverage != null)
                {
                    // If the beverage Id is the same as the search Id
                    if (beverage.id == id)
                    {
                        // Set the return string to the result
                        // of the beverage's ToString method.
                        returnString = BeverageToString(beverage);
                    }
                }
            }
            // Return the returnString
            return returnString;
        }

        // Method used to get and format the beverages from the database
        public string BeverageToString(Beverage beverage)
        {
            return $"{beverage.id}".TrimEnd() + " " + $"{beverage.name}".TrimEnd() + " " + $"{beverage.pack}".TrimEnd() + " " + $"{beverage.price}" + " " + $"{beverage.active}";
        }

        // Method to print the list
        public void PrintList()
        {
            // Print every beverage from the database
            foreach(Beverage beverage in _beverageContext.Beverages)
            {
                Console.WriteLine(BeverageToString(beverage));
            }
        }
    }
}
