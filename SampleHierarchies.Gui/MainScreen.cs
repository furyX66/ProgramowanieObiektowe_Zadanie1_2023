using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.Net.Http.Json;


namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor
   
    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private AnimalsScreen _animalsScreen;
    private ISettings _settings;
   
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    /// <param name="settings">Settings</param>
    public MainScreen(
        IDataService dataService,
        AnimalsScreen animalsScreen,
        ISettings settings)
    {
        _dataService = dataService;
        _animalsScreen = animalsScreen;
        _settings = settings;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settings.ReadFromJson("MainScreen");
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Animals");
            Console.WriteLine("2. Create a new settings");
            Console.Write("Please enter your choice: ");
         
            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.Animals:
                        _animalsScreen.Show();
                        break;
                    case MainScreenChoices.Settings:
                        EditSettings();
                        break;

                    case MainScreenChoices.Exit:
                        Console.WriteLine("Goodbye.");
                        return;
                }
            }
            catch (FormatException) 
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
    public void EditSettings() //Edit color for choosen screen
    {
        if (File.Exists("ColorSettings.json"))
        {
            while (true)
            {
                string content = File.ReadAllText("ColorSettings.json");
                dynamic deserializedContent = JsonConvert.DeserializeObject(content);
                Console.WriteLine();
                Console.WriteLine("Here is the list of avaliable screens");
                Console.WriteLine("1.MainScreen,\r\n2.AnimalsScreen,\r\n3.MammalsScreen,\r\n4.DogsScreen,\r\n5.African_Elephant,\r\n6.OrangutanScreen,\r\n7.BeaverScreen");
                Console.WriteLine("Choose screen which you want to modify");
                int screenNumber;
                if (int.TryParse(Console.ReadLine(), out screenNumber) && screenNumber >= 1 && screenNumber <= 7)
                {
                    string screenChoice = GetScreenChoiceByNumber(screenNumber);
                    Console.WriteLine($"Current {screenChoice} color is {deserializedContent[screenChoice]}. Write new color");
                    Console.WriteLine("Available colors:");
                    PrintAvailableColors();
                    int colorNumber;
                    if (int.TryParse(Console.ReadLine(), out colorNumber) && colorNumber >= 1 && colorNumber <= 16)
                    {
                        ConsoleColor colorChoice = GetColorChoiceByNumber(colorNumber);

                        deserializedContent[screenChoice] = colorChoice.ToString();
                        File.WriteAllText("ColorSettings.json", JsonConvert.SerializeObject(deserializedContent));

                        Console.Clear();
                        Console.WriteLine($"Color of {screenChoice} has successfully changed to {colorChoice}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File does not exist, do you want to create? y/n");
            string? choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "y":
                    AddSetting();
                    break;
                case "n":
                    break;
            }
        }
    }
    private string GetScreenChoiceByNumber(int number) //Converts number choosen by user to screen name
    {
        switch (number)
        {
            case 1: return "MainScreen";
            case 2: return "AnimalsScreen";
            case 3: return "MammalsScreen";
            case 4: return "DogsScreen";
            case 5: return "African_Elephant";
            case 6: return "OrangutanScreen";
            case 7: return "BeaverScreen";
            default: return "";
        }
    }
    private void PrintAvailableColors()//Prints all colors from enum ConsoleColor
    {
        foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
        {
            Console.WriteLine($"{(int)color}. {color}");
        }
    }
    private ConsoleColor GetColorChoiceByNumber(int number)//Converts number to color
    {
        if (Enum.IsDefined(typeof(ConsoleColor), number))
        {
            return (ConsoleColor)number;
        }
        else
        {
            return ConsoleColor.White;
        }
    }//
    private void AddSetting()
    {
        List<string> screensNames = new List<string>
        {
             "MainScreen",
             "AnimalsScreen",
             "MammalsScreen",
             "DogsScreen",
             "African_Elephant",
             "OrangutanScreen",
             "BeaverScreen"
        };
        Dictionary<string, string> settingsDic = new Dictionary<string, string>();
        Console.WriteLine("Write color for every screen from list");
        foreach (string screenName in screensNames)
        {
            Console.Write($"{screenName}: ");
            string? screenChoice = Console.ReadLine();
            settingsDic.Add(screenName, screenChoice);
        }
        string content = JsonConvert.SerializeObject(settingsDic, Formatting.Indented);
        File.WriteAllText("ColorSettings.json", content);
        Console.WriteLine("File ColorSetting.json created successfully");
    }//Creates new file with color settings
}
        #endregion // Public Methods
