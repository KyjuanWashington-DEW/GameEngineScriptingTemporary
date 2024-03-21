using UnityEngine;
using UnityEngine.UI;

public class RockPaperScissorsGame : MonoBehaviour
{
    public Text choiceText;
    public Text candyCounterText;

    public int candyCount = 0;

    
    public void PlayerSelect(string playerChoice)
    {
        //random choice for the opponent npc
        string[] choices = { "Rock", "Paper", "Scissors" };
        int randomIndex = Random.Range(0, choices.Length);
        string opponentChoice = choices[randomIndex];

        
        string result = DetermineOutcome(playerChoice, opponentChoice);

        // what you choose
        choiceText.text = "You chose " + playerChoice + ". Your classmate chose " + opponentChoice + ". " + result;

        // more candy if you win
        if (result == "You win!")
        {
            candyCount++;
           
        }
    }

    // game outcomes
    public string DetermineOutcome(string playerChoice, string opponentChoice)
    {
        if (playerChoice == opponentChoice)
        {
            return "It's a draw!";
        }
        else if ((playerChoice == "Rock" && opponentChoice == "Scissors") ||
                 (playerChoice == "Paper" && opponentChoice == "Rock") ||
                 (playerChoice == "Scissors" && opponentChoice == "Paper"))
        {
            return "You win!";
        }
        else
        {
            return "You lose!";
        }
    }
}

