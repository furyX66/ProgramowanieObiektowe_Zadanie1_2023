using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.Runtime;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class AfricanElephantsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;
    private ISettings _settings;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public AfricanElephantsScreen(IDataService dataService, ISettings settings)
    {
        _dataService = dataService;
        _settings = settings;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settings.ReadFromJson("African_Elephant");
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List all elephants");
            Console.WriteLine("2. Create a new elephant");
            Console.WriteLine("3. Delete existing elephant");
            Console.WriteLine("4. Modify existing elephant");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                GeneralMammalsScreenChoices choice = (GeneralMammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case GeneralMammalsScreenChoices.List:
                        ListElephants();
                        break;

                    case GeneralMammalsScreenChoices.Create:
                        AddElephant(); break;

                    case GeneralMammalsScreenChoices.Delete: 
                        DeleteElephant();
                        break;

                    case GeneralMammalsScreenChoices.Modify:
                        EditElephantMain();
                        break;

                    case GeneralMammalsScreenChoices.Exit:
                        Console.WriteLine("Going back to parent menu.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// List all Elephants.
    /// </summary>
    private void ListElephants()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.AfricanElephants is not null &&
            _dataService.Animals.Mammals.AfricanElephants.Count > 0)
        {
            Console.WriteLine("Here's a list of elephants:");
            int i = 1;
            foreach (AfricanElephant africanElephant in _dataService.Animals.Mammals.AfricanElephants)
            {
                Console.Write($"African elephants number {i}, ");
                africanElephant.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of elephants is empty.");
        }
    }

    /// <summary>
    /// Add an elephant.
    /// </summary>
    private void AddElephant()
    {
        try
        {
            AfricanElephant elephant = AddEditElephant();
            _dataService?.Animals?.Mammals?.AfricanElephants.Add(elephant);
            Console.WriteLine("Elephant with name: {0} has been added to a list of elephants", elephant.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Deletes a elephant.
    /// </summary>
    private void DeleteElephant()
    {
        try
        {
            Console.Write("What is the name of the elephant you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            AfricanElephant? elephant = (AfricanElephant?)(_dataService?.Animals?.Mammals?.AfricanElephants
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (elephant is not null)
            {
                _dataService?.Animals?.Mammals?.AfricanElephants?.Remove(elephant);
                Console.WriteLine("Elephant with name: {0} has been deleted from a list of elephants", elephant.Name);
            }
            else
            {
                Console.WriteLine("Elephant not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing elephant after choice made.
    /// </summary>
    private void EditElephantMain()
    {
        try
        {
            Console.Write("What is the name of the elephant you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            AfricanElephant? elephant = (AfricanElephant?)(_dataService?.Animals?.Mammals?.AfricanElephants
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (elephant is not null)
            {
                AfricanElephant elephantEdited = AddEditElephant();
                elephant.Copy(elephantEdited);
                Console.Write("Elephant after edit:");
                elephant.Display();
            }
            else
            {
                Console.WriteLine("Elephant not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific elephant.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private AfricanElephant AddEditElephant()
    {
        Console.Write("What name of the elephant? ");
        string? name = Console.ReadLine();
        Console.Write("What is the elephant's age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("What is the elephant's height? ");
        string? heightAsString = (Console.ReadLine());
        Console.Write("What is the elephant's weight? ");
        string? weightAsString = Console.ReadLine();
        Console.Write("What is the elephant's tusk length? ");
        string? tuskLengthAsString = Console.ReadLine();
        Console.Write("How many years will he live? ");
        string? longLifespanAsString = Console.ReadLine();
        Console.Write("Describe elephant's socical behavior: ");
        string? socialBehavior = Console.ReadLine();

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (socialBehavior is null)
        {
            throw new ArgumentNullException(nameof(socialBehavior));
        }
        if (heightAsString is null)
        {
            throw new ArgumentNullException(nameof(heightAsString));
        }
        if (weightAsString is null)
        {
            throw new ArgumentNullException(nameof(weightAsString));
        }
        if (tuskLengthAsString is null)
        {
            throw new ArgumentNullException(nameof(tuskLengthAsString));
        }
        if (longLifespanAsString is null)
        {
            throw new ArgumentNullException(nameof(longLifespanAsString));
        }
        int age = Int32.Parse(ageAsString);
        float height = float.Parse(heightAsString);
        float weight = float.Parse(weightAsString);
        float tuskLength = float.Parse(tuskLengthAsString);
        int longLifespan = Int32.Parse(longLifespanAsString);   

        AfricanElephant elephant = new AfricanElephant(name, age, height, weight, tuskLength, longLifespan, socialBehavior);

        return elephant;
    }

    #endregion // Private Methods
}
