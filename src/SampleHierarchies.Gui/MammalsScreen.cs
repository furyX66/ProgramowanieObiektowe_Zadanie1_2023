using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private DogsScreen _dogsScreen;
    private AfricanElephantsScreen _africanElephantsScreen;
    private OrangutanScreen _orangutanScreen;
    private BeaverScreen _beeverScreen;
    private ISettings _settings;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    /// <param name="africanElephantsScreen">African elphants screen</param>
    /// <param name="orangutanScreen">Orangutan screen</param>
    public MammalsScreen(DogsScreen dogsScreen, AfricanElephantsScreen africanElephantsScreen, OrangutanScreen orangutanScreen, BeaverScreen beeverScreen, ISettings settings)
    {
        _dogsScreen = dogsScreen;
        _africanElephantsScreen = africanElephantsScreen;
        _orangutanScreen = orangutanScreen;
        _beeverScreen = beeverScreen;
        _settings = settings;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settings.ReadFromJson("MammalsScreen");
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Dogs");
            Console.WriteLine("2. Elephants");
            Console.WriteLine("3. Orangutans");
            Console.WriteLine("4. Beaver");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show();
                        break;
                    case MammalsScreenChoices.AfricanElephants:
                        _africanElephantsScreen.Show(); 
                        break;
                    case MammalsScreenChoices.Orangutans:
                        _orangutanScreen.Show();
                        break;
                    case MammalsScreenChoices.Beavers:
                        _beeverScreen.Show();
                        break;

                    case MammalsScreenChoices.Exit:
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
}
