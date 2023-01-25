using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class GronsfeldCipher
    {
        public string [] alph = { "а","б","в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я"};
        public string  Gronspheld(string s, int k,int change)
        {
            int q = 0;
            int u = 0;

            string[] word = new string[s.Length];
            for (int i = 0; i < s.Length; i++)
                word[i] = Convert.ToString(s[i]);
            int flag = 0;
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < alph.Length; j++)
                {
                    if (word[i] == alph[j])
                        flag++;

                }
                if (flag == 0)
                {
                    string error =  "Посторонние символы в строке ввода";
                    return error;
                }
            }
            int[] key = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
                key[i] = 10;
            for (int h = 0; h < s.Length; h++)
            {
                if (k > 10)
                {
                    key[s.Length - h - 1] = k % 10;
                }
                else
                {
                    key[s.Length - h - 1] = k;
                    break;
                }
                k = k / 10;
            }

            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] != 10)
                {
                    key[q] = key[i];
                    key[i] = 10;
                    q++;

                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (key[i] == 10)
                {
                    key[i] = key[u];
                    u++;
                }
            }

            if (change == 0)
            {
                for (int l = 0; l < word.Length; l++)
                {


                    int index = Array.IndexOf(alph, word[l]);
                    if (index == 32)
                        index = 0 + key[l] - 1;
                    else
                        index += key[l];
                    if (index > 32)
                        index = index - 32;
                    word[l] = alph[index];

                }
            }
            else
            {
                for (int l = 0; l < word.Length; l++)
                {
                    int index = Array.IndexOf(alph, word[l]);

                    if (index < key[l])
                        index = 33 - (key[l] - index);
                    else
                        index -= key[l];

                    word[l] = alph[index];
                }
            }
            string o = String.Concat<string>(word);
            return o;
        }
    }
}

