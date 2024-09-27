namespace ContactManagerApplication
{
    internal class Program
    {
        public enum EditOptions
        {
            FirstName = 1,
            LastName,
            Gender,
            City,
            Phone,
            Email,
            Address,
            Exit = 0
        }

        static Contact contactList = new Contact();
        static void Main(string[] args)
        {
            int input;
            Console.WriteLine("WELCOME <3 ");
            do
            {
                Console.WriteLine("Enter Number : ");
                Console.WriteLine("1. Add Contact " +
                    "2. Edit Contact " +
                    "3. Delete Contact " +
                    "4. Search for Contact " +
                    "5. Show All Users " +
                    "6.  Save Contacts To File" +
                    "7. Load Contacts From File" +
                    "0. Exit");
                if (int.TryParse(Console.ReadLine(), out input))
                {



                    switch (input)
                    {
                        case 1:
                            AddUser2();
                            break;
                        case 2:
                            EditUser2();
                            break;
                        case 3:
                            DeleteUser2();
                            break;
                        case 4:
                            SearchUser2();
                            break;
                        case 5:
                            ShowAllUsers2();
                            break;
                        case 6:
                            SaveContactsToFile();
                            break;
                        case 7:
                            LoadContactsFromFile();
                            break;
                        case 0:
                            Console.WriteLine("EXIT");
                            break;
                        default:
                            Console.WriteLine("NOT VALID");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("INVALID INPUT. PLEASE ENTER A NUMBER.");
                }
            }
            while (input != 0);


            static void AddUser2()
            {
                int id;
                while (true)
                {
                    Console.WriteLine("Enter User ID: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                        break;  
                    Console.WriteLine("Invalid ID. Please enter a valid integer.");
                }

                string firstName = GetNonEmptyInput("Enter First Name: ");
                string lastName = GetNonEmptyInput("Enter Last Name: ");
                string gender = GetNonEmptyInput("Enter Gender: ");
                string city = GetNonEmptyInput("Enter City: ");
                string addedDate = GetNonEmptyInput("Enter Added Date (YYYY-MM-DD): ");

                User user = new User(id, firstName, lastName, gender, city, addedDate);

                string phone = GetNonEmptyInput("Enter Phone Number: ");
                user.AddContact("phone", phone);

                string email = GetNonEmptyInput("Enter Email: ");
                user.AddContact("email", email);

                string address = GetNonEmptyInput("Enter Address: ");
                user.AddContact("address", address);

                contactList.AddUser(user);
                Console.WriteLine("User added successfully.");
            }

            static string GetNonEmptyInput(string prompt)
            {
                string? input;
                do
                {
                    Console.Write(prompt);
                    input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("This field cannot be empty. Please enter a value.");
                    }
                } while (string.IsNullOrWhiteSpace(input));

                return input;
            }


            static void EditUser2()
            {
                Console.WriteLine("Enter the First Name and Last Name of the user you want to edit: ");
                string? FN = Console.ReadLine();
                string? LN = Console.ReadLine();

                User? UserToEdit = contactList.SearchUser(FN, LN);

                if (UserToEdit != null)
                {

                    Console.WriteLine("What do you want to edit?");
                    foreach (var option in Enum.GetValues(typeof(EditOptions)))
                    
                    {
                        Console.WriteLine($"{(int)option}. {option}");
                         
                    }


                    int userInput;
                    if (int.TryParse(Console.ReadLine(), out userInput) && Enum.IsDefined(typeof(EditOptions), userInput))
                   
                    {
                        EditOptions selectedOption = (EditOptions)userInput;

                        switch (selectedOption)
                        {
                            case EditOptions.FirstName:
                                Console.WriteLine("Enter new First Name: ");
                                string newFirstName = Console.ReadLine() ?? "You didn't enter any new Information";
                                UserToEdit.EditInfo("firstName", newFirstName);
                                break;

                            case EditOptions.LastName:
                                Console.WriteLine("Enter new Last Name: ");
                                string newLastName = Console.ReadLine() ?? "You didn't enter any new Information";
                                UserToEdit.EditInfo("lastName", newLastName);
                                break;

                            case EditOptions.Gender:
                                Console.WriteLine("Enter new Gender: ");
                                string newGender = Console.ReadLine() ?? "You didn't enter any new Information";
                                UserToEdit.EditInfo("gender", newGender);
                                break;

                            case EditOptions.City:
                                Console.WriteLine("Enter new City: ");
                                string newCity = Console.ReadLine() ?? "You didn't enter any new Information";
                                UserToEdit.EditInfo("city", newCity);
                                break;

                            case EditOptions.Phone:
                                Console.WriteLine("Enter the old Phone number to edit: ");
                                string oldPhone = Console.ReadLine() ?? "Where's the Old Information";
                                Console.WriteLine("Enter the new Phone number: ");
                                string newPhone = Console.ReadLine() ?? "You didn't enter any new Information";
                                UserToEdit.EditCon("phone", oldPhone, newPhone);
                                break;

                            case EditOptions.Email:
                                Console.WriteLine("Enter the old Email to edit: ");
                                string oldEmail = Console.ReadLine() ?? "Where's the Old Information";
                                Console.WriteLine("Enter the new Email: ");
                                string newEmail = Console.ReadLine() ?? "You didn't enter any new Information";
                                UserToEdit.EditCon("email", oldEmail, newEmail);
                                break;

                            case EditOptions.Address:
                                Console.WriteLine("Enter the old Address to edit: ");
                                string oldAddress = Console.ReadLine() ?? "Where's the Old Information";
                                Console.WriteLine("Enter the new Address: ");
                                string newAddress = Console.ReadLine() ?? "You didn't enter any new Information";
                                UserToEdit.EditCon("address", oldAddress, newAddress);
                                break;

                            case EditOptions.Exit:
                                Console.WriteLine("Exiting...");
                                break;

                            default:
                                Console.WriteLine("Invalid option.");
                                break;
                        }

                        Console.WriteLine("User information updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            static void DeleteUser2()
            {
                Console.WriteLine("Enter Id of User You Want Delete ");
                int IdInput;
                bool boolT = int.TryParse(Console.ReadLine(), out IdInput);
                if (boolT)
                {
                    contactList.DeleteUser(IdInput);
                    Console.WriteLine("User Has been Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("The ID You Are Added Is Not Valid");
                }
            }

            static void SearchUser2()
            {
                Console.WriteLine("Enter First Name Of User");
                string? InputFN = Console.ReadLine();
                Console.WriteLine("Enter Last Name Of User");
                string? InputLN = Console.ReadLine();
                if (string.IsNullOrEmpty(InputFN) || string.IsNullOrEmpty(InputLN))
                {
                    Console.WriteLine("CAN'T BE SKIPPED");
                }
                else if (InputLN != null && InputFN != null)
                {
                    contactList.SearchUser(InputFN, InputLN);
                }

            }

            static void ShowAllUsers2()
            {
                contactList.ShowAll();
            }


            static void SaveContactsToFile()
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter("contacts.txt"))
                    {
                        foreach (User contact in contactList.users)
                        {
                            writer.WriteLine($"{contact.Id},{contact.FirstName},{contact.LastName},{contact.City},{contact.Gender},{contact.AddedDate}");
                           
                        }




                        foreach (User contact in contactList.users)  
                        {
                            
                            string phoneNumbers = string.Join(";", contact.phone);  
                            string emailAddresses = string.Join(";", contact.email);  

                            
                            writer.WriteLine($"{contact.Id},{contact.FirstName},{contact.LastName},{phoneNumbers},{emailAddresses}");
                        }
                    }
                    Console.WriteLine("Contacts saved successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while saving contacts: " + ex.Message);
                }
            }




            static void LoadContactsFromFile()
            {
                try
                {
                    using (StreamReader reader = new StreamReader("contacts.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line != null) 
                            {
                                string[] parts = line.Split(',');

                                
                                if (parts.Length >= 8) 
                                {
                                    User contact = new User(
                                        id: int.Parse(parts[0]),
                                        firstName: parts[1],
                                        lastName: parts[2],
                                        gender: parts[3],
                                        city: parts[4],
                                        addedDate: parts[5]
                                    );

                                    
                                    contact.phone.Add(parts[6]); 
                                    contact.email.Add(parts[7]);   

                                
                                    contactList.users.Add(contact);
                                }
                            }
                        }
                    }
                    Console.WriteLine("Contacts loaded successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while loading contacts: " + ex.Message);
                }
            }

        }
    }
}

