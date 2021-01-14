using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;

    // Game configuration data
    string[] level1Passwords = {"one", "desk", "lamp", "mug", "laptop", "notepad"};
    string[] level2Passwords = {"two", "ether", "creativity", "logical", "conceptualize", "meaning"};

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("What's up dude!");
    }

    void ShowMainMenu(string greeting) {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Unscramble the coded words.");
        Terminal.WriteLine("Pick a Level: 1 - 2 - 3.");
    }

    void OnUserInput(string input) {
		if (input == "main") {
            // Takes Player to Main Menu
            ShowMainMenu("--MAIN MENU--");
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input) {

        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber) {
            level = int.Parse(input);
            AskForPassword();
        }



         else if (input == "hey") {
            ShowMainMenu("Hey?..That's it?... Go fuck yourself");
        } else {
            ShowMainMenu("Type the number of the level");
        }

        }

    void CheckPassword(string input) {
        if (input == password) {
            DisplayWinScreen();
        } else {
            AskForPassword();
        }

        
    }

   void DisplayWinScreen() {
       currentScreen = Screen.Win;
       Terminal.ClearScreen();
       ShowLevelReward();
       
   }

   void ShowLevelReward() {
       Terminal.WriteLine(@"
              \'-=======-'/
              _|   .=.   |_
             ((|  {{1}}  |))
              \|   /|\   |/
               \__ '`' __/
                 _`) (`_
              _/_______\_
              /___________\
       ");
       Terminal.WriteLine("Congratulations!");
   }

    void AskForPassword() {

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter the password - HINT:" + password.Anagram());
    }

    void SetRandomPassword() {
        switch(level) {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
}
