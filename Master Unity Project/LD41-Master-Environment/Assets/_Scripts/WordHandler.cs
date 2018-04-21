using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tile { question_mark = 27, _ = 0, A = 1, B = 2, C = 3, D = 4, E = 5, F = 6, G = 7, H = 8, I = 9, J = 10, K = 11, L = 12, M = 13, N = 14, O = 15, P = 16, Q = 17, R = 18, S = 19, T = 20, U = 21, V = 22, W = 23, X = 24, Y = 25, Z = 26 }



public class WordHandler : MonoBehaviour {



    public static WordHandler instance;
    public Texture2D[] lettertile_textures;
    public GameObject LetterPrefab;
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
            return (Tile)((int)(char.ToUpper(A)) - 64);
        }
        else return Tile._;
    }

    public char TiletoChar(Tile A)
    {
        return 'A';
    }

    public Tile[] RandomWord(int word_length)
    {
        string word = "Cat";

        Tile[] return_word = new Tile[word.Length];
        for(int i = 0; i < return_word.Length; i++)
        {
            return_word[i] = ChartoTile(word[i]);
        }
        return return_word;
    }

    public void SpawnWord(GameObject[] roadstrip)
    {


    }


    public int EvalWord(Tile[] word)
    {

        return -1;
    }

}
