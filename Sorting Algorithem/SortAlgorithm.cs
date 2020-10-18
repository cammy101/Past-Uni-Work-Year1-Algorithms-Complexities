using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            // Creates a List to hold records
            var RecordList = new List<Record>();

            // Takes in the Data from txt files
            string[] Daytxt = File.ReadAllLines(Environment.CurrentDirectory + @"\DataFiles\Day_1.txt");
            string[] Depthtxt = File.ReadAllLines(Environment.CurrentDirectory + @"\DataFiles\Depth_1.txt");
            string[] IRIStxt = File.ReadAllLines(Environment.CurrentDirectory + @"\DataFiles\IRIS_ID_1.txt");
            string[] Latitudetxt = File.ReadAllLines(Environment.CurrentDirectory + @"\DataFiles\Latitude_1.txt");
            string[] Longitudetxt = File.ReadAllLines(Environment.CurrentDirectory + @"\DataFiles\Longitude_1.txt");
            string[] Magnitudetxt = File.ReadAllLines(Environment.CurrentDirectory + @"\DataFiles\Magnitude_1.txt");
            string[] Month = File.ReadAllLines(Environment.CurrentDirectory + @"\DataFiles\Month_1.txt");
            string[] Region = File.ReadAllLines(Environment.CurrentDirectory + @"\DataFiles\Region_1.txt");
            string[] Time = File.ReadAllLines(Environment.CurrentDirectory + @"\DataFiles\Time_1.txt");
            string[] Timestamptxt = File.ReadAllLines(Environment.CurrentDirectory + @"\DataFiles\Timestamp_1.txt");
            string[] Yeartxt = File.ReadAllLines(Environment.CurrentDirectory + @"\DataFiles\Year_1.txt");

            //Converts all numerical data from strings to doubles
            double[] Day = Array.ConvertAll(Daytxt, double.Parse);
            double[] IRIS = Array.ConvertAll(IRIStxt, double.Parse);
            double[] Timestamp = Array.ConvertAll(Timestamptxt, double.Parse);
            double[] Year = Array.ConvertAll(Yeartxt, double.Parse);

            double[] Depth = Array.ConvertAll(Depthtxt, double.Parse);
            double[] Latitude = Array.ConvertAll(Latitudetxt, double.Parse);
            double[] Longitude = Array.ConvertAll(Longitudetxt, double.Parse);
            double[] Magnitude = Array.ConvertAll(Magnitudetxt, double.Parse);

            // creates the objects in the record
            for (int i = 0; i < 600; i++)
            {
                RecordList.Add(new Record { Number = (i + 1) });
            }

            int counter = 0;

            // for each loop to assign one line of data from the txt file to create a record
            foreach (var Record in RecordList)
            {
                Record.Day = Day[counter];
                Record.IRIS = IRIS[counter];
                Record.Timestamp = Timestamp[counter];
                Record.Year = Year[counter];

                Record.Depth = Depth[counter];
                Record.Latitude = Latitude[counter];
                Record.Longitude = Longitude[counter];
                Record.Magnitude = Magnitude[counter];

                Record.Month = Month[counter];
                Record.Region = Region[counter];
                Record.Time = Time[counter];

                counter++;
            }

            // Gives the user a menu and options to choose from
            MainMenu:
            Console.WriteLine("Would you like to either:");

            Console.WriteLine("                              ");

            Console.WriteLine("1. Sort and read a specific Array.");
            Console.WriteLine("2. Search through a specific Array.");
            Console.WriteLine("3. Search for a Month and every Array connected to it.");
            Console.WriteLine("4. Exit.");

            Console.WriteLine("                              ");
            Console.WriteLine("******************************");
            Console.WriteLine("                              ");

            // takes the user's input/ there choice
            string SubMenu = Console.ReadLine();

            Console.WriteLine("                              ");

            // strings that are usedd further down to take another input from users
            string ArrayChoice;
            string OrderChoice;


            //shows only when program user chooses option 1 from the above options
            ArrayMenu: // a go-to in place incase the user inputs something that does not exsist while choosing what array they would like to sort, it will bring them back to the ArrayMenu
            switch (SubMenu)
            {
                case "1":
                    //outputs the sort menu
                    Console.WriteLine("Choose to sort:");
                    Console.WriteLine("1. Year");
                    Console.WriteLine("2. Month");
                    Console.WriteLine("3. Day");
                    Console.WriteLine("4. Time");
                    Console.WriteLine("5. Magnitude");
                    Console.WriteLine("6. Latitude");
                    Console.WriteLine("7. Longitude");
                    Console.WriteLine("8. Depth");
                    Console.WriteLine("9. Region");
                    Console.WriteLine("10. IRIS ID");
                    Console.WriteLine("11. TimeStamp");
                    Console.Write("Please enter your choice: ");
                    //reads user input
                    ArrayChoice = Console.ReadLine();

                    // an array that uses the user's input from array choice to choose the next case statements
                    switch (ArrayChoice)
                    {
                        case "1":
                            // ask's the user if they would like to sort the arrya in ascending and descending order
                            Console.WriteLine("Would you like to sort in Ascending or Descending order?");
                            Console.WriteLine("A: Ascending.");
                            Console.WriteLine("D: Descending.");
                            OrderChoice = Console.ReadLine();

                            switch (OrderChoice)
                            {
                                case "A":
                                    //run's the quicksort algorithm for ascending order
                                    IntAsceQuick_Sort(Year, 0, Year.Length - 1);
                                    break;
                                case "D":
                                    // run's the quicksort algorithm for Descending order
                                    IntDescQuick_Sort(Year, 0, Year.Length - 1);
                                    break;
                                default:
                                    // if user enters something other than A and D the program will return to the ArrayMenu Go-to
                                    Console.WriteLine("Wrong Input");
                                    goto ArrayMenu;
                            }

                            //prints the chosen array in order
                            foreach (var item in Year)
                            {
                                Console.WriteLine("{0}", item);
                            }
                            break;

                        case "2":                       
                            Console.WriteLine("Would you like to sort in Ascending or Descending order?");
                            Console.WriteLine("A: Ascending.");
                            Console.WriteLine("D: Descending.");
                            OrderChoice = Console.ReadLine();

                            switch (OrderChoice)
                            {
                                case "A":
                                    StringAsceQuick_Sort(Month, 0, Month.Length - 1);
                                    break;
                                case "D":
                                    StringDescQuick_Sort(Month, 0, Month.Length - 1);
                                    break;
                                default:
                                    Console.WriteLine("Wrong Input");
                                    goto ArrayMenu;
                            }

                            foreach (var item in Month)
                            {
                                Console.WriteLine("{0}", item);
                            }
                            break;

                        case "3":
                            Console.WriteLine("Would you like to sort in Ascending or Descending order?");
                            Console.WriteLine("A: Ascending.");
                            Console.WriteLine("D: Descending.");
                            OrderChoice = Console.ReadLine();

                            switch (OrderChoice)
                            {
                                case "A":
                                    IntAsceQuick_Sort(Day, 0, Day.Length - 1);
                                    break;
                                case "D":
                                    IntDescQuick_Sort(Day, 0, Day.Length - 1);
                                    break;
                                default:
                                    Console.WriteLine("Wrong Input");
                                    goto ArrayMenu;
                            }

                            foreach (var item in Day)
                            {
                                Console.WriteLine("{0}", item);
                            }
                            break;

                        case "4":
                            Console.WriteLine("Would you like to sort in Ascending or Descending order?");
                            Console.WriteLine("A: Ascending.");
                            Console.WriteLine("D: Descending.");
                            OrderChoice = Console.ReadLine();

                            switch (OrderChoice)
                            {
                                case "A":
                                    StringAsceQuick_Sort(Time, 0, Time.Length - 1);
                                    break;
                                case "D":
                                    StringDescQuick_Sort(Time, 0, Time.Length - 1);
                                    break;
                                default:
                                    Console.WriteLine("Wrong Input");
                                    goto ArrayMenu;
                            }

                            foreach (var item in Time)
                            {
                                Console.WriteLine("{0}", item);
                            }
                            break;

                        case "5":
                            Console.WriteLine("Would you like to sort in Ascending or Descending order?");
                            Console.WriteLine("A: Ascending.");
                            Console.WriteLine("D: Descending.");
                            OrderChoice = Console.ReadLine();

                            switch (OrderChoice)
                            {
                                case "A":
                                    IntAsceQuick_Sort(Magnitude, 0, Magnitude.Length - 1);
                                    break;
                                case "D":
                                    IntDescQuick_Sort(Magnitude, 0, Magnitude.Length - 1);
                                    break;
                                default:
                                    Console.WriteLine("Wrong Input");
                                    goto ArrayMenu;
                            }

                            foreach (var item in Magnitude)
                            {
                                Console.WriteLine("{0}", item);
                            }
                            break;

                        case "6":
                            Console.WriteLine("Would you like to sort in Ascending or Descending order?");
                            Console.WriteLine("A: Ascending.");
                            Console.WriteLine("D: Descending.");
                            OrderChoice = Console.ReadLine();

                            switch (OrderChoice)
                            {
                                case "A":
                                    IntAsceQuick_Sort(Latitude, 0, Latitude.Length - 1);
                                    break;
                                case "D":
                                    IntDescQuick_Sort(Latitude, 0, Latitude.Length - 1);
                                    break;
                                default:
                                    Console.WriteLine("Wrong Input");
                                    goto ArrayMenu;
                            }

                            foreach (var item in Latitude)
                            {
                                Console.WriteLine("{0}", item);
                            }
                            break;

                        case "7":
                            Console.WriteLine("Would you like to sort in Ascending or Descending order?");
                            Console.WriteLine("A: Ascending.");
                            Console.WriteLine("D: Descending.");
                            OrderChoice = Console.ReadLine();

                            switch (OrderChoice)
                            {
                                case "A":
                                    IntAsceQuick_Sort(Longitude, 0, Longitude.Length - 1);
                                    break;
                                case "D":
                                    IntDescQuick_Sort(Longitude, 0, Longitude.Length - 1);
                                    break;
                                default:
                                    Console.WriteLine("Wrong Input");
                                    goto ArrayMenu;
                            }

                            foreach (var item in Longitude)
                            {
                                Console.WriteLine("{0}", item);
                            }
                            break;

                        case "8":
                            Console.WriteLine("Would you like to sort in Ascending or Descending order?");
                            Console.WriteLine("A: Ascending.");
                            Console.WriteLine("D: Descending.");
                            OrderChoice = Console.ReadLine();

                            switch (OrderChoice)
                            {
                                case "A":
                                    IntAsceQuick_Sort(Depth, 0, Depth.Length - 1);
                                    break;
                                case "D":
                                    IntDescQuick_Sort(Depth, 0, Depth.Length - 1);
                                    break;
                                default:
                                    Console.WriteLine("Wrong Input");
                                    goto ArrayMenu;
                            }

                            foreach (var item in Depth)
                            {
                                Console.WriteLine("{0}", item);
                            }
                            break;

                        case "9":
                            Console.WriteLine("Would you like to sort in Ascending or Descending order?");
                            Console.WriteLine("A: Ascending.");
                            Console.WriteLine("D: Descending.");
                            OrderChoice = Console.ReadLine();

                            switch (OrderChoice)
                            {
                                case "A":
                                    StringAsceQuick_Sort(Region, 0, Region.Length - 1);
                                    break;
                                case "D":
                                    StringDescQuick_Sort(Region, 0, Region.Length - 1);
                                    break;
                                default:
                                    Console.WriteLine("Wrong Input");
                                    goto ArrayMenu;
                            }

                            foreach (var item in Region)
                            {
                                Console.WriteLine("{0}", item);
                            }
                            break;

                        case "10":
                            Console.WriteLine("Would you like to sort in Ascending or Descending order?");
                            Console.WriteLine("A: Ascending.");
                            Console.WriteLine("D: Descending.");
                            OrderChoice = Console.ReadLine();

                            switch (OrderChoice)
                            {
                                case "A":
                                    IntAsceQuick_Sort(IRIS, 0, IRIS.Length - 1);
                                    break;
                                case "D":
                                    IntDescQuick_Sort(IRIS, 0, IRIS.Length - 1);
                                    break;
                                default:
                                    Console.WriteLine("Wrong Input");
                                    goto ArrayMenu;
                            }

                            foreach (var item in IRIS)
                            {
                                Console.WriteLine("{0}", item);
                            }
                            break;

                        case "11":
                            Console.WriteLine("Would you like to sort in Ascending or Descending order?");
                            Console.WriteLine("A: Ascending.");
                            Console.WriteLine("D: Descending.");
                            OrderChoice = Console.ReadLine();

                            switch (OrderChoice)
                            {
                                case "A":
                                    IntAsceQuick_Sort(Timestamp, 0, Timestamp.Length - 1);
                                    break;
                                case "D":
                                    IntDescQuick_Sort(Timestamp, 0, Timestamp.Length - 1);
                                    break;
                                default:
                                    Console.WriteLine("Wrong Input");
                                    goto ArrayMenu;
                            }

                            foreach (var item in Timestamp)
                            {
                                Console.WriteLine("{0}", item);
                            }
                            break;
                    }

                    Console.WriteLine("                              ");
                    Console.WriteLine("******************************");
                    Console.WriteLine("                              ");

                    // once the user has chosen there array and the program sorts and print sit out takes the user back to the MainMenu goto
                    goto MainMenu;

                case "2":

                    Console.WriteLine("Please choose which array you would like to search for to see how how many times said array exsists in the record:");
                    Console.WriteLine("1. Year");
                    Console.WriteLine("2. Month");
                    Console.WriteLine("3. Day");
                    Console.WriteLine("4. Time");
                    Console.WriteLine("5. Magnitude");
                    Console.WriteLine("6. Latitude");
                    Console.WriteLine("7. Longitude");
                    Console.WriteLine("8. Depth");
                    Console.WriteLine("9. Region");
                    Console.WriteLine("10. IRIS");
                    Console.WriteLine("11. TimeStamp");
                    Console.Write("Please enter your choice: ");
                    string UserChoice = Console.ReadLine();

                    switch (UserChoice)
                    {
                        case "1":
                            Console.WriteLine("Please enter the Year you would like to search for:");
                            // converts double to int so the searching algorithem can run 
                            double YearChoice = Convert.ToInt32(Console.ReadLine());

                            // call's the searching method for searching ints
                            IntLinearSeach(Year, YearChoice);

                            break;

                        case "2":

                            Console.WriteLine("Please enter the Month you would like to search for:");
                            string MonthChoice2 = Console.ReadLine();

                            // calls the searching method for searching strings
                            StringLinearSeach(Month, MonthChoice2);

                            break;

                        case "3":

                            Console.WriteLine("Please enter the Day you would like to search for:");
                            double DayChoice = Convert.ToInt32(Console.ReadLine());

                            IntLinearSeach(Day, DayChoice);

                            break;

                        case "4":

                            Console.WriteLine("Please enter the Time you would like to search for:");
                            string TimeChoice = Console.ReadLine();

                            StringLinearSeach(Time, TimeChoice);

                            break;

                        case "5":

                            Console.WriteLine("Please enter the Magnitude you would like to search for:");
                            // As there are decimals used in this data, converts to double so the linear search can run on it
                            double MagnitudeChoice = Convert.ToDouble(Console.ReadLine());

                            IntLinearSeach(Magnitude, MagnitudeChoice);

                            break;

                        case "6":

                            Console.WriteLine("Please enter the Latidue you would like to search for:");
                            double LatitudeChoice = Convert.ToDouble(Console.ReadLine());

                            IntLinearSeach(Latitude, LatitudeChoice);

                            break;

                        case "7":

                            Console.WriteLine("Please enter the Longitude you would like to search for:");
                            double LongitudeChoice = Convert.ToDouble(Console.ReadLine());

                            IntLinearSeach(Longitude, LongitudeChoice);

                            break;

                        case "8":
                            Console.WriteLine("Please enter the Depth you would like to search for:");
                            double DepthChoice = Convert.ToDouble(Console.ReadLine());

                            IntLinearSeach(Depth, DepthChoice);

                            break;

                        case "9":

                            Console.WriteLine("Please enter the Region you would like to search for:");
                            string RegionChoice = Console.ReadLine();

                            StringLinearSeach(Region, RegionChoice);

                            break;

                        case "10":

                            Console.WriteLine("Please enter the IRIS you would like to search for:");
                            double IRISChoice = Convert.ToInt32(Console.ReadLine());

                            IntLinearSeach(IRIS, IRISChoice);

                            break;

                        case "11":

                            Console.WriteLine("Please enter the TimeStamp you would like to search for:");
                            double TimeStampChoice = Convert.ToInt32(Console.ReadLine());

                            IntLinearSeach(Timestamp, TimeStampChoice);

                            break;


                    }

                    Console.WriteLine("                              ");
                    Console.WriteLine("******************************");
                    Console.WriteLine("                              ");

                    goto MainMenu;

                case "3":

                    Console.WriteLine("Please enter A month you would like to search");
                    // takes  user in put
                    string MonthChoice = Console.ReadLine();

                    // uses, user input to decide what month they would like to check. Checks for each data file in record and each data file that is connect to its month
                    foreach (var Record in RecordList)
                    {
                        if (Record.Month == MonthChoice)
                        {
                            Console.Write("Record: {0} ", Record.Number);
                            Console.Write("Day: {0} ", Record.Day);
                            Console.Write("Month: {0} ", Record.Month);
                            Console.Write("Year: {0} ", Record.Year);
                            Console.Write("Time: {0} ", Record.Time);
                            Console.Write("Timestamp: {0} ", Record.Timestamp);
                            Console.Write("Depth: {0} ", Record.Depth);
                            Console.Write("Latitude: {0} ", Record.Latitude);
                            Console.Write("Longitude: {0} ", Record.Longitude);
                            Console.Write("Magnitude: {0} ", Record.Magnitude);
                            Console.Write("IRIS: {0} ", Record.IRIS);
                            Console.WriteLine();
                        }
                    }

                    Console.WriteLine("                              ");
                    Console.WriteLine("******************************");
                    Console.WriteLine("                              ");

                    goto MainMenu;

                case "4":

                    goto End;


            }


            /*
            foreach (var Record in RecordList)
            {
                Console.Write("Record: {0} ", Record.Number);
                Console.Write("Day: {0} ", Record.Day);
                Console.Write("Month: {0} ", Record.Month);
                Console.Write("Year: {0} ", Record.Year);
                Console.Write("Time: {0} ", Record.Time);
                Console.Write("Timestamp: {0} ", Record.Timestamp);
                Console.Write("Depth: {0} ", Record.Depth);
                Console.Write("Latitude: {0} ", Record.Latitude);
                Console.Write("Longitude: {0} ", Record.Longitude);
                Console.Write("Magnitude: {0} ", Record.Magnitude);
                Console.Write("IRIS: {0} ", Record.IRIS);
                Console.WriteLine();
            }
            */

            End:
            Console.WriteLine("Exiting Program");
            Console.ReadLine();
        }

        //  Sorts Int's in descending order
        public static void IntDescQuick_Sort(double[] data, int left, int right)
        {
            int i, j;
            double pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];
            do
            {
                while ((data[i] > pivot)) i++;
                while ((pivot > data[j])) j--;
                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (left < j) IntDescQuick_Sort(data, left, j);
            if (i < right) IntDescQuick_Sort(data, i, right);
        }

        // Sorts ints in Ascending order
        public static void IntAsceQuick_Sort(double[] data, int left, int right)
        {
            int i, j;
            double pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];
            do
            {
                while ((data[i] < pivot)) i++;
                while ((pivot < data[j])) j--;
                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (left < j) IntAsceQuick_Sort(data, left, j);
            if (i < right) IntAsceQuick_Sort(data, i, right);
        }

        // sorts string in descending order (alphabetically)
        public static void StringDescQuick_Sort(string[] data, int left, int right)
        {
            int i, j;
            string pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];
            do
            {
                while ((data[i].CompareTo(pivot)) > 0) i++;
                while ((data[j].CompareTo(pivot)) < 0) j--;
                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (left < j) StringDescQuick_Sort(data, left, j);
            if (i < right) StringDescQuick_Sort(data, i, right);
        }

        // sorts strings in ascending order (alphabetically)
        public static void StringAsceQuick_Sort(string[] data, int left, int right)
        {
            int i, j;
            string pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];
            do
            {
                while ((data[i].CompareTo(pivot)) < 0) i++;
                while ((data[j].CompareTo(pivot)) > 0) j--;
                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (left < j) StringAsceQuick_Sort(data, left, j);
            if (i < right) StringAsceQuick_Sort(data, i, right);
        }

        //linear search for ints
        static void IntLinearSeach(double[] data, double value)
        {
            int counter = 0;


            foreach (var item in data)
            {
                if (item == value)
                {
                    Console.WriteLine("{0} ", item);
                    counter++;

                }
            }

            if (counter > 0)
            {
                Console.WriteLine("There is {0} '{1}' enteries in the array", counter, value);
            }
            else
            {
                Console.WriteLine("Error; This Data Does Not Exsist");
            }
        }

        // linear search for strings
        static void StringLinearSeach(string[] data, string value)
        {
            int counter = 0;


            foreach (var item in data)
            {
                if (item == value)
                {
                    Console.WriteLine("{0} ", item);
                    counter++;

                }
            }

            if (counter > 0)
            {
                Console.WriteLine("There is {0} '{1}' enteries in the array", counter, value);
            }
            else
            {
                Console.WriteLine("Error; This Data Does Not Exsist");
            }
        }
    }

    //holds the record

    class Record
    {
        public double Number;
        public double Day;
        public double IRIS;
        public double Timestamp;
        public double Year;

        public double Depth;
        public double Latitude;
        public double Longitude;
        public double Magnitude;

        public string Month;
        public string Region;
        public string Time;
    }
}