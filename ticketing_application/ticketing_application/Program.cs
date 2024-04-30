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
            int optionChoice, 
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
            char retryChoice = 'x';
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
                    Console.Clear();
                    Console.WriteLine("[1] Login");
                    Console.WriteLine("[2] Register");
                    Console.Write("Enter choice: ");
                    optionChoice = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    switch (optionChoice)
                    {
                       #region login
                        case 1:
                            if (username.Length <= 0 && password.Length <= 0)
                            {
                                Console.WriteLine("No user authentication entered");
                                Console.Write("Return to Home Page? (Y/N): ");
                                retryChoice = char.Parse(Console.ReadLine());
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
                                Console.WriteLine("Login Page");
                                Console.Write("Enter username: ");
                                string loginUsername = Console.ReadLine();
                                Console.Write("Enter password: ");
                                string loginPassword = Console.ReadLine();
                                if (loginUsername != username || loginPassword != password)
                                {

                                    Console.WriteLine("Invalid username or password");
                                    Console.Write("Return to login Page? (Y/N): ");
                                    retryChoice = char.Parse(Console.ReadLine());
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
                                    Console.WriteLine("[1] Ticketing Transactions");
                                    Console.WriteLine("[2] View / Input Passengers Record");
                                    Console.WriteLine("[3] View / Search Trip Information");
                                    Console.WriteLine("[4] View a Search Trip Info");
                                    Console.WriteLine("[5] Return to Start of Application");
                                    Console.Write("Enter choice: ");
                                    optionChoice = int.Parse(Console.ReadLine());
                                    switch (optionChoice)
                                    {
                                        case 1:
                                            if (hasNotSavedTicketingInformation == true) 
                                            {
                                                Console.WriteLine("\nThis action will overwrite the previously entered selction");
                                                Console.Write("Would you like to proceed? (Y/N): ");
                                                retryChoice = char.Parse(Console.ReadLine());
                                                Console.ResetColor();
                                                if (retryChoice == 'N' || retryChoice == 'n')
                                                {
                                                    goto transactionOptions;
                                                }
                                            }
                                            // select a distination
                                            Console.Clear();
                                            //creating the window form
                                            for (int i = 0; i < destinations.Length; i++)
                                            {
                                                // Display the destination available
                                                Console.WriteLine("[{0}] - {1}", (i + 1), destinations[i]);
                                            }
                                            Console.Write("Enter choice: ");
                                            destinationChoice = int.Parse(Console.ReadLine());
                                            Console.ResetColor();
                                            // select a travel time
                                    selectTravelTime:
                                            for (int i = 0; i < travelTimes.Length; i++)
                                            {
                                                // Display the travel time available
                                                Console.WriteLine("[{0}] - {1}", (i + 1), travelTimes[i]);
                                            }
                                            Console.Write("Enter choice: ");
                                            travelTimeChoice = int.Parse(Console.ReadLine());
                                            if(travelTimeChoice > travelTimes.Length)
                                            {
                                                Console.WriteLine("Please select within the choices given!");
                                                goto selectTravelTime;
                                            }
                                            Console.ResetColor();
                                    inputDateOfTravel:
                                            Console.WriteLine("Enter date of travel: ({0})", _dateTime.ToString("MM/dd/yyyy"));
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
                                                    Console.WriteLine("The date of travel is in the past.");
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
                                            for (int i = 0; i < accomodations.Length; i++)
                                            {
                                                Console.WriteLine("[{0}] - {1} - Price: P{2}", (i + 1), accomodations[i], accomodationPrice[i]);
                                            }
                                            Console.Write("Enter choice: ");
                                            accomodationChoice = int.Parse(Console.ReadLine());
                                            if (accomodationChoice > accomodations.Length)
                                            {
                                                Console.WriteLine("Please select within the choices given!");
                                                goto selectAccomodations;
                                            }
                                            Console.ResetColor();
                                            // select deck number
                                    selectDeckNumber:
                                            for (int y = 1; y <= 5; y++)
                                            {
                                                for (int x = 0; x < 4; x++)
                                                {
                                                    int number = x * 5 + y; // Generate the number based on row and column
                                                    Console.Write("#{0}\t", deckNumbers[number - 1]);
                                                }
                                                Console.WriteLine(); // Move to the next row after printing each row
                                            }
                                            Console.Write("Enter the deck number of your choice: ");
                                            deckNumberChoice = int.Parse(Console.ReadLine());
                                            if (deckNumberChoice > 20) {
                                                Console.WriteLine("Please select within the deck numbers given!");
                                                goto selectDeckNumber;
                                            }
                                            // display the current transaction infomation
                                            Console.WriteLine("Your transaction information are as follows");
                                            Console.WriteLine("Destination: {0}", destinations[destinationChoice -1]);
                                            Console.WriteLine("Travel Time: {0}", travelTimes[travelTimeChoice -1]);
                                            Console.WriteLine("Accomodation: {0}", accomodations[accomodationChoice - 1]);
                                            Console.WriteLine("Date of Travel: {0}", enterDateOfTravel );
                                            Console.WriteLine("Deck Number: {0}", deckNumberChoice );
                                            Console.Write("Would you like to proceed? (Y/N): ");
                                            retryChoice = char.Parse(Console.ReadLine());
                                            if (retryChoice == 'Y' || retryChoice == 'y')
                                            {
                                                hasTicketingInformation = true;
                                                hasNotSavedTicketingInformation = false;
                                                dateOfTravel = enterDateOfTravel;
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
                                                Console.SetCursorPosition((column), row + 1);
                                                Console.WriteLine("You haven't selected any of the ticketing transaction!");
                                                Console.SetCursorPosition((column), row + 2);
                                                Console.Write("Would you like to proceed? (Y/N): ");
                                                retryChoice = char.Parse(Console.ReadLine());
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
                                                Console.Clear();
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
                                                for (int i = 0; i < genders.Length; i++)
                                                {
                                                    Console.WriteLine("[{0}] - {1}", (i + 1), genders[i]);
                                                }
                                                Console.Write("Enter Gender: ");
                                                genderChoice = int.Parse(Console.ReadLine());
                                                if (genderChoice > genders.Length)
                                                {
                                                    Console.WriteLine("Please select within the deck numbers given!");
                                                    Console.ReadKey();
                                                    goto selectGender;
                                                }
                                                //select type of passenger
                                            selectTypeOfPassenger:
                                                Console.ResetColor();
                                                Console.Clear();
                                                for (int i = 0; i < typeOfPassengers.Length; i++) 
                                                {
                                                    Console.WriteLine("[{0}] - {1} - Discount: {2}%", (i + 1), typeOfPassengers[i], typeOfPassengerDiscounts[i]);
                                                }
                                                Console.Write("Enter choice: ");
                                                typeOfPassengerChoice = int.Parse(Console.ReadLine());
                                                if (typeOfPassengerChoice > typeOfPassengers.Length) 
                                                {
                                                    Console.WriteLine("Please select within the deck numbers given!");
                                                    Console.ReadKey();
                                                    goto selectTypeOfPassenger;
                                                }

                                                //validate the user's age by comparing it to the selected type of passenger
                                                Console.ResetColor();
                                                Console.Clear();
                                                Console.Write("Enter Age: ");
                                                age = int.Parse(Console.ReadLine());

                                                if (age > 0)
                                                {
                                                    // valdating if user is senior citizen
                                                    if(typeOfPassengerChoice == 1)
                                                    {
                                                        if (age < 60)
                                                        {
                                                            Console.WriteLine("You've entered an invalid age");
                                                            Console.Write("Would you like to proceed? (Y/N): ");
                                                            retryChoice = char.Parse(Console.ReadLine());
                                                            if (retryChoice == 'Y' || retryChoice == 'y')
                                                            {
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
                                                            Console.WriteLine("You've entered an invalid age");
                                                            Console.Write("Would you like to proceed? (Y/N): ");
                                                            retryChoice = char.Parse(Console.ReadLine());
                                                            if (retryChoice == 'Y' || retryChoice == 'y')
                                                            {
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
                                                    Console.WriteLine("You've entered an invalid age");
                                                    Console.Write("Would you like to proceed? (Y/N): ");
                                                    retryChoice = char.Parse(Console.ReadLine());
                                                    if (retryChoice == 'Y' || retryChoice == 'y')
                                                    {
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
                                                Console.Clear();
                                                Console.WriteLine("Price: P{0}", accomodationPrice[accomodationChoice - 1]);
                                                double discount = accomodationPrice[accomodationChoice - 1] * typeOfPassengerDiscounts[typeOfPassengerChoice - 1];
                                                Console.WriteLine("Discount: P{0}", discount);
                                                totalPayment = accomodationPrice[accomodationChoice - 1] - discount;
                                                Console.WriteLine("Total Payment: P{0}", totalPayment);
                                                Console.Write("Enter your payment: ");
                                                payment = double.Parse(Console.ReadLine());
                                                if (payment >= totalPayment)
                                                {
                                                    change = payment - totalPayment;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("You've entered an invalid payment");
                                                    Console.Write("Would you like to enter payment? (Y/N): ");
                                                    retryChoice = char.Parse(Console.ReadLine());
                                                    if (retryChoice == 'Y' || retryChoice == 'y')
                                                    {
                                                        Console.ResetColor();
                                                        goto calculateTotalPayment;
                                                    }
                                                    else
                                                    {
                                                        terminateApplication = true;
                                                    }
                                                }

                                                // Confirm payment and transaction
                                                Console.WriteLine("Total Payment (Discount included if applicable): P{0}", totalPayment);
                                                Console.WriteLine("Your Payment: P{0}", payment);
                                                Console.WriteLine("Change: P{0}", change);
                                                Console.Write("Confirm Transaction? (Y/N): ");
                                                retryChoice = char.Parse(Console.ReadLine());
                                                if(retryChoice == 'Y' || retryChoice == 'y')
                                                {
                                                    // generate ticket number
                                                    ticketNumber = _random.Next(1000000, 9999999).ToString();
                                                    transactionData = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", fullName, destinations[destinationChoice - 1], travelTimes[travelTimeChoice - 1], dateOfTravel, accomodations[accomodationChoice - 1], deckNumberChoice);
                                                    // validate if transaction is duplicated
                                                    if (transactionSize > 0)
                                                    {
                                                        string value;
                                                        string[] validateTransaction = new string[transactionSize];
                                                        for (int x = 0; x < transactionSize - 1; x++)
                                                        {
                                                            value = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", transactions[x, 1], transactions[x, 2], transactions[x, 3], transactions[x, 4], transactions[x, 5], transactions[x, 6]);
                                                            validateTransaction[x] = value;
                                                        }
                                                        foreach (string item in validateTransaction)
                                                        {
                                                            if (item == transactionData)
                                                            {
                                                                Console.WriteLine("Duplicate Transaction Entery Error");
                                                                Console.WriteLine("We will have to ask you re-enter all your trasaction information");
                                                                Console.Write("Re-enter Transaction? (Y/N)");
                                                                retryChoice = char.Parse(Console.ReadLine());
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
                                                   
                                                    // this will store the transaction data on the transaction array
                                                    transactions = new string[transactionSize, transactionColumnSize];
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
                                                    Console.Clear();
                                                    Console.WriteLine("ROBLE SHIPPING Inc.");
                                                    Console.WriteLine("ES Baclig Avenue T Padilla Ext");
                                                    Console.WriteLine("6000 Cebu City (Capital)");
                                                    Console.WriteLine("Cebu, Philippines");
                                                    for(int i = 0; i < width - 2; i++) Console.Write("=");
                                                    Console.SetCursorPosition(column, row++);
                                                    Console.WriteLine("Ticket #: {0}", ticketNumber.ToUpper());
                                                    Console.WriteLine("Name : {0}", fullName.ToUpper());
                                                    Console.WriteLine("Vessel : IMMACULATE STAR");
                                                    Console.WriteLine("Deck # : {0}", deckNumberChoice);
                                                    Console.WriteLine("Route # : {0}", destinations[destinationChoice - 1]);
                                                    Console.WriteLine("Date of Travel # : {0}", dateOfTravel);
                                                    Console.WriteLine("Travel Time # : {0}", travelTimes[travelTimeChoice - 1]);
                                                    Console.WriteLine("Accomodations # : {0}", accomodations[accomodationChoice - 1]);
                                                    Console.WriteLine("Sex / Age: {0}/{1}", genders[genderChoice - 1], age);
                                                    for (int i = 0; i < width - 2; i++) Console.Write("=");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
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
                                                Console.WriteLine("You haven't selected any of the ticketing transaction!");
                                                Console.Write("Would you like to proceed? (Y/N): ");
                                                retryChoice = char.Parse(Console.ReadLine());
                                                if (retryChoice == 'Y' || retryChoice == 'y')
                                                {
                                                    Console.ResetColor();
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
                                                Console.ResetColor();
                                                Console.Clear();
                                                for (int i = 0; i < transactionSize -1; i++)
                                                {
                                                    Console.WriteLine("Ticket #: {0}", transactions[i, 0].ToUpper());
                                                    Console.WriteLine("Fullname {0}", transactions[i, 1].ToUpper());
                                                    Console.WriteLine("Destination {0}", transactions[i, 2].ToUpper());
                                                    Console.WriteLine("Travel Time {0}", transactions[i, 3].ToUpper());
                                                    Console.WriteLine("Date of Travel {0}", transactions[i, 4].ToUpper());
                                                    Console.WriteLine("Accomodation {0}", transactions[i, 5].ToUpper());
                                                    Console.WriteLine("Deck #: {0}", transactions[i, 6].ToUpper());
                                                    row++;
                                                    if (i > 3) { break; }
                                                }
                                                Console.SetCursorPosition((column), row++);
                                                Console.WriteLine("Enter Ticket #: ");
                                                string searchTicketNumber = Console.ReadLine();
                                                column = defaultColumn; row = defaultRow;
                                                // search for the transaction based on the ticket number
                                                Console.ResetColor();
                                                Console.Clear();
                                                for (int i = 0; i < transactionSize - 1; i++)
                                                {
                                                    if (ticketNumbers[i] == searchTicketNumber)
                                                    {
                                                        Console.WriteLine("Ticket #: {0}", transactions[i, 0].ToUpper());
                                                        Console.WriteLine("Fullname {0}", transactions[i, 1].ToUpper());
                                                        Console.WriteLine("Destination {0}", transactions[i, 2].ToUpper());
                                                        Console.WriteLine("Travel Time {0}", transactions[i, 3].ToUpper());
                                                        Console.WriteLine("Date of Travel {0}", transactions[i, 4].ToUpper());
                                                        Console.WriteLine("Accomodation {0}", transactions[i, 5].ToUpper());
                                                        Console.WriteLine("Deck #: {0}", transactions[i, 6].ToUpper());
                                                        noTicketNumberFound = true;
                                                        Console.WriteLine("Find another transaction? (Y/N): ");
                                                        retryChoice = char.Parse(Console.ReadLine());
                                                        if (retryChoice == 'Y' || retryChoice == 'y')
                                                        {
                                                            Console.ResetColor();
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
                                                    Console.WriteLine("No search result(s) found");
                                                    Console.WriteLine("Try again? (Y/N): ");
                                                    retryChoice = char.Parse(Console.ReadLine());
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
                                                Console.WriteLine("You haven't selected any of the ticketing transaction!");
                                                Console.Write("Would you like to proceed? (Y/N): ");
                                                retryChoice = char.Parse(Console.ReadLine());
                                                if (retryChoice == 'Y' || retryChoice == 'y')
                                                {
                                                    Console.ResetColor();
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
                                                retryChoice = char.Parse(Console.ReadLine());
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
                            Console.WriteLine("Register Page");
                            Console.Write("Enter new username: ");
                            string newUsername = Console.ReadLine();
                            if (newUsername.Length > 0)
                            {
                                username = newUsername;
                                Console.Write("Enter new password: ");
                                string newPassword = Console.ReadLine();
                                if (newPassword.Length > 0)
                                {
                                    password = newPassword;
                                    goto startOfApplication;
                                }
                            }
                            else
                            {
                                // invalid input 
                                Console.WriteLine("Invalid Input!");
                                Console.Write("Return to Home Page? (Y/N): ");
                                retryChoice = char.Parse(Console.ReadLine());
                                if (retryChoice == 'Y' || retryChoice == 'y')
                                {
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
                            Console.WriteLine("Invalid Input!");
                            Console.Write("Return to Home Page? (Y/N): ");
                            retryChoice = char.Parse(Console.ReadLine());
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
                    Console.Clear();
                    Console.WriteLine("Error");
                    // invalid input
                    Console.WriteLine("An unexpeted error occured.." + ex.Message);
                    //Console.WriteLine(ex.StackTrace);
                    Console.Write("Restart Application? (Y/N): ");
                    retryChoice = char.Parse(Console.ReadLine());
                    Console.ResetColor();
                    if (retryChoice == 'Y' || retryChoice == 'y')
                    {
                        column = defaultColumn; row = defaultRow;
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
