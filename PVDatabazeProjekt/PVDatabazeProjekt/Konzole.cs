using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabazeProjekt
{
    public class Konzole
    {
        public void Start()
        {
            try
            {
                MainMenu();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Problém s připojením do databáze.");
            }
            Console.WriteLine("Konec");
        }
        public void MainMenu()
        {
            Menu menu = new Menu("Vyber jednu možnost: ");
            menu.Add(new MenuItem("Produkt",
                new Action(() =>
                {
                    var m = ProduktMenu();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Zakazníka",
                new Action(() =>
                {
                    var m = ZakaznikMenu();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Dodavatele",
                new Action(() =>
                {
                    var m = DodavatelMenu();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Ukončit program", new Action(() => { exit = true; })));

            while (!exit)
            {
                var item = menu.Execute();
                item.Execute();
            }
        }

        private bool exit = false;
        private Menu ProduktMenu()
        {
            Menu m = new Menu("Vyber akci pro produkt: ");
            ProduktDAO produktDAO = new ProduktDAO();
            m.Add(new MenuItem("Přidat produkt",
                new Action(() =>
                {
                    Console.WriteLine("Zadejte název produktu:");
                    string nazev = Console.ReadLine();
                    Console.WriteLine("Zadejte cenu produktu:");
                    decimal cena = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Zadejte datum výroby produktu (YYYY-MM-DD):");
                    DateTime datumVyroby = DateTime.Parse(Console.ReadLine());
                    produktDAO.Vlozit(nazev, cena, datumVyroby);
                })));
            m.Add(new MenuItem("Vymazat produkt",
                new Action(() =>
                {
                    Console.WriteLine("Zadejte ID produktu k vymazání:");
                    int id = int.Parse(Console.ReadLine());
                    Produkt produkt = produktDAO.PodleID(id);
                    if (produkt != null)
                    {
                        produktDAO.Smazat(produkt);
                        Console.WriteLine("Produkt byl úspěšně smazán.");
                    }
                    else
                    {
                        Console.WriteLine("Produkt s daným ID nebyl nalezen.");
                    }
                })));
            m.Add(new MenuItem("Zobrazit všechny produkty",
                new Action(() =>
                {
                    foreach (var produkt in produktDAO.Vsechny())
                    {
                        Console.WriteLine($"ID: {produkt.ID}, Název: {produkt.Nazev}, Cena: {produkt.Cena}, Datum výroby: {produkt.DatumVyroby}");
                    }
                })));
            m.Add(new MenuItem("Zobrazit produkt podle ID",
                new Action(() =>
                {
                    Console.WriteLine("Zadejte ID produktu:");
                    int id = int.Parse(Console.ReadLine());
                    Produkt produkt = produktDAO.PodleID(id);
                    if (produkt != null)
                    {
                        Console.WriteLine($"ID: {produkt.ID}, Název: {produkt.Nazev}, Cena: {produkt.Cena}, Datum výroby: {produkt.DatumVyroby}");
                    }
                    else
                    {
                        Console.WriteLine("Produkt s daným ID nebyl nalezen.");
                    }
                })));
            return m;
        }

        private Menu ZakaznikMenu()
        {
            Menu m = new Menu("Vyber akci pro zákazníka: ");
            ZakaznikDAO zakaznikDAO = new ZakaznikDAO();
            m.Add(new MenuItem("Přidat zákazníka",
                new Action(() =>
                {
                    Console.WriteLine("Zadejte jméno zákazníka:");
                    string jmeno = Console.ReadLine();
                    Console.WriteLine("Zadejte adresu zákazníka:");
                    string adresa = Console.ReadLine();
                    Console.WriteLine("Zadejte telefonní číslo zákazníka:");
                    string telefonCislo = Console.ReadLine();
                    zakaznikDAO.Vlozit(jmeno, adresa, telefonCislo);
                })));
            m.Add(new MenuItem("Vymazat zákazníka",
                new Action(() =>
                {
                    Console.WriteLine("Zadejte ID zákazníka k vymazání:");
                    int id = int.Parse(Console.ReadLine());
                    Zakaznik zakaznik = zakaznikDAO.PodleID(id);
                    if (zakaznik != null)
                    {
                        zakaznikDAO.Smazat(zakaznik);
                        Console.WriteLine("Zákazník byl úspěšně smazán.");
                    }
                    else
                    {
                        Console.WriteLine("Zákazník s daným ID nebyl nalezen.");
                    }
                })));
            m.Add(new MenuItem("Zobrazit všechny zákazníky",
                new Action(() =>
                {
                    foreach (var zakaznik in zakaznikDAO.Vsechny())
                    {
                        Console.WriteLine($"ID: {zakaznik.ID}, Jméno: {zakaznik.Jmeno}, Adresa: {zakaznik.Adresa}, Telefonní číslo: {zakaznik.TelefonCislo}");
                    }
                })));
            m.Add(new MenuItem("Zobrazit zákazníka podle ID",
                new Action(() =>
                {
                    Console.WriteLine("Zadejte ID zákazníka:");
                    int id = int.Parse(Console.ReadLine());
                    Zakaznik zakaznik = zakaznikDAO.PodleID(id);
                    if (zakaznik != null)
                    {
                        Console.WriteLine($"ID: {zakaznik.ID}, Jméno: {zakaznik.Jmeno}, Adresa: {zakaznik.Adresa}, Telefonní číslo: {zakaznik.TelefonCislo}");
                    }
                    else
                    {
                        Console.WriteLine("Zákazník s daným ID nebyl nalezen.");
                    }
                })));
            return m;
        }

        private Menu DodavatelMenu()
        {
            Menu m = new Menu("Vyber akci pro dodavatele: ");
            DodavatelDAO dodavatelDAO = new DodavatelDAO();
            m.Add(new MenuItem("Přidat dodavatele",
                new Action(() =>
                {
                    Console.WriteLine("Zadejte jméno dodavatele:");
                    string jmeno = Console.ReadLine();
                    Console.WriteLine("Zadejte adresu dodavatele:");
                    string adresa = Console.ReadLine();
                    Console.WriteLine("Zadejte telefonní číslo dodavatele:");
                    string telefonCislo = Console.ReadLine();
                    dodavatelDAO.Vlozit(jmeno, adresa, telefonCislo);
                })));
            m.Add(new MenuItem("Vymazat dodavatele",
                new Action(() =>
                {
                    Console.WriteLine("Zadejte ID dodavatele k vymazání:");
                    int id = int.Parse(Console.ReadLine());
                    Dodavatel dodavatel = dodavatelDAO.PodleID(id);
                    if (dodavatel != null)
                    {
                        dodavatelDAO.Smazat(dodavatel);
                        Console.WriteLine("Dodavatel byl úspěšně smazán.");
                    }
                    else
                    {
                        Console.WriteLine("Dodavatel s daným ID nebyl nalezen.");
                    }
                })));
            m.Add(new MenuItem("Zobrazit všechny dodavatele",
                new Action(() =>
                {
                    foreach (var dodavatel in dodavatelDAO.Vsechny())
                    {
                        Console.WriteLine($"ID: {dodavatel.ID}, Jméno: {dodavatel.Jmeno}, Adresa: {dodavatel.Adresa}, Telefonní číslo: {dodavatel.TelefonCislo}");
                    }
                })));
            m.Add(new MenuItem("Zobrazit dodavatele podle ID",
                new Action(() =>
                {
                    Console.WriteLine("Zadejte ID dodavatele:");
                    int id = int.Parse(Console.ReadLine());
                    Dodavatel dodavatel = dodavatelDAO.PodleID(id);
                    if (dodavatel != null)
                    {
                        Console.WriteLine($"ID: {dodavatel.ID}, Jméno: {dodavatel.Jmeno}, Adresa: {dodavatel.Adresa}, Telefonní číslo: {dodavatel.TelefonCislo}");
                    }
                    else
                    {
                        Console.WriteLine("Dodavatel s daným ID nebyl nalezen.");
                    }
                })));
            return m;
        }


    }
}
