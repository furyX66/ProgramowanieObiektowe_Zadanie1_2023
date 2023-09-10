using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class OrangutanScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;
    private ISettings _settings;
    /// <summary>
    /// Local variables.
    /// </summary>
    bool hasArborealLifeStyle;
    bool hasOpposableThumbs;
    bool hasSolitariBehavior;
    bool hasSlowReproductiveRate;

    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public OrangutanScreen(IDataService dataService, ISettings settings)
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
            _settings.ReadFromJson("OrangutanScreen");
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List all orangutans");
            Console.WriteLine("2. Create a new orangutan");
            Console.WriteLine("3. Delete existing orangutan");
            Console.WriteLine("4. Modify existing orangutan");
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
                        ListOrangutans();
                        break;

                    case GeneralMammalsScreenChoices.Create:
                        AddOrangutan(); break;

                    case GeneralMammalsScreenChoices.Delete:
                        DeleteOrangutan();
                        break;

                    case GeneralMammalsScreenChoices.Modify:
                        EditOrangutanMain();
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
    /// List all Orangutans
    /// </summary>
    private void ListOrangutans()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Orangutans is not null &&
            _dataService.Animals.Mammals.Orangutans.Count > 0)
        {
            Console.WriteLine("Here's a list of orangutans:");
            int i = 1;
            foreach (Orangutan orangutan in _dataService.Animals.Mammals.Orangutans)
            {
                Console.Write($"Orangutans number {i}, ");
                orangutan.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of orangutans is empty.");
        }
    }

    /// <summary>
    /// Add an orangutan.
    /// </summary>
    private void AddOrangutan()
    {
        try
        {
            Orangutan orangutan = AddEditOrangutan();
            _dataService?.Animals?.Mammals?.Orangutans.Add(orangutan);
            Console.WriteLine("Orangutan with name: {0} has been added to a list of orangutans", orangutan.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Deletes a orangutan.
    /// </summary>
    private void DeleteOrangutan()
    {
        try
        {
            Console.Write("What is the name of the orangutan you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Orangutan? orangutan = (Orangutan?)(_dataService?.Animals?.Mammals?.Orangutans
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (orangutan is not null)
            {
                _dataService?.Animals?.Mammals?.Orangutans?.Remove(orangutan);
                Console.WriteLine("Orangutan with name: {0} has been added to a list of orangutans", orangutan.Name);
            }
            else
            {
                Console.WriteLine("Orangutan not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing orangutan after choice made.
    /// </summary>
    private void EditOrangutanMain()
    {
        try
        {
            Console.Write("What is the name of the orangutan you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Orangutan? orangutan = (Orangutan?)(_dataService?.Animals?.Mammals?.Orangutans
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (orangutan is not null)
            {
                Orangutan orangutanEdited = AddEditOrangutan();
                orangutan.Copy(orangutanEdited);
                Console.Write("Orangutan after edit:");
                orangutan.Display();
            }
            else
            {
                Console.WriteLine("Orangutan not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific orangutan.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Orangutan AddEditOrangutan()
    {
        Console.Write("What name of the orangutan? ");
        string? name = Console.ReadLine();
        Console.Write("What is the orangutan's age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("Does orangutan like to climb trees(Yes/No)? ");
        string? arborealLifeStyle = Console.ReadLine().ToLower();
        if (arborealLifeStyle == "yes" || arborealLifeStyle == "y")
        {
            hasArborealLifeStyle = true;
        }
        else
        {
            hasArborealLifeStyle = false;
        }
        Console.Write("Does orangutan have opposable thumbs(Yes/No)?  ");
        string? opposableThumbs = Console.ReadLine().ToLower();
        if (opposableThumbs == "yes" || opposableThumbs == "y")
        {
            hasOpposableThumbs = true;
        }
        else
        {
            hasOpposableThumbs = false;
        }
        Console.Write("Does orangutan like to be alone(Yes/No)? ");
        string? solitaryBehavior = Console.ReadLine().ToLower();
        if (solitaryBehavior == "yes" || solitaryBehavior == "y")
        {
            hasSolitariBehavior = true;
        }
        else
        {
            hasSolitariBehavior = false;
        }
        Console.Write("Does orangutan have slow reproduction rate(Yes/No)? ");
        string? slowReproductiveRate = Console.ReadLine().ToLower();
        if (slowReproductiveRate == "yes" || slowReproductiveRate == "y")
        {
            hasSlowReproductiveRate = true;
        }
        else
        {
            hasSlowReproductiveRate = false;
        }
        Console.Write("What is level of his iq? ");
        int highIntelligence = int.Parse(Console.ReadLine());
        
        
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (arborealLifeStyle is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (opposableThumbs is null)
        {
            throw new ArgumentNullException(nameof(opposableThumbs));
        }
        if (solitaryBehavior is null)
        {
            throw new ArgumentNullException(nameof(solitaryBehavior));
        }
        if (slowReproductiveRate is null)
        {
            throw new ArgumentNullException(nameof(slowReproductiveRate));
        }
        int age = Int32.Parse(ageAsString);
        Orangutan orangutan = new Orangutan(name, age, hasArborealLifeStyle, hasOpposableThumbs, hasSolitariBehavior, hasSlowReproductiveRate, highIntelligence);

        return orangutan;
    }

    #endregion // Private Methods
}
