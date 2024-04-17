using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketing_application
{
    class Program
    {
        static void Main(string[] args)
        {
            Random _random = new Random();
            DateTime _dateTime = DateTime.Now;
            string username = "", password = "",
                // these variables are used in the input passenger record 
                fullName = "", address = "",
                // this will hold all the tranction data before it will be confirm and store to -> transactions array
                transactionData = "",
                // this will hold all the date of travel data before it will be confirm and store to -> transactions array
                dateOfTravel = "",
                // this used to store the generated ticket number for the user
                ticketNumber = "",
                // this is used to store the inputed the date of travel by the user
                enterDateOfTravel= "";
            double totalPayment = 0.0, payment = 0.0, change= 0.0;
            bool terminateApplication = false,
                // this is used to flag if user has already entered ticketing information
                hasTicketingInformation = false,
                hasNotSavedTicketingInformation = false,
                // this is used to flag if user has already sucessfully entered passenger record
                hasPassengerRecord = false;
            int retryChoice, optionChoice, 
                /**
                 * these choices variable are used during the ticketing transaction feature,
                 * it stores the selected options made by the user
                 * */
                destinationChoice = 0, travelTimeChoice = 0, accomodationChoice = 0, deckNumberChoice = 0,
                // this variable is used in the input passenger record
                age = 0, typeOfPassengerChoice = 0, genderChoice = 0,
                // these are used for the windor form settings
                width=90, height = 20, column = 13, row = 5, headerHeight = 2 , defaultColumn = 13, defaultRow = 5;
            // these are used for the color setings of the windows form
            ConsoleColor foreGroundColor = ConsoleColor.Magenta, backGroundColor = ConsoleColor.Gray, headerColor = foreGroundColor, errorHeaderColor= ConsoleColor.DarkRed, warningHeaderColor = ConsoleColor.DarkYellow;
            /*
             * arrays & variables are used in the ticketing transaction feature of the applications
             * these are displayed using for loops during the showcasing of user choices per transactions
             */
            string[] destinations = new string[]
            {
                "Hilongos - Cebu",
                "Cebu - Hilongos",
                "Cebu - Ormoc",
                "Ormoc - Cebu",
            };
            string[] travelTimes = new string[]
            {
                "Day Trip",
                "Night Trip"
            };
            string[] accomodations = new string[]
            {
                "Tourist",
                "Economy A",
                "Economy B"
            };
            double[] accomodationPrice = new double[]
            {
                800.00,
                480.00,
                400.00
            };
            int deckNumberSize = 20;
            int[] deckNumbers = new int[deckNumberSize];
            for (int i = 0; i < deckNumberSize; i++)
            {
                deckNumbers[i] = (i + 1);
            }
            /*
             * these are used in the view / input passenger information of the application
             */
            string[] typeOfPassengers = new string[]
            {
                "Senior Citizen",
                "DSWD",
                "Minor",
                "Regular"
            };
            double[] typeOfPassengerDiscounts = new double[]
            {
                0.30,
                0.20,
                0.10,
                0.00
            };
            string[] genders = new string[]
            {
                "Male",
                "Female"
            };

         // used for storing of transaction
            /*
             * string[,] transctions is array to store all transaction data
             * transactionData = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", fullName, destinations[destinationChoice - 1], travelTimes[travelTimeChoice - 1], dateOfTravel, accomodations[accomodationChoice - 1], deckNumberChoice);
             * [0] - ticket Number
             * [1] - full Name
             * [2] - destinations
             * [3] - travel time
             * [4] - date of travel
             * [5] - accomodations
             * [6] - deck number
             */
            int transactionSize = 1, transactionColumnSize = 7;
            string[,] transactions = new string[transactionSize, transactionColumnSize];
            // these are used to easily loop through the data
            int ticketNumberSize = 0;
            string[] ticketNumbers = new string[ticketNumberSize];
            int dateOfTravelsSize = 0;
            string[] dateOfTravels = new string[dateOfTravelsSize];
        // END
           // start of the application process
           do {
                try
                {
                // start of the application
                startOfApplication:
                    #region start of Application
                    Console.Clear();
                    //creating the window form
                    for (int i = 0; i < height; i++)
                    {
                        Console.SetCursorPosition(column, (row)++);
                        for (int x = 0; x < width; x++)
                        {
                            if (i <= headerHeight)
                            {
                                // creating the header design
                                Console.BackgroundColor = headerColor;
                                Console.Write(" ");
                            }
                            else {
                                Console.BackgroundColor = backGroundColor;
                                Console.Write(" ");
                            }
                           
                        }
                        Console.WriteLine();
                    }
                    column = defaultColumn; row = defaultRow;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = headerColor;
                    Console.SetCursorPosition((column) + 2, (row) + 1);
                    Console.WriteLine("Welcome");

                    Console.ForegroundColor = foreGroundColor;
                    Console.BackgroundColor = backGroundColor;
                    Console.SetCursorPosition((column) + 2, (row) + 4);
                    Console.WriteLine("[1] Login");
                    Console.SetCursorPosition((column) + 2, (row) + 5);
                    Console.WriteLine("[2] Register");
                    Console.SetCursorPosition((column) + 2, (row) + 6);
                    Console.Write("Enter choice: ");
                    optionChoice = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    #endregion
                    switch (optionChoice)
                    {
                       #region login
                        case 1:
                            if (username.Length <= 0 && password.Length <= 0)
                            {
                                Console.ForegroundColor = foreGroundColor;
                                Console.BackgroundColor = backGroundColor;
                                Console.SetCursorPosition((column) + 2, (row) + 8);
                                Console.WriteLine("No user authentication entered");
                                Console.SetCursorPosition((column) + 2, (row) + 9);
                                Console.Write("Return to Home Page? (Y/N): ");
                                retryChoice = Console.ReadLine()[0];
                                Console.ResetColor();
                                if (retryChoice == 'Y' || retryChoice == 'y')
                                {
                                    goto startOfApplication;
                                }
                                else
                                {
                                    terminateApplication = true;
                                }
                            }
                            else
                            {
                            // user access authentication process
                            userLogin:
                                Console.Clear();
                                //creating the window form
                                for (int i = 0; i < height; i++)
                                {
                                    Console.SetCursorPosition(column, (row)++);
                                    for (int x = 0; x < width; x++)
                                    {
                                        if (i <= headerHeight)
                                        {
                                            // creating the header design
                                            Console.BackgroundColor = headerColor;
                                            Console.Write(" ");
                                        }
                                        else
                                        {
                                            Console.BackgroundColor = backGroundColor;
                                            Console.Write(" ");
                                        }

                                    }
                                    Console.WriteLine();
                                }
                                column = defaultColumn; row = defaultRow;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = headerColor;
                                Console.SetCursorPosition((column) + 2, (row) + 1);
                                Console.WriteLine("Login Page");

                                Console.ForegroundColor = foreGroundColor;
                                Console.BackgroundColor = backGroundColor;
                                Console.SetCursorPosition((column) + 2, (row) + 4);
                                Console.Write("Enter username: ");
                                string loginUsername = Console.ReadLine();
                                Console.SetCursorPosition((column) + 2, (row) + 5);
                                Console.Write("Enter password: ");
                                string loginPassword = Console.ReadLine();
                                Console.ResetColor();
                                if (loginUsername != username || loginPassword != password)
                                {

                                    Console.ForegroundColor = foreGroundColor;
                                    Console.BackgroundColor = backGroundColor;
                                    Console.SetCursorPosition((column) + 2, (row) + 7);
                                    Console.WriteLine("Invalid username or password");
                                    Console.SetCursorPosition((column) + 2, (row) + 8);
                                    Console.Write("Return to login Page? (Y/N): ");
                                    retryChoice = Console.ReadLine()[0];
                                    Console.ResetColor();
                                    if (retryChoice == 'Y' || retryChoice == 'y')
                                    {
                                        goto userLogin;
                                    }
                                    else
                                    {
                                        terminateApplication = true;
                                    }
                                }
                                else
                                {
                                // select transaction option
                                transactionOptions:
                                    Console.Clear();
                                    //creating the window form
                                    for (int i = 0; i < height; i++)
                                    {
                                        Console.SetCursorPosition(column, (row)++);
                                        for (int x = 0; x < width; x++)
                                        {
                                            if (i <= headerHeight)
                                            {
                                                // creating the header design
                                                Console.BackgroundColor = headerColor;
                                                Console.Write(" ");
                                            }
                                            else
                                            {
                                                Console.BackgroundColor = backGroundColor;
                                                Console.Write(" ");
                                            }

                                        }
                                        Console.WriteLine();
                                    }
                                    column = defaultColumn; row = defaultRow;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = headerColor;
                                    Console.SetCursorPosition((column) + 2, (row) + 1);
                                    Console.WriteLine("Transaction Options");

                                    Console.ForegroundColor = foreGroundColor;
                                    Console.BackgroundColor = backGroundColor;
                                    Console.SetCursorPosition((column) + 2, (row) + 4);
                                    Console.WriteLine("[1] Ticketing Transactions");
                                    Console.SetCursorPosition((column) + 2, (row) + 5);
                                    Console.WriteLine("[2] View / Input Passengers Record");
                                    Console.SetCursorPosition((column) + 2, (row) + 6);
                                    Console.WriteLine("[3] View / Search Trip Information");
                                    Console.SetCursorPosition((column) + 2, (row) + 7);
                                    Console.WriteLine("[4] View a Search Trip Info");
                                    Console.SetCursorPosition((column) + 2, (row) + 8);
                                    Console.WriteLine("[5] Return to Start of Application");
                                    
                                    Console.SetCursorPosition((column) + 2, (row) + 10);
                                    Console.Write("Enter choice: ");
                                    optionChoice = int.Parse(Console.ReadLine());
                                    Console.ResetColor();
                                    switch (optionChoice)
                                    {
                                        case 1:
                                            if (hasNotSavedTicketingInformation == true) 
                                            {
                                                Console.SetCursorPosition((column) + 2, (row) + 10);
                                                Console.WriteLine("\nThis action will overwrite the previously entered selction");
                                                Console.SetCursorPosition((column) + 2, (row) + 11);
                                                Console.Write("Would you like to proceed? (Y/N): ");
                                                retryChoice = Console.ReadLine()[0];
                                                Console.ResetColor();
                                                if (retryChoice == 'N' || retryChoice == 'n')
                                                {
                                                    goto transactionOptions;
                                                }
                                            }
                                            // select a distination
                                            Console.Clear();
                                            //creating the window form
                                            #region Create Window Form
                                            for (int i = 0; i < height; i++)
                                            {
                                                Console.SetCursorPosition(column, (row)++);
                                                for (int x = 0; x < width; x++)
                                                {
                                                    if (i <= headerHeight)
                                                    {
                                                        // creating the header design
                                                        Console.BackgroundColor = headerColor;
                                                        Console.Write(" ");
                                                    }
                                                    else
                                                    {
                                                        Console.BackgroundColor = backGroundColor;
                                                        Console.Write(" ");
                                                    }

                                                }
                                                Console.WriteLine();
                                            }
                                            column = defaultColumn; row = defaultRow;
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.BackgroundColor = headerColor;
                                            Console.SetCursorPosition((column) + 2, (row) + 1);
                                            Console.WriteLine("TICKETING TRANSACTIONS");
                                            Console.ForegroundColor = foreGroundColor;
                                            Console.BackgroundColor = backGroundColor;
                                            #endregion
                                            column += 2; row += 4;
                                            for (int i = 0; i < destinations.Length; i++)
                                            {
                                                // Display the destination available
                                                Console.SetCursorPosition(column, row ++);
                                                Console.WriteLine("[{0}] - {1}", (i + 1), destinations[i]);
                                            }
                                            Console.SetCursorPosition(column, row + 1);
                                            Console.Write("Enter choice: ");
                                            destinationChoice = int.Parse(Console.ReadLine());
                                            Console.ResetColor();
                                            // select a travel time
                                    selectTravelTime:
                                            Console.Clear();
                                            #region Create Window Form
                                            column = defaultColumn; row = defaultRow;
                                            for (int i = 0; i < height; i++)
                                            {
                                                Console.SetCursorPosition(column, (row)++);
                                                for (int x = 0; x < width; x++)
                                                {
                                                    if (i <= headerHeight)
                                                    {
                                                        // creating the header design
                                                        Console.BackgroundColor = headerColor;
                                                        Console.Write(" ");
                                                    }
                                                    else
                                                    {
                                                        Console.BackgroundColor = backGroundColor;
                                                        Console.Write(" ");
                                                    }

                                                }
                                                Console.WriteLine();
                                            }
                                            column = defaultColumn; row = defaultRow;
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.BackgroundColor = headerColor;
                                            Console.SetCursorPosition((column) + 2, (row) + 1);
                                            Console.WriteLine("Select Travel Time");
                                            Console.ForegroundColor = foreGroundColor;
                                            Console.BackgroundColor = backGroundColor;
                                            column += 2; row += 4;
                                            #endregion
                                            for (int i = 0; i < travelTimes.Length; i++)
                                            {
                                                // Display the travel time available
                                                Console.SetCursorPosition(column, row++);
                                                Console.WriteLine("[{0}] - {1}", (i + 1), travelTimes[i]);
                                            }
                                            Console.SetCursorPosition(column, row++);
                                            Console.Write("Enter choice: ");
                                            travelTimeChoice = int.Parse(Console.ReadLine());
                                            if(travelTimeChoice > travelTimes.Length)
                                            {
                                                Console.SetCursorPosition(column, row+2);
                                                Console.WriteLine("Please select within the choices given!");
                                                Console.ReadKey();
                                                Console.ResetColor();
                                                goto selectTravelTime;
                                            }
                                            Console.ResetColor();
                                    inputDateOfTravel:
                                            // select / input date of travel
                                            Console.Clear();
                                            #region Create Window Form
                                            column = defaultColumn; row = defaultRow;
                                            for (int i = 0; i < height; i++)
                                            {
                                                Console.SetCursorPosition(column, (row)++);
                                                for (int x = 0; x < width; x++)
                                                {
                                                    if (i <= headerHeight)
                                                    {
                                                        // creating the header design
                                                        Console.BackgroundColor = headerColor;
                                                        Console.Write(" ");
                                                    }
                                                    else
                                                    {
                                                        Console.BackgroundColor = backGroundColor;
                                                        Console.Write(" ");
                                                    }

                                                }
                                                Console.WriteLine();
                                            }
                                            column = defaultColumn; row = defaultRow;
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.BackgroundColor = headerColor;
                                            Console.SetCursorPosition((column) + 2, (row) + 1);
                                            Console.WriteLine("Date of Travel");
                                            Console.ForegroundColor = foreGroundColor;
                                            Console.BackgroundColor = backGroundColor;
                                            column += 2; row += 4;
                                            #endregion
                                            Console.SetCursorPosition((column), (row));
                                            Console.WriteLine("Enter date of travel: ({0})", _dateTime.ToString("MM/dd/yyyy"));
                                            Console.SetCursorPosition((column), (row) + 1);
                                            enterDateOfTravel = Console.ReadLine();
                                            // check if input is valid date
                                            DateTime parsedDate;
                                            if ((DateTime.TryParseExact(enterDateOfTravel, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate)))
                                            {
                                                // Get the current date
                                                DateTime currentDate = DateTime.Now.Date;
                                                // Compare the date of travel with the current date
                                                if (parsedDate < currentDate)
                                                {
                                                    Console.SetCursorPosition((column), (row) + 3);
                                                    Console.WriteLine("The date of travel is in the past.");
                                                    Console.ReadKey();
                                                    Console.ResetColor();
                                                    goto inputDateOfTravel;
                                                }
                                            }
                                            else {
                                                Console.SetCursorPosition((column), (row) + 3);
                                                Console.WriteLine("Please enter a valid date!");
                                                Console.ReadKey();
                                                Console.ResetColor();
                                                goto inputDateOfTravel;
                                            }
                                            Console.ResetColor();
                                            // select accomodation
                                    selectAccomodations:
                                            Console.Clear();
                                            #region Create Window Form
                                            column = defaultColumn; row = defaultRow;
                                            for (int i = 0; i < height; i++)
                                            {
                                                Console.SetCursorPosition(column, (row)++);
                                                for (int x = 0; x < width; x++)
                                                {
                                                    if (i <= headerHeight)
                                                    {
                                                        // creating the header design
                                                        Console.BackgroundColor = headerColor;
                                                        Console.Write(" ");
                                                    }
                                                    else
                                                    {
                                                        Console.BackgroundColor = backGroundColor;
                                                        Console.Write(" ");
                                                    }

                                                }
                                                Console.WriteLine();
                                            }
                                            column = defaultColumn; row = defaultRow;
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.BackgroundColor = headerColor;
                                            Console.SetCursorPosition((column) + 2, (row) + 1);
                                            Console.WriteLine("Select Accomodations");
                                            Console.ForegroundColor = foreGroundColor;
                                            Console.BackgroundColor = backGroundColor;
                                            column += 2; row += 3;
                                            #endregion
                                            for (int i = 0; i < accomodations.Length; i++)
                                            {
                                                // Display the accomodations available
                                                Console.SetCursorPosition((column), (row) += 1);
                                                Console.WriteLine("[{0}] - {1} - Price: P{2}", (i + 1), accomodations[i], accomodationPrice[i]);
                                            }
                                            Console.SetCursorPosition((column), (row) += 2);
                                            Console.Write("Enter choice: ");
                                            accomodationChoice = int.Parse(Console.ReadLine());
                                            if (accomodationChoice > accomodations.Length)
                                            {
                                                Console.WriteLine("Please select within the choices given!");
                                                Console.ReadKey();
                                                goto selectAccomodations;
                                            }
                                            Console.ResetColor();
                                            // select deck number
                                    selectDeckNumber:
                                            Console.Clear();
                                            #region Create Window Form
                                            column = defaultColumn; row = defaultRow; 
                                            for (int i = 0; i < height; i++)
                                            {
                                                Console.SetCursorPosition(column, (row)++);
                                                for (int x = 0; x < width; x++)
                                                {
                                                    if (i <= headerHeight)
                                                    {
                                                        // creating the header design
                                                        Console.BackgroundColor = headerColor;
                                                        Console.Write(" ");
                                                    }
                                                    else
                                                    {
                                                        Console.BackgroundColor = backGroundColor;
                                                        Console.Write(" ");
                                                    }

                                                }
                                                Console.WriteLine();
                                            }
                                            column = defaultColumn; row = defaultRow;
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.BackgroundColor = headerColor;
                                            Console.SetCursorPosition((column) + 2, (row) + 1);
                                            Console.WriteLine("Select Deck Number");
                                            Console.ForegroundColor = foreGroundColor;
                                            Console.BackgroundColor = backGroundColor;
                                            column += 2; row += 4;
                                            #endregion
                                            Console.SetCursorPosition((column), (row));
                                            for (int y = 1; y <= 5; y++)
                                            {
                                                Console.SetCursorPosition((column), (row)++);
                                                for (int x = 0; x < 4; x++)
                                                {
                                                    int number = x * 5 + y; // Generate the number based on row and column
                                                    Console.Write("#{0}\t", deckNumbers[number - 1]);
                                                }
                                                Console.WriteLine(); // Move to the next row after printing each row
                                            }
                                            Console.SetCursorPosition((column), (row) + 2);
                                            Console.Write("Enter the deck number of your choice: ");
                                            deckNumberChoice = int.Parse(Console.ReadLine());
                                            if (deckNumberChoice > 20) {
                                                Console.SetCursorPosition((column), (row) + 2);
                                                Console.WriteLine("Please select within the deck numbers given!");
                                                Console.ReadKey();
                                                Console.ResetColor();
                                                goto selectDeckNumber;
                                            }
                                            Console.ResetColor();
                                            // display the current transaction infomation
                                            Console.Clear();
                                            #region Create Window Form
                                            column = defaultColumn; row = defaultRow; 
                                            for (int i = 0; i < height; i++)
                                            {
                                                Console.SetCursorPosition(column, (row)++);
                                                for (int x = 0; x < width; x++)
                                                {
                                                    if (i <= headerHeight)
                                                    {
                                                        // creating the header design
                                                        Console.BackgroundColor = headerColor;
                                                        Console.Write(" ");
                                                    }
                                                    else
                                                    {
                                                        Console.BackgroundColor = backGroundColor;
                                                        Console.Write(" ");
                                                    }

                                                }
                                                Console.WriteLine();
                                            }
                                            column = defaultColumn; row = defaultRow;
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.BackgroundColor = headerColor;
                                            Console.SetCursorPosition((column) + 2, (row) + 1);
                                            Console.WriteLine("Confirm Transaction Information");
                                            Console.ForegroundColor = foreGroundColor;
                                            Console.BackgroundColor = backGroundColor;
                                            column += 2; row += 3;
                                            #endregion
                                            Console.SetCursorPosition((column), row + 1);
                                            Console.WriteLine("Your transaction information are as follows");
                                            Console.SetCursorPosition((column), row + 2);
                                            Console.WriteLine("Destination: {0}", destinations[destinationChoice -1]);
                                            Console.SetCursorPosition((column), row + 3);
                                            Console.WriteLine("Travel Time: {0}", travelTimes[travelTimeChoice -1]);
                                            Console.SetCursorPosition((column), row + 4);
                                            Console.WriteLine("Accomodation: {0}", accomodations[accomodationChoice - 1]);
                                            Console.SetCursorPosition((column), row + 5);
                                            Console.WriteLine("Date of Travel: {0}", enterDateOfTravel );
                                            Console.SetCursorPosition((column), row + 6);
                                            Console.WriteLine("Deck Number: {0}", deckNumberChoice );
                                            Console.SetCursorPosition((column), row + 8);
                                            Console.Write("Would you like to proceed? (Y/N): ");
                                            retryChoice = Console.ReadLine()[0];
                                            if (retryChoice == 'Y' || retryChoice == 'y')
                                            {
                                                hasTicketingInformation = true;
                                                hasNotSavedTicketingInformation = false;
                                                dateOfTravel = enterDateOfTravel;
                                                column = defaultColumn; row = defaultRow;
                                                Console.ResetColor();
                                                goto transactionOptions;
                                            }
                                            else {
                                                terminateApplication = true;
                                            }
                                            
                                            break;

                                        case 2:
                                        inputPassengersRecord:
                                            Console.Clear();
                                            if (hasTicketingInformation == false)
                                            {
                                                #region Create Window Form
                                                column = defaultColumn; row = defaultRow;
                                                for (int i = 0; i < height; i++)
                                                {
                                                    Console.SetCursorPosition(column, (row)++);
                                                    for (int x = 0; x < width; x++)
                                                    {
                                                        if (i <= headerHeight)
                                                        {
                                                            // creating the header design
                                                            Console.BackgroundColor = warningHeaderColor;
                                                            Console.Write(" ");
                                                        }
                                                        else
                                                        {
                                                            Console.BackgroundColor = backGroundColor;
                                                            Console.Write(" ");
                                                        }

                                                    }
                                                    Console.WriteLine();
                                                }
                                                column = defaultColumn; row = defaultRow;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.BackgroundColor = warningHeaderColor;
                                                Console.SetCursorPosition((column) + 2, (row) + 1);
                                                Console.WriteLine("Warning!");
                                                Console.ForegroundColor = warningHeaderColor;
                                                Console.BackgroundColor = backGroundColor;
                                                column += 2; row += 3;
                                                #endregion
                                                Console.SetCursorPosition((column), row + 1);
                                                Console.WriteLine("You haven't selected any of the ticketing transaction!");
                                                Console.SetCursorPosition((column), row + 2);
                                                Console.Write("Would you like to proceed? (Y/N): ");
                                                retryChoice = Console.ReadLine()[0];
                                                if (retryChoice == 'Y' || retryChoice == 'y')
                                                {
                                                    Console.ResetColor();
                                                    column = defaultColumn; row = defaultRow;
                                                    goto transactionOptions;
                                                }
                                                else
                                                {
                                                    terminateApplication = true;
                                                }
                                            }
                                            else
                                            {
                                                Console.ResetColor();
                                                Console.Clear();
                                                #region Create Window Form
                                                column = defaultColumn; row = defaultRow;
                                                for (int i = 0; i < height; i++)
                                                {
                                                    Console.SetCursorPosition(column, (row)++);
                                                    for (int x = 0; x < width; x++)
                                                    {
                                                        if (i <= headerHeight)
                                                        {
                                                            // creating the header design
                                                            Console.BackgroundColor = headerColor;
                                                            Console.Write(" ");
                                                        }
                                                        else
                                                        {
                                                            Console.BackgroundColor = backGroundColor;
                                                            Console.Write(" ");
                                                        }

                                                    }
                                                    Console.WriteLine();
                                                }
                                                column = defaultColumn; row = defaultRow;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.BackgroundColor = headerColor;
                                                Console.SetCursorPosition((column) + 2, (row) + 1);
                                                Console.WriteLine("Input Passenger's Information");
                                                Console.ForegroundColor = foreGroundColor;
                                                Console.BackgroundColor = backGroundColor;
                                                column += 2; row += 3;
                                                #endregion
                                                Console.SetCursorPosition((column), row + 1);
                                                Console.Write("Enter Fullname: ");
                                                fullName = Console.ReadLine();
                                                Console.SetCursorPosition((column), (row) + 2);
                                                Console.Write("Enter Address: ");
                                                address = Console.ReadLine();
                                                
                                                // select gender
                                            selectGender:
                                                Console.ResetColor();
                                                Console.Clear();
                                                #region Create Window Form
                                                column = defaultColumn; row = defaultRow;
                                                for (int i = 0; i < height; i++)
                                                {
                                                    Console.SetCursorPosition(column, (row)++);
                                                    for (int x = 0; x < width; x++)
                                                    {
                                                        if (i <= headerHeight)
                                                        {
                                                            // creating the header design
                                                            Console.BackgroundColor = headerColor;
                                                            Console.Write(" ");
                                                        }
                                                        else
                                                        {
                                                            Console.BackgroundColor = backGroundColor;
                                                            Console.Write(" ");
                                                        }

                                                    }
                                                    Console.WriteLine();
                                                }
                                                column = defaultColumn; row = defaultRow;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.BackgroundColor = headerColor;
                                                Console.SetCursorPosition((column) + 2, (row) + 1);
                                                Console.WriteLine("Select Gender");
                                                Console.ForegroundColor = foreGroundColor;
                                                Console.BackgroundColor = backGroundColor;
                                                column += 2; row += 4;
                                                #endregion
                                                for (int i = 0; i < genders.Length; i++)
                                                {
                                                    Console.SetCursorPosition((column), (row) ++);
                                                    Console.WriteLine("[{0}] - {1}", (i + 1), genders[i]);
                                                }
                                                Console.SetCursorPosition((column), (row)+1);
                                                Console.Write("Enter Gender: ");
                                                genderChoice = int.Parse(Console.ReadLine());
                                                if (genderChoice > genders.Length)
                                                {
                                                    Console.SetCursorPosition((column), (row) + 2);
                                                    Console.WriteLine("Please select within the deck numbers given!");
                                                    Console.ReadKey();
                                                    Console.ResetColor();
                                                    column = defaultRow; row = defaultRow;
                                                    goto selectGender;
                                                }
                                                //select type of passenger
                                            selectTypeOfPassenger:
                                                Console.ResetColor();
                                                Console.Clear();
                                                #region Create Window Form
                                                column = defaultColumn; row = defaultRow;
                                                for (int i = 0; i < height; i++)
                                                {
                                                    Console.SetCursorPosition(column, (row)++);
                                                    for (int x = 0; x < width; x++)
                                                    {
                                                        if (i <= headerHeight)
                                                        {
                                                            // creating the header design
                                                            Console.BackgroundColor = headerColor;
                                                            Console.Write(" ");
                                                        }
                                                        else
                                                        {
                                                            Console.BackgroundColor = backGroundColor;
                                                            Console.Write(" ");
                                                        }

                                                    }
                                                    Console.WriteLine();
                                                }
                                                column = defaultColumn; row = defaultRow;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.BackgroundColor = headerColor;
                                                Console.SetCursorPosition((column) + 2, (row) + 1);
                                                Console.WriteLine("Select Type Of Passenger");
                                                Console.ForegroundColor = foreGroundColor;
                                                Console.BackgroundColor = backGroundColor;
                                                column += 2; row += 4;
                                                #endregion
                                                for (int i = 0; i < typeOfPassengers.Length; i++) 
                                                {
                                                    Console.SetCursorPosition((column), (row) ++);
                                                    Console.WriteLine("[{0}] - {1} - Discount: {2}%", (i + 1), typeOfPassengers[i], typeOfPassengerDiscounts[i]);
                                                }
                                                Console.SetCursorPosition((column), (row)+ 1);
                                                Console.Write("Enter choice: ");
                                                typeOfPassengerChoice = int.Parse(Console.ReadLine());
                                                if (typeOfPassengerChoice > typeOfPassengers.Length) 
                                                {
                                                    Console.SetCursorPosition((column), (row) + 2);
                                                    Console.WriteLine("Please select within the deck numbers given!");
                                                    Console.ReadKey();
                                                    column = defaultRow; row = defaultRow;
                                                    goto selectTypeOfPassenger;
                                                }

                                                //validate the user's age by comparing it to the selected type of passenger
                                                Console.ResetColor();
                                                Console.Clear();
                                                #region Create Window Form
                                                column = defaultColumn; row = defaultRow;
                                                for (int i = 0; i < height; i++)
                                                {
                                                    Console.SetCursorPosition(column, (row)++);
                                                    for (int x = 0; x < width; x++)
                                                    {
                                                        if (i <= headerHeight)
                                                        {
                                                            // creating the header design
                                                            Console.BackgroundColor = headerColor;
                                                            Console.Write(" ");
                                                        }
                                                        else
                                                        {
                                                            Console.BackgroundColor = backGroundColor;
                                                            Console.Write(" ");
                                                        }

                                                    }
                                                    Console.WriteLine();
                                                }
                                                column = defaultColumn; row = defaultRow;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.BackgroundColor = headerColor;
                                                Console.SetCursorPosition((column) + 2, (row) + 1);
                                                Console.WriteLine("Passenger's Age");
                                                Console.ForegroundColor = foreGroundColor;
                                                Console.BackgroundColor = backGroundColor;
                                                column += 2; row += 4;
                                                #endregion
                                                Console.SetCursorPosition((column), (row));
                                                Console.Write("Enter Age: ");
                                                age = int.Parse(Console.ReadLine());

                                                if (age > 0)
                                                {
                                                    // valdating if user is senior citizen
                                                    if(typeOfPassengerChoice == 1)
                                                    {
                                                        if (age < 60)
                                                        {
                                                            Console.SetCursorPosition((column), (row) + 2);
                                                            Console.WriteLine("You've entered an invalid age");
                                                            Console.SetCursorPosition((column), (row) + 3);
                                                            Console.Write("Would you like to proceed? (Y/N): ");
                                                            retryChoice = Console.ReadLine()[0];
                                                            if (retryChoice == 'Y' || retryChoice == 'y')
                                                            {
                                                                column = defaultRow; row = defaultRow;
                                                                Console.ResetColor();
                                                                goto inputPassengersRecord;
                                                            }
                                                            else
                                                            {
                                                                terminateApplication = true;
                                                            }
                                                        }
                                                    } else if(typeOfPassengerChoice == 3)
                                                    {
                                                        if(age > 18)
                                                        {
                                                            Console.SetCursorPosition((column), (row) + 2);
                                                            Console.WriteLine("You've entered an invalid age");
                                                            Console.SetCursorPosition((column), (row) + 3);
                                                            Console.Write("Would you like to proceed? (Y/N): ");
                                                            retryChoice = Console.ReadLine()[0];
                                                            if (retryChoice == 'Y' || retryChoice == 'y')
                                                            {
                                                                column = defaultRow; row = defaultRow;
                                                                Console.ResetColor();
                                                                goto inputPassengersRecord;
                                                            }
                                                            else
                                                            {
                                                                terminateApplication = true;
                                                            }
                                                        }
                                                    }
                                                }
                                                else {
                                                    Console.SetCursorPosition((column), (row) + 2);
                                                    Console.WriteLine("You've entered an invalid age");
                                                    Console.SetCursorPosition((column), (row) + 3);
                                                    Console.Write("Would you like to proceed? (Y/N): ");
                                                    retryChoice = Console.ReadLine()[0];
                                                    if (retryChoice == 'Y' || retryChoice == 'y')
                                                    {
                                                        column = defaultRow; row = defaultRow;
                                                        Console.ResetColor();
                                                        goto inputPassengersRecord;
                                                    }
                                                    else
                                                    {
                                                        terminateApplication = true;
                                                    }
                                                }


                                                //calculate total amount to be paid
                                            calculateTotalPayment:
                                                Console.ResetColor();
                                                Console.Clear();
                                                #region Create Window Form
                                                column = defaultColumn; row = defaultRow;
                                                for (int i = 0; i < height; i++)
                                                {
                                                    Console.SetCursorPosition(column, (row)++);
                                                    for (int x = 0; x < width; x++)
                                                    {
                                                        if (i <= headerHeight)
                                                        {
                                                            // creating the header design
                                                            Console.BackgroundColor = headerColor;
                                                            Console.Write(" ");
                                                        }
                                                        else
                                                        {
                                                            Console.BackgroundColor = backGroundColor;
                                                            Console.Write(" ");
                                                        }

                                                    }
                                                    Console.WriteLine();
                                                }
                                                column = defaultColumn; row = defaultRow;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.BackgroundColor = headerColor;
                                                Console.SetCursorPosition((column) + 2, (row) + 1);
                                                Console.WriteLine("Payment Transaction");
                                                Console.ForegroundColor = foreGroundColor;
                                                Console.BackgroundColor = backGroundColor;
                                                column += 2; row += 4;
                                                #endregion
                                                Console.SetCursorPosition((column), (row) + 1);
                                                Console.WriteLine("Price: P{0}", accomodationPrice[accomodationChoice - 1]);
                                                double discount = accomodationPrice[accomodationChoice - 1] * typeOfPassengerDiscounts[typeOfPassengerChoice - 1];
                                                Console.SetCursorPosition((column), (row) + 2);
                                                Console.WriteLine("Discount: P{0}", discount);
                                                totalPayment = accomodationPrice[accomodationChoice - 1] - discount;
                                                Console.SetCursorPosition((column), (row) + 3);
                                                Console.WriteLine("Total Payment: P{0}", totalPayment);

                                                Console.SetCursorPosition((column), (row) + 5);
                                                Console.Write("Enter your payment: ");
                                                payment = double.Parse(Console.ReadLine());
                                                if (payment >= totalPayment)
                                                {
                                                    change = payment - totalPayment;
                                                }
                                                else
                                                {
                                                    Console.SetCursorPosition((column), (row) + 7);
                                                    Console.WriteLine("You've entered an invalid payment");
                                                    Console.SetCursorPosition((column), (row) + 8);
                                                    Console.Write("Would you like to enter payment? (Y/N): ");
                                                    retryChoice = Console.ReadLine()[0];
                                                    if (retryChoice == 'Y' || retryChoice == 'y')
                                                    {
                                                        column = defaultColumn; row = defaultRow;
                                                        Console.ResetColor();
                                                        goto calculateTotalPayment;
                                                    }
                                                    else
                                                    {
                                                        terminateApplication = true;
                                                    }
                                                }

                                                // Confirm payment and transaction
                                                Console.SetCursorPosition((column), (row) + 9);
                                                Console.WriteLine("Total Payment (Discount included if applicable): P{0}", totalPayment);
                                                Console.SetCursorPosition((column), (row) + 10);
                                                Console.WriteLine("Your Payment: P{0}", payment);
                                                Console.SetCursorPosition((column), (row) + 11);
                                                Console.WriteLine("Change: P{0}", change);
                                                Console.SetCursorPosition((column), (row) + 12);
                                                Console.Write("\nConfirm Transaction? (Y/N): ");
                                                retryChoice = Console.ReadLine()[0];
                                                if(retryChoice == 'Y' || retryChoice == 'y')
                                                {
                                                    transactionData = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", fullName, destinations[destinationChoice - 1], travelTimes[travelTimeChoice - 1], dateOfTravel, accomodations[accomodationChoice - 1], deckNumberChoice);
                                                    // validate if transaction is duplicated
                                                    if (transactionSize > 0)
                                                    {

                                                        foreach (string item in transactions)
                                                        {
                                                            if (item == transactionData)
                                                            {
                                                                Console.SetCursorPosition((column), (row) + 14);
                                                                Console.WriteLine("Duplicate Transaction Entery Error");
                                                                Console.SetCursorPosition((column), (row) + 15);
                                                                Console.WriteLine("We will have to ask you re-enter all your trasaction information");
                                                                Console.SetCursorPosition((column), (row) + 16);
                                                                Console.WriteLine("Re-enter Transaction? (Y/N)");
                                                                retryChoice = Console.ReadLine()[0];
                                                                if (retryChoice == 'Y' || retryChoice == 'y')
                                                                {
                                                                    goto transactionOptions;
                                                                }
                                                                else
                                                                {
                                                                    terminateApplication = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    // generate ticket number
                                                    ticketNumber = _random.Next(1000000, 9999999).ToString();

                                                    // this will store the transaction data on the transaction array
                                                    transactions[transactionSize - 1, 0] = ticketNumber;
                                                    transactions[transactionSize - 1, 1] = fullName;
                                                    transactions[transactionSize - 1, 2] = destinations[destinationChoice - 1];
                                                    transactions[transactionSize - 1, 3] = travelTimes[travelTimeChoice - 1];
                                                    transactions[transactionSize - 1, 4] = dateOfTravel;
                                                    transactions[transactionSize - 1, 5] = accomodations[accomodationChoice - 1];
                                                    transactions[transactionSize - 1, 6] = deckNumberChoice.ToString();
                                                    transactionSize++;

                                                    // this will store the ticket data on the transaction array
                                                    Array.Resize(ref ticketNumbers, ticketNumberSize + 1);
                                                    ticketNumbers[ticketNumberSize] = ticketNumber; 
                                                    ticketNumberSize++;

                                                    // this will store the date of travel input by the user
                                                    Array.Resize(ref dateOfTravels, dateOfTravelsSize + 1);
                                                    dateOfTravels[dateOfTravelsSize] = dateOfTravel;
                                                    dateOfTravelsSize++;

                                                // Display receipt
                                                displayReceipt:
                                                    Console.ResetColor();
                                                    Console.Clear();
                                                    Console.WriteLine("ROBLE SHIPPING Inc.");
                                                    Console.WriteLine("ES Baclig Avenue T Padilla Ext");
                                                    Console.WriteLine("6000 Cebu City (Capital)");
                                                    Console.WriteLine("Cebu, Philippines");
                                                    Console.WriteLine("================================================================================\n");
                                                    Console.WriteLine("Ticket #: {0}", ticketNumber.ToUpper());
                                                    Console.WriteLine("Name : {0}", fullName.ToUpper());
                                                    Console.WriteLine("Vessel : IMMACULATE STAR");
                                                    Console.WriteLine("Deck # : {0}", deckNumberChoice);
                                                    Console.WriteLine("Route # : {0}", destinations[destinationChoice - 1]);
                                                    Console.WriteLine("Date of Travel # : {0}", dateOfTravel);
                                                    Console.WriteLine("Travel Time # : {0}", travelTimes[travelTimeChoice - 1]);
                                                    Console.WriteLine("Accomodations # : {0}", accomodations[accomodationChoice - 1]);
                                                    Console.WriteLine("Sex / Age: {0}/{1}", genders[genderChoice - 1], age);
                                                    Console.WriteLine("\n================================================================================\n");
                                                    Console.WriteLine("Thank you for Choosing ROBLE SHIPPING Inc.");

                                                    hasPassengerRecord = true;
                                                    hasNotSavedTicketingInformation = false;
                                                    Console.ReadKey();
                                                    goto transactionOptions;
                                                }
                                                else if (retryChoice == 'N' || retryChoice == 'n')
                                                {
                                                    goto transactionOptions;
                                                }
                                                else {
                                                    goto startOfApplication;
                                                }
                                            }

                                            break;
                                        case 3:
                                            // validate if user already has ticketing inforation and passenger information
                                            if (hasTicketingInformation == false || hasPassengerRecord == false)
                                            {
                                                Console.WriteLine("\nYou haven't selected any of the ticketing transaction or Entered any passenger information!");
                                                Console.Write("Would you like to proceed? (Y/N): ");
                                                retryChoice = Console.ReadLine()[0];
                                                if (retryChoice == 'Y' || retryChoice == 'y')
                                                {
                                                    goto transactionOptions;
                                                }
                                                else
                                                {
                                                    terminateApplication = true;
                                                }
                                            }
                                            else {
                                                // view / search trip information
                                            viewSearchTripInformation:
                                                bool noTicketNumberFound = false;
                                                Console.Clear();
                                                for (int i = 0; i < ticketNumberSize; i++)
                                                {
                                                    Console.WriteLine("Ticket #: {0}", transactions[i, 0].ToUpper());
                                                    Console.WriteLine("Fullname {0}", transactions[i, 1].ToUpper());
                                                    Console.WriteLine("Destination {0}", transactions[i, 2].ToUpper());
                                                    Console.WriteLine("Travel Time {0}", transactions[i, 3].ToUpper());
                                                    Console.WriteLine("Date of Travel {0}", transactions[i, 4].ToUpper());
                                                    Console.WriteLine("Accomodation {0}", transactions[i, 5].ToUpper());
                                                    Console.WriteLine("Deck #: {0}", transactions[i, 6].ToUpper());
                                                    if (i >= 10) { break; }
                                                }
                                                Console.WriteLine("\nEnter Ticket #: ");
                                                string searchTicketNumber = Console.ReadLine();

                                                // search for the transaction based on the ticket number
                                                for (int i = 0; i < ticketNumberSize; i++) {
                                                    if (ticketNumbers[i] == searchTicketNumber)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Ticket #: {0}", transactions[i, 0].ToUpper());
                                                        Console.WriteLine("Fullname {0}", transactions[i, 1].ToUpper());
                                                        Console.WriteLine("Destination {0}", transactions[i, 2].ToUpper());
                                                        Console.WriteLine("Travel Time {0}", transactions[i, 3].ToUpper());
                                                        Console.WriteLine("Date of Travel {0}", transactions[i, 4].ToUpper());
                                                        Console.WriteLine("Accomodation {0}", transactions[i, 5].ToUpper());
                                                        Console.WriteLine("Deck #: {0}", transactions[i, 6].ToUpper());
                                                        noTicketNumberFound = true;

                                                        Console.WriteLine("\nFind another transaction? (Y/N): ");
                                                        retryChoice = Console.ReadLine()[0];
                                                        if (retryChoice == 'Y' || retryChoice == 'y')
                                                        {
                                                            goto viewSearchTripInformation;
                                                        }
                                                        else
                                                        {
                                                            goto transactionOptions;
                                                        }
                                                    }
                                                    else {
                                                        noTicketNumberFound = false;
                                                    }
                                                }

                                                if (!noTicketNumberFound)
                                                {
                                                    Console.WriteLine("\nNo search result(s) found");
                                                    Console.WriteLine("Try again? (Y/N): ");
                                                    retryChoice = Console.ReadLine()[0];
                                                    if (retryChoice == 'Y' || retryChoice == 'y')
                                                    {
                                                        goto viewSearchTripInformation;
                                                    }
                                                    else
                                                    {
                                                        goto transactionOptions;
                                                    }
                                                }
                                            }
                                            break;
                                        case 4:
                                            // validate if user already has ticketing inforation and passenger information
                                            if (hasTicketingInformation == false || hasPassengerRecord == false)
                                            {
                                                Console.WriteLine("\nYou haven't selected any of the ticketing transaction or Entered any passenger information!");
                                                Console.Write("Would you like to proceed? (Y/N): ");
                                                retryChoice = Console.ReadLine()[0];
                                                if (retryChoice == 'Y' || retryChoice == 'y')
                                                {
                                                    goto transactionOptions;
                                                }
                                                else
                                                {
                                                    terminateApplication = true;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                            searchByDate:
                                                Console.Write("Enter start date (MM/dd/yyyy): ");
                                                string startDateInput = Console.ReadLine();
                                                Console.Write("Enter end date (MM/dd/yyyy): ");
                                                string endDateInput = Console.ReadLine();

                                                // Convert user input strings to DateTime objects
                                                DateTime startDate, endDate;
                                                if (!DateTime.TryParseExact(startDateInput, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out startDate) ||
                                                    !DateTime.TryParseExact(endDateInput, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out endDate))
                                                {
                                                    Console.WriteLine("Invalid date format.");
                                                    return;
                                                }

                                                // Filter dates between start and end dates
                                                var filteredDates = dateOfTravels.Where(dateStr =>
                                                {
                                                    DateTime date;
                                                    return DateTime.TryParseExact(dateStr, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date) &&
                                                           date >= startDate &&
                                                           date <= endDate;
                                                });

                                                // Output filtered dates
                                                Console.Clear();
                                                Console.WriteLine("Transactions between {0} and {1}:", startDate.ToShortDateString(), endDate.ToShortDateString());
                                                for (int i = 0; i < filteredDates.Count(); i++) {
                                                    
                                                    Console.WriteLine("\nTicket #: {0}", transactions[i, 0].ToUpper());
                                                    Console.WriteLine("Fullname {0}", transactions[i, 1].ToUpper());
                                                    Console.WriteLine("Destination {0}", transactions[i, 2].ToUpper());
                                                    Console.WriteLine("Travel Time {0}", transactions[i, 3].ToUpper());
                                                    Console.WriteLine("Date of Travel {0}", transactions[i, 4].ToUpper());
                                                    Console.WriteLine("Accomodation {0}", transactions[i, 5].ToUpper());
                                                    Console.WriteLine("Deck #: {0}", transactions[i, 6].ToUpper());
                                                }

                                                Console.Write("\nTry again? (Y/N): ");
                                                retryChoice = Console.ReadLine()[0];
                                                if (retryChoice == 'Y' || retryChoice == 'y')
                                                {
                                                    goto searchByDate;
                                                }
                                                else
                                                {
                                                    goto startOfApplication;
                                                }
                                            }
                                            break;
                                        case 5:
                                            break;
                                        default:
                                            Console.WriteLine("invalid input, you will be logout from the application!");
                                            Console.ReadKey();
                                            goto startOfApplication;
                                    }
                                }

                            }
                            break;
                    #endregion
                       #region registerPage
                        case 2:
                        // register user authentication
                        registerUserAuthentication:
                            Console.Clear();
                            //creating the window form
                            for (int i = 0; i < height; i++)
                            {
                                Console.SetCursorPosition(column, (row)++);
                                for (int x = 0; x < width; x++)
                                {
                                    if (i <= headerHeight)
                                    {
                                        // creating the header design
                                        Console.BackgroundColor = headerColor;
                                        Console.Write(" ");
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = backGroundColor;
                                        Console.Write(" ");
                                    }

                                }
                                Console.WriteLine();
                            }
                            column = defaultColumn; row = defaultRow;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = headerColor;
                            Console.SetCursorPosition((column) + 2, (row) + 1);
                            Console.WriteLine("Register Page");

                            Console.BackgroundColor = backGroundColor;
                            Console.ForegroundColor = foreGroundColor;
                            Console.SetCursorPosition((column) + 2, (row) + 4);
                            Console.Write("Enter new username: ");
                            string newUsername = Console.ReadLine();
                            if (newUsername.Length > 0)
                            {
                                username = newUsername;
                                Console.SetCursorPosition((column) + 2, (row) + 5);
                                Console.Write("Enter new password: ");
                                string newPassword = Console.ReadLine();
                                if (newPassword.Length > 0)
                                {
                                    Console.ResetColor();
                                    password = newPassword;
                                    goto startOfApplication;
                                }
                            }
                            else
                            {
                                // invalid input 
                                Console.SetCursorPosition((column) + 2, (row) + 6);
                                Console.WriteLine("Invalid Input!");
                                Console.SetCursorPosition((column) + 2, (row) + 7);
                                Console.Write("Return to Home Page? (Y/N): ");
                                retryChoice = Console.ReadLine()[0];
                                if (retryChoice == 'Y' || retryChoice == 'y')
                                {
                                    Console.ResetColor();
                                    goto startOfApplication;
                                }
                                else
                                {
                                    terminateApplication = true;
                                }
                            }
                            break;
                       #endregion
                        default:
                            // invalid input
                            Console.ForegroundColor = foreGroundColor;
                            Console.BackgroundColor = backGroundColor;
                            Console.SetCursorPosition((column) + 2, (row) + 8);
                            Console.WriteLine("Invalid Input!");
                            Console.SetCursorPosition((column) + 2, (row) + 9);
                            Console.Write("Return to Home Page? (Y/N): ");
                            retryChoice = Console.ReadLine()[0];
                            if (retryChoice == 'Y' || retryChoice == 'y')
                            {
                                goto startOfApplication;
                            }
                            else
                            {
                                terminateApplication = true;
                            }
                            break;
                    }
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ResetColor();
                    Console.Clear();
                    column = defaultColumn; row = defaultRow;
                    //creating the window form
                    for (int i = 0; i < height; i++)
                    {
                        Console.SetCursorPosition(column, (row)++);
                        for (int x = 0; x < width; x++)
                        {
                            if (i <= headerHeight)
                            {
                                // creating the header design
                                Console.BackgroundColor = errorHeaderColor;
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.BackgroundColor = backGroundColor;
                                Console.Write(" ");
                            }

                        }
                        Console.WriteLine();
                    }
                    column = defaultColumn; row = defaultRow;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = errorHeaderColor;
                    Console.SetCursorPosition((column) + 2, (row) + 1);
                    Console.WriteLine("Error");
                    // invalid input
                    Console.ForegroundColor = errorHeaderColor;
                    Console.BackgroundColor = backGroundColor;
                    Console.SetCursorPosition((column) + 2, (row) + 5);
                    Console.WriteLine("An unexpeted error occured.." + ex.Message);
                    Console.SetCursorPosition((column) + 2, (row) + 6);
                    Console.Write("Restart Application? (Y/N): ");
                    retryChoice = Console.ReadLine()[0];
                    Console.ResetColor();
                    if (retryChoice == 'Y' || retryChoice == 'y')
                    {
                        continue;
                    }
                    else
                    {
                        terminateApplication = true;
                    }
                }
            } while (terminateApplication == false);
        }
    }
}
