using System;

namespace AlapBankmodel_Viki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int viki = 10000000;
            int peter = 10000000;
            string user = null;

            while (true)
            {
                if (user == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Belépés: 1 Viki | 2 Péter | 0 Kilép");
                    string c = Console.ReadLine();
                    if (!int.TryParse(c, out int choice)) { Console.WriteLine("Érvénytelen"); continue; }
                    if (choice == 0) break;
                    if (choice == 1) user = "Viki";
                    else if (choice == 2) user = "Péter";
                    else { Console.WriteLine("Nincs ilyen profil"); }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Bejelentkezve: {user}");
                    Console.WriteLine("1 Egyenleg | 2 Hozzáad | 3 Levétel | 5 Utalás | 4 Kijelentkezés | 0 Kilép");
                    string a = Console.ReadLine();
                    if (!int.TryParse(a, out int action)) { Console.WriteLine("Érvénytelen"); continue; }
                    if (action == 0) break;
                    if (action == 4) { user = null; continue; }

                    if (action == 1)
                    {
                        Console.WriteLine(user == "Viki" ? viki.ToString() : peter.ToString());
                        continue;
                    }

                    if (action == 5)
                    {
                        Console.WriteLine("Kinek utal? 1 Viki | 2 Péter");
                        string r = Console.ReadLine();
                        if (!int.TryParse(r, out int recip)) { Console.WriteLine("Érvénytelen"); continue; }
                        string target = recip == 1 ? "Viki" : recip == 2 ? "Péter" : null;
                        if (target == null) { Console.WriteLine("Nincs ilyen profil"); continue; }
                        if (target == user) { Console.WriteLine("Nem utalhatsz magadnak"); continue; }

                        Console.WriteLine("Összeg:");
                        string s2 = Console.ReadLine();
                        if (!int.TryParse(s2, out int amt2) || amt2 <= 0) { Console.WriteLine("Érvénytelen"); continue; }

                        
                        if (user == "Viki")
                        {
                            if (viki < amt2) { Console.WriteLine("Nincs elég pénz"); continue; }
                            viki -= amt2;
                            peter += amt2;
                        }
                        else
                        {
                            if (peter < amt2) { Console.WriteLine("Nincs elég pénz"); continue; }
                            peter -= amt2;
                            viki += amt2;
                        }
                        Console.WriteLine("Utalás sikeres");
                        continue;
                    }

                    if (action == 2)
                    {
                        Console.WriteLine("Összeg:");
                        string s = Console.ReadLine();
                        if (!int.TryParse(s, out int amt) || amt <= 0) { Console.WriteLine("Érvénytelen"); continue; }
                        if (user == "Viki") viki += amt; else peter += amt;
                        Console.WriteLine("Sikeres");
                        continue;
                    }

                    if (action == 3)
                    {
                        Console.WriteLine("Összeg:");
                        string s = Console.ReadLine();
                        if (!int.TryParse(s, out int amt) || amt <= 0) { Console.WriteLine("Érvénytelen"); continue; }
                        if (user == "Viki")
                        {
                            if (viki >= amt) { viki -= amt; Console.WriteLine("Sikeres"); }
                            else Console.WriteLine("Nincs elég pénz");
                        }
                        else
                        {
                            if (peter >= amt) { peter -= amt; Console.WriteLine("Sikeres"); }
                            else Console.WriteLine("Nincs elég pénz");
                        }
                        continue;
                    }

                    Console.WriteLine("Ismeretlen parancs");
                }
            }
        }
    }
}
