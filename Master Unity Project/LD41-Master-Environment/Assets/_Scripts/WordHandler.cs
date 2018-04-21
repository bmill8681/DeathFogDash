using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tile { question_mark = 63, _ = 95, A = 65, B = 66, C = 67, D = 68, E = 69, F = 70, G = 71, H = 72, I = 73, J = 74, K = 75, L = 76, M = 77, N = 78, O = 79, P = 80, Q = 81, R = 82, S = 83, T = 84, U = 85, V = 86, W = 87, X = 88, Y = 89, Z = 90 }

public class WordHandler : MonoBehaviour {

    public static WordHandler instance;

    public Tile tester;

    private void Awake()
    {
        if (WordHandler.instance == null)
            WordHandler.instance = this;
        else if (WordHandler.instance != this)
            Destroy(this.gameObject);

    }

    private void Start()
    {

        Debug.Log(ChartoTile('a'));
        Debug.Log(ChartoTile('b'));
    }

    public Tile ChartoTile(char A)
    {
        if (char.IsLetter(A))
        {
            tester = (Tile)((int)(char.ToUpper(A)));
            return (Tile)((int)(char.ToUpper(A)));
        }
        else return Tile._;
    }

    public char TiletoChar(Tile A)
    {
        return 'A';
    }

    public Tile[] RandomWord()
    {
        string word = "Cat";

        Tile[] return_word = new Tile[word.Length];
        for(int i = 0; i < return_word.Length; i++)
        {
            return_word[i] = ChartoTile(word[i]);
        }
        return return_word;
    }

    public int EvalWord(Tile[] word)
    {

        return -1;
    }

}
