namespace Mastermind;

// Typist / Navigator / Next
// CC
// JS
// RB
// RF
// SS


public record Results (int Correct, int Misplaced);
// public record Results {
//     int Correct;
//     int Misplaced; // but correct
// }

public class Engine
{
    public int Misplaced(string[] secret, string[] guess) {
        //return Enumerable.Range(0, secret.Count()).ToList().Count(n => secret[n] == guess[n]);
        int misplaced = 0;
        Dictionary<string, int> colorCounts = secret.ToList().GroupBy(c => c).ToDictionary(group => (group.Key), group => group.Count());

        for (int i = 0; i < secret.Count(); i++) {
            if (secret[i] != guess[i] && secret.Contains(guess[i]) && colorCounts[guess[i]]!=0) {
                misplaced++;
                colorCounts[guess[i]] = colorCounts[guess[i]]-1;
            }
        }
        return misplaced;
    }

    public int WellPlaced(string[] secret, string[] guess) {
        return Enumerable.Range(0, secret.Count()).ToList().Count(n => secret[n] == guess[n]);
    }

    public Results Evaluate(string[] secret, string[] guess) {
        return new Results(WellPlaced(secret, guess), Misplaced(secret, guess));
    }
}
