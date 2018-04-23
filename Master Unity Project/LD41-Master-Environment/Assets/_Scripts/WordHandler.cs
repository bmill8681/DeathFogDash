using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tile { question_mark = 27, _ = 0, A = 1, B = 2, C = 3, D = 4, E = 5, F = 6, G = 7, H = 8, I = 9, J = 10, K = 11, L = 12, M = 13, N = 14, O = 15, P = 16, Q = 17, R = 18, S = 19, T = 20, U = 21, V = 22, W = 23, X = 24, Y = 25, Z = 26 }



public class WordHandler : MonoBehaviour {


    public GameObject letter_tile_prefab;
    public GameObject LetterPrefab;
    public GameObject letter_crate_prefab;
    public static WordHandler instance;
    public Texture2D[] lettertile_textures;

    public Transform tile_daddy;
    public Transform crate_daddy;

    public Tile tester;
    List<string> words_3;
    List<string> words_4;
    List<string> words_5;
    List<string> words_6;
    List<string> words_7;


    private void Awake()
    {
        if (WordHandler.instance == null)
            WordHandler.instance = this;
        else if (WordHandler.instance != this)
            Destroy(this.gameObject);
        words_3 = new List<string>();
        words_4 = new List<string>();
        words_5 = new List<string>();
        words_6 = new List<string>();
        words_7 = new List<string>();
        string[] text = System.IO.File.ReadAllLines("./Assets/Dictionary/words.txt");
        for (int i = 0; i < text.Length; i++)
        {
            switch (text[i].Length)
            {
                case 3:
                    words_3.Add(text[i].ToUpper());
                    break;
                case 4:
                    words_4.Add(text[i].ToUpper());
                    break;
                case 5:
                    words_5.Add(text[i].ToUpper());
                    break;
                case 6:
                    words_6.Add(text[i].ToUpper());
                    break;
                case 7:
                    words_7.Add(text[i].ToUpper());
                    break;
                default:
                    Debug.Log("\"" + text[i] + "\" is not allowed");
                    break;
            }
        }
    }

    private void Start()
    {
        var cli = new System.Net.WebClient();
        string data = cli.DownloadString("http://app.aspell.net/lookup?dict=en_US;words=word");
        Debug.Log(data);
        
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
        if(A == Tile._) { return '_'; }
        else if(A == Tile.question_mark) { return '?'; }
        else
        {
            return (char)((int)A + 64);
        }
    }

    public string TilestoString(Tile[] AAAA)
    {

       char[] str = new char[AAAA.Length];
       for(int i = 0; i< AAAA.Length; i++)
       {
            str[i] = TiletoChar(AAAA[i]);
       }
        Debug.Log(new string(str));
        return (new string(str));
    }

    

    public void PlaceRandomLetter(Transform place)
    {
        Instantiate(WordHandler.instance.letter_tile_prefab, place.position, Quaternion.identity, Proceed.instance.holder[1]);
    }

    public Tile[] RandomWord(int word_length)
    {
        string word = "Cat";

        switch (word_length)
        {
            case 3:
                word = words_3[Random.Range(0,words_3.Count)];
                break;
            case 4:
                word = words_4[Random.Range(0, words_4.Count)];
                break;
            case 5:
                word = words_5[Random.Range(0, words_5.Count)];
                break;
            case 6:
                word = words_6[Random.Range(0, words_6.Count)];
                break;
            case 7:
                word = words_7[Random.Range(0, words_7.Count)];
                break;
            default:
                Debug.Log("word_length too long, returning CAT instead");
                break;
        }

        Tile[] return_word = new Tile[word.Length];
        for(int i = 0; i < return_word.Length; i++)
        {
            return_word[i] = ChartoTile(word[i]);
        }
        return_word[Random.Range(1, return_word.Length - 2)] = Tile.question_mark;
        return return_word;
    }


    public int EvalWord(Tile[] word)
    {
        Debug.Log(word.Length + " bbbbb" );
        switch (word.Length)
        {
            case 3:
                if (words_3.Contains(TilestoString(word))) { AudioManagerScript.instance.playTileSound(1); return 1; }
                else  AudioManagerScript.instance.playTileSound(2);  return -1; 
            case 4:
                if (words_4.Contains(TilestoString(word))) { AudioManagerScript.instance.playTileSound(1); return 1; }
                else AudioManagerScript.instance.playTileSound(2); return -1;
            case 5:
                if (words_5.Contains(TilestoString(word))) { AudioManagerScript.instance.playTileSound(1); return 1; }
                else AudioManagerScript.instance.playTileSound(2); return -1;
            case 6:
                if (words_6.Contains(TilestoString(word))) { AudioManagerScript.instance.playTileSound(1); return 1; }
                else AudioManagerScript.instance.playTileSound(2); return -1;
            case 7:
                if (words_7.Contains(TilestoString(word))) { AudioManagerScript.instance.playTileSound(1); return 1; }
                else AudioManagerScript.instance.playTileSound(2); return -1;
            default:
                Debug.Log("word_length wrong");
                return -1;
        }
        
    }

}
