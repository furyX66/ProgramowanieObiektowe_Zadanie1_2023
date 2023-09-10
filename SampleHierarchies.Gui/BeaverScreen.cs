using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class BeaverScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;
    private ISettings _settings;
    ///<summary>
    ///Local variables
    ///</summary>
    bool canBuildDam;

    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public BeaverScreen(IDataService dataService, ISettings settings)
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
            _settings.ReadFromJson("BeaverScreen");
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List all beavers");
            Console.WriteLine("2. Create a new beaver");
            Console.WriteLine("3. Delete existing beaver");
            Console.WriteLine("4. Modify existing beaver");
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
                        ListBeavers();
                        break;

                    case GeneralMammalsScreenChoices.Create:
                        AddBeaver();
                        break;

                    case GeneralMammalsScreenChoices.Delete:
                        DeleteBeaver();
                        break;

                    case GeneralMammalsScreenChoices.Modify:
                        EditBeaverMain();
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
    /// List all Beavers
    /// </summary>
    private void ListBeavers()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Beavers is not null &&
            _dataService.Animals.Mammals.Beavers.Count > 0)
        {
            Console.WriteLine("Here's a list of beavers:");
            int i = 1;
            foreach (Beaver beaver in _dataService.Animals.Mammals.Beavers)
            {
                Console.Write($"Beaver number {i}, ");
                beaver.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of beavers is empty.");
        }
    }

    /// <summary>
    /// Add a beaver.
    /// </summary>
    private void AddBeaver()
    {
        try
        {
            Beaver beaver = AddEditBeaver();
            _dataService?.Animals?.Mammals?.Beavers.Add(beaver);
            Console.WriteLine("Beaver with name: {0} has been added to the list of beavers", beaver.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Deletes a beaver.
    /// </summary>
    private void DeleteBeaver()
    {
        try
        {
            Console.Write("What is the name of the beaver you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Beaver? beaver = (Beaver?)(_dataService?.Animals?.Mammals?.Beavers
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (beaver is not null)
            {
                _dataService?.Animals?.Mammals?.Beavers?.Remove(beaver);
                Console.WriteLine("Beaver with name: {0} has been removed from the list of beavers", beaver.Name);
            }
            else
            {
                Console.WriteLine("Beaver not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing beaver after choice made.
    /// </summary>
    private void EditBeaverMain()
    {
        try
        {
            Console.Write("What is the name of the beaver you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Beaver? beaver = (Beaver?)(_dataService?.Animals?.Mammals?.Beavers
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (beaver is not null)
            {
                Beaver beaverEdited = AddEditBeaver();
                beaver.Copy(beaverEdited);
                Console.Write("Beaver after edit:");
                beaver.Display();
            }
            else
            {
                Console.WriteLine("Beaver not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific beaver.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Beaver AddEditBeaver()
    {
        Console.Write("What is the name of the beaver? ");
        string? name = Console.ReadLine();
        Console.Write("What is the beaver's age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("What color beaver is? ");
        string? color = Console.ReadLine();
        Console.Write("What is beaver's favorite food? ");
        string? favoriteFood = Console.ReadLine();
        Console.Write("What length of beaver's tail? ");
        string? tailLenghtAsString = Console.ReadLine();
        Console.Write("Can beaver build a dam? ");
        string? isDamBuilder = Console.ReadLine().ToLower();
        if (isDamBuilder == "yes"|| isDamBuilder == "y") 
        {
            canBuildDam=true;
        }
        else 
        { 
            canBuildDam=false; 
        } 
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (color is null)
        {
            throw new ArgumentNullException(nameof(color));
        }
        if (favoriteFood is null)
        {
            throw new ArgumentNullException(nameof(favoriteFood));
        }
        if (tailLenghtAsString is null)
        {
            throw new ArgumentNullException(nameof(tailLenghtAsString));
        }
        int age = Int32.Parse(ageAsString);
        int tailLenght = int.Parse(tailLenghtAsString);
        Beaver beaver = new Beaver(name, age, color, favoriteFood, tailLenght, canBuildDam);

        return beaver;
    }

    #endregion // Private Methods
}
