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
            string username = "1", password = "1",
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
                age = 0, typeOfPassengerChoice = 0, genderChoice = 0;
            
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
                    Console.Clear();
                    Console.WriteLine("[1] Login");
                    Console.WriteLine("[2] Register");
                    Console.Write("Enter choice: ");
                    optionChoice = int.Parse(Console.ReadLine());

                    switch (optionChoice)
                    {
                        case 1:
                            if (username.Length <= 0 && password.Length <= 0)
                            {
                                Console.WriteLine("No user authentication entered");
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
                            }
                            else
                            {
                            // user access authentication process
                            userLogin:
                                Console.Clear();
                                Console.Write("Enter username: ");
                                string loginUsername = Console.ReadLine();
                                Console.Write("Enter password: ");
                                string loginPassword = Console.ReadLine();
                                if (loginUsername != username || loginPassword != password)
                                {
                                    Console.WriteLine("Invalid username or password");
                                    Console.Write("Return to login Page? (Y/N): ");
                                    retryChoice = Console.ReadLine()[0];
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
                                    Console.WriteLine("Transaction Options");
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
                                                retryChoice = Console.ReadLine()[0];
                                                if (retryChoice == 'N' || retryChoice == 'n')
                                                {
                                                    goto transactionOptions;
                                                }
                                            }
                                            // select a distination
                                            Console.Clear();
                                            Console.WriteLine("TICKETING TRANSACTIONS");
                                            for (int i = 0; i < destinations.Length; i++)
                                            {
                                                // Display the destination available
                                                Console.WriteLine("[{0}] - {1}", (i + 1), destinations[i]);
                                            }
                                            Console.Write("Enter choice: ");
                                            destinationChoice = int.Parse(Console.ReadLine());
                                            
                                            // select a travel time
                                    selectTravelTime:
                                            Console.Clear();
                                            Console.WriteLine("Select Travel Time");
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
                                                Console.ReadKey();
                                                goto selectTravelTime;
                                            }
                                    inputDateOfTravel:
                                            // select / input date of travel
                                            Console.Clear();
                                            Console.WriteLine("Enter date of travel: {0}", _dateTime.ToString("MM/dd/yyyy"));
                                            enterDateOfTravel = Console.ReadLine();
                                            DateTime parsedDate;
                                            if ((!DateTime.TryParseExact(enterDateOfTravel, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate)) && (parsedDate < DateTime.Today))
                                            {
                                                Console.WriteLine("Please enter a valid date!");
                                                Console.ReadKey();
                                                goto inputDateOfTravel;
                                            }
                                            // select accomodation
                                    selectAccomodations:
                                            Console.Clear();
                                            Console.WriteLine("Select Accomodations");
                                            for (int i = 0; i < accomodations.Length; i++)
                                            {
                                                // Display the accomodations available
                                                Console.WriteLine("[{0}] - {1} - Price: P{2}", (i + 1), accomodations[i], accomodationPrice[i]);
                                            }
                                            Console.Write("Enter choice: ");
                                            accomodationChoice = int.Parse(Console.ReadLine());
                                            if (accomodationChoice > accomodations.Length)
                                            {
                                                Console.WriteLine("Please select within the choices given!");
                                                Console.ReadKey();
                                                goto selectAccomodations;
                                            }

                                            // select deck number
                                    selectDeckNumber:
                                            Console.Clear();
                                            Console.WriteLine("Select Deck Number");
                                            for (int y = 1; y <= 5; y++)
                                            {
                                                for (int x = 0; x < 4; x++)
                                                {
                                                    int number = x * 5 + y; // Generate the number based on row and column
                                                    Console.Write("#{0}\t", deckNumbers[number - 1]);
                                                }
                                                Console.WriteLine(); // Move to the next row after printing each row
                                            }

                                            Console.Write("\nEnter the deck number of your choice: ");
                                            deckNumberChoice = int.Parse(Console.ReadLine());
                                            if (deckNumberChoice > 20) {
                                                Console.WriteLine("Please select within the deck numbers given!");
                                                Console.ReadKey();
                                                goto selectDeckNumber;
                                            }
                                            // display the current transaction infomation
                                            Console.Clear();
                                            Console.WriteLine("Your transaction information are as follows");
                                            Console.WriteLine("Destination: {0}", destinations[destinationChoice -1]);
                                            Console.WriteLine("Travel Time: {0}", travelTimes[travelTimeChoice -1]);
                                            Console.WriteLine("Accomodation: {0}", accomodations[accomodationChoice - 1]);
                                            Console.WriteLine("Date of Travel: {0}", enterDateOfTravel );
                                            Console.WriteLine("Deck Number: {0}", deckNumberChoice );

                                            Console.Write("\nWould you like to proceed? (Y/N): ");
                                            retryChoice = Console.ReadLine()[0];
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
                                                Console.WriteLine("\nYou haven't selected any of the ticketing transaction!");
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
                                                Console.Write("Enter Fullname: ");
                                                fullName = Console.ReadLine();

                                                Console.Clear();
                                                Console.Write("Enter Address: ");
                                                address = Console.ReadLine();
                                                
                                                // select gender
                                            selectGender:
                                                Console.Clear();
                                                Console.WriteLine("Select Gender");
                                                for (int i = 0; i < genders.Length; i++)
                                                {
                                                    Console.WriteLine("[{0}] - {1}", (i + 1), genders[i]);
                                                }
                                                Console.Write("\nEnter Gender: ");
                                                genderChoice = int.Parse(Console.ReadLine());
                                                if (genderChoice > genders.Length)
                                                {
                                                    Console.WriteLine("Please select within the deck numbers given!");
                                                    Console.ReadKey();
                                                    goto selectGender;
                                                }
                                                //select type of passenger
                                            selectTypeOfPassenger:
                                                Console.Clear();
                                                for (int i = 0; i < typeOfPassengers.Length; i++) 
                                                {
                                                    Console.WriteLine("[{0}] - {1} - Discount: {2}%", (i + 1), typeOfPassengers[i], typeOfPassengerDiscounts[i]);
                                                }
                                                Console.Write("\nEnter choice: ");
                                                typeOfPassengerChoice = int.Parse(Console.ReadLine());
                                                if (typeOfPassengerChoice > typeOfPassengers.Length) 
                                                {
                                                    Console.WriteLine("Please select within the deck numbers given!");
                                                    Console.ReadKey();
                                                    goto selectTypeOfPassenger;
                                                }

                                                //validate the user's age by comparing it to the selected type of passenger
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
                                                            retryChoice = Console.ReadLine()[0];
                                                            if (retryChoice == 'Y' || retryChoice == 'y')
                                                            {
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
                                                            retryChoice = Console.ReadLine()[0];
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
                                                    retryChoice = Console.ReadLine()[0];
                                                    if (retryChoice == 'Y' || retryChoice == 'y')
                                                    {
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
                                                else {
                                                    Console.WriteLine("You've entered an invalid payment");
                                                    Console.Write("Would you like to enter payment? (Y/N): ");
                                                    retryChoice = Console.ReadLine()[0];
                                                    if (retryChoice == 'Y' || retryChoice == 'y')
                                                    {
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
                                                                Console.WriteLine("\nDuplicate Transaction Entery Error");
                                                                Console.WriteLine("We will have to ask you re-enter all your trasaction information");
                                                                Console.WriteLine("\nRe-enter Transaction? (Y/N)");
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
                        case 2:
                        // register user authentication
                        registerUserAuthentication:
                            Console.Clear();
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
                                retryChoice = Console.ReadLine()[0];
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
                        default:
                            // invalid input
                            Console.WriteLine("Invalid Input!");
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
                }
                catch (Exception ex)
                {
                    // invalid input
                    Console.Clear();
                    Console.WriteLine("An unexpeted error occured.." + ex.Message);
                    Console.Write("Restart Application? (Y/N): ");
                    retryChoice = Console.ReadLine()[0];
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
