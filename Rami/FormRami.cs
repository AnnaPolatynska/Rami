using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Rami
{
    public partial class FormRami : Form
    {
        private enum _enum { start, nowy, otwarty, zapisJako, zapisz, zamknij };    //czynności
        private int _czynnosc;                                                      //rejestruje wykonaną czyność

        private nsDane.dane _dane;                                                  //zapis i odczyt danych z pliku xml
        private string _plik = string.Empty;                                        //plik zapisu i odczytu danych

        private string _suma0;  // suma wartości zamienionych na znaki na poczatku;

        //private ToolTip[] _podpowiedzi = new ToolTip [0];                           //podpowiedzi dla niektórych formantów

        private string _helpFile = Application.StartupPath + "\\RamiHelp.chm";      //plik pomocy bezpośredniej po polsku
        private string _helpFileA = Application.StartupPath + "\\RamiHelpA.chm";  //plik pomocy bezpośredniej po angielsku
        private ToolTip _tt = new ToolTip();

        private class Tlumacz
        {
            private string[] _pls = new string[0];  // tablica słów polskich
            private string[] _ens = new string[0];  //angielskich
            private bool _isEn; //jesli true to angielska wersja językowa

            /// <summary>
            /// Konstruktor
            /// </summary>
            /// <param name="isEn">Czy język angielski - tak jeśli true.</param>
            public Tlumacz(bool isEn)
            {
                _isEn = isEn;

                //Menu 
                dodaj("&Nowy", ref _pls);
                dodaj("&New", ref _ens);
                dodaj("&Otwórz", ref _pls);
                dodaj("&Open", ref _ens);
                dodaj("&Zapisz", ref _pls);
                dodaj("&Save", ref _ens);
                dodaj("Zapisz &jako", ref _pls);
                dodaj("Save &as", ref _ens);
                dodaj("&Sprawdź", ref _pls);
                dodaj("&Check", ref _ens);
                dodaj("Zam&knij", ref _pls);
                dodaj("Clo&se", ref _ens);
                dodaj("&Pomoc", ref _pls);
                dodaj("&Help", ref _ens);
                dodaj("&O programie", ref _pls);
                dodaj("&About", ref _ens);
                dodaj("Język", ref _pls);
                dodaj("Language", ref _ens);

                // ToolTipText
                dodaj("Nowe dane", ref _pls);
                dodaj("New data", ref _ens);
                dodaj("Otwiera plik danych", ref _pls);
                dodaj("Open data file", ref _ens);
                dodaj("Zapisuje plik", ref _pls);
                dodaj("Save file", ref _ens);
                dodaj("Zapisuje plik z nazwą", ref _pls);
                dodaj("Save file as", ref _ens);
                dodaj("Sprawdza dane", ref _pls);
                dodaj("Check data", ref _ens);
                dodaj("Zamyka dane", ref _pls);
                dodaj("Close data", ref _ens);
                dodaj("Pomoc bezpośrednia", ref _pls);
                dodaj("Direct help", ref _ens);
                dodaj("O Rami", ref _pls);
                dodaj("About Rami", ref _ens);
                dodaj("Wersja językowa", ref _pls);
                dodaj("Language version", ref _ens);

                //zakładki Przyrząd/ Słowniki/ Relacje
                dodaj("Przyrząd", ref _pls);
                dodaj("Instrument", ref _ens);
                dodaj("Słowniki", ref _pls);
                dodaj("Dictionaries", ref _ens);
                dodaj("Relacje", ref _pls);
                dodaj("Relations", ref _ens);

                //zakładka Przyrząd label
                dodaj("Nazwa:", ref _pls);
                dodaj("Name:", ref _ens);
                dodaj("Opis:", ref _pls);
                dodaj("Description:", ref _ens);

                //zakładka Słowniki -> "Regulacje / Aktywa" / Wł.ochrony / Zagrożenie / Ataki / Wykonawcy
                dodaj("Regulacje / Aktywa", ref _pls);
                dodaj("Regulations / Assets", ref _ens);
                dodaj("Wł. ochrony", ref _pls);
                dodaj("Security properties", ref _ens);
                dodaj("Zagrożenia", ref _pls);
                dodaj("Threats", ref _ens);
                dodaj("Ataki", ref _pls);
                dodaj("Attacks", ref _ens);
                dodaj("Wykonawcy", ref _pls);
                dodaj("Attackers", ref _ens);

                //zakładka Słowniki-> Regulacje/Aktywa
                dodaj("Regulacja 1", ref _pls);
                dodaj("Regulation 1", ref _ens);
                dodaj("Regulacja 2", ref _pls);
                dodaj("Regulation 2", ref _ens);
                dodaj("Regulacja 3", ref _pls);
                dodaj("Regulation 3", ref _ens);
                dodaj("Regulacja 4", ref _pls);
                dodaj("Regulation 4", ref _ens);
                dodaj("Regulacja 5", ref _pls);
                dodaj("Regulation 5", ref _ens);
                dodaj("Regulacja 6", ref _pls);
                dodaj("Regulation 6", ref _ens);
                dodaj("Regulacja 7", ref _pls);
                dodaj("Regulation 7", ref _ens);
                dodaj("Regulacja 8", ref _pls);
                dodaj("Regulation 8", ref _ens);
                dodaj("Regulacja 9", ref _pls);
                dodaj("Regulation 9", ref _ens);
                dodaj("Regulacja 10", ref _pls);
                dodaj("Regulation 10", ref _ens);
                dodaj("Aktywa 1", ref _pls);
                dodaj("Assets 1", ref _ens);
                dodaj("Aktywa 2", ref _pls);
                dodaj("Assets 2", ref _ens);
                dodaj("Aktywa 3", ref _pls);
                dodaj("Assets 3", ref _ens);
                dodaj("Aktywa 4", ref _pls);
                dodaj("Assets 4", ref _ens);
                dodaj("Aktywa 5", ref _pls);
                dodaj("Assets 5", ref _ens);
                dodaj("Aktywa 6", ref _pls);
                dodaj("Assets 6", ref _ens);
                dodaj("Aktywa 7", ref _pls);
                dodaj("Assets 7", ref _ens);
                dodaj("Aktywa 8", ref _pls);
                dodaj("Assets 8", ref _ens);
                dodaj("Aktywa 9", ref _pls);
                dodaj("Assets 9", ref _ens);
                dodaj("Aktywa 10", ref _pls);
                dodaj("Assets 10", ref _ens);
                // wpływ wartości dynamicznie zmieniające się
                dodaj("Wpływ: ", ref _pls);
                dodaj("Impact: ", ref _ens);

                //zakładka Słowniki -> Wł.ochrony
                dodaj("Ochrona 1", ref _pls);
                dodaj("Security 1", ref _ens);
                dodaj("Ochrona 2", ref _pls);
                dodaj("Security 2", ref _ens);
                dodaj("Ochrona 3", ref _pls);
                dodaj("Security 3", ref _ens);
                dodaj("Ochrona 4", ref _pls);
                dodaj("Security 4", ref _ens);
                dodaj("Ochrona 5", ref _pls);
                dodaj("Security 5", ref _ens);
                dodaj("Ochrona 6", ref _pls);
                dodaj("Security 6", ref _ens);
                dodaj("Ochrona 7", ref _pls);
                dodaj("Security 7", ref _ens);
                dodaj("Ochrona 8", ref _pls);
                dodaj("Security 8", ref _ens);
                dodaj("Ochrona 9", ref _pls);
                dodaj("Security 9", ref _ens);
                dodaj("Ochrona 10", ref _pls);
                dodaj("Security 10", ref _ens);

                //zakładka Słowniki -> Zagrożenie
                dodaj("Zagrożenie 1", ref _pls);
                dodaj("Threat 1", ref _ens);
                dodaj("Zagrożenie 2", ref _pls);
                dodaj("Threat 2", ref _ens);
                dodaj("Zagrożenie 3", ref _pls);
                dodaj("Threat 3", ref _ens);
                dodaj("Zagrożenie 4", ref _pls);
                dodaj("Threat 4", ref _ens);
                dodaj("Zagrożenie 5", ref _pls);
                dodaj("Threat 5", ref _ens);
                dodaj("Zagrożenie 6", ref _pls);
                dodaj("Threat 6", ref _ens);
                dodaj("Zagrożenie 7", ref _pls);
                dodaj("Threat 7", ref _ens);
                dodaj("Zagrożenie 8", ref _pls);
                dodaj("Threat 8", ref _ens);
                dodaj("Zagrożenie 9", ref _pls);
                dodaj("Threat 9", ref _ens);
                dodaj("Zagrożenie 10", ref _pls);
                dodaj("Threat 10", ref _ens);

                //zakładka Słowniki -> Ataki
                dodaj("Atak 1", ref _pls);
                dodaj("Attack 1", ref _ens);
                dodaj("Atak 2", ref _pls);
                dodaj("Attack 2", ref _ens);
                dodaj("Atak 3", ref _pls);
                dodaj("Attack 3", ref _ens);
                dodaj("Atak 4", ref _pls);
                dodaj("Attack 4", ref _ens);
                dodaj("Atak 5", ref _pls);
                dodaj("Attack 5", ref _ens);
                dodaj("Atak 6", ref _pls);
                dodaj("Attack 6", ref _ens);
                dodaj("Atak 7", ref _pls);
                dodaj("Attack 7", ref _ens);
                dodaj("Atak 8", ref _pls);
                dodaj("Attack 8", ref _ens);
                dodaj("Atak 9", ref _pls);
                dodaj("Attack 9", ref _ens);
                dodaj("Atak 10", ref _pls);
                dodaj("Attack 10", ref _ens);

                //zakładka Słowniki -> Wykonawcy
                dodaj("Wykonawca 1", ref _pls);
                dodaj("Attacker 1", ref _ens);
                dodaj("Wykonawca 2", ref _pls);
                dodaj("Attacker 2", ref _ens);
                dodaj("Wykonawca 3", ref _pls);
                dodaj("Attacker 3", ref _ens);
                dodaj("Wykonawca 4", ref _pls);
                dodaj("Attacker 4", ref _ens);
                dodaj("Wykonawca 5", ref _pls);
                dodaj("Attacker 5", ref _ens);
                dodaj("Wykonawca 6", ref _pls);
                dodaj("Attacker 6", ref _ens);
                dodaj("Wykonawca 7", ref _pls);
                dodaj("Attacker 7", ref _ens);
                dodaj("Wykonawca 8", ref _pls);
                dodaj("Attacker 8", ref _ens);
                dodaj("Wykonawca 9", ref _pls);
                dodaj("Attacker 9", ref _ens);
                dodaj("Wykonawca 10", ref _pls);
                dodaj("Attacker 10", ref _ens);

                //zakładki Relacje-> Regulacja-Aktywa / Aktywa-Wł.ochrony / Atak-Aktywa / Atak-Zagrożenie / Atak-Wykonawca / Atak-Ryzyko
                dodaj("Regulacja-Aktywa", ref _pls);
                dodaj("Regulation-Assets", ref _ens);
                dodaj("Aktywa-Wł.ochrony", ref _pls);
                dodaj("Assets-Security properties", ref _ens);
                dodaj("Atak-Aktywa", ref _pls);
                dodaj("Attack-Assets", ref _ens);
                dodaj("Atak-Zagrożenie", ref _pls);
                dodaj("Attack-Threat", ref _ens);
                dodaj("Atak-Wykonawca", ref _pls);
                dodaj("Attack-Attacker", ref _ens);
                dodaj("Atak-Ryzyko", ref _pls);
                dodaj("Attack-Risk", ref _ens);

                //zakładki Relacje->Regulacja-Aktywa-> Regulacja 1-Aktywa / ... / Regulacja 10-Aktywa
                dodaj("Regulacja 1-Aktywa", ref _pls);
                dodaj("Regulation 1-Assets", ref _ens);
                dodaj("Regulacja 2-Aktywa", ref _pls);
                dodaj("Regulation 2-Assets", ref _ens);
                dodaj("Regulacja 3-Aktywa", ref _pls);
                dodaj("Regulation 3-Assets", ref _ens);
                dodaj("Regulacja 4-Aktywa", ref _pls);
                dodaj("Regulation 4-Assets", ref _ens);
                dodaj("Regulacja 5-Aktywa", ref _pls);
                dodaj("Regulation 5-Assets", ref _ens);
                dodaj("Regulacja 6-Aktywa", ref _pls);
                dodaj("Regulation 6-Assets", ref _ens);
                dodaj("Regulacja 7-Aktywa", ref _pls);
                dodaj("Regulation 7-Assets", ref _ens);
                dodaj("Regulacja 8-Aktywa", ref _pls);
                dodaj("Regulation 8-Assets", ref _ens);
                dodaj("Regulacja 9-Aktywa", ref _pls);
                dodaj("Regulation 9-Assets", ref _ens);
                dodaj("Regulacja 10-Aktywa", ref _pls);
                dodaj("Regulation 10-Assets", ref _ens);

                dodaj("Regulacja 1", ref _pls);
                dodaj("Regulation 1", ref _ens);
                dodaj("Regulacja 2", ref _pls);
                dodaj("Regulation 2", ref _ens);
                dodaj("Regulacja 3", ref _pls);
                dodaj("Regulation 3", ref _ens);
                dodaj("Regulacja 4", ref _pls);
                dodaj("Regulation 4", ref _ens);
                dodaj("Regulacja 5", ref _pls);
                dodaj("Regulation 5", ref _ens);
                dodaj("Regulacja 6", ref _pls);
                dodaj("Regulation 6", ref _ens);
                dodaj("Regulacja 7", ref _pls);
                dodaj("Regulation 7", ref _ens);
                dodaj("Regulacja 8", ref _pls);
                dodaj("Regulation 8", ref _ens);
                dodaj("Regulacja 9", ref _pls);
                dodaj("Regulation 9", ref _ens);
                dodaj("Regulacja 10", ref _pls);
                dodaj("Regulation 10", ref _ens);

                //zakładki Relacje->Aktywa-Wł.ochrony-> Aktywa 1-Wł.ochrony / ... / Aktywa 10-Wł.ochrony
                dodaj("Aktywa 1-Wł.ochrony", ref _pls);
                dodaj("Assets 1-Security properties", ref _ens);
                dodaj("Aktywa 2-Wł.ochrony", ref _pls);
                dodaj("Assets 2-Security properties", ref _ens);
                dodaj("Aktywa 3-Wł.ochrony", ref _pls);
                dodaj("Assets 3-Security properties", ref _ens);
                dodaj("Aktywa 4-Wł.ochrony", ref _pls);
                dodaj("Assets 4-Security properties", ref _ens);
                dodaj("Aktywa 5-Wł.ochrony", ref _pls);
                dodaj("Assets 5-Security properties", ref _ens);
                dodaj("Aktywa 6-Wł.ochrony", ref _pls);
                dodaj("Assets 6-Security properties", ref _ens);
                dodaj("Aktywa 7-Wł.ochrony", ref _pls);
                dodaj("Assets 7-Security properties", ref _ens);
                dodaj("Aktywa 8-Wł.ochrony", ref _pls);
                dodaj("Assets 8-Security properties", ref _ens);
                dodaj("Aktywa 9-Wł.ochrony", ref _pls);
                dodaj("Assets 9-Security properties", ref _ens);
                dodaj("Aktywa 10-Wł.ochrony", ref _pls);
                dodaj("Assets 10-Security properties", ref _ens);

                //zakładki Relacje->Atak-Aktywa-> Atak 1-Aktywa / ... / Atak 10-Aktywa
                dodaj("Atak 1-Aktywa", ref _pls);
                dodaj("Attack 1-Assets", ref _ens);
                dodaj("Atak 2-Aktywa", ref _pls);
                dodaj("Attack 2-Assets", ref _ens);
                dodaj("Atak 3-Aktywa", ref _pls);
                dodaj("Attack 3-Assets", ref _ens);
                dodaj("Atak 4-Aktywa", ref _pls);
                dodaj("Attack 4-Assets", ref _ens);
                dodaj("Atak 5-Aktywa", ref _pls);
                dodaj("Attack 5-Assets", ref _ens);
                dodaj("Atak 6-Aktywa", ref _pls);
                dodaj("Attack 6-Assets", ref _ens);
                dodaj("Atak 7-Aktywa", ref _pls);
                dodaj("Attack 7-Assets", ref _ens);
                dodaj("Atak 8-Aktywa", ref _pls);
                dodaj("Attack 8-Assets", ref _ens);
                dodaj("Atak 9-Aktywa", ref _pls);
                dodaj("Attack 9-Assets", ref _ens);
                dodaj("Atak 10-Aktywa", ref _pls);
                dodaj("Attack 10-Assets", ref _ens);

                //zakładki Relacje-> Atak -Zagrożenie-> Atak 1-Zagrożenie / ... / Atak 10-Zagrożenie
                dodaj("Atak 1-Zagrożenie", ref _pls);
                dodaj("Attack 1-Threat", ref _ens);
                dodaj("Atak 2-Zagrożenie", ref _pls);
                dodaj("Attack 2-Threat", ref _ens);
                dodaj("Atak 3-Zagrożenie", ref _pls);
                dodaj("Attack 3-Threat", ref _ens);
                dodaj("Atak 4-Zagrożenie", ref _pls);
                dodaj("Attack 4-Threat", ref _ens);
                dodaj("Atak 5-Zagrożenie", ref _pls);
                dodaj("Attack 5-Threat", ref _ens);
                dodaj("Atak 6-Zagrożenie", ref _pls);
                dodaj("Attack 6-Threat", ref _ens);
                dodaj("Atak 7-Zagrożenie", ref _pls);
                dodaj("Attack 7-Threat", ref _ens);
                dodaj("Atak 8-Zagrożenie", ref _pls);
                dodaj("Attack 8-Threat", ref _ens);
                dodaj("Atak 9-Zagrożenie", ref _pls);
                dodaj("Attack 9-Threat", ref _ens);
                dodaj("Atak 10-Zagrożenie", ref _pls);
                dodaj("Attack 10-Threat", ref _ens);

                //zakładki Relacje-> Atak -Wykonawca-> Atak 1-Wykonawca / ... / Atak 10-Wykonawca
                dodaj("Atak 1-Wykonawca", ref _pls);
                dodaj("Attack 1-Attacker", ref _ens);
                dodaj("Atak 2-Wykonawca", ref _pls);
                dodaj("Attack 2-Attacker", ref _ens);
                dodaj("Atak 3-Wykonawca", ref _pls);
                dodaj("Attack 3-Attacker", ref _ens);
                dodaj("Atak 4-Wykonawca", ref _pls);
                dodaj("Attack 4-Attacker", ref _ens);
                dodaj("Atak 5-Wykonawca", ref _pls);
                dodaj("Attack 5-Attacker", ref _ens);
                dodaj("Atak 6-Wykonawca", ref _pls);
                dodaj("Attack 6-Attacker", ref _ens);
                dodaj("Atak 7-Wykonawca", ref _pls);
                dodaj("Attack 7-Attacker", ref _ens);
                dodaj("Atak 8-Wykonawca", ref _pls);
                dodaj("Attack 8-Attacker", ref _ens);
                dodaj("Atak 9-Wykonawca", ref _pls);
                dodaj("Attack 9-Attacker", ref _ens);
                dodaj("Atak 10-Wykonawca", ref _pls);
                dodaj("Attack 10-Attacker", ref _ens);

                //zakładki Relacje-> Atak -Ryzyko-> Atak 1-Ryzyko / ... / Atak 10-Ryzyko
                dodaj("Atak 1-Ryzyko", ref _pls);
                dodaj("Attack 1-Risk", ref _ens);
                dodaj("Atak 2-Ryzyko", ref _pls);
                dodaj("Attack 2-Risk", ref _ens);
                dodaj("Atak 3-Ryzyko", ref _pls);
                dodaj("Attack 3-Risk", ref _ens);
                dodaj("Atak 4-Ryzyko", ref _pls);
                dodaj("Attack 4-Risk", ref _ens);
                dodaj("Atak 5-Ryzyko", ref _pls);
                dodaj("Attack 5-Risk", ref _ens);
                dodaj("Atak 6-Ryzyko", ref _pls);
                dodaj("Attack 6-Risk", ref _ens);
                dodaj("Atak 7-Ryzyko", ref _pls);
                dodaj("Attack 7-Risk", ref _ens);
                dodaj("Atak 8-Ryzyko", ref _pls);
                dodaj("Attack 8-Risk", ref _ens);
                dodaj("Atak 9-Ryzyko", ref _pls);
                dodaj("Attack 9-Risk", ref _ens);
                dodaj("Atak 10-Ryzyko", ref _pls);
                dodaj("Attack 10-Risk", ref _ens);

                //tłumaczenia dla wartości dynamicznie zmieniających się
                dodaj("Czas: ", ref _pls);
                dodaj("Time: ", ref _ens);
                dodaj("Kwalifikacje: ", ref _pls);
                dodaj("Qualifications: ", ref _ens);
                dodaj("Wiedza: ", ref _pls);
                dodaj("Knowledge: ", ref _ens);
                dodaj("Wyposażenie: ", ref _pls);
                dodaj("Equipment: ", ref _ens);
                dodaj("Dostęp: ", ref _pls);
                dodaj("Access: ", ref _ens);
                dodaj("Ryzyko: ", ref _pls);
                dodaj("Risk: ", ref _ens);

                dodaj("<= dzień", ref _pls);
                dodaj("<= day", ref _ens);
                dodaj("<= tydz.", ref _pls);
                dodaj("<= week", ref _ens);
                dodaj("<= 2 tyg.", ref _pls);
                dodaj("<= 2 weeks", ref _ens);
                dodaj("<= mies.", ref _pls);
                dodaj("<= month", ref _ens);
                dodaj("<= 2 mies.", ref _pls);
                dodaj("<= 2 months", ref _ens);
                dodaj("<= 3 mies.", ref _pls);
                dodaj("<= 3 months", ref _ens);
                dodaj("<= 4 mies.", ref _pls);
                dodaj("<= 4 months", ref _ens);
                dodaj("<= 5 mies.", ref _pls);
                dodaj("<= 5 months", ref _ens);
                dodaj("<= 6 mies.", ref _pls);
                dodaj("<= 6 months", ref _ens);
                dodaj("> 6 mies.", ref _pls);
                dodaj("> 6 months", ref _ens);

                dodaj("Laik", ref _pls);
                dodaj("Layman", ref _ens);
                dodaj("Biegły", ref _pls);
                dodaj("Proficient", ref _ens);
                dodaj("Ekspert", ref _pls);
                dodaj("Expert", ref _ens);
                dodaj("Ekspert kilku dziedzin", ref _pls);
                dodaj("An expert in several fields of science", ref _ens);

                dodaj("Publiczna", ref _pls);
                dodaj("Public", ref _ens);
                dodaj("Ograniczona", ref _pls);
                dodaj("Restricted", ref _ens);
                dodaj("Wrażliwa", ref _pls);
                dodaj("Sensitive", ref _ens);
                dodaj("Krytyczna", ref _pls);
                dodaj("Critical", ref _ens);

                dodaj("Standardowe", ref _pls);
                dodaj("Standard", ref _ens);
                dodaj("Specjalistyczne", ref _pls);
                dodaj("Specialistic", ref _ens);
                dodaj("Na zamówienie", ref _pls);
                dodaj("To order", ref _ens);
                dodaj("Wielokrotne zamówienie", ref _pls);
                dodaj("Multiple order", ref _ens);

                dodaj("Nieograniczony", ref _pls);
                dodaj("Unlimited", ref _ens);
                dodaj("Łatwy", ref _pls);
                dodaj("Easy", ref _ens);
                dodaj("Umiarkowany", ref _pls);
                dodaj("Standard", ref _ens);
                dodaj("Trudny", ref _pls);
                dodaj("Difficult ", ref _ens);

                //tłumaczenia dla tekstu podpowiedzi
                dodaj("Treść regulacji prawnej, przepisu, normy, ...", ref _pls);
                dodaj("Content of legal regulation, provision, norm, ...", ref _ens);
                dodaj("Wpływ regulacji prawnej, przepisu, normy, ...", ref _pls);
                dodaj("Impact of legal regulation, provision, norm, ...", ref _ens);
                dodaj("Aktywa - wartość podlegająca ochronie.", ref _pls);
                dodaj("Assets - protected value.", ref _ens);
                dodaj("Czas potrzebny do realizacji ataku.", ref _pls);
                dodaj("Time needed to implement the attack.", ref _ens);
                dodaj("Wymagane kwalifikacje merytoryczne agresora do realizacji ataku.", ref _pls);
                dodaj("requred professional qualifications of the aggressor needed to implement the attack.", ref _ens);
                dodaj("Wiedza na temat przyrządu pomiarowego jaką powinien dysponować agresor.", ref _pls);
                dodaj("Knowledge about the measuring instrument that should be available to an aggressor.", ref _ens);
                dodaj("Środki techniczne wymagane do realizacji ataku.", ref _pls);
                dodaj("Technical measures required to implement the attack.", ref _ens);
                dodaj("Wskaźnik ograniczeń dostępu do przyrządu dla agresora.", ref _pls);
                dodaj("Indicator of instrument access restriction for the aggressor.", ref _ens);
                dodaj("Ryzyko realizacji ataku w skali 1...5.", ref _pls);
                dodaj("Risk of attack on a scale of 1 to 5.", ref _ens);

                // czynności związane z zapisem zmian
                dodaj("Czy zapisać zmiany?", ref _pls);
                dodaj("Do you want to save changes?", ref _ens);

                dodaj("Brak regulacji.", ref _pls);
                dodaj("There is no regulation", ref _ens);
                dodaj("Brak aktywa.", ref _pls);
                dodaj("There is no asset", ref _ens);
                dodaj("Brak własności ochrony.", ref _pls);
                dodaj("There is no security properties", ref _ens);
                dodaj("Brak szkody.", ref _pls);
                dodaj("There is no loss", ref _ens);
                dodaj("Brak ataku.", ref _pls);
                dodaj("There is no attack", ref _ens);
                dodaj("Brak wykonawcy ataku.", ref _pls);
                dodaj("There is no Attacker", ref _ens);

                dodaj("Regulacja 1 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Regulation 1 has no assets assigned.", ref _ens);
                dodaj("Regulacja 2 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Regulation 2 has no assets assigned.", ref _ens);
                dodaj("Regulacja 3 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Regulation 3 has no assets assigned.", ref _ens);
                dodaj("Regulacja 4 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Regulation 4 has no assets assigned.", ref _ens);
                dodaj("Regulacja 5 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Regulation 5 has no assets assigned.", ref _ens);
                dodaj("Regulacja 6 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Regulation 6 has no assets assigned.", ref _ens);
                dodaj("Regulacja 7 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Regulation 7 has no assets assigned.", ref _ens);
                dodaj("Regulacja 8 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Regulation 8 has no assets assigned.", ref _ens);
                dodaj("Regulacja 9 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Regulation 9 has no assets assigned.", ref _ens);
                dodaj("Regulacja 10 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Regulation 10 has no assets assigned.", ref _ens);

                dodaj("Aktywa 1 nie ma przypisanych własności ochrony.", ref _pls);
                dodaj("Asset 1 has no security properties assigned", ref _ens);
                dodaj("Aktywa 2 nie ma przypisanych własności ochrony.", ref _pls);
                dodaj("Asset 2 has no security properties assigned", ref _ens);
                dodaj("Aktywa 3 nie ma przypisanych własności ochrony.", ref _pls);
                dodaj("Asset 3 has no security properties assigned", ref _ens);
                dodaj("Aktywa 4 nie ma przypisanych własności ochrony.", ref _pls);
                dodaj("Asset 4 has no security properties assigned", ref _ens);
                dodaj("Aktywa 5 nie ma przypisanych własności ochrony.", ref _pls);
                dodaj("Asset 5 has no security properties assigned", ref _ens);
                dodaj("Aktywa 6 nie ma przypisanych własności ochrony.", ref _pls);
                dodaj("Asset 6 has no security properties assigned", ref _ens);
                dodaj("Aktywa 7 nie ma przypisanych własności ochrony.", ref _pls);
                dodaj("Asset 7 has no security properties assigned", ref _ens);
                dodaj("Aktywa 8 nie ma przypisanych własności ochrony.", ref _pls);
                dodaj("Asset 8 has no security properties assigned", ref _ens);
                dodaj("Aktywa 9 nie ma przypisanych własności ochrony.", ref _pls);
                dodaj("Asset 9 has no security properties assigned", ref _ens);
                dodaj("Aktywa 10 nie ma przypisanych własności ochrony.", ref _pls);
                dodaj("Asset 10 has no security properties assigned", ref _ens);

                dodaj("Atak 1 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Attack 1 has no assets assigned.", ref _ens);
                dodaj("Atak 2 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Attack 2 has no assets assigned.", ref _ens);
                dodaj("Atak 3 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Attack 3 has no assets assigned.", ref _ens);
                dodaj("Atak 4 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Attack 4 has no assets assigned.", ref _ens);
                dodaj("Atak 5 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Attack 5 has no assets assigned.", ref _ens);
                dodaj("Atak 6 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Attack 6 has no assets assigned.", ref _ens);
                dodaj("Atak 7 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Attack 7 has no assets assigned.", ref _ens);
                dodaj("Atak 8 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Attack 8 has no assets assigned.", ref _ens);
                dodaj("Atak 9 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Attack 9 has no assets assigned.", ref _ens);
                dodaj("Atak 10 nie ma przypisanych aktywów.", ref _pls);
                dodaj("Attack 10 has no assets assigned.", ref _ens);

                dodaj("Atak 1 nie ma przypisanych zagrożeń.", ref _pls);
                dodaj("Attack 1 has no threats assigned.", ref _ens);
                dodaj("Atak 2 nie ma przypisanych zagrożeń.", ref _pls);
                dodaj("Attack 2 has no threats assigned.", ref _ens);
                dodaj("Atak 3 nie ma przypisanych zagrożeń.", ref _pls);
                dodaj("Attack 3 has no threats assigned.", ref _ens);
                dodaj("Atak 4 nie ma przypisanych zagrożeń.", ref _pls);
                dodaj("Attack 4 has no threats assigned.", ref _ens);
                dodaj("Atak 5 nie ma przypisanych zagrożeń.", ref _pls);
                dodaj("Attack 5 has no threats assigned.", ref _ens);
                dodaj("Atak 6 nie ma przypisanych zagrożeń.", ref _pls);
                dodaj("Attack 6 has no threats assigned.", ref _ens);
                dodaj("Atak 7 nie ma przypisanych zagrożeń.", ref _pls);
                dodaj("Attack 7 has no threats assigned.", ref _ens);
                dodaj("Atak 8 nie ma przypisanych zagrożeń.", ref _pls);
                dodaj("Attack 8 has no threats assigned.", ref _ens);
                dodaj("Atak 9 nie ma przypisanych zagrożeń.", ref _pls);
                dodaj("Attack 9 has no threats assigned.", ref _ens);
                dodaj("Atak 10 nie ma przypisanych zagrożeń.", ref _pls);
                dodaj("Attack 10 has no threats assigned.", ref _ens);

                dodaj("Atak 1 nie ma przypisanych wykonawców.", ref _pls);
                dodaj("Attack 1 has no attacker assigned.", ref _ens);
                dodaj("Atak 2 nie ma przypisanych wykonawców.", ref _pls);
                dodaj("Attack 2 has no attacker assigned.", ref _ens);
                dodaj("Atak 3 nie ma przypisanych wykonawców.", ref _pls);
                dodaj("Attack 3 has no attacker assigned.", ref _ens);
                dodaj("Atak 4 nie ma przypisanych wykonawców.", ref _pls);
                dodaj("Attack 4 has no attacker assigned.", ref _ens);
                dodaj("Atak 5 nie ma przypisanych wykonawców.", ref _pls);
                dodaj("Attack 5 has no attacker assigned.", ref _ens);
                dodaj("Atak 6 nie ma przypisanych wykonawców.", ref _pls);
                dodaj("Attack 6 has no attacker assigned.", ref _ens);
                dodaj("Atak 7 nie ma przypisanych wykonawców.", ref _pls);
                dodaj("Attack 7 has no attacker assigned.", ref _ens);
                dodaj("Atak 8 nie ma przypisanych wykonawców.", ref _pls);
                dodaj("Attack 8 has no attacker assigned.", ref _ens);
                dodaj("Atak 9 nie ma przypisanych wykonawców.", ref _pls);
                dodaj("Attack 9 has no attacker assigned.", ref _ens);
                dodaj("Atak 10 nie ma przypisanych wykonawców.", ref _pls);
                dodaj("Attack 10 has no attacker assigned.", ref _ens);

                dodaj("Aktywa 1 nie występują w żadnej regulacji.", ref _pls);
                dodaj("Assets 1 do not appear in any regulation.", ref _ens);
                dodaj("Aktywa 2 nie występują w żadnej regulacji.", ref _pls);
                dodaj("Assets 2 do not appear in any regulation.", ref _ens);
                dodaj("Aktywa 3 nie występują w żadnej regulacji.", ref _pls);
                dodaj("Assets 3 do not appear in any regulation.", ref _ens);
                dodaj("Aktywa 4 nie występują w żadnej regulacji.", ref _pls);
                dodaj("Assets 4 do not appear in any regulation.", ref _ens);
                dodaj("Aktywa 5 nie występują w żadnej regulacji.", ref _pls);
                dodaj("Assets 5 do not appear in any regulation.", ref _ens);
                dodaj("Aktywa 6 nie występują w żadnej regulacji.", ref _pls);
                dodaj("Assets 6 do not appear in any regulation.", ref _ens);
                dodaj("Aktywa 7 nie występują w żadnej regulacji.", ref _pls);
                dodaj("Assets 7 do not appear in any regulation.", ref _ens);
                dodaj("Aktywa 8 nie występują w żadnej regulacji.", ref _pls);
                dodaj("Assets 8 do not appear in any regulation.", ref _ens);
                dodaj("Aktywa 9 nie występują w żadnej regulacji.", ref _pls);
                dodaj("Assets 9 do not appear in any regulation.", ref _ens);
                dodaj("Aktywa 10 nie występują w żadnej regulacji.", ref _pls);
                dodaj("Assets 10 do not appear in any regulation.", ref _ens);

                dodaj("Wlasność 1 nie występuje w żadnym aktywie.", ref _pls);
                dodaj("Property 1 does not exist in any of the assets.", ref _ens);
                dodaj("Wlasność 2 nie występuje w żadnym aktywie.", ref _pls);
                dodaj("Property 2 does not exist in any of the assets.", ref _ens);
                dodaj("Wlasność 3 nie występuje w żadnym aktywie.", ref _pls);
                dodaj("Property 3 does not exist in any of the assets.", ref _ens);
                dodaj("Wlasność 4 nie występuje w żadnym aktywie.", ref _pls);
                dodaj("Property 4 does not exist in any of the assets.", ref _ens);
                dodaj("Wlasność 5 nie występuje w żadnym aktywie.", ref _pls);
                dodaj("Property 5 does not exist in any of the assets.", ref _ens);
                dodaj("Wlasność 6 nie występuje w żadnym aktywie.", ref _pls);
                dodaj("Property 6 does not exist in any of the assets.", ref _ens);
                dodaj("Wlasność 7 nie występuje w żadnym aktywie.", ref _pls);
                dodaj("Property 7 does not exist in any of the assets.", ref _ens);
                dodaj("Wlasność 8 nie występuje w żadnym aktywie.", ref _pls);
                dodaj("Property 8 does not exist in any of the assets.", ref _ens);
                dodaj("Wlasność 9 nie występuje w żadnym aktywie.", ref _pls);
                dodaj("Property 9 does not exist in any of the assets.", ref _ens);
                dodaj("Wlasność 10 nie występuje w żadnym aktywie.", ref _pls);
                dodaj("Property 10 does not exist in any of the assets.", ref _ens);

                dodaj("Zagrożenie 1 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Threat 1 does not occur in any attack.", ref _ens);
                dodaj("Zagrożenie 2 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Threat 2 does not occur in any attack.", ref _ens);
                dodaj("Zagrożenie 3 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Threat 3 does not occur in any attack.", ref _ens);
                dodaj("Zagrożenie 4 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Threat 4 does not occur in any attack.", ref _ens);
                dodaj("Zagrożenie 5 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Threat 5 does not occur in any attack.", ref _ens);
                dodaj("Zagrożenie 6 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Threat 6 does not occur in any attack.", ref _ens);
                dodaj("Zagrożenie 7 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Threat 7 does not occur in any attack.", ref _ens);
                dodaj("Zagrożenie 8 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Threat 8 does not occur in any attack.", ref _ens);
                dodaj("Zagrożenie 9 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Threat 9 does not occur in any attack.", ref _ens);
                dodaj("Zagrożenie 10 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Threat 10 does not occur in any attack.", ref _ens);

                dodaj("Wykonawca 1 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Attacker 1 does not appear in any attack.", ref _ens);
                dodaj("Wykonawca 2 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Attacker 2 does not appear in any attack.", ref _ens);
                dodaj("Wykonawca 3 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Attacker 3 does not appear in any attack.", ref _ens);
                dodaj("Wykonawca 4 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Attacker 4 does not appear in any attack.", ref _ens);
                dodaj("Wykonawca 5 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Attacker 5 does not appear in any attack.", ref _ens);
                dodaj("Wykonawca 6 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Attacker 6 does not appear in any attack.", ref _ens);
                dodaj("Wykonawca 7 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Attacker 7 does not appear in any attack.", ref _ens);
                dodaj("Wykonawca 8 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Attacker 8 does not appear in any attack.", ref _ens);
                dodaj("Wykonawca 9 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Attacker 9 does not appear in any attack.", ref _ens);
                dodaj("Wykonawca 10 nie występuje w żadnym ataku.", ref _pls);
                dodaj("Attacker 10 does not appear in any attack.", ref _ens);

                dodaj("Dane są spójne.", ref _pls);
                dodaj("The data is consistent.", ref _ens);

                dodaj("Zmiany zostały zapisane poprawnie w XML.", ref _pls);
                dodaj("The changes have been saved correctly in XML.", ref _ens);

            }//tlumacz

            /// <summary>
            /// Zamienia tekst polski na angielski.
            /// </summary>
            /// <param name="tekst">Słowo polskie.</param>
            /// <returns>Tłumaczenie angielskie.</returns>
            public string zmien(string tekst)
            {
                for (int i = 0; i < _pls.Length; i++)
                {
                    if (_isEn)
                    {
                        if (_pls[i] == tekst) return _ens[i];
                    }
                    if (!_isEn)
                    {
                        if (_ens[i] == tekst) return _pls[i];           
                    }
                }
                return tekst;
            }//zmien


            /// <summary>
            /// Dodawanie nowej pozycji do tablicy.
            /// </summary>
            /// <param name="tekst">Nowa pozycja.</param>
            /// <param name="tab">Tablica.</param>
            private void dodaj(string tekst, ref string[] tab)
            {
                Array.Resize(ref tab, tab.Length + 1);
                tab[tab.Length - 1] = tekst;
            }//dodaj


            /// <summary>
            /// Ustawia tłumaczenie na angielski.
            /// </summary>
            public bool ustawAng
            {          
                set
                {
                    _isEn = value;
                }
            }

           // public void ustawfAng(bool val)
            //{
            //    _isEn = val;
            //}

        }//class tlumacz


        private Tlumacz _tlumacz = new Tlumacz(true);

        public FormRami()
        {
            InitializeComponent();

        }//FormRami

        private void FormRami_Shown(object sender, EventArgs e)
        {
            toolStripComboBoxJezyk.SelectedIndex = 0;

            ustawWlasnosci();
            ustawDostep();
            ustawPodpowiedzi();

            _suma0 = sumaWartosci();

            pokazTytul();

            _czynnosc = (int)_enum.start;
        }//FormRami_Shown

        /// <summary>
        /// Ustawia podpowiedzi dla niektórych formantów.
        /// </summary>
        private void ustawPodpowiedzi()
        {
            string tt = _tlumacz.zmien("Treść regulacji prawnej, przepisu, normy, ...");
            string bb = _tlumacz.zmien("Wpływ regulacji prawnej, przepisu, normy, ...");
            string cc = _tlumacz.zmien("Aktywa - wartość podlegająca ochronie.");
            string dd = _tlumacz.zmien("Czas potrzebny do realizacji ataku.");
            string ee = _tlumacz.zmien("Wymagane kwalifikacje merytoryczne agresora do realizacji ataku.");
            string ff = _tlumacz.zmien("Wiedza na temat przyrządu pomiarowego jaką powinien dysponować agresor.");
            string gg = _tlumacz.zmien("Środki techniczne wymagane do realizacji ataku.");
            string hh = _tlumacz.zmien("Wskaźnik ograniczeń dostępu do przyrządu dla agresora.");
            string ii = _tlumacz.zmien("Ryzyko realizacji ataku w skali 1...5.");

            //"Treść regulacji prawnej, przepisu, normy, ..."
            ustawPodpowiedz(textBoxRegulacja1, tt);
            ustawPodpowiedz(textBoxRegulacja2, tt);
            ustawPodpowiedz(textBoxRegulacja3, tt);
            ustawPodpowiedz(textBoxRegulacja4, tt);
            ustawPodpowiedz(textBoxRegulacja5, tt);
            ustawPodpowiedz(textBoxRegulacja6, tt);
            ustawPodpowiedz(textBoxRegulacja7, tt);
            ustawPodpowiedz(textBoxRegulacja8, tt);
            ustawPodpowiedz(textBoxRegulacja9, tt);
            ustawPodpowiedz(textBoxRegulacja10, tt);

            //"Wpływ regulacji prawnej, przepisu, normy, ...";
            ustawPodpowiedz(trackBarWplyw1, bb);
            ustawPodpowiedz(trackBarWplyw2, bb);
            ustawPodpowiedz(trackBarWplyw3, bb);
            ustawPodpowiedz(trackBarWplyw4, bb);
            ustawPodpowiedz(trackBarWplyw5, bb);
            ustawPodpowiedz(trackBarWplyw6, bb);
            ustawPodpowiedz(trackBarWplyw7, bb);
            ustawPodpowiedz(trackBarWplyw8, bb);
            ustawPodpowiedz(trackBarWplyw8, bb);
            ustawPodpowiedz(trackBarWplyw10, bb);

            //"Aktywa - wartość podlegająca ochronie."
            ustawPodpowiedz(textBoxAktywa1, cc);
            ustawPodpowiedz(textBoxAktywa2, cc);
            ustawPodpowiedz(textBoxAktywa3, cc);
            ustawPodpowiedz(textBoxAktywa4, cc);
            ustawPodpowiedz(textBoxAktywa5, cc);
            ustawPodpowiedz(textBoxAktywa6, cc);
            ustawPodpowiedz(textBoxAktywa7, cc);
            ustawPodpowiedz(textBoxAktywa8, cc);
            ustawPodpowiedz(textBoxAktywa9, cc);
            ustawPodpowiedz(textBoxAktywa10, cc);

            //"Czas potrzebny do realizacji ataku.";
            ustawPodpowiedz(trackBarCzas1, dd);
            ustawPodpowiedz(trackBarCzas2, dd);
            ustawPodpowiedz(trackBarCzas3, dd);
            ustawPodpowiedz(trackBarCzas4, dd);
            ustawPodpowiedz(trackBarCzas5, dd);
            ustawPodpowiedz(trackBarCzas6, dd);
            ustawPodpowiedz(trackBarCzas7, dd);
            ustawPodpowiedz(trackBarCzas8, dd);
            ustawPodpowiedz(trackBarCzas9, dd);
            ustawPodpowiedz(trackBarCzas10, dd);

            // "Wymagane kwalifikacje merytoryczne agresora do realizacji ataku.")
            ustawPodpowiedz(trackBarKwalifikacje1, ee);
            ustawPodpowiedz(trackBarKwalifikacje2, ee);
            ustawPodpowiedz(trackBarKwalifikacje3, ee);
            ustawPodpowiedz(trackBarKwalifikacje4, ee);
            ustawPodpowiedz(trackBarKwalifikacje5, ee);
            ustawPodpowiedz(trackBarKwalifikacje6, ee);
            ustawPodpowiedz(trackBarKwalifikacje7, ee);
            ustawPodpowiedz(trackBarKwalifikacje8, ee);
            ustawPodpowiedz(trackBarKwalifikacje9, ee);
            ustawPodpowiedz(trackBarKwalifikacje10, ee);

            //"Wiedza na temat przyrządu pomiarowego jaką powinien dysponować agresor."
            ustawPodpowiedz(trackBarWiedza1, ff);
            ustawPodpowiedz(trackBarWiedza2, ff);
            ustawPodpowiedz(trackBarWiedza3, ff);
            ustawPodpowiedz(trackBarWiedza4, ff);
            ustawPodpowiedz(trackBarWiedza5, ff);
            ustawPodpowiedz(trackBarWiedza6, ff);
            ustawPodpowiedz(trackBarWiedza7, ff);
            ustawPodpowiedz(trackBarWiedza8, ff);
            ustawPodpowiedz(trackBarWiedza9, ff);
            ustawPodpowiedz(trackBarWiedza10, ff);

            //"Środki techniczne wymagane do realizacji ataku."
            ustawPodpowiedz(trackBarWyposazenie1, gg);
            ustawPodpowiedz(trackBarWyposazenie2, gg);
            ustawPodpowiedz(trackBarWyposazenie3, gg);
            ustawPodpowiedz(trackBarWyposazenie4, gg);
            ustawPodpowiedz(trackBarWyposazenie5, gg);
            ustawPodpowiedz(trackBarWyposazenie6, gg);
            ustawPodpowiedz(trackBarWyposazenie7, gg);
            ustawPodpowiedz(trackBarWyposazenie8, gg);
            ustawPodpowiedz(trackBarWyposazenie9, gg);
            ustawPodpowiedz(trackBarWyposazenie10, gg);

            //"Wskaźnik ograniczeń dostępu do przyrządu dla agresora."
            ustawPodpowiedz(trackBarDostep1, hh);
            ustawPodpowiedz(trackBarDostep2, hh);
            ustawPodpowiedz(trackBarDostep3, hh);
            ustawPodpowiedz(trackBarDostep4, hh);
            ustawPodpowiedz(trackBarDostep5, hh);
            ustawPodpowiedz(trackBarDostep6, hh);
            ustawPodpowiedz(trackBarDostep7, hh);
            ustawPodpowiedz(trackBarDostep8, hh);
            ustawPodpowiedz(trackBarDostep9, hh);
            ustawPodpowiedz(trackBarDostep10, hh);

            //"Ryzyko realizacji ataku w skali 1...5."
            ustawPodpowiedz(trackBarRyzyko1, ii);
            ustawPodpowiedz(trackBarRyzyko2, ii);
            ustawPodpowiedz(trackBarRyzyko3, ii);
            ustawPodpowiedz(trackBarRyzyko4, ii);
            ustawPodpowiedz(trackBarRyzyko5, ii);
            ustawPodpowiedz(trackBarRyzyko6, ii);
            ustawPodpowiedz(trackBarRyzyko7, ii);
            ustawPodpowiedz(trackBarRyzyko8, ii);
            ustawPodpowiedz(trackBarRyzyko9, ii);
            ustawPodpowiedz(trackBarRyzyko10, ii);


        }//ustawPodpowiedzi

        /// <summary>
        /// Ustawia podpowiedz dla frormantu.
        /// </summary>
        /// <param name="o">Formant.</param>
        /// <param name="tekst">Treść podpowiedzi.</param>
        private void ustawPodpowiedz(object o, string tekst)
        {
            //int i = _podpowiedzi.Length;
            //ToolTip tt = new ToolTip();
            _tt.SetToolTip((Control)o, tekst);
            //Array.Resize(ref _podpowiedzi, _podpowiedzi.Length + 1);
            //_podpowiedzi[i] = tt;
        }//ustawPodpowiedz

        /// <summary>
        /// Ustawia niektore parametry formantów.
        /// </summary>
        private void ustawWlasnosci()
        {


            //tłumacz Menu główne
            nowyToolStripMenuItem.Text = _tlumacz.zmien(nowyToolStripMenuItem.Text);
            otworzToolStripMenuItem.Text = _tlumacz.zmien(otworzToolStripMenuItem.Text);
            zapiszToolStripMenuItem.Text = _tlumacz.zmien(zapiszToolStripMenuItem.Text);
            zapiszJakoToolStripMenuItem.Text = _tlumacz.zmien(zapiszJakoToolStripMenuItem.Text);
            sprawdzToolStripMenuItem.Text = _tlumacz.zmien(sprawdzToolStripMenuItem.Text);
            zamknijToolStripMenuItem.Text = _tlumacz.zmien(zamknijToolStripMenuItem.Text);
            pomocToolStripMenuItem.Text = _tlumacz.zmien(pomocToolStripMenuItem.Text);
            oProgramieToolStripMenuItem.Text = _tlumacz.zmien(oProgramieToolStripMenuItem.Text);
            toolStripComboBoxJezyk.Text = _tlumacz.zmien(toolStripComboBoxJezyk.Text);

            nowyToolStripMenuItem.ToolTipText = _tlumacz.zmien(nowyToolStripMenuItem.ToolTipText);
            otworzToolStripMenuItem.ToolTipText = _tlumacz.zmien(otworzToolStripMenuItem.ToolTipText);
            zapiszToolStripMenuItem.ToolTipText = _tlumacz.zmien(zapiszToolStripMenuItem.ToolTipText);
            zapiszJakoToolStripMenuItem.ToolTipText = _tlumacz.zmien(zapiszJakoToolStripMenuItem.ToolTipText);
            sprawdzToolStripMenuItem.ToolTipText = _tlumacz.zmien(sprawdzToolStripMenuItem.ToolTipText);
            zamknijToolStripMenuItem.ToolTipText = _tlumacz.zmien(zamknijToolStripMenuItem.ToolTipText);
            pomocToolStripMenuItem.ToolTipText = _tlumacz.zmien(pomocToolStripMenuItem.ToolTipText);
            oProgramieToolStripMenuItem.ToolTipText = _tlumacz.zmien(oProgramieToolStripMenuItem.ToolTipText);
            toolStripComboBoxJezyk.ToolTipText = _tlumacz.zmien(toolStripComboBoxJezyk.ToolTipText); // podpowiedz dla wersji językowej

            //tłumacz zakładki Przyrząd/ Slowniki/ Relacje
            tabControl1.TabPages[0].Text = _tlumacz.zmien(tabControl1.TabPages[0].Text);
            tabControl1.TabPages[1].Text = _tlumacz.zmien(tabControl1.TabPages[1].Text);
            tabControl1.TabPages[2].Text = _tlumacz.zmien(tabControl1.TabPages[2].Text);

            //tłumacz Przyrząd label
            labelNazwa.Text = _tlumacz.zmien(labelNazwa.Text);
            labelOpis.Text = _tlumacz.zmien(labelOpis.Text);

            //tłumacz słowniki zakładki "Regulacje / Aktywa" / Wł.ochrony / Zagrożenie / Ataki / Wykonawcy
            tabControl2.TabPages[0].Text = _tlumacz.zmien(tabControl2.TabPages[0].Text);
            tabControl2.TabPages[1].Text = _tlumacz.zmien(tabControl2.TabPages[1].Text);
            tabControl2.TabPages[2].Text = _tlumacz.zmien(tabControl2.TabPages[2].Text);
            tabControl2.TabPages[3].Text = _tlumacz.zmien(tabControl2.TabPages[3].Text);
            tabControl2.TabPages[4].Text = _tlumacz.zmien(tabControl2.TabPages[4].Text);

            //tłumacz zakładki Regulacja-Aktywa / Aktywa-Wł.ochrony / Atak-Aktywa / Atak-Zagrożenie / Atak-Wykonawca / Atak-Ryzyko
            tabControl8.TabPages[0].Text = _tlumacz.zmien(tabControl8.TabPages[0].Text);
            tabControl8.TabPages[1].Text = _tlumacz.zmien(tabControl8.TabPages[1].Text);
            tabControl8.TabPages[2].Text = _tlumacz.zmien(tabControl8.TabPages[2].Text);
            tabControl8.TabPages[3].Text = _tlumacz.zmien(tabControl8.TabPages[3].Text);
            tabControl8.TabPages[4].Text = _tlumacz.zmien(tabControl8.TabPages[4].Text);
            tabControl8.TabPages[5].Text = _tlumacz.zmien(tabControl8.TabPages[5].Text);

            //tłumacz zakładki Relacje->Regulacje-Aktywa-> Regulacja 1-Aktywa / ... / Regulacja 10-Aktywa
            tabControl4.TabPages[0].Text = _tlumacz.zmien(tabControl4.TabPages[0].Text);
            tabControl4.TabPages[1].Text = _tlumacz.zmien(tabControl4.TabPages[1].Text);
            tabControl4.TabPages[2].Text = _tlumacz.zmien(tabControl4.TabPages[2].Text);
            tabControl4.TabPages[3].Text = _tlumacz.zmien(tabControl4.TabPages[3].Text);
            tabControl4.TabPages[4].Text = _tlumacz.zmien(tabControl4.TabPages[4].Text);
            tabControl4.TabPages[5].Text = _tlumacz.zmien(tabControl4.TabPages[5].Text);
            tabControl4.TabPages[6].Text = _tlumacz.zmien(tabControl4.TabPages[6].Text);
            tabControl4.TabPages[7].Text = _tlumacz.zmien(tabControl4.TabPages[7].Text);
            tabControl4.TabPages[8].Text = _tlumacz.zmien(tabControl4.TabPages[8].Text);
            tabControl4.TabPages[9].Text = _tlumacz.zmien(tabControl4.TabPages[9].Text);

            //tłumacz zakładki Relacje->Aktywa-Wł.ochrony-> Aktywa 1-Wł.ochrony / ... / Aktywa 10-Wł.ochrony
            tabControl10.TabPages[0].Text = _tlumacz.zmien(tabControl10.TabPages[0].Text);
            tabControl10.TabPages[1].Text = _tlumacz.zmien(tabControl10.TabPages[1].Text);
            tabControl10.TabPages[2].Text = _tlumacz.zmien(tabControl10.TabPages[2].Text);
            tabControl10.TabPages[3].Text = _tlumacz.zmien(tabControl10.TabPages[3].Text);
            tabControl10.TabPages[4].Text = _tlumacz.zmien(tabControl10.TabPages[4].Text);
            tabControl10.TabPages[5].Text = _tlumacz.zmien(tabControl10.TabPages[5].Text);
            tabControl10.TabPages[6].Text = _tlumacz.zmien(tabControl10.TabPages[6].Text);
            tabControl10.TabPages[7].Text = _tlumacz.zmien(tabControl10.TabPages[7].Text);
            tabControl10.TabPages[8].Text = _tlumacz.zmien(tabControl10.TabPages[8].Text);
            tabControl10.TabPages[9].Text = _tlumacz.zmien(tabControl10.TabPages[9].Text);

            //tłumacz zakładki Relacje->Atak-Aktywa-> Atak 1-Aktywa / ... / Atak 10-Aktywa
            tabControl11.TabPages[0].Text = _tlumacz.zmien(tabControl11.TabPages[0].Text);
            tabControl11.TabPages[1].Text = _tlumacz.zmien(tabControl11.TabPages[1].Text);
            tabControl11.TabPages[2].Text = _tlumacz.zmien(tabControl11.TabPages[2].Text);
            tabControl11.TabPages[3].Text = _tlumacz.zmien(tabControl11.TabPages[3].Text);
            tabControl11.TabPages[4].Text = _tlumacz.zmien(tabControl11.TabPages[4].Text);
            tabControl11.TabPages[5].Text = _tlumacz.zmien(tabControl11.TabPages[5].Text);
            tabControl11.TabPages[6].Text = _tlumacz.zmien(tabControl11.TabPages[6].Text);
            tabControl11.TabPages[7].Text = _tlumacz.zmien(tabControl11.TabPages[7].Text);
            tabControl11.TabPages[8].Text = _tlumacz.zmien(tabControl11.TabPages[8].Text);
            tabControl11.TabPages[9].Text = _tlumacz.zmien(tabControl11.TabPages[9].Text);

            //tłumacz zakładki Relacje-> Atak -Zagrożenie-> Atak 1-Zagrożenie / ... / Atak 10-Zagrożenie
            tabControl12.TabPages[0].Text = _tlumacz.zmien(tabControl12.TabPages[0].Text);
            tabControl12.TabPages[1].Text = _tlumacz.zmien(tabControl12.TabPages[1].Text);
            tabControl12.TabPages[2].Text = _tlumacz.zmien(tabControl12.TabPages[2].Text);
            tabControl12.TabPages[3].Text = _tlumacz.zmien(tabControl12.TabPages[3].Text);
            tabControl12.TabPages[4].Text = _tlumacz.zmien(tabControl12.TabPages[4].Text);
            tabControl12.TabPages[5].Text = _tlumacz.zmien(tabControl12.TabPages[5].Text);
            tabControl12.TabPages[6].Text = _tlumacz.zmien(tabControl12.TabPages[6].Text);
            tabControl12.TabPages[7].Text = _tlumacz.zmien(tabControl12.TabPages[7].Text);
            tabControl12.TabPages[8].Text = _tlumacz.zmien(tabControl12.TabPages[8].Text);
            tabControl12.TabPages[9].Text = _tlumacz.zmien(tabControl12.TabPages[9].Text);

            //tłumacz zakładki Relacje-> Atak -Wykonawca-> Atak 1-Wykonawca / ... / Atak 10-Wykonawca
            tabControl13.TabPages[0].Text = _tlumacz.zmien(tabControl13.TabPages[0].Text);
            tabControl13.TabPages[1].Text = _tlumacz.zmien(tabControl13.TabPages[1].Text);
            tabControl13.TabPages[2].Text = _tlumacz.zmien(tabControl13.TabPages[2].Text);
            tabControl13.TabPages[3].Text = _tlumacz.zmien(tabControl13.TabPages[3].Text);
            tabControl13.TabPages[4].Text = _tlumacz.zmien(tabControl13.TabPages[4].Text);
            tabControl13.TabPages[5].Text = _tlumacz.zmien(tabControl13.TabPages[5].Text);
            tabControl13.TabPages[6].Text = _tlumacz.zmien(tabControl13.TabPages[6].Text);
            tabControl13.TabPages[7].Text = _tlumacz.zmien(tabControl13.TabPages[7].Text);
            tabControl13.TabPages[8].Text = _tlumacz.zmien(tabControl13.TabPages[8].Text);
            tabControl13.TabPages[9].Text = _tlumacz.zmien(tabControl13.TabPages[9].Text);


            //tłumacz zakładki Relacje-> Atak -Ryzyko-> Atak 1-Ryzyko / ... / Atak 10-Ryzyko
            tabControl14.TabPages[0].Text = _tlumacz.zmien(tabControl14.TabPages[0].Text);
            tabControl14.TabPages[1].Text = _tlumacz.zmien(tabControl14.TabPages[1].Text);
            tabControl14.TabPages[2].Text = _tlumacz.zmien(tabControl14.TabPages[2].Text);
            tabControl14.TabPages[3].Text = _tlumacz.zmien(tabControl14.TabPages[3].Text);
            tabControl14.TabPages[4].Text = _tlumacz.zmien(tabControl14.TabPages[4].Text);
            tabControl14.TabPages[5].Text = _tlumacz.zmien(tabControl14.TabPages[5].Text);
            tabControl14.TabPages[6].Text = _tlumacz.zmien(tabControl14.TabPages[6].Text);
            tabControl14.TabPages[7].Text = _tlumacz.zmien(tabControl14.TabPages[7].Text);
            tabControl14.TabPages[8].Text = _tlumacz.zmien(tabControl14.TabPages[8].Text);
            tabControl14.TabPages[9].Text = _tlumacz.zmien(tabControl14.TabPages[9].Text);

            //------------------------------- Regulacje

            labelR1.Text = _tlumacz.zmien(labelR1.Text);
            labelR2.Text = _tlumacz.zmien(labelR2.Text);
            labelR3.Text = _tlumacz.zmien(labelR3.Text);
            labelR4.Text = _tlumacz.zmien(labelR4.Text);
            labelR5.Text = _tlumacz.zmien(labelR5.Text);
            labelR6.Text = _tlumacz.zmien(labelR6.Text);
            labelR7.Text = _tlumacz.zmien(labelR7.Text);
            labelR8.Text = _tlumacz.zmien(labelR8.Text);
            labelR9.Text = _tlumacz.zmien(labelR9.Text);
            labelR10.Text = _tlumacz.zmien(labelR10.Text);

            int x = labelR1.Left;

            labelR2.Left = x;
            labelR3.Left = x;
            labelR4.Left = x;
            labelR5.Left = x;
            labelR6.Left = x;
            labelR7.Left = x;
            labelR8.Left = x;
            labelR9.Left = x;
            labelR10.Left = x;

            labelR1.Top = textBoxRegulacja1.Top;
            labelR2.Top = textBoxRegulacja2.Top;
            labelR3.Top = textBoxRegulacja3.Top;
            labelR4.Top = textBoxRegulacja4.Top;
            labelR5.Top = textBoxRegulacja5.Top;
            labelR6.Top = textBoxRegulacja6.Top;
            labelR7.Top = textBoxRegulacja7.Top;
            labelR8.Top = textBoxRegulacja8.Top;
            labelR9.Top = textBoxRegulacja9.Top;
            labelR10.Top = textBoxRegulacja10.Top;

            x = textBoxRegulacja1.Left;

            textBoxRegulacja2.Left = x;
            textBoxRegulacja3.Left = x;
            textBoxRegulacja4.Left = x;
            textBoxRegulacja5.Left = x;
            textBoxRegulacja6.Left = x;
            textBoxRegulacja7.Left = x;
            textBoxRegulacja8.Left = x;
            textBoxRegulacja9.Left = x;
            textBoxRegulacja10.Left = x;

            x = labelWplyw1.Left;
            labelWplyw2.Left = x;
            labelWplyw3.Left = x;
            labelWplyw4.Left = x;
            labelWplyw5.Left = x;
            labelWplyw6.Left = x;
            labelWplyw7.Left = x;
            labelWplyw8.Left = x;
            labelWplyw9.Left = x;
            labelWplyw10.Left = x;

            labelWplyw1.Top = textBoxRegulacja1.Top;
            labelWplyw2.Top = textBoxRegulacja2.Top;
            labelWplyw3.Top = textBoxRegulacja3.Top;
            labelWplyw4.Top = textBoxRegulacja4.Top;
            labelWplyw5.Top = textBoxRegulacja5.Top;
            labelWplyw6.Top = textBoxRegulacja6.Top;
            labelWplyw7.Top = textBoxRegulacja7.Top; 
            labelWplyw8.Top = textBoxRegulacja8.Top;
            labelWplyw9.Top = textBoxRegulacja9.Top;
            labelWplyw10.Top = textBoxRegulacja10.Top;

            //------------------------------- Regulacje / Aktywa 

            labelA1.Text = _tlumacz.zmien(labelA1.Text);
            labelA2.Text = _tlumacz.zmien(labelA2.Text);
            labelA3.Text = _tlumacz.zmien(labelA3.Text);
            labelA4.Text = _tlumacz.zmien(labelA4.Text);
            labelA5.Text = _tlumacz.zmien(labelA5.Text);
            labelA6.Text = _tlumacz.zmien(labelA6.Text);
            labelA7.Text = _tlumacz.zmien(labelA7.Text);
            labelA8.Text = _tlumacz.zmien(labelA8.Text);
            labelA9.Text = _tlumacz.zmien(labelA9.Text);
            labelA10.Text = _tlumacz.zmien(labelA10.Text);

            x = labelR1.Left;

            labelA1.Top = textBoxAktywa1.Top;
            labelA2.Top = textBoxAktywa2.Top;
            labelA3.Top = textBoxAktywa3.Top;
            labelA4.Top = textBoxAktywa4.Top;
            labelA5.Top = textBoxAktywa5.Top;
            labelA6.Top = textBoxAktywa6.Top;
            labelA7.Top = textBoxAktywa7.Top;
            labelA8.Top = textBoxAktywa8.Top;
            labelA9.Top = textBoxAktywa9.Top;
            labelA10.Top = textBoxAktywa10.Top;

            x = textBoxRegulacja1.Left;

            //------------------------------- Własnosci ochrony

            labelO1.Text = _tlumacz.zmien(labelO1.Text);
            labelO2.Text = _tlumacz.zmien(labelO2.Text);
            labelO3.Text = _tlumacz.zmien(labelO3.Text);
            labelO4.Text = _tlumacz.zmien(labelO4.Text);
            labelO5.Text = _tlumacz.zmien(labelO5.Text);
            labelO6.Text = _tlumacz.zmien(labelO6.Text);
            labelO7.Text = _tlumacz.zmien(labelO7.Text);
            labelO8.Text = _tlumacz.zmien(labelO8.Text);
            labelO9.Text = _tlumacz.zmien(labelO9.Text);
            labelO10.Text = _tlumacz.zmien(labelO10.Text);

            x = labelR1.Left;

            labelO1.Left = x;
            labelO2.Left = x;
            labelO3.Left = x;
            labelO4.Left = x;
            labelO5.Left = x;
            labelO6.Left = x;
            labelO7.Left = x;
            labelO8.Left = x;
            labelO9.Left = x;
            labelO10.Left = x;

            labelO1.Top = textBoxWlasnosc1.Top;
            labelO2.Top = textBoxWlasnosc2.Top;
            labelO3.Top = textBoxWlasnosc3.Top;
            labelO4.Top = textBoxWlasnosc4.Top;
            labelO5.Top = textBoxWlasnosc5.Top;
            labelO6.Top = textBoxWlasnosc6.Top;
            labelO7.Top = textBoxWlasnosc7.Top;
            labelO8.Top = textBoxWlasnosc8.Top;
            labelO9.Top = textBoxWlasnosc9.Top;
            labelO10.Top = textBoxWlasnosc10.Top;

            //------------------------------- Zagrożenie

            labelZ1.Text = _tlumacz.zmien(labelZ1.Text);
            labelZ2.Text = _tlumacz.zmien(labelZ2.Text);
            labelZ3.Text = _tlumacz.zmien(labelZ3.Text);
            labelZ4.Text = _tlumacz.zmien(labelZ4.Text);
            labelZ5.Text = _tlumacz.zmien(labelZ5.Text);
            labelZ6.Text = _tlumacz.zmien(labelZ6.Text);
            labelZ7.Text = _tlumacz.zmien(labelZ7.Text);
            labelZ8.Text = _tlumacz.zmien(labelZ8.Text);
            labelZ9.Text = _tlumacz.zmien(labelZ9.Text);
            labelZ10.Text = _tlumacz.zmien(labelZ10.Text);

            wspolneWlasnosci(labelO1, labelZ1);
            wspolneWlasnosci(labelO2, labelZ2);
            wspolneWlasnosci(labelO3, labelZ3);
            wspolneWlasnosci(labelO4, labelZ4);
            wspolneWlasnosci(labelO5, labelZ5);
            wspolneWlasnosci(labelO6, labelZ6);
            wspolneWlasnosci(labelO7, labelZ7);
            wspolneWlasnosci(labelO8, labelZ8);
            wspolneWlasnosci(labelO9, labelZ9);
            wspolneWlasnosci(labelO10, labelZ10);

            wspolneWlasnosci(textBoxWlasnosc1, textBoxZagrozenie1);
            wspolneWlasnosci(textBoxWlasnosc2, textBoxZagrozenie2);
            wspolneWlasnosci(textBoxWlasnosc3, textBoxZagrozenie3);
            wspolneWlasnosci(textBoxWlasnosc4, textBoxZagrozenie4);
            wspolneWlasnosci(textBoxWlasnosc5, textBoxZagrozenie5);
            wspolneWlasnosci(textBoxWlasnosc6, textBoxZagrozenie6);
            wspolneWlasnosci(textBoxWlasnosc7, textBoxZagrozenie7);
            wspolneWlasnosci(textBoxWlasnosc8, textBoxZagrozenie8);
            wspolneWlasnosci(textBoxWlasnosc9, textBoxZagrozenie9);
            wspolneWlasnosci(textBoxWlasnosc10, textBoxZagrozenie10);

            //------------------------------- Ataki

            labelM1.Text = _tlumacz.zmien(labelM1.Text);
            labelM2.Text = _tlumacz.zmien(labelM2.Text);
            labelM3.Text = _tlumacz.zmien(labelM3.Text);
            labelM4.Text = _tlumacz.zmien(labelM4.Text);
            labelM5.Text = _tlumacz.zmien(labelM5.Text);
            labelM6.Text = _tlumacz.zmien(labelM6.Text);
            labelM7.Text = _tlumacz.zmien(labelM7.Text);
            labelM8.Text = _tlumacz.zmien(labelM8.Text);
            labelM9.Text = _tlumacz.zmien(labelM9.Text);
            labelM10.Text = _tlumacz.zmien(labelM10.Text);

            wspolneWlasnosci(labelR1, labelM1);
            wspolneWlasnosci(labelR2, labelM2);
            wspolneWlasnosci(labelR3, labelM3);
            wspolneWlasnosci(labelR4, labelM4);
            wspolneWlasnosci(labelR5, labelM5);
            wspolneWlasnosci(labelR6, labelM6);
            wspolneWlasnosci(labelR7, labelM7);
            wspolneWlasnosci(labelR8, labelM8);
            wspolneWlasnosci(labelR9, labelM9);
            wspolneWlasnosci(labelR10, labelM10);

            //textBoxAtak1.Location = textBoxRegulacja1.Location;
            //textBoxAtak2.Location = textBoxRegulacja2.Location;
            //textBoxAtak3.Location = textBoxRegulacja3.Location;
            //textBoxAtak4.Location = textBoxRegulacja4.Location;
            //textBoxAtak5.Location = textBoxRegulacja5.Location;
            //textBoxAtak6.Location = textBoxRegulacja6.Location;
            //textBoxAtak7.Location = textBoxRegulacja7.Location;
            //textBoxAtak8.Location = textBoxRegulacja8.Location;
            //textBoxAtak9.Location = textBoxRegulacja9.Location;
            //textBoxAtak10.Location = textBoxRegulacja10.Location;

            //------------------------------- Wykonawca

            labelW1.Text = _tlumacz.zmien(labelW1.Text);
            labelW2.Text = _tlumacz.zmien(labelW2.Text);
            labelW3.Text = _tlumacz.zmien(labelW3.Text);
            labelW4.Text = _tlumacz.zmien(labelW4.Text);
            labelW5.Text = _tlumacz.zmien(labelW5.Text);
            labelW6.Text = _tlumacz.zmien(labelW6.Text);
            labelW7.Text = _tlumacz.zmien(labelW7.Text);
            labelW8.Text = _tlumacz.zmien(labelW8.Text);
            labelW9.Text = _tlumacz.zmien(labelW9.Text);
            labelW10.Text = _tlumacz.zmien(labelW10.Text);

            wspolneWlasnosci(labelO1, labelW1);
            wspolneWlasnosci(labelO2, labelW2);
            wspolneWlasnosci(labelO3, labelW3);
            wspolneWlasnosci(labelO4, labelW4);
            wspolneWlasnosci(labelO5, labelW5);
            wspolneWlasnosci(labelO6, labelW6);
            wspolneWlasnosci(labelO7, labelW7);
            wspolneWlasnosci(labelO8, labelW8);
            wspolneWlasnosci(labelO9, labelW9);
            wspolneWlasnosci(labelO10, labelW10);

            wspolneWlasnosci(textBoxWlasnosc1, textBoxWykonawca1);
            wspolneWlasnosci(textBoxWlasnosc2, textBoxWykonawca2);
            wspolneWlasnosci(textBoxWlasnosc3, textBoxWykonawca3);
            wspolneWlasnosci(textBoxWlasnosc4, textBoxWykonawca4);
            wspolneWlasnosci(textBoxWlasnosc5, textBoxWykonawca5);
            wspolneWlasnosci(textBoxWlasnosc6, textBoxWykonawca6);
            wspolneWlasnosci(textBoxWlasnosc7, textBoxWykonawca7);
            wspolneWlasnosci(textBoxWlasnosc8, textBoxWykonawca8);
            wspolneWlasnosci(textBoxWlasnosc9, textBoxWykonawca9);
            wspolneWlasnosci(textBoxWlasnosc10, textBoxWykonawca10);

            //------------------------------- Regulacja - Aktywa

            labelRegulacja1.Text = _tlumacz.zmien(labelRegulacja1.Text);
            labelRegulacja2.Text = _tlumacz.zmien(labelRegulacja2.Text);
            labelRegulacja3.Text = _tlumacz.zmien(labelRegulacja3.Text);
            labelRegulacja1.Text = _tlumacz.zmien(labelRegulacja1.Text);
            labelRegulacja1.Text = _tlumacz.zmien(labelRegulacja1.Text);
            labelRegulacja1.Text = _tlumacz.zmien(labelRegulacja1.Text);
            labelRegulacja1.Text = _tlumacz.zmien(labelRegulacja1.Text);
            labelRegulacja1.Text = _tlumacz.zmien(labelRegulacja1.Text);
            labelRegulacja1.Text = _tlumacz.zmien(labelRegulacja1.Text);
            labelRegulacja1.Text = _tlumacz.zmien(labelRegulacja1.Text);

            wspolneWlasnosci(labelRegulacja1, labelRegulacja2);
            wspolneWlasnosci(labelRegulacja1, labelRegulacja3);
            wspolneWlasnosci(labelRegulacja1, labelRegulacja4);
            wspolneWlasnosci(labelRegulacja1, labelRegulacja5);
            wspolneWlasnosci(labelRegulacja1, labelRegulacja6);
            wspolneWlasnosci(labelRegulacja1, labelRegulacja7);
            wspolneWlasnosci(labelRegulacja1, labelRegulacja8);
            wspolneWlasnosci(labelRegulacja1, labelRegulacja9);
            wspolneWlasnosci(labelRegulacja1, labelRegulacja10);

            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa2);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa3);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa4);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa5);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa6);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa7);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa8);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa9);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa10);

            dodajPozycje(checkedListBoxAktywa1, 10);
            dodajPozycje(checkedListBoxAktywa2, 10);
            dodajPozycje(checkedListBoxAktywa3, 10);
            dodajPozycje(checkedListBoxAktywa4, 10);
            dodajPozycje(checkedListBoxAktywa5, 10);
            dodajPozycje(checkedListBoxAktywa6, 10);
            dodajPozycje(checkedListBoxAktywa7, 10);
            dodajPozycje(checkedListBoxAktywa8, 10);
            dodajPozycje(checkedListBoxAktywa9, 10);
            dodajPozycje(checkedListBoxAktywa10, 10);

            //------------------------------- Aktywa - Wł ochrony

            wspolneWlasnosci(labelRegulacja1, labelAktywa1);
            wspolneWlasnosci(labelRegulacja1, labelAktywa2);
            wspolneWlasnosci(labelRegulacja1, labelAktywa3);
            wspolneWlasnosci(labelRegulacja1, labelAktywa4);
            wspolneWlasnosci(labelRegulacja1, labelAktywa5);
            wspolneWlasnosci(labelRegulacja1, labelAktywa6);
            wspolneWlasnosci(labelRegulacja1, labelAktywa7);
            wspolneWlasnosci(labelRegulacja1, labelAktywa8);
            wspolneWlasnosci(labelRegulacja1, labelAktywa9);
            wspolneWlasnosci(labelRegulacja1, labelAktywa10);

            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWlasnosc1);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWlasnosc2);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWlasnosc3);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWlasnosc4);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWlasnosc5);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWlasnosc6);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWlasnosc7);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWlasnosc8);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWlasnosc9);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWlasnosc10);

            dodajPozycje(checkedListBoxWlasnosc1, 10);
            dodajPozycje(checkedListBoxWlasnosc2, 10);
            dodajPozycje(checkedListBoxWlasnosc3, 10);
            dodajPozycje(checkedListBoxWlasnosc4, 10);
            dodajPozycje(checkedListBoxWlasnosc5, 10);
            dodajPozycje(checkedListBoxWlasnosc6, 10);
            dodajPozycje(checkedListBoxWlasnosc7, 10);
            dodajPozycje(checkedListBoxWlasnosc8, 10);
            dodajPozycje(checkedListBoxWlasnosc9, 10);
            dodajPozycje(checkedListBoxWlasnosc10, 10);

            //-------------------------------Atak - Aktywa

            wspolneWlasnosci(labelRegulacja1, labelAtak1);
            wspolneWlasnosci(labelRegulacja1, labelAtak2);
            wspolneWlasnosci(labelRegulacja1, labelAtak3);
            wspolneWlasnosci(labelRegulacja1, labelAtak4);
            wspolneWlasnosci(labelRegulacja1, labelAtak5);
            wspolneWlasnosci(labelRegulacja1, labelAtak6);
            wspolneWlasnosci(labelRegulacja1, labelAtak7);
            wspolneWlasnosci(labelRegulacja1, labelAtak8);
            wspolneWlasnosci(labelRegulacja1, labelAtak9);
            wspolneWlasnosci(labelRegulacja1, labelAtak10);

            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa11);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa12);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa13);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa14);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa15);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa16);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa17);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa18);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa19);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxAktywa110);

            dodajPozycje(checkedListBoxAktywa11, 10);
            dodajPozycje(checkedListBoxAktywa12, 10);
            dodajPozycje(checkedListBoxAktywa13, 10);
            dodajPozycje(checkedListBoxAktywa14, 10);
            dodajPozycje(checkedListBoxAktywa15, 10);
            dodajPozycje(checkedListBoxAktywa16, 10);
            dodajPozycje(checkedListBoxAktywa17, 10);
            dodajPozycje(checkedListBoxAktywa18, 10);
            dodajPozycje(checkedListBoxAktywa19, 10);
            dodajPozycje(checkedListBoxAktywa110, 10);

            //-------------------------------Atak - Zagrożenie

            wspolneWlasnosci(labelRegulacja1, labelAtak11);
            wspolneWlasnosci(labelRegulacja1, labelAtak12);
            wspolneWlasnosci(labelRegulacja1, labelAtak13);
            wspolneWlasnosci(labelRegulacja1, labelAtak14);
            wspolneWlasnosci(labelRegulacja1, labelAtak15);
            wspolneWlasnosci(labelRegulacja1, labelAtak16);
            wspolneWlasnosci(labelRegulacja1, labelAtak17);
            wspolneWlasnosci(labelRegulacja1, labelAtak18);
            wspolneWlasnosci(labelRegulacja1, labelAtak19);
            wspolneWlasnosci(labelRegulacja1, labelAtak110);

            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxZagrozenie1);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxZagrozenie2);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxZagrozenie3);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxZagrozenie4);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxZagrozenie5);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxZagrozenie6);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxZagrozenie7);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxZagrozenie8);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxZagrozenie9);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxZagrozenie10);

            dodajPozycje(checkedListBoxZagrozenie1, 10);
            dodajPozycje(checkedListBoxZagrozenie2, 10);
            dodajPozycje(checkedListBoxZagrozenie3, 10);
            dodajPozycje(checkedListBoxZagrozenie4, 10);
            dodajPozycje(checkedListBoxZagrozenie5, 10);
            dodajPozycje(checkedListBoxZagrozenie6, 10);
            dodajPozycje(checkedListBoxZagrozenie7, 10);
            dodajPozycje(checkedListBoxZagrozenie8, 10);
            dodajPozycje(checkedListBoxZagrozenie9, 10);
            dodajPozycje(checkedListBoxZagrozenie10, 10);

            //-------------------------------Atak - Wykonawca

            wspolneWlasnosci(labelRegulacja1, labelAtak21);
            wspolneWlasnosci(labelRegulacja1, labelAtak22);
            wspolneWlasnosci(labelRegulacja1, labelAtak23);
            wspolneWlasnosci(labelRegulacja1, labelAtak24);
            wspolneWlasnosci(labelRegulacja1, labelAtak25);
            wspolneWlasnosci(labelRegulacja1, labelAtak26);
            wspolneWlasnosci(labelRegulacja1, labelAtak27);
            wspolneWlasnosci(labelRegulacja1, labelAtak28);
            wspolneWlasnosci(labelRegulacja1, labelAtak29);
            wspolneWlasnosci(labelRegulacja1, labelAtak210);

            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWykonawca1);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWykonawca2);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWykonawca3);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWykonawca4);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWykonawca5);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWykonawca6);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWykonawca7);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWykonawca8);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWykonawca9);
            wspolneWlasnosci(checkedListBoxAktywa1, checkedListBoxWykonawca10);

            dodajPozycje(checkedListBoxWykonawca1, 10);
            dodajPozycje(checkedListBoxWykonawca2, 10);
            dodajPozycje(checkedListBoxWykonawca3, 10);
            dodajPozycje(checkedListBoxWykonawca4, 10);
            dodajPozycje(checkedListBoxWykonawca5, 10);
            dodajPozycje(checkedListBoxWykonawca6, 10);
            dodajPozycje(checkedListBoxWykonawca7, 10);
            dodajPozycje(checkedListBoxWykonawca8, 10);
            dodajPozycje(checkedListBoxWykonawca9, 10);
            dodajPozycje(checkedListBoxWykonawca10, 10);

            //-------------------------------Atak - Ryzyko

            wspolneWlasnosci(labelRegulacja1, labelAtak31);
            wspolneWlasnosci(labelRegulacja1, labelAtak32);
            wspolneWlasnosci(labelRegulacja1, labelAtak33);
            wspolneWlasnosci(labelRegulacja1, labelAtak34);
            wspolneWlasnosci(labelRegulacja1, labelAtak35);
            wspolneWlasnosci(labelRegulacja1, labelAtak36);
            wspolneWlasnosci(labelRegulacja1, labelAtak37);
            wspolneWlasnosci(labelRegulacja1, labelAtak38);
            wspolneWlasnosci(labelRegulacja1, labelAtak39);
            wspolneWlasnosci(labelRegulacja1, labelAtak310);

            wspolneWlasnosci(labelCzas1, labelCzas2);
            wspolneWlasnosci(labelCzas1, labelCzas2);
            wspolneWlasnosci(labelCzas1, labelCzas3);
            wspolneWlasnosci(labelCzas1, labelCzas4);
            wspolneWlasnosci(labelCzas1, labelCzas5);
            wspolneWlasnosci(labelCzas1, labelCzas6);
            wspolneWlasnosci(labelCzas1, labelCzas7);
            wspolneWlasnosci(labelCzas1, labelCzas8);
            wspolneWlasnosci(labelCzas1, labelCzas9);
            wspolneWlasnosci(labelCzas1, labelCzas10);

            wspolneWlasnosci(labelKwalifikacje1, labelKwalifikacje2);
            wspolneWlasnosci(labelKwalifikacje1, labelKwalifikacje3);
            wspolneWlasnosci(labelKwalifikacje1, labelKwalifikacje4);
            wspolneWlasnosci(labelKwalifikacje1, labelKwalifikacje5);
            wspolneWlasnosci(labelKwalifikacje1, labelKwalifikacje6);
            wspolneWlasnosci(labelKwalifikacje1, labelKwalifikacje7);
            wspolneWlasnosci(labelKwalifikacje1, labelKwalifikacje8);
            wspolneWlasnosci(labelKwalifikacje1, labelKwalifikacje9);
            wspolneWlasnosci(labelKwalifikacje1, labelKwalifikacje10);

            wspolneWlasnosci(labelWiedza1, labelWiedza2);
            wspolneWlasnosci(labelWiedza1, labelWiedza3);
            wspolneWlasnosci(labelWiedza1, labelWiedza4);
            wspolneWlasnosci(labelWiedza1, labelWiedza5);
            wspolneWlasnosci(labelWiedza1, labelWiedza6);
            wspolneWlasnosci(labelWiedza1, labelWiedza7);
            wspolneWlasnosci(labelWiedza1, labelWiedza8);
            wspolneWlasnosci(labelWiedza1, labelWiedza9);
            wspolneWlasnosci(labelWiedza1, labelWiedza10);

            wspolneWlasnosci(labelWyposazenie1, labelWyposazenie2);
            wspolneWlasnosci(labelWyposazenie1, labelWyposazenie3);
            wspolneWlasnosci(labelWyposazenie1, labelWyposazenie4);
            wspolneWlasnosci(labelWyposazenie1, labelWyposazenie5);
            wspolneWlasnosci(labelWyposazenie1, labelWyposazenie6);
            wspolneWlasnosci(labelWyposazenie1, labelWyposazenie7);
            wspolneWlasnosci(labelWyposazenie1, labelWyposazenie8);
            wspolneWlasnosci(labelWyposazenie1, labelWyposazenie9);
            wspolneWlasnosci(labelWyposazenie1, labelWyposazenie10);

            wspolneWlasnosci(labelDostep1, labelDostep2);
            wspolneWlasnosci(labelDostep1, labelDostep3);
            wspolneWlasnosci(labelDostep1, labelDostep4);
            wspolneWlasnosci(labelDostep1, labelDostep5);
            wspolneWlasnosci(labelDostep1, labelDostep6);
            wspolneWlasnosci(labelDostep1, labelDostep7);
            wspolneWlasnosci(labelDostep1, labelDostep8);
            wspolneWlasnosci(labelDostep1, labelDostep9);
            wspolneWlasnosci(labelDostep1, labelDostep10);

            wspolneWlasnosci(labelRyzyko1, labelRyzyko2);
            wspolneWlasnosci(labelRyzyko1, labelRyzyko3);
            wspolneWlasnosci(labelRyzyko1, labelRyzyko4);
            wspolneWlasnosci(labelRyzyko1, labelRyzyko5);
            wspolneWlasnosci(labelRyzyko1, labelRyzyko6);
            wspolneWlasnosci(labelRyzyko1, labelRyzyko7);
            wspolneWlasnosci(labelRyzyko1, labelRyzyko8);
            wspolneWlasnosci(labelRyzyko1, labelRyzyko9);
            wspolneWlasnosci(labelRyzyko1, labelRyzyko10);

            wspolneWlasnosci(trackBarCzas1, trackBarCzas2);
            wspolneWlasnosci(trackBarCzas1, trackBarCzas3);
            wspolneWlasnosci(trackBarCzas1, trackBarCzas4);
            wspolneWlasnosci(trackBarCzas1, trackBarCzas5);
            wspolneWlasnosci(trackBarCzas1, trackBarCzas6);
            wspolneWlasnosci(trackBarCzas1, trackBarCzas7);
            wspolneWlasnosci(trackBarCzas1, trackBarCzas8);
            wspolneWlasnosci(trackBarCzas1, trackBarCzas9);
            wspolneWlasnosci(trackBarCzas1, trackBarCzas10);

            wspolneWlasnosci(trackBarKwalifikacje1, trackBarKwalifikacje2);
            wspolneWlasnosci(trackBarKwalifikacje1, trackBarKwalifikacje3);
            wspolneWlasnosci(trackBarKwalifikacje1, trackBarKwalifikacje4);
            wspolneWlasnosci(trackBarKwalifikacje1, trackBarKwalifikacje5);
            wspolneWlasnosci(trackBarKwalifikacje1, trackBarKwalifikacje6);
            wspolneWlasnosci(trackBarKwalifikacje1, trackBarKwalifikacje7);
            wspolneWlasnosci(trackBarKwalifikacje1, trackBarKwalifikacje8);
            wspolneWlasnosci(trackBarKwalifikacje1, trackBarKwalifikacje9);
            wspolneWlasnosci(trackBarKwalifikacje1, trackBarKwalifikacje10);

            wspolneWlasnosci(trackBarWiedza1, trackBarWiedza2);
            wspolneWlasnosci(trackBarWiedza1, trackBarWiedza3);
            wspolneWlasnosci(trackBarWiedza1, trackBarWiedza4);
            wspolneWlasnosci(trackBarWiedza1, trackBarWiedza5);
            wspolneWlasnosci(trackBarWiedza1, trackBarWiedza6);
            wspolneWlasnosci(trackBarWiedza1, trackBarWiedza7);
            wspolneWlasnosci(trackBarWiedza1, trackBarWiedza8);
            wspolneWlasnosci(trackBarWiedza1, trackBarWiedza9);
            wspolneWlasnosci(trackBarWiedza1, trackBarWiedza10);

            wspolneWlasnosci(trackBarWyposazenie1, trackBarWyposazenie2);
            wspolneWlasnosci(trackBarWyposazenie1, trackBarWyposazenie3);
            wspolneWlasnosci(trackBarWyposazenie1, trackBarWyposazenie4);
            wspolneWlasnosci(trackBarWyposazenie1, trackBarWyposazenie5);
            wspolneWlasnosci(trackBarWyposazenie1, trackBarWyposazenie6);
            wspolneWlasnosci(trackBarWyposazenie1, trackBarWyposazenie7);
            wspolneWlasnosci(trackBarWyposazenie1, trackBarWyposazenie8);
            wspolneWlasnosci(trackBarWyposazenie1, trackBarWyposazenie9);
            wspolneWlasnosci(trackBarWyposazenie1, trackBarWyposazenie10);

            wspolneWlasnosci(trackBarDostep1, trackBarDostep2);
            wspolneWlasnosci(trackBarDostep1, trackBarDostep3);
            wspolneWlasnosci(trackBarDostep1, trackBarDostep4);
            wspolneWlasnosci(trackBarDostep1, trackBarDostep5);
            wspolneWlasnosci(trackBarDostep1, trackBarDostep6);
            wspolneWlasnosci(trackBarDostep1, trackBarDostep7);
            wspolneWlasnosci(trackBarDostep1, trackBarDostep8);
            wspolneWlasnosci(trackBarDostep1, trackBarDostep9);
            wspolneWlasnosci(trackBarDostep1, trackBarDostep10);

            wspolneWlasnosci(trackBarRyzyko1, trackBarRyzyko2);
            wspolneWlasnosci(trackBarRyzyko1, trackBarRyzyko3);
            wspolneWlasnosci(trackBarRyzyko1, trackBarRyzyko4);
            wspolneWlasnosci(trackBarRyzyko1, trackBarRyzyko5);
            wspolneWlasnosci(trackBarRyzyko1, trackBarRyzyko6);
            wspolneWlasnosci(trackBarRyzyko1, trackBarRyzyko7);
            wspolneWlasnosci(trackBarRyzyko1, trackBarRyzyko8);
            wspolneWlasnosci(trackBarRyzyko1, trackBarRyzyko9);
            wspolneWlasnosci(trackBarRyzyko1, trackBarRyzyko10);

            wspolneWlasnosci(labelCzasOpis1, labelCzasOpis2);
            wspolneWlasnosci(labelCzasOpis1, labelCzasOpis3);
            wspolneWlasnosci(labelCzasOpis1, labelCzasOpis4);
            wspolneWlasnosci(labelCzasOpis1, labelCzasOpis5);
            wspolneWlasnosci(labelCzasOpis1, labelCzasOpis6);
            wspolneWlasnosci(labelCzasOpis1, labelCzasOpis7);
            wspolneWlasnosci(labelCzasOpis1, labelCzasOpis8);
            wspolneWlasnosci(labelCzasOpis1, labelCzasOpis9);
            wspolneWlasnosci(labelCzasOpis1, labelCzasOpis10);

            wspolneWlasnosci(labelKwalifikacjeOpis1, labelKwalifikacjeOpis2);
            wspolneWlasnosci(labelKwalifikacjeOpis1, labelKwalifikacjeOpis3);
            wspolneWlasnosci(labelKwalifikacjeOpis1, labelKwalifikacjeOpis4);
            wspolneWlasnosci(labelKwalifikacjeOpis1, labelKwalifikacjeOpis5);
            wspolneWlasnosci(labelKwalifikacjeOpis1, labelKwalifikacjeOpis6);
            wspolneWlasnosci(labelKwalifikacjeOpis1, labelKwalifikacjeOpis7);
            wspolneWlasnosci(labelKwalifikacjeOpis1, labelKwalifikacjeOpis8);
            wspolneWlasnosci(labelKwalifikacjeOpis1, labelKwalifikacjeOpis9);
            wspolneWlasnosci(labelKwalifikacjeOpis1, labelKwalifikacjeOpis10);

            wspolneWlasnosci(labelWiedzaOpis1, labelWiedzaOpis2);
            wspolneWlasnosci(labelWiedzaOpis1, labelWiedzaOpis3);
            wspolneWlasnosci(labelWiedzaOpis1, labelWiedzaOpis4);
            wspolneWlasnosci(labelWiedzaOpis1, labelWiedzaOpis5);
            wspolneWlasnosci(labelWiedzaOpis1, labelWiedzaOpis6);
            wspolneWlasnosci(labelWiedzaOpis1, labelWiedzaOpis7);
            wspolneWlasnosci(labelWiedzaOpis1, labelWiedzaOpis8);
            wspolneWlasnosci(labelWiedzaOpis1, labelWiedzaOpis9);
            wspolneWlasnosci(labelWiedzaOpis1, labelWiedzaOpis10);

            wspolneWlasnosci(labelWyposazenieOpis1, labelWyposazenieOpis2);
            wspolneWlasnosci(labelWyposazenieOpis1, labelWyposazenieOpis3);
            wspolneWlasnosci(labelWyposazenieOpis1, labelWyposazenieOpis4);
            wspolneWlasnosci(labelWyposazenieOpis1, labelWyposazenieOpis5);
            wspolneWlasnosci(labelWyposazenieOpis1, labelWyposazenieOpis6);
            wspolneWlasnosci(labelWyposazenieOpis1, labelWyposazenieOpis7);
            wspolneWlasnosci(labelWyposazenieOpis1, labelWyposazenieOpis8);
            wspolneWlasnosci(labelWyposazenieOpis1, labelWyposazenieOpis9);
            wspolneWlasnosci(labelWyposazenieOpis1, labelWyposazenieOpis10);

            wspolneWlasnosci(labelDostepOpis1, labelDostepOpis2);
            wspolneWlasnosci(labelDostepOpis1, labelDostepOpis3);
            wspolneWlasnosci(labelDostepOpis1, labelDostepOpis4);
            wspolneWlasnosci(labelDostepOpis1, labelDostepOpis5);
            wspolneWlasnosci(labelDostepOpis1, labelDostepOpis6);
            wspolneWlasnosci(labelDostepOpis1, labelDostepOpis7);
            wspolneWlasnosci(labelDostepOpis1, labelDostepOpis8);
            wspolneWlasnosci(labelDostepOpis1, labelDostepOpis9);
            wspolneWlasnosci(labelDostepOpis1, labelDostepOpis10);

            labelAtak31.Text = textBoxAtak1.Text;
            labelAtak32.Text = textBoxAtak2.Text;
            labelAtak33.Text = textBoxAtak3.Text;
            labelAtak34.Text = textBoxAtak4.Text;
            labelAtak35.Text = textBoxAtak5.Text;
            labelAtak36.Text = textBoxAtak6.Text;
            labelAtak37.Text = textBoxAtak7.Text;
            labelAtak38.Text = textBoxAtak8.Text;
            labelAtak39.Text = textBoxAtak9.Text;
            labelAtak310.Text = textBoxAtak10.Text;

        }//ustawWlasnosci

        /// <summary>
        /// Ustawia możliwość oddziaływania na formanty.
        /// </summary>
        private void ustawDostep()
        {
            if (_czynnosc == (int)_enum.start)
            {
                nowyToolStripMenuItem.Enabled = true;
                otworzToolStripMenuItem.Enabled = true;
                zapiszToolStripMenuItem.Enabled = false;
                zapiszJakoToolStripMenuItem.Enabled = false;
                sprawdzToolStripMenuItem.Enabled = false;
                zamknijToolStripMenuItem.Enabled = false;
                pomocToolStripMenuItem.Enabled = true;
                oProgramieToolStripMenuItem.Enabled = true;
                tabControl1.Enabled = false;
            }

            if (_czynnosc == (int)_enum.nowy)
            {
                nowyToolStripMenuItem.Enabled = false;
                otworzToolStripMenuItem.Enabled = false;
                zapiszToolStripMenuItem.Enabled = true;
                zapiszJakoToolStripMenuItem.Enabled = true;
                sprawdzToolStripMenuItem.Enabled = true;
                zamknijToolStripMenuItem.Enabled = true;
                pomocToolStripMenuItem.Enabled = true;
                oProgramieToolStripMenuItem.Enabled = true;
                tabControl1.Enabled = true;
            }

            if (_czynnosc == (int)_enum.zapisJako)
            {
                nowyToolStripMenuItem.Enabled = false;
                otworzToolStripMenuItem.Enabled = false;
                zapiszToolStripMenuItem.Enabled = true;
                zapiszJakoToolStripMenuItem.Enabled = true;
                sprawdzToolStripMenuItem.Enabled = true;
                zamknijToolStripMenuItem.Enabled = true;
                pomocToolStripMenuItem.Enabled = true;
                oProgramieToolStripMenuItem.Enabled = true;
                tabControl1.Enabled = true;
            }

            if (_czynnosc == (int)_enum.zapisz)
            {
                nowyToolStripMenuItem.Enabled = false;
                otworzToolStripMenuItem.Enabled = false;
                zapiszToolStripMenuItem.Enabled = true;
                zapiszJakoToolStripMenuItem.Enabled = true;
                sprawdzToolStripMenuItem.Enabled = true;
                zamknijToolStripMenuItem.Enabled = true;
                pomocToolStripMenuItem.Enabled = true;
                oProgramieToolStripMenuItem.Enabled = true;
                tabControl1.Enabled = true;
            }

            if (_czynnosc == (int)_enum.otwarty)
            {
                nowyToolStripMenuItem.Enabled = false;
                otworzToolStripMenuItem.Enabled = false;
                zapiszToolStripMenuItem.Enabled = true;
                zapiszJakoToolStripMenuItem.Enabled = true;
                sprawdzToolStripMenuItem.Enabled = true;
                zamknijToolStripMenuItem.Enabled = true;
                pomocToolStripMenuItem.Enabled = true;
                oProgramieToolStripMenuItem.Enabled = true;
                tabControl1.Enabled = true;
            }

            if (_czynnosc == (int)_enum.zamknij)
            {
                nowyToolStripMenuItem.Enabled = true;
                otworzToolStripMenuItem.Enabled = true;
                zapiszToolStripMenuItem.Enabled = false;
                zapiszJakoToolStripMenuItem.Enabled = false;
                sprawdzToolStripMenuItem.Enabled = false;
                zamknijToolStripMenuItem.Enabled = false;
                pomocToolStripMenuItem.Enabled = true;
                oProgramieToolStripMenuItem.Enabled = true;
                tabControl1.Enabled = false;
            }

        }//ustawDostep

        /// <summary>
        /// Zwraca ciąg znaków stanowiących sume wszystkich wartości zamienionych na znaki.
        /// </summary>
        /// <returns>Złożenie ciągów znaków.</returns>
        private string sumaWartosci()
        {
            string s = string.Empty;

            s += textBoxNazwa.Text;
            s += textBoxOpis.Text;

            if (toolStripComboBoxJezyk.SelectedIndex == 0)
                s += "false";
            else
                s += "true";

            s += textBoxRegulacja1.Text;
            s += textBoxRegulacja2.Text;
            s += textBoxRegulacja3.Text;
            s += textBoxRegulacja4.Text;
            s += textBoxRegulacja5.Text;
            s += textBoxRegulacja6.Text;
            s += textBoxRegulacja7.Text;
            s += textBoxRegulacja8.Text;
            s += textBoxRegulacja9.Text;
            s += textBoxRegulacja10.Text;

            s += trackBarWplyw1.Value.ToString();
            s += trackBarWplyw2.Value.ToString();
            s += trackBarWplyw3.Value.ToString();
            s += trackBarWplyw4.Value.ToString();
            s += trackBarWplyw5.Value.ToString();
            s += trackBarWplyw6.Value.ToString();
            s += trackBarWplyw7.Value.ToString();
            s += trackBarWplyw8.Value.ToString();
            s += trackBarWplyw9.Value.ToString();
            s += trackBarWplyw10.Value.ToString();

            s += textBoxAktywa1.Text;
            s += textBoxAktywa2.Text;
            s += textBoxAktywa3.Text;
            s += textBoxAktywa4.Text;
            s += textBoxAktywa5.Text;
            s += textBoxAktywa6.Text;
            s += textBoxAktywa7.Text;
            s += textBoxAktywa8.Text;
            s += textBoxAktywa9.Text;
            s += textBoxAktywa10.Text;

            s += textBoxWlasnosc1.Text;
            s += textBoxWlasnosc2.Text;
            s += textBoxWlasnosc3.Text;
            s += textBoxWlasnosc4.Text;
            s += textBoxWlasnosc5.Text;
            s += textBoxWlasnosc6.Text;
            s += textBoxWlasnosc7.Text;
            s += textBoxWlasnosc8.Text;
            s += textBoxWlasnosc9.Text;
            s += textBoxWlasnosc10.Text;

            s += textBoxZagrozenie1.Text;
            s += textBoxZagrozenie2.Text;
            s += textBoxZagrozenie3.Text;
            s += textBoxZagrozenie4.Text;
            s += textBoxZagrozenie5.Text;
            s += textBoxZagrozenie6.Text;
            s += textBoxZagrozenie7.Text;
            s += textBoxZagrozenie8.Text;
            s += textBoxZagrozenie9.Text;
            s += textBoxZagrozenie10.Text;

            s += textBoxAtak1.Text;
            s += textBoxAtak2.Text;
            s += textBoxAtak3.Text;
            s += textBoxAtak4.Text;
            s += textBoxAtak5.Text;
            s += textBoxAtak6.Text;
            s += textBoxAtak7.Text;
            s += textBoxAtak8.Text;
            s += textBoxAtak9.Text;
            s += textBoxAtak10.Text;

            s += textBoxWykonawca1.Text;
            s += textBoxWykonawca2.Text;
            s += textBoxWykonawca3.Text;
            s += textBoxWykonawca4.Text;
            s += textBoxWykonawca5.Text;
            s += textBoxWykonawca6.Text;
            s += textBoxWykonawca7.Text;
            s += textBoxWykonawca8.Text;
            s += textBoxWykonawca9.Text;
            s += textBoxWykonawca10.Text;

            s += sumaWartosci(checkedListBoxAktywa1);
            s += sumaWartosci(checkedListBoxAktywa2);
            s += sumaWartosci(checkedListBoxAktywa3);
            s += sumaWartosci(checkedListBoxAktywa4);
            s += sumaWartosci(checkedListBoxAktywa5);
            s += sumaWartosci(checkedListBoxAktywa6);
            s += sumaWartosci(checkedListBoxAktywa7);
            s += sumaWartosci(checkedListBoxAktywa8);
            s += sumaWartosci(checkedListBoxAktywa9);
            s += sumaWartosci(checkedListBoxAktywa10);

            s += sumaWartosci(checkedListBoxWlasnosc1);
            s += sumaWartosci(checkedListBoxWlasnosc2);
            s += sumaWartosci(checkedListBoxWlasnosc3);
            s += sumaWartosci(checkedListBoxWlasnosc4);
            s += sumaWartosci(checkedListBoxWlasnosc5);
            s += sumaWartosci(checkedListBoxWlasnosc6);
            s += sumaWartosci(checkedListBoxWlasnosc7);
            s += sumaWartosci(checkedListBoxWlasnosc8);
            s += sumaWartosci(checkedListBoxWlasnosc9);
            s += sumaWartosci(checkedListBoxWlasnosc10);

            s += sumaWartosci(checkedListBoxAktywa11);
            s += sumaWartosci(checkedListBoxAktywa12);
            s += sumaWartosci(checkedListBoxAktywa13);
            s += sumaWartosci(checkedListBoxAktywa14);
            s += sumaWartosci(checkedListBoxAktywa15);
            s += sumaWartosci(checkedListBoxAktywa16);
            s += sumaWartosci(checkedListBoxAktywa17);
            s += sumaWartosci(checkedListBoxAktywa18);
            s += sumaWartosci(checkedListBoxAktywa19);
            s += sumaWartosci(checkedListBoxAktywa110);

            s += sumaWartosci(checkedListBoxZagrozenie1);
            s += sumaWartosci(checkedListBoxZagrozenie2);
            s += sumaWartosci(checkedListBoxZagrozenie3);
            s += sumaWartosci(checkedListBoxZagrozenie4);
            s += sumaWartosci(checkedListBoxZagrozenie5);
            s += sumaWartosci(checkedListBoxZagrozenie6);
            s += sumaWartosci(checkedListBoxZagrozenie7);
            s += sumaWartosci(checkedListBoxZagrozenie8);
            s += sumaWartosci(checkedListBoxZagrozenie9);
            s += sumaWartosci(checkedListBoxZagrozenie10);

            s += sumaWartosci(checkedListBoxWykonawca1);
            s += sumaWartosci(checkedListBoxWykonawca2);
            s += sumaWartosci(checkedListBoxWykonawca3);
            s += sumaWartosci(checkedListBoxWykonawca4);
            s += sumaWartosci(checkedListBoxWykonawca5);
            s += sumaWartosci(checkedListBoxWykonawca6);
            s += sumaWartosci(checkedListBoxWykonawca7);
            s += sumaWartosci(checkedListBoxWykonawca8);
            s += sumaWartosci(checkedListBoxWykonawca9);
            s += sumaWartosci(checkedListBoxWykonawca10);

            s += trackBarCzas1.Value.ToString();
            s += trackBarKwalifikacje1.Value.ToString();
            s += trackBarWiedza1.Value.ToString();
            s += trackBarWyposazenie1.Value.ToString();
            s += trackBarDostep1.Value.ToString();
            s += trackBarRyzyko1.Value.ToString();

            s += trackBarCzas2.Value.ToString();
            s += trackBarKwalifikacje2.Value.ToString();
            s += trackBarWiedza2.Value.ToString();
            s += trackBarWyposazenie2.Value.ToString();
            s += trackBarDostep2.Value.ToString();
            s += trackBarRyzyko2.Value.ToString();

            s += trackBarCzas3.Value.ToString();
            s += trackBarKwalifikacje3.Value.ToString();
            s += trackBarWiedza3.Value.ToString();
            s += trackBarWyposazenie3.Value.ToString();
            s += trackBarDostep3.Value.ToString();
            s += trackBarRyzyko3.Value.ToString();

            s += trackBarCzas4.Value.ToString();
            s += trackBarKwalifikacje4.Value.ToString();
            s += trackBarWiedza4.Value.ToString();
            s += trackBarWyposazenie4.Value.ToString();
            s += trackBarDostep4.Value.ToString();
            s += trackBarRyzyko4.Value.ToString();

            s += trackBarCzas5.Value.ToString();
            s += trackBarKwalifikacje5.Value.ToString();
            s += trackBarWiedza5.Value.ToString();
            s += trackBarWyposazenie5.Value.ToString();
            s += trackBarDostep5.Value.ToString();
            s += trackBarRyzyko5.Value.ToString();

            s += trackBarCzas6.Value.ToString();
            s += trackBarKwalifikacje6.Value.ToString();
            s += trackBarWiedza6.Value.ToString();
            s += trackBarWyposazenie6.Value.ToString();
            s += trackBarDostep6.Value.ToString();
            s += trackBarRyzyko6.Value.ToString();

            s += trackBarCzas7.Value.ToString();
            s += trackBarKwalifikacje7.Value.ToString();
            s += trackBarWiedza7.Value.ToString();
            s += trackBarWyposazenie7.Value.ToString();
            s += trackBarDostep7.Value.ToString();
            s += trackBarRyzyko7.Value.ToString();

            s += trackBarCzas8.Value.ToString();
            s += trackBarKwalifikacje8.Value.ToString();
            s += trackBarWiedza8.Value.ToString();
            s += trackBarWyposazenie8.Value.ToString();
            s += trackBarDostep8.Value.ToString();
            s += trackBarRyzyko8.Value.ToString();

            s += trackBarCzas9.Value.ToString();
            s += trackBarKwalifikacje9.Value.ToString();
            s += trackBarWiedza9.Value.ToString();
            s += trackBarWyposazenie9.Value.ToString();
            s += trackBarDostep9.Value.ToString();
            s += trackBarRyzyko9.Value.ToString();

            s += trackBarCzas10.Value.ToString();
            s += trackBarKwalifikacje10.Value.ToString();
            s += trackBarWiedza10.Value.ToString();
            s += trackBarWyposazenie10.Value.ToString();
            s += trackBarDostep10.Value.ToString();
            s += trackBarRyzyko10.Value.ToString();

            return s;
        }//sumaWartosci
       

        /// <summary>
        /// Zwraca sumę wartości wszystkich stanów wyboru w liście.
        /// </summary>
        /// <param name="clb">Lista wyboru.</param>
        /// <returns>Sum wartości.</returns>
        private string sumaWartosci(CheckedListBox clb)
        {
            string s = string.Empty;

            for (int i = 0; i < clb.Items.Count; i++)
            {
                s += Convert.ToString(clb.GetItemChecked(i));
            }
            return s;
        }//sumaWartosci

        private void wspolneWlasnosci(Label o1, Label o2)
        {
            o2.Left = o1.Left;
            o2.Top = o1.Top;
            o2.Width = o1.Width;
            o2.Height = o1.Height;
            o2.Anchor = o1.Anchor;
            o2.Dock = o1.Dock;
            o2.Font = o1.Font;
            o2.Location = o1.Location;
            o2.TextAlign = o1.TextAlign;

        }//wspolnleWlasnosci

        private void wspolneWlasnosci(TextBox o1, TextBox o2)
        {
            o2.Left = o1.Left;
            o2.Top = o1.Top;
            o2.Width = o1.Width;
            o2.Height = o1.Height;
            o2.Anchor = o1.Anchor;
            o2.Dock = o1.Dock;
            o2.Font = o1.Font;
        }//wspolnleWlasnosci

        private void wspolneWlasnosci(TrackBar o1, TrackBar o2)
        {
            o2.Left = o1.Left;
            o2.Top = o1.Top;
            o2.Width = o1.Width;
            o2.Height = o1.Height;
            o2.Anchor = o1.Anchor;
            o2.Dock = o1.Dock;
            o2.Font = o1.Font;
        }//wspolnleWlasnosci

        private void wspolneWlasnosci(CheckedListBox o1, CheckedListBox o2)
        {
            o2.Left = o1.Left;
            o2.Top = o1.Top;
            o2.Width = o1.Width;
            o2.Height = o1.Height;
            o2.Anchor = o1.Anchor;
            o2.Dock = o1.Dock;
            o2.Font = o1.Font;
            o2.CheckOnClick = o1.CheckOnClick;
        }//wspolnleWlasnosci

        /// <summary>
        /// Oblicza ryzyko.
        /// </summary>
        /// <param name="wplyw">Wpływ regulacji.</param>
        /// <param name="czas">Czas dostępu.</param>
        /// <param name="kwalifikacje">Wymagane kwalifikacje.</param>
        /// <param name="wiedza">Wymagana wiedza.</param>
        /// <param name="wyposazenie">Wymagane wyposażenie.</param>
        /// <param name="mozliwosci">Wymagane możliwosci.</param>
        /// <returns>Wartość ryzyka w skali 1-5.</returns>
        private int ryzyko(int wplyw, int czas, int kwalifikacje, int wiedza, int wyposazenie, int mozliwosci)
        {
            int suma = czas + kwalifikacje + wiedza + wyposazenie + mozliwosci;

            int p = 5;

            if (suma >= 10 & suma <= 13) p = 4;
            if (suma >= 14 & suma <= 19) p = 3;
            if (suma >= 20 & suma <= 24) p = 2;
            if (suma > 24) p = 1;

            int v = wplyw * p / 5;

            if (v < 1) v = 1;
            if (v > 5) v = 5;

            return (int)v;
        }//ryzyko

        private void trackBarWplyw1_Scroll(object sender, EventArgs e)
        {
            labelWplyw1.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw1.Value.ToString();
            pokazParametryRyzyka1();
        }

        private void trackBarWplyw2_Scroll(object sender, EventArgs e)
        {
            labelWplyw2.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw2.Value.ToString();
            pokazParametryRyzyka2();
        }

        private void trackBarWplyw3_Scroll(object sender, EventArgs e)
        {
            labelWplyw3.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw3.Value.ToString();
            pokazParametryRyzyka3();
        }

        private void trackBarWplyw4_Scroll(object sender, EventArgs e)
        {
            labelWplyw4.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw4.Value.ToString();
            pokazParametryRyzyka4();
        }

        private void trackBarWplyw5_Scroll(object sender, EventArgs e)
        {
            labelWplyw5.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw5.Value.ToString();
            pokazParametryRyzyka5();
        }

        private void trackBarWplyw6_Scroll(object sender, EventArgs e)
        {
            labelWplyw6.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw6.Value.ToString();
            pokazParametryRyzyka6();
        }

        private void trackBarWplyw7_Scroll(object sender, EventArgs e)
        {
            labelWplyw7.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw7.Value.ToString();
            pokazParametryRyzyka7();
        }

        private void trackBarWplyw8_Scroll(object sender, EventArgs e)
        {
            labelWplyw8.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw8.Value.ToString();
            pokazParametryRyzyka8();
        }

        private void trackBarWplyw9_Scroll(object sender, EventArgs e)
        {
            labelWplyw9.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw9.Value.ToString();
            pokazParametryRyzyka9();
        }

        private void trackBarWplyw10_Scroll(object sender, EventArgs e)
        {
            labelWplyw10.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw10.Value.ToString();
            pokazParametryRyzyka10();
        }

        /// <summary>
        /// Pokazuje parametry ryzyka.
        /// </summary>
        private void pokazParametryRyzyka1()
        {
            trackBarRyzyko1.Value = ryzyko(trackBarWplyw1.Value,
                trackBarCzas1.Value,
                trackBarKwalifikacje1.Value,
                trackBarWiedza1.Value,
                trackBarWyposazenie1.Value,
                trackBarDostep1.Value);

            labelCzas1.Text = _tlumacz.zmien("Czas: ") + trackBarCzas1.Value.ToString();
            labelKwalifikacje1.Text = _tlumacz.zmien("Kwalifikacje: ") + trackBarKwalifikacje1.Value.ToString();
            labelWiedza1.Text = _tlumacz.zmien("Wiedza: ") + trackBarWiedza1.Value.ToString();
            labelWyposazenie1.Text = _tlumacz.zmien("Wyposażenie: ") + trackBarWyposazenie1.Value.ToString();
            labelDostep1.Text = _tlumacz.zmien("Dostęp: ") + trackBarDostep1.Value.ToString();
            labelRyzyko1.Text = _tlumacz.zmien("Ryzyko: ") + trackBarRyzyko1.Value.ToString();

            labelCzasOpis1.Text = czasOpis(trackBarCzas1.Value);
            labelKwalifikacjeOpis1.Text = kwalifikacjeOpis(trackBarKwalifikacje1.Value);
            labelWiedzaOpis1.Text = wiedzaOpis(trackBarWiedza1.Value);
            labelWyposazenieOpis1.Text = wyposazenieOpis(trackBarWyposazenie1.Value);
            labelDostepOpis1.Text = dostepOpis(trackBarDostep1.Value);
        }//ustawRyzyko1

        private void pokazParametryRyzyka2()
        {
            trackBarRyzyko2.Value = ryzyko(trackBarWplyw2.Value,
                trackBarCzas2.Value,
                trackBarKwalifikacje2.Value,
                trackBarWiedza2.Value,
                trackBarWyposazenie2.Value,
                trackBarDostep2.Value);

            labelCzas2.Text = _tlumacz.zmien("Czas: ") + trackBarCzas2.Value.ToString();
            labelKwalifikacje2.Text = _tlumacz.zmien("Kwalifikacje: ") + trackBarKwalifikacje2.Value.ToString();
            labelWiedza2.Text = _tlumacz.zmien("Wiedza: ") + trackBarWiedza2.Value.ToString();
            labelWyposazenie2.Text = _tlumacz.zmien("Wyposażenie: ") + trackBarWyposazenie2.Value.ToString();
            labelDostep2.Text = _tlumacz.zmien("Dostęp: ") + trackBarDostep2.Value.ToString();
            labelRyzyko2.Text = _tlumacz.zmien("Ryzyko: ") + trackBarRyzyko2.Value.ToString();

            labelCzasOpis2.Text = czasOpis(trackBarCzas2.Value);
            labelKwalifikacjeOpis2.Text = kwalifikacjeOpis(trackBarKwalifikacje2.Value);
            labelWiedzaOpis2.Text = wiedzaOpis(trackBarWiedza2.Value);
            labelWyposazenieOpis2.Text = wyposazenieOpis(trackBarWyposazenie2.Value);
            labelDostepOpis2.Text = dostepOpis(trackBarDostep2.Value);
        }//ustawRyzyko2

        private void pokazParametryRyzyka3()
        {
            trackBarRyzyko3.Value = ryzyko(trackBarWplyw3.Value,
                trackBarCzas3.Value,
                trackBarKwalifikacje3.Value,
                trackBarWiedza3.Value,
                trackBarWyposazenie3.Value,
                trackBarDostep3.Value);

            labelCzas3.Text = _tlumacz.zmien("Czas: ") + trackBarCzas3.Value.ToString();
            labelKwalifikacje3.Text = _tlumacz.zmien("Kwalifikacje: ") + trackBarKwalifikacje3.Value.ToString();
            labelWiedza3.Text = _tlumacz.zmien("Wiedza: ") + trackBarWiedza3.Value.ToString();
            labelWyposazenie3.Text = _tlumacz.zmien("Wyposażenie: ") + trackBarWyposazenie3.Value.ToString();
            labelDostep3.Text = _tlumacz.zmien("Dostęp: ") + trackBarDostep3.Value.ToString();
            labelRyzyko3.Text = _tlumacz.zmien("Ryzyko: ") + trackBarRyzyko3.Value.ToString();

            labelCzasOpis3.Text = czasOpis(trackBarCzas3.Value);
            labelKwalifikacjeOpis3.Text = kwalifikacjeOpis(trackBarKwalifikacje3.Value);
            labelWiedzaOpis3.Text = wiedzaOpis(trackBarWiedza3.Value);
            labelWyposazenieOpis3.Text = wyposazenieOpis(trackBarWyposazenie3.Value);
            labelDostepOpis3.Text = dostepOpis(trackBarDostep3.Value);
        }//ustawRyzyko3

        private void pokazParametryRyzyka4()
        {
            trackBarRyzyko4.Value = ryzyko(trackBarWplyw4.Value,
                trackBarCzas4.Value,
                trackBarKwalifikacje4.Value,
                trackBarWiedza4.Value,
                trackBarWyposazenie4.Value,
                trackBarDostep4.Value);

            labelCzas4.Text = _tlumacz.zmien("Czas: ") + trackBarCzas4.Value.ToString();
            labelKwalifikacje4.Text = _tlumacz.zmien("Kwalifikacje: ") + trackBarKwalifikacje4.Value.ToString();
            labelWiedza4.Text = _tlumacz.zmien("Wiedza: ") + trackBarWiedza4.Value.ToString();
            labelWyposazenie4.Text = _tlumacz.zmien("Wyposażenie: ") + trackBarWyposazenie4.Value.ToString();
            labelDostep4.Text = _tlumacz.zmien("Dostęp: ") + trackBarDostep4.Value.ToString();
            labelRyzyko4.Text = _tlumacz.zmien("Ryzyko: ") + trackBarRyzyko4.Value.ToString();

            labelCzasOpis4.Text = czasOpis(trackBarCzas4.Value);
            labelKwalifikacjeOpis4.Text = kwalifikacjeOpis(trackBarKwalifikacje4.Value);
            labelWiedzaOpis4.Text = wiedzaOpis(trackBarWiedza4.Value);
            labelWyposazenieOpis4.Text = wyposazenieOpis(trackBarWyposazenie4.Value);
            labelDostepOpis4.Text = dostepOpis(trackBarDostep4.Value);
        }//ustawRyzyko4

        private void pokazParametryRyzyka5()
        {
            trackBarRyzyko5.Value = ryzyko(trackBarWplyw5.Value,
                trackBarCzas5.Value,
                trackBarKwalifikacje5.Value,
                trackBarWiedza5.Value,
                trackBarWyposazenie5.Value,
                trackBarDostep5.Value);

            labelCzas5.Text = _tlumacz.zmien("Czas: ") + trackBarCzas5.Value.ToString();
            labelKwalifikacje5.Text = _tlumacz.zmien("Kwalifikacje: ") + trackBarKwalifikacje5.Value.ToString();
            labelWiedza5.Text = _tlumacz.zmien("Wiedza: ") + trackBarWiedza5.Value.ToString();
            labelWyposazenie5.Text = _tlumacz.zmien("Wyposażenie: ") + trackBarWyposazenie5.Value.ToString();
            labelDostep5.Text = _tlumacz.zmien("Dostęp: ") + trackBarDostep5.Value.ToString();
            labelRyzyko5.Text = _tlumacz.zmien("Ryzyko: ") + trackBarRyzyko5.Value.ToString();

            labelCzasOpis5.Text = czasOpis(trackBarCzas5.Value);
            labelKwalifikacjeOpis5.Text = kwalifikacjeOpis(trackBarKwalifikacje5.Value);
            labelWiedzaOpis5.Text = wiedzaOpis(trackBarWiedza5.Value);
            labelWyposazenieOpis5.Text = wyposazenieOpis(trackBarWyposazenie5.Value);
            labelDostepOpis5.Text = dostepOpis(trackBarDostep5.Value);
        }//ustawRyzyko5

        private void pokazParametryRyzyka6()
        {
            trackBarRyzyko6.Value = ryzyko(trackBarWplyw6.Value,
                trackBarCzas6.Value,
                trackBarKwalifikacje6.Value,
                trackBarWiedza6.Value,
                trackBarWyposazenie6.Value,
                trackBarDostep6.Value);

            labelCzas6.Text = _tlumacz.zmien("Czas: ") + trackBarCzas6.Value.ToString();
            labelKwalifikacje6.Text = _tlumacz.zmien("Kwalifikacje: ") + trackBarKwalifikacje6.Value.ToString();
            labelWiedza6.Text = _tlumacz.zmien("Wiedza: ") + trackBarWiedza6.Value.ToString();
            labelWyposazenie6.Text = _tlumacz.zmien("Wyposażenie: ") + trackBarWyposazenie6.Value.ToString();
            labelDostep6.Text = _tlumacz.zmien("Dostęp: ") + trackBarDostep6.Value.ToString();
            labelRyzyko6.Text = _tlumacz.zmien("Ryzyko: ") + trackBarRyzyko6.Value.ToString();

            labelCzasOpis6.Text = czasOpis(trackBarCzas6.Value);
            labelKwalifikacjeOpis6.Text = kwalifikacjeOpis(trackBarKwalifikacje6.Value);
            labelWiedzaOpis6.Text = wiedzaOpis(trackBarWiedza6.Value);
            labelWyposazenieOpis6.Text = wyposazenieOpis(trackBarWyposazenie6.Value);
            labelDostepOpis6.Text = dostepOpis(trackBarDostep6.Value);
        }//ustawRyzyko6

        private void pokazParametryRyzyka7()
        {
            trackBarRyzyko7.Value = ryzyko(trackBarWplyw7.Value,
                trackBarCzas7.Value,
                trackBarKwalifikacje7.Value,
                trackBarWiedza7.Value,
                trackBarWyposazenie7.Value,
                trackBarDostep7.Value);

            labelCzas7.Text = _tlumacz.zmien("Czas: ") + trackBarCzas7.Value.ToString();
            labelKwalifikacje7.Text = _tlumacz.zmien("Kwalifikacje: ") + trackBarKwalifikacje7.Value.ToString();
            labelWiedza7.Text = _tlumacz.zmien("Wiedza: ") + trackBarWiedza7.Value.ToString();
            labelWyposazenie7.Text = _tlumacz.zmien("Wyposażenie: ") + trackBarWyposazenie7.Value.ToString();
            labelDostep7.Text = _tlumacz.zmien("Dostęp: ") + trackBarDostep7.Value.ToString();
            labelRyzyko7.Text = _tlumacz.zmien("Ryzyko: ") + trackBarRyzyko7.Value.ToString();

            labelCzasOpis7.Text = czasOpis(trackBarCzas7.Value);
            labelKwalifikacjeOpis7.Text = kwalifikacjeOpis(trackBarKwalifikacje7.Value);
            labelWiedzaOpis7.Text = wiedzaOpis(trackBarWiedza7.Value);
            labelWyposazenieOpis7.Text = wyposazenieOpis(trackBarWyposazenie7.Value);
            labelDostepOpis7.Text = dostepOpis(trackBarDostep7.Value);
        }//ustawRyzyko7

        private void pokazParametryRyzyka8()
        {
            trackBarRyzyko8.Value = ryzyko(trackBarWplyw8.Value,
                trackBarCzas8.Value,
                trackBarKwalifikacje8.Value,
                trackBarWiedza8.Value,
                trackBarWyposazenie8.Value,
                trackBarDostep8.Value);

            labelCzas8.Text = _tlumacz.zmien("Czas: ") + trackBarCzas8.Value.ToString();
            labelKwalifikacje8.Text = _tlumacz.zmien("Kwalifikacje: ") + trackBarKwalifikacje8.Value.ToString();
            labelWiedza8.Text = _tlumacz.zmien("Wiedza: ") + trackBarWiedza8.Value.ToString();
            labelWyposazenie8.Text = _tlumacz.zmien("Wyposażenie: ") + trackBarWyposazenie8.Value.ToString();
            labelDostep8.Text = _tlumacz.zmien("Dostęp: ") + trackBarDostep8.Value.ToString();
            labelRyzyko8.Text = _tlumacz.zmien("Ryzyko: ") + trackBarRyzyko8.Value.ToString();

            labelCzasOpis8.Text = czasOpis(trackBarCzas8.Value);
            labelKwalifikacjeOpis8.Text = kwalifikacjeOpis(trackBarKwalifikacje8.Value);
            labelWiedzaOpis8.Text = wiedzaOpis(trackBarWiedza8.Value);
            labelWyposazenieOpis8.Text = wyposazenieOpis(trackBarWyposazenie8.Value);
            labelDostepOpis8.Text = dostepOpis(trackBarDostep8.Value);
        }//ustawRyzyko8

        private void pokazParametryRyzyka9()
        {
            trackBarRyzyko9.Value = ryzyko(trackBarWplyw9.Value,
                trackBarCzas9.Value,
                trackBarKwalifikacje9.Value,
                trackBarWiedza9.Value,
                trackBarWyposazenie9.Value,
                trackBarDostep9.Value);

            labelCzas9.Text = _tlumacz.zmien("Czas: ") + trackBarCzas9.Value.ToString();
            labelKwalifikacje9.Text = _tlumacz.zmien("Kwalifikacje: ") + trackBarKwalifikacje9.Value.ToString();
            labelWiedza9.Text = _tlumacz.zmien("Wiedza: ") + trackBarWiedza9.Value.ToString();
            labelWyposazenie9.Text = _tlumacz.zmien("Wyposażenie: ") + trackBarWyposazenie9.Value.ToString();
            labelDostep9.Text = _tlumacz.zmien("Dostęp: ") + trackBarDostep9.Value.ToString();
            labelRyzyko9.Text = _tlumacz.zmien("Ryzyko: ") + trackBarRyzyko9.Value.ToString();

            labelCzasOpis9.Text = czasOpis(trackBarCzas9.Value);
            labelKwalifikacjeOpis9.Text = kwalifikacjeOpis(trackBarKwalifikacje9.Value);
            labelWiedzaOpis9.Text = wiedzaOpis(trackBarWiedza9.Value);
            labelWyposazenieOpis9.Text = wyposazenieOpis(trackBarWyposazenie9.Value);
            labelDostepOpis9.Text = dostepOpis(trackBarDostep9.Value);
        }//ustawRyzyko9

        private void pokazParametryRyzyka10()
        {
            trackBarRyzyko10.Value = ryzyko(trackBarWplyw10.Value,
               trackBarCzas10.Value,
               trackBarKwalifikacje10.Value,
               trackBarWiedza10.Value,
               trackBarWyposazenie10.Value,
               trackBarDostep10.Value);

            labelCzas10.Text = _tlumacz.zmien("Czas: ") + trackBarCzas10.Value.ToString();
            labelKwalifikacje10.Text = _tlumacz.zmien("Kwalifikacje: ") + trackBarKwalifikacje10.Value.ToString();
            labelWiedza10.Text = _tlumacz.zmien("Wiedza: ") + trackBarWiedza10.Value.ToString();
            labelWyposazenie10.Text = _tlumacz.zmien("Wyposażenie: ") + trackBarWyposazenie10.Value.ToString();
            labelDostep10.Text = _tlumacz.zmien("Dostęp: ") + trackBarDostep10.Value.ToString();
            labelRyzyko10.Text = _tlumacz.zmien("Ryzyko: ") + trackBarRyzyko10.Value.ToString();

            labelCzasOpis10.Text = czasOpis(trackBarCzas10.Value);
            labelKwalifikacjeOpis10.Text = kwalifikacjeOpis(trackBarKwalifikacje10.Value);
            labelWiedzaOpis10.Text = wiedzaOpis(trackBarWiedza10.Value);
            labelWyposazenieOpis10.Text = wyposazenieOpis(trackBarWyposazenie10.Value);
            labelDostepOpis10.Text = dostepOpis(trackBarDostep10.Value);
        }//ustawRyzyko10

        /// <summary>
        /// Opisuje wartość czasu.
        /// </summary>
        /// <param name="v">Wartość czasu.</param>
        /// <returns>Parametr opisowy.</returns>
        private string czasOpis(int v)
        {
            string s = string.Empty;

            s = _tlumacz.zmien("<= dzień");
            if (v == 1) s = _tlumacz.zmien("<= tydz.");
            if (v == 2) s = _tlumacz.zmien("<= 2 tyg.");
            if (v > 2 & v <= 4) s = _tlumacz.zmien("<= mies.");
            if (v > 4 & v <= 7) s = _tlumacz.zmien("<= 2 mies.");
            if (v > 7 & v <= 10) s = _tlumacz.zmien("<= 3 mies.");
            if (v > 10 & v <= 13) s = _tlumacz.zmien("<= 4 mies.");
            if (v > 13 & v <= 15) s = _tlumacz.zmien("<= 5 mies.");
            if (v > 15 & v <= 17) s = _tlumacz.zmien("<= 6 mies.");
            if (v > 17) s = _tlumacz.zmien("> 6 mies.");

            return s;
        }//opisCzasu

        /// <summary>
        /// Opisuje wartość kwalifikacji.
        /// </summary>
        /// <param name="v">Wartość kwalifikacji.</param>
        /// <returns>Parametr opisowy.</returns>
        private string kwalifikacjeOpis(int v)
        {
            string s = string.Empty;

            s = _tlumacz.zmien("Laik");
            if (v > 1 & v <= 3) s = _tlumacz.zmien("Biegły");
            if (v > 3 & v <= 6) s = _tlumacz.zmien("Ekspert");
            if (v > 6) s = _tlumacz.zmien("Ekspert kilku dziedzin");
            return s;
        }//kwalifikacjeOpis

        /// <summary>
        /// Opisuje wartość wiedzy.
        /// </summary>
        /// <param name="v">Wartość wiedzy.</param>
        /// <returns>Parametr opisowy.</returns>
        private string wiedzaOpis(int v)
        {
            string s = string.Empty;

            s = _tlumacz.zmien("Publiczna");
            if (v > 0 & v <= 3) s = _tlumacz.zmien("Ograniczona");
            if (v > 3 & v <= 7) s = _tlumacz.zmien("Wrażliwa");
            if (v > 7) s = _tlumacz.zmien("Krytyczna");
            return s;
        }//wiedzaOpis

        /// <summary>
        /// Opisuje wartość wymaganej wiedzy.
        /// </summary>
        /// <param name="v">Wartość wiedzy.</param>
        /// <returns>Parametr opisowy.</returns>
        private string wyposazenieOpis(int v)
        {
            string s = string.Empty;

            s = _tlumacz.zmien("Standardowe");
            if (v > 0 & v <= 4) s = _tlumacz.zmien("Specjalistyczne");
            if (v > 4 & v <= 7) s = _tlumacz.zmien("Na zamówienie");
            if (v > 7) s = _tlumacz.zmien("Wielokrotne zamówienie");
            return s;
        }//wyposazenieOpis

        /// <summary>
        /// Opisuje wartość dostepu do przyrzadu.
        /// </summary>
        /// <param name="v">Wartość dostępy do przyrządu.</param>
        /// <returns>Parametr opisowy.</returns>
        private string dostepOpis(int v)
        {
            string s = string.Empty;

            s = _tlumacz.zmien("Nieograniczony");
            if (v == 1) s = _tlumacz.zmien("Łatwy");
            if (v > 1 & v <= 4) s = _tlumacz.zmien("Umiarkowany");
            if (v > 4) s = _tlumacz.zmien("Trudny");
            return s;
        }//dostepOpis

        /// <summary>
        /// Tworzy nowy dokument.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            czysc();
            _suma0 = sumaWartosci();
            _czynnosc = (int)_enum.nowy;
            ustawDostep();
            pokazTytul();
        }//nowyToolStripMenuItem_Click

        /// <summary>
        /// Pokazuje na belce tytułowej nazwę programu i ewentualnie nazwę otwartego pliku.
        /// </summary>
        private void pokazTytul()
        {
            this.Text = "Rami";

            if (_plik != string.Empty)
            {
                FileInfo fi = new FileInfo(_plik);

                this.Text += " [" + fi.Name + "]";
            }
        }//pokazTytul

        /// <summary>
        /// Czysci zawartość formantów.
        /// </summary>
        private void czysc()
        {
            textBoxNazwa.Text = string.Empty;
            textBoxOpis.Text = string.Empty;

            //-----------------------------------Regulacje
            textBoxRegulacja1.Text = string.Empty;
            textBoxRegulacja2.Text = string.Empty;
            textBoxRegulacja3.Text = string.Empty;
            textBoxRegulacja4.Text = string.Empty;
            textBoxRegulacja5.Text = string.Empty;
            textBoxRegulacja6.Text = string.Empty;
            textBoxRegulacja7.Text = string.Empty;
            textBoxRegulacja8.Text = string.Empty;
            textBoxRegulacja9.Text = string.Empty;
            textBoxRegulacja10.Text = string.Empty;

            trackBarWplyw1.Value = trackBarWplyw1.Maximum;
            trackBarWplyw2.Value = trackBarWplyw2.Maximum;
            trackBarWplyw3.Value = trackBarWplyw3.Maximum;
            trackBarWplyw4.Value = trackBarWplyw4.Maximum;
            trackBarWplyw5.Value = trackBarWplyw5.Maximum;
            trackBarWplyw6.Value = trackBarWplyw6.Maximum;
            trackBarWplyw7.Value = trackBarWplyw7.Maximum;
            trackBarWplyw8.Value = trackBarWplyw8.Maximum;
            trackBarWplyw9.Value = trackBarWplyw9.Maximum;
            trackBarWplyw10.Value = trackBarWplyw10.Maximum;

            labelWplyw1.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw1.Value.ToString();
            labelWplyw2.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw2.Value.ToString();
            labelWplyw3.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw3.Value.ToString();
            labelWplyw4.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw4.Value.ToString();
            labelWplyw5.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw5.Value.ToString();
            labelWplyw6.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw6.Value.ToString();
            labelWplyw7.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw7.Value.ToString();
            labelWplyw8.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw8.Value.ToString();
            labelWplyw9.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw9.Value.ToString();
            labelWplyw10.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw10.Value.ToString();

            //-----------------------------------Aktywa
            textBoxAktywa1.Text = string.Empty;
            textBoxAktywa2.Text = string.Empty;
            textBoxAktywa3.Text = string.Empty;
            textBoxAktywa4.Text = string.Empty;
            textBoxAktywa5.Text = string.Empty;
            textBoxAktywa6.Text = string.Empty;
            textBoxAktywa7.Text = string.Empty;
            textBoxAktywa8.Text = string.Empty;
            textBoxAktywa9.Text = string.Empty;
            textBoxAktywa10.Text = string.Empty;

            //-----------------------------------Wł.ochrony
            textBoxWlasnosc1.Text = string.Empty;
            textBoxWlasnosc2.Text = string.Empty;
            textBoxWlasnosc3.Text = string.Empty;
            textBoxWlasnosc4.Text = string.Empty;
            textBoxWlasnosc5.Text = string.Empty;
            textBoxWlasnosc6.Text = string.Empty;
            textBoxWlasnosc7.Text = string.Empty;
            textBoxWlasnosc8.Text = string.Empty;
            textBoxWlasnosc9.Text = string.Empty;
            textBoxWlasnosc10.Text = string.Empty;

            //-----------------------------------Szkody
            textBoxZagrozenie1.Text = string.Empty;
            textBoxZagrozenie2.Text = string.Empty;
            textBoxZagrozenie3.Text = string.Empty;
            textBoxZagrozenie4.Text = string.Empty;
            textBoxZagrozenie5.Text = string.Empty;
            textBoxZagrozenie6.Text = string.Empty;
            textBoxZagrozenie7.Text = string.Empty;
            textBoxZagrozenie8.Text = string.Empty;
            textBoxZagrozenie9.Text = string.Empty;
            textBoxZagrozenie10.Text = string.Empty;

            //-----------------------------------Ataki
            textBoxAtak1.Text = string.Empty;
            textBoxAtak2.Text = string.Empty;
            textBoxAtak3.Text = string.Empty;
            textBoxAtak4.Text = string.Empty;
            textBoxAtak5.Text = string.Empty;
            textBoxAtak6.Text = string.Empty;
            textBoxAtak7.Text = string.Empty;
            textBoxAtak8.Text = string.Empty;
            textBoxAtak9.Text = string.Empty;
            textBoxAtak10.Text = string.Empty;

            //-----------------------------------Wykonawcy
            textBoxWykonawca1.Text = string.Empty;
            textBoxWykonawca2.Text = string.Empty;
            textBoxWykonawca3.Text = string.Empty;
            textBoxWykonawca4.Text = string.Empty;
            textBoxWykonawca5.Text = string.Empty;
            textBoxWykonawca6.Text = string.Empty;
            textBoxWykonawca7.Text = string.Empty;
            textBoxWykonawca8.Text = string.Empty;
            textBoxWykonawca9.Text = string.Empty;
            textBoxWykonawca10.Text = string.Empty;

            //-----------------------------------Regulacja-Aktywa
            labelRegulacja1.Text = string.Empty;
            labelRegulacja2.Text = string.Empty;
            labelRegulacja3.Text = string.Empty;
            labelRegulacja4.Text = string.Empty;
            labelRegulacja5.Text = string.Empty;
            labelRegulacja6.Text = string.Empty;
            labelRegulacja7.Text = string.Empty;
            labelRegulacja8.Text = string.Empty;
            labelRegulacja9.Text = string.Empty;
            labelRegulacja10.Text = string.Empty;

            dodajPozycje(checkedListBoxAktywa1, 10);
            dodajPozycje(checkedListBoxAktywa2, 10);
            dodajPozycje(checkedListBoxAktywa3, 10);
            dodajPozycje(checkedListBoxAktywa4, 10);
            dodajPozycje(checkedListBoxAktywa5, 10);
            dodajPozycje(checkedListBoxAktywa6, 10);
            dodajPozycje(checkedListBoxAktywa7, 10);
            dodajPozycje(checkedListBoxAktywa8, 10);
            dodajPozycje(checkedListBoxAktywa9, 10);
            dodajPozycje(checkedListBoxAktywa10, 10);

            //-----------------------------------Wł.ochrony
            labelAktywa1.Text = string.Empty;
            labelAktywa2.Text = string.Empty;
            labelAktywa3.Text = string.Empty;
            labelAktywa4.Text = string.Empty;
            labelAktywa5.Text = string.Empty;
            labelAktywa6.Text = string.Empty;
            labelAktywa7.Text = string.Empty;
            labelAktywa8.Text = string.Empty;
            labelAktywa9.Text = string.Empty;
            labelAktywa10.Text = string.Empty;

            dodajPozycje(checkedListBoxWlasnosc1, 10);
            dodajPozycje(checkedListBoxWlasnosc2, 10);
            dodajPozycje(checkedListBoxWlasnosc3, 10);
            dodajPozycje(checkedListBoxWlasnosc4, 10);
            dodajPozycje(checkedListBoxWlasnosc5, 10);
            dodajPozycje(checkedListBoxWlasnosc6, 10);
            dodajPozycje(checkedListBoxWlasnosc7, 10);
            dodajPozycje(checkedListBoxWlasnosc8, 10);
            dodajPozycje(checkedListBoxWlasnosc9, 10);
            dodajPozycje(checkedListBoxWlasnosc10, 10);

            //-----------------------------------Atak-Aktywa
            labelAtak1.Text = string.Empty;
            labelAtak2.Text = string.Empty;
            labelAtak3.Text = string.Empty;
            labelAtak4.Text = string.Empty;
            labelAtak5.Text = string.Empty;
            labelAtak6.Text = string.Empty;
            labelAtak7.Text = string.Empty;
            labelAtak8.Text = string.Empty;
            labelAtak9.Text = string.Empty;
            labelAtak10.Text = string.Empty;

            dodajPozycje(checkedListBoxAktywa11, 10);
            dodajPozycje(checkedListBoxAktywa12, 10);
            dodajPozycje(checkedListBoxAktywa13, 10);
            dodajPozycje(checkedListBoxAktywa14, 10);
            dodajPozycje(checkedListBoxAktywa15, 10);
            dodajPozycje(checkedListBoxAktywa16, 10);
            dodajPozycje(checkedListBoxAktywa17, 10);
            dodajPozycje(checkedListBoxAktywa18, 10);
            dodajPozycje(checkedListBoxAktywa19, 10);
            dodajPozycje(checkedListBoxAktywa110, 10);

            //-----------------------------------Atak-Szkoda
            labelAtak11.Text = string.Empty;
            labelAtak12.Text = string.Empty;
            labelAtak13.Text = string.Empty;
            labelAtak14.Text = string.Empty;
            labelAtak15.Text = string.Empty;
            labelAtak16.Text = string.Empty;
            labelAtak17.Text = string.Empty;
            labelAtak18.Text = string.Empty;
            labelAtak19.Text = string.Empty;
            labelAtak110.Text = string.Empty;

            dodajPozycje(checkedListBoxZagrozenie1, 10);
            dodajPozycje(checkedListBoxZagrozenie2, 10);
            dodajPozycje(checkedListBoxZagrozenie3, 10);
            dodajPozycje(checkedListBoxZagrozenie4, 10);
            dodajPozycje(checkedListBoxZagrozenie5, 10);
            dodajPozycje(checkedListBoxZagrozenie6, 10);
            dodajPozycje(checkedListBoxZagrozenie7, 10);
            dodajPozycje(checkedListBoxZagrozenie8, 10);
            dodajPozycje(checkedListBoxZagrozenie9, 10);
            dodajPozycje(checkedListBoxZagrozenie10, 10);

            //-----------------------------------Atak-Wykonawca
            labelAtak21.Text = string.Empty;
            labelAtak22.Text = string.Empty;
            labelAtak23.Text = string.Empty;
            labelAtak24.Text = string.Empty;
            labelAtak25.Text = string.Empty;
            labelAtak26.Text = string.Empty;
            labelAtak27.Text = string.Empty;
            labelAtak28.Text = string.Empty;
            labelAtak29.Text = string.Empty;
            labelAtak210.Text = string.Empty;

            dodajPozycje(checkedListBoxWykonawca1, 10);
            dodajPozycje(checkedListBoxWykonawca2, 10);
            dodajPozycje(checkedListBoxWykonawca3, 10);
            dodajPozycje(checkedListBoxWykonawca4, 10);
            dodajPozycje(checkedListBoxWykonawca5, 10);
            dodajPozycje(checkedListBoxWykonawca6, 10);
            dodajPozycje(checkedListBoxWykonawca7, 10);
            dodajPozycje(checkedListBoxWykonawca8, 10);
            dodajPozycje(checkedListBoxWykonawca9, 10);
            dodajPozycje(checkedListBoxWykonawca10, 10);

            //-----------------------------------Atak-Ryzyko
            labelAtak31.Text = string.Empty;
            trackBarCzas1.Value = trackBarCzas1.Minimum;
            trackBarKwalifikacje1.Value = trackBarKwalifikacje1.Minimum;
            trackBarWiedza1.Value = trackBarWiedza1.Minimum;
            trackBarWyposazenie1.Value = trackBarWyposazenie1.Minimum;
            trackBarDostep1.Value = trackBarDostep1.Minimum;
            trackBarRyzyko1.Value = trackBarRyzyko1.Minimum;

            labelAtak32.Text = string.Empty;
            trackBarCzas2.Value = trackBarCzas2.Minimum;
            trackBarKwalifikacje2.Value = trackBarKwalifikacje2.Minimum;
            trackBarWiedza2.Value = trackBarWiedza2.Minimum;
            trackBarWyposazenie2.Value = trackBarWyposazenie2.Minimum;
            trackBarDostep2.Value = trackBarDostep2.Minimum;
            trackBarRyzyko2.Value = trackBarRyzyko2.Minimum;

            labelAtak33.Text = string.Empty;
            trackBarCzas3.Value = trackBarCzas3.Minimum;
            trackBarKwalifikacje3.Value = trackBarKwalifikacje3.Minimum;
            trackBarWiedza3.Value = trackBarWiedza3.Minimum;
            trackBarWyposazenie3.Value = trackBarWyposazenie3.Minimum;
            trackBarDostep3.Value = trackBarDostep3.Minimum;
            trackBarRyzyko3.Value = trackBarRyzyko3.Minimum;

            labelAtak34.Text = string.Empty;
            trackBarCzas4.Value = trackBarCzas4.Minimum;
            trackBarKwalifikacje4.Value = trackBarKwalifikacje4.Minimum;
            trackBarWiedza4.Value = trackBarWiedza4.Minimum;
            trackBarWyposazenie4.Value = trackBarWyposazenie4.Minimum;
            trackBarDostep4.Value = trackBarDostep4.Minimum;
            trackBarRyzyko4.Value = trackBarRyzyko4.Minimum;

            labelAtak35.Text = string.Empty;
            trackBarCzas5.Value = trackBarCzas5.Minimum;
            trackBarKwalifikacje5.Value = trackBarKwalifikacje5.Minimum;
            trackBarWiedza5.Value = trackBarWiedza5.Minimum;
            trackBarWyposazenie5.Value = trackBarWyposazenie5.Minimum;
            trackBarDostep5.Value = trackBarDostep5.Minimum;
            trackBarRyzyko5.Value = trackBarRyzyko5.Minimum;

            labelAtak36.Text = string.Empty;
            trackBarCzas6.Value = trackBarCzas6.Minimum;
            trackBarKwalifikacje6.Value = trackBarKwalifikacje6.Minimum;
            trackBarWiedza6.Value = trackBarWiedza6.Minimum;
            trackBarWyposazenie6.Value = trackBarWyposazenie6.Minimum;
            trackBarDostep6.Value = trackBarDostep6.Minimum;
            trackBarRyzyko6.Value = trackBarRyzyko6.Minimum;

            labelAtak37.Text = string.Empty;
            trackBarCzas7.Value = trackBarCzas7.Minimum;
            trackBarKwalifikacje7.Value = trackBarKwalifikacje7.Minimum;
            trackBarWiedza7.Value = trackBarWiedza7.Minimum;
            trackBarWyposazenie7.Value = trackBarWyposazenie7.Minimum;
            trackBarDostep7.Value = trackBarDostep7.Minimum;
            trackBarRyzyko7.Value = trackBarRyzyko7.Minimum;

            labelAtak38.Text = string.Empty;
            trackBarCzas8.Value = trackBarCzas8.Minimum;
            trackBarKwalifikacje8.Value = trackBarKwalifikacje8.Minimum;
            trackBarWiedza8.Value = trackBarWiedza8.Minimum;
            trackBarWyposazenie8.Value = trackBarWyposazenie8.Minimum;
            trackBarDostep8.Value = trackBarDostep8.Minimum;
            trackBarRyzyko8.Value = trackBarRyzyko8.Minimum;

            labelAtak39.Text = string.Empty;
            trackBarCzas9.Value = trackBarCzas9.Minimum;
            trackBarKwalifikacje9.Value = trackBarKwalifikacje9.Minimum;
            trackBarWiedza9.Value = trackBarWiedza9.Minimum;
            trackBarWyposazenie9.Value = trackBarWyposazenie9.Minimum;
            trackBarDostep9.Value = trackBarDostep9.Minimum;
            trackBarRyzyko9.Value = trackBarRyzyko9.Minimum;

            labelAtak310.Text = string.Empty;
            trackBarCzas10.Value = trackBarCzas10.Minimum;
            trackBarKwalifikacje10.Value = trackBarKwalifikacje10.Minimum;
            trackBarWiedza10.Value = trackBarWiedza10.Minimum;
            trackBarWyposazenie10.Value = trackBarWyposazenie10.Minimum;
            trackBarDostep10.Value = trackBarDostep10.Minimum;
            trackBarRyzyko10.Value = trackBarRyzyko10.Minimum;

        }//czysc

        /// <summary>
        /// Dodaje puste pozycje.
        /// </summary>
        /// <param name="clb">CheckBoxList.</param>
        /// <param name="n">Liczba pozycji.</param>
        private void dodajPozycje(CheckedListBox clb, int n)
        {
            clb.Items.Clear();

            for (int i = 0; i < n; i++) clb.Items.Add(string.Empty);
        }//dodajPozycje

        private void trackBarCzas1_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka1();
        }

        private void trackBarKwalifikacje1_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka1();
        }

        private void trackBarWiedza1_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka1();
        }

        private void trackWiedza1_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka1();
        }

        private void trackBarDostep1_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka1();
        }

        private void trackBarWyposazenie1_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka1();
        }

        private void trackBarCzas2_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka2();
        }

        private void trackBarKwalifikacje2_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka2();
        }

        private void trackBarWiedza2_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka2();
        }

        private void trackBarWyposazenie2_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka2();
        }

        private void trackBarDostep2_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka2();
        }

        private void trackBarCzas3_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka3();
        }

        private void trackBarKwalifikacje3_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka3();
        }

        private void trackBarWiedza3_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka3();
        }

        private void trackBarWyposazenie3_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka3();
        }

        private void trackBarDostep3_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka3();
        }

        private void trackBarCzas4_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka4();
        }

        private void trackBarKwalifikacje4_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka4();
        }

        private void trackBarWiedza4_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka4();
        }

        private void trackBarWyposazenie4_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka4();
        }

        private void trackBarDostep4_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka4();
        }

        private void trackBarCzas5_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka5();
        }

        private void trackBarKwalifikacje5_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka5();
        }

        private void trackBarWiedza5_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka5();
        }

        private void trackBarWyposazenie5_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka5();
        }

        private void trackBarDostep5_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka5();
        }

        private void trackBarCzas6_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka6();
        }

        private void trackBarKwalifikacje6_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka6();
        }

        private void trackBarWiedza6_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka6();
        }

        private void trackBarWyposazenie6_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka6();
        }

        private void trackBarDostep6_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka6();
        }

        private void trackBarCzas7_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka7();
        }

        private void trackBarKwalifikacje7_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka7();
        }

        private void trackBarWiedza7_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka7();
        }

        private void trackBarWyposazenie7_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka7();
        }

        private void trackBarDostep7_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka7();
        }

        private void trackBarCzas8_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka8();
        }

        private void trackBarKwalifikacje8_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka8();
        }

        private void trackBarWiedza8_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka8();
        }

        private void trackBarWyposazenie8_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka8();
        }

        private void trackBarDostep8_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka8();
        }

        private void trackBarCzas9_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka9();
        }

        private void trackBarKwalifikacje9_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka9();
        }

        private void trackBarWiedza9_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka9();
        }

        private void trackBarWyposazenie9_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka9();
        }

        private void trackBarDostep9_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka9();
        }

        private void trackBarCzas10_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka10();
        }

        private void trackBarKwalifikacje10_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka10();
        }

        private void trackBarWiedza10_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka10();
        }

        private void trackBarWyposazenie10_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka10();
        }

        private void trackBarDostep10_Scroll(object sender, EventArgs e)
        {
            pokazParametryRyzyka10();
        }

        //Otwiera plik z danymi
        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();

            ofp.Filter = "XML|*.xml";
            ofp.Title = "Otwarcie pliku XML";

            if (ofp.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _plik = ofp.FileName;
                    _dane = new nsDane.dane();
                    _dane.read(ofp.FileName);

                    if(!_dane._isEn)
                    {
                        toolStripComboBoxJezyk.SelectedIndex = 0;
                    }
                    else
                        toolStripComboBoxJezyk.SelectedIndex = 1;

                    textBoxNazwa.Text = _dane._nazwa;
                    textBoxOpis.Text = _dane._opis;

                    //------------------------------ Regulacje
                    textBoxRegulacja1.Text = _dane._regulacja1;
                    textBoxRegulacja2.Text = _dane._regulacja2;
                    textBoxRegulacja3.Text = _dane._regulacja3;
                    textBoxRegulacja4.Text = _dane._regulacja4;
                    textBoxRegulacja5.Text = _dane._regulacja5;
                    textBoxRegulacja6.Text = _dane._regulacja6;
                    textBoxRegulacja7.Text = _dane._regulacja7;
                    textBoxRegulacja8.Text = _dane._regulacja8;
                    textBoxRegulacja9.Text = _dane._regulacja9;
                    textBoxRegulacja10.Text = _dane._regulacja10;

                    trackBarWplyw1.Value = _dane._wplyw1;
                    trackBarWplyw2.Value = _dane._wplyw2;
                    trackBarWplyw3.Value = _dane._wplyw3;
                    trackBarWplyw4.Value = _dane._wplyw4;
                    trackBarWplyw5.Value = _dane._wplyw5;
                    trackBarWplyw6.Value = _dane._wplyw6;
                    trackBarWplyw7.Value = _dane._wplyw7;
                    trackBarWplyw8.Value = _dane._wplyw8;
                    trackBarWplyw9.Value = _dane._wplyw9;
                    trackBarWplyw10.Value = _dane._wplyw10;

                    labelWplyw1.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw1.Value.ToString();
                    labelWplyw2.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw2.Value.ToString();
                    labelWplyw3.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw3.Value.ToString();
                    labelWplyw4.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw4.Value.ToString();
                    labelWplyw5.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw5.Value.ToString();
                    labelWplyw6.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw6.Value.ToString();
                    labelWplyw7.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw7.Value.ToString();
                    labelWplyw8.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw8.Value.ToString();
                    labelWplyw9.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw9.Value.ToString();
                    labelWplyw10.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw10.Value.ToString();

                    //------------------------------ Aktywa
                    textBoxAktywa1.Text = _dane._aktywa1;
                    textBoxAktywa2.Text = _dane._aktywa2;
                    textBoxAktywa3.Text = _dane._aktywa3;
                    textBoxAktywa4.Text = _dane._aktywa4;
                    textBoxAktywa5.Text = _dane._aktywa5;
                    textBoxAktywa6.Text = _dane._aktywa6;
                    textBoxAktywa7.Text = _dane._aktywa7;
                    textBoxAktywa8.Text = _dane._aktywa8;
                    textBoxAktywa9.Text = _dane._aktywa9;
                    textBoxAktywa10.Text = _dane._aktywa10;

                    //------------------------------ Wł. ochrony
                    textBoxWlasnosc1.Text = _dane._wlasnosc1;
                    textBoxWlasnosc2.Text = _dane._wlasnosc2;
                    textBoxWlasnosc3.Text = _dane._wlasnosc3;
                    textBoxWlasnosc4.Text = _dane._wlasnosc4;
                    textBoxWlasnosc5.Text = _dane._wlasnosc5;
                    textBoxWlasnosc6.Text = _dane._wlasnosc6;
                    textBoxWlasnosc7.Text = _dane._wlasnosc7;
                    textBoxWlasnosc8.Text = _dane._wlasnosc8;
                    textBoxWlasnosc9.Text = _dane._wlasnosc9;
                    textBoxWlasnosc10.Text = _dane._wlasnosc10;

                    //------------------------------ Szkoda
                    textBoxZagrozenie1.Text = _dane._szkoda1;
                    textBoxZagrozenie2.Text = _dane._szkoda2;
                    textBoxZagrozenie3.Text = _dane._szkoda3;
                    textBoxZagrozenie4.Text = _dane._szkoda4;
                    textBoxZagrozenie5.Text = _dane._szkoda5;
                    textBoxZagrozenie6.Text = _dane._szkoda6;
                    textBoxZagrozenie7.Text = _dane._szkoda7;
                    textBoxZagrozenie8.Text = _dane._szkoda8;
                    textBoxZagrozenie9.Text = _dane._szkoda9;
                    textBoxZagrozenie10.Text = _dane._szkoda10;

                    //------------------------------ Atak
                    textBoxAtak1.Text = _dane._atak1;
                    textBoxAtak2.Text = _dane._atak2;
                    textBoxAtak3.Text = _dane._atak3;
                    textBoxAtak4.Text = _dane._atak4;
                    textBoxAtak5.Text = _dane._atak5;
                    textBoxAtak6.Text = _dane._atak6;
                    textBoxAtak7.Text = _dane._atak7;
                    textBoxAtak8.Text = _dane._atak8;
                    textBoxAtak9.Text = _dane._atak9;
                    textBoxAtak10.Text = _dane._atak10;

                    //------------------------------ Wykonawca
                    textBoxWykonawca1.Text = _dane._wykonawca1;
                    textBoxWykonawca2.Text = _dane._wykonawca2;
                    textBoxWykonawca3.Text = _dane._wykonawca3;
                    textBoxWykonawca4.Text = _dane._wykonawca4;
                    textBoxWykonawca5.Text = _dane._wykonawca5;
                    textBoxWykonawca6.Text = _dane._wykonawca6;
                    textBoxWykonawca7.Text = _dane._wykonawca7;
                    textBoxWykonawca8.Text = _dane._wykonawca8;
                    textBoxWykonawca9.Text = _dane._wykonawca9;
                    textBoxWykonawca10.Text = _dane._wykonawca10;

                    //------------------------------ Regulacja - Aktywa
                    labelRegulacja1.Text = _dane._regulacja1;

                    checkedListBoxAktywa1.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa1.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa1.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa1.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa1.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa1.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa1.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa1.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa1.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa1.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa1.SetItemChecked(0, Convert.ToBoolean(_dane._regulacja1_aktywa1));
                    checkedListBoxAktywa1.SetItemChecked(1, Convert.ToBoolean(_dane._regulacja1_aktywa2));
                    checkedListBoxAktywa1.SetItemChecked(2, Convert.ToBoolean(_dane._regulacja1_aktywa3));
                    checkedListBoxAktywa1.SetItemChecked(3, Convert.ToBoolean(_dane._regulacja1_aktywa4));
                    checkedListBoxAktywa1.SetItemChecked(4, Convert.ToBoolean(_dane._regulacja1_aktywa5));
                    checkedListBoxAktywa1.SetItemChecked(5, Convert.ToBoolean(_dane._regulacja1_aktywa6));
                    checkedListBoxAktywa1.SetItemChecked(6, Convert.ToBoolean(_dane._regulacja1_aktywa7));
                    checkedListBoxAktywa1.SetItemChecked(7, Convert.ToBoolean(_dane._regulacja1_aktywa8));
                    checkedListBoxAktywa1.SetItemChecked(8, Convert.ToBoolean(_dane._regulacja1_aktywa9));
                    checkedListBoxAktywa1.SetItemChecked(9, Convert.ToBoolean(_dane._regulacja1_aktywa10));

                    //----------------
                    labelRegulacja2.Text = _dane._regulacja2;

                    checkedListBoxAktywa2.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa2.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa2.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa2.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa2.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa2.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa2.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa2.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa2.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa2.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa2.SetItemChecked(0, Convert.ToBoolean(_dane._regulacja2_aktywa1));
                    checkedListBoxAktywa2.SetItemChecked(1, Convert.ToBoolean(_dane._regulacja2_aktywa2));
                    checkedListBoxAktywa2.SetItemChecked(2, Convert.ToBoolean(_dane._regulacja2_aktywa3));
                    checkedListBoxAktywa2.SetItemChecked(3, Convert.ToBoolean(_dane._regulacja2_aktywa4));
                    checkedListBoxAktywa2.SetItemChecked(4, Convert.ToBoolean(_dane._regulacja2_aktywa5));
                    checkedListBoxAktywa2.SetItemChecked(5, Convert.ToBoolean(_dane._regulacja2_aktywa6));
                    checkedListBoxAktywa2.SetItemChecked(6, Convert.ToBoolean(_dane._regulacja2_aktywa7));
                    checkedListBoxAktywa2.SetItemChecked(7, Convert.ToBoolean(_dane._regulacja2_aktywa8));
                    checkedListBoxAktywa2.SetItemChecked(8, Convert.ToBoolean(_dane._regulacja2_aktywa9));
                    checkedListBoxAktywa2.SetItemChecked(9, Convert.ToBoolean(_dane._regulacja2_aktywa10));

                    //----------------
                    labelRegulacja3.Text = _dane._regulacja3;

                    checkedListBoxAktywa3.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa3.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa3.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa3.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa3.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa3.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa3.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa3.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa3.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa3.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa3.SetItemChecked(0, Convert.ToBoolean(_dane._regulacja3_aktywa1));
                    checkedListBoxAktywa3.SetItemChecked(1, Convert.ToBoolean(_dane._regulacja3_aktywa2));
                    checkedListBoxAktywa3.SetItemChecked(2, Convert.ToBoolean(_dane._regulacja3_aktywa3));
                    checkedListBoxAktywa3.SetItemChecked(3, Convert.ToBoolean(_dane._regulacja3_aktywa4));
                    checkedListBoxAktywa3.SetItemChecked(4, Convert.ToBoolean(_dane._regulacja3_aktywa5));
                    checkedListBoxAktywa3.SetItemChecked(5, Convert.ToBoolean(_dane._regulacja3_aktywa6));
                    checkedListBoxAktywa3.SetItemChecked(6, Convert.ToBoolean(_dane._regulacja3_aktywa7));
                    checkedListBoxAktywa3.SetItemChecked(7, Convert.ToBoolean(_dane._regulacja3_aktywa8));
                    checkedListBoxAktywa3.SetItemChecked(8, Convert.ToBoolean(_dane._regulacja3_aktywa9));
                    checkedListBoxAktywa3.SetItemChecked(9, Convert.ToBoolean(_dane._regulacja3_aktywa10));

                    //----------------
                    labelRegulacja4.Text = _dane._regulacja4;

                    checkedListBoxAktywa4.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa4.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa4.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa4.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa4.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa4.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa4.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa4.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa4.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa4.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa4.SetItemChecked(0, Convert.ToBoolean(_dane._regulacja4_aktywa1));
                    checkedListBoxAktywa4.SetItemChecked(1, Convert.ToBoolean(_dane._regulacja4_aktywa2));
                    checkedListBoxAktywa4.SetItemChecked(2, Convert.ToBoolean(_dane._regulacja4_aktywa3));
                    checkedListBoxAktywa4.SetItemChecked(3, Convert.ToBoolean(_dane._regulacja4_aktywa4));
                    checkedListBoxAktywa4.SetItemChecked(4, Convert.ToBoolean(_dane._regulacja4_aktywa5));
                    checkedListBoxAktywa4.SetItemChecked(5, Convert.ToBoolean(_dane._regulacja4_aktywa6));
                    checkedListBoxAktywa4.SetItemChecked(6, Convert.ToBoolean(_dane._regulacja4_aktywa7));
                    checkedListBoxAktywa4.SetItemChecked(7, Convert.ToBoolean(_dane._regulacja4_aktywa8));
                    checkedListBoxAktywa4.SetItemChecked(8, Convert.ToBoolean(_dane._regulacja4_aktywa9));
                    checkedListBoxAktywa4.SetItemChecked(9, Convert.ToBoolean(_dane._regulacja4_aktywa10));

                    //----------------
                    labelRegulacja5.Text = _dane._regulacja5;

                    checkedListBoxAktywa5.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa5.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa5.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa5.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa5.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa5.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa5.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa5.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa5.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa5.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa5.SetItemChecked(0, Convert.ToBoolean(_dane._regulacja5_aktywa1));
                    checkedListBoxAktywa5.SetItemChecked(1, Convert.ToBoolean(_dane._regulacja5_aktywa2));
                    checkedListBoxAktywa5.SetItemChecked(2, Convert.ToBoolean(_dane._regulacja5_aktywa3));
                    checkedListBoxAktywa5.SetItemChecked(3, Convert.ToBoolean(_dane._regulacja5_aktywa4));
                    checkedListBoxAktywa5.SetItemChecked(4, Convert.ToBoolean(_dane._regulacja5_aktywa5));
                    checkedListBoxAktywa5.SetItemChecked(5, Convert.ToBoolean(_dane._regulacja5_aktywa6));
                    checkedListBoxAktywa5.SetItemChecked(6, Convert.ToBoolean(_dane._regulacja5_aktywa7));
                    checkedListBoxAktywa5.SetItemChecked(7, Convert.ToBoolean(_dane._regulacja5_aktywa8));
                    checkedListBoxAktywa5.SetItemChecked(8, Convert.ToBoolean(_dane._regulacja5_aktywa9));
                    checkedListBoxAktywa5.SetItemChecked(9, Convert.ToBoolean(_dane._regulacja5_aktywa10));

                    //----------------
                    labelRegulacja6.Text = _dane._regulacja6;

                    checkedListBoxAktywa6.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa6.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa6.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa6.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa6.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa6.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa6.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa6.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa6.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa6.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa6.SetItemChecked(0, Convert.ToBoolean(_dane._regulacja6_aktywa1));
                    checkedListBoxAktywa6.SetItemChecked(1, Convert.ToBoolean(_dane._regulacja6_aktywa2));
                    checkedListBoxAktywa6.SetItemChecked(2, Convert.ToBoolean(_dane._regulacja6_aktywa3));
                    checkedListBoxAktywa6.SetItemChecked(3, Convert.ToBoolean(_dane._regulacja6_aktywa4));
                    checkedListBoxAktywa6.SetItemChecked(4, Convert.ToBoolean(_dane._regulacja6_aktywa5));
                    checkedListBoxAktywa6.SetItemChecked(5, Convert.ToBoolean(_dane._regulacja6_aktywa6));
                    checkedListBoxAktywa6.SetItemChecked(6, Convert.ToBoolean(_dane._regulacja6_aktywa7));
                    checkedListBoxAktywa6.SetItemChecked(7, Convert.ToBoolean(_dane._regulacja6_aktywa8));
                    checkedListBoxAktywa6.SetItemChecked(8, Convert.ToBoolean(_dane._regulacja6_aktywa9));
                    checkedListBoxAktywa6.SetItemChecked(9, Convert.ToBoolean(_dane._regulacja6_aktywa10));

                    //----------------
                    labelRegulacja7.Text = _dane._regulacja7;

                    checkedListBoxAktywa7.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa7.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa7.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa7.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa7.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa7.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa7.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa7.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa7.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa7.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa7.SetItemChecked(0, Convert.ToBoolean(_dane._regulacja7_aktywa1));
                    checkedListBoxAktywa7.SetItemChecked(1, Convert.ToBoolean(_dane._regulacja7_aktywa2));
                    checkedListBoxAktywa7.SetItemChecked(2, Convert.ToBoolean(_dane._regulacja7_aktywa3));
                    checkedListBoxAktywa7.SetItemChecked(3, Convert.ToBoolean(_dane._regulacja7_aktywa4));
                    checkedListBoxAktywa7.SetItemChecked(4, Convert.ToBoolean(_dane._regulacja7_aktywa5));
                    checkedListBoxAktywa7.SetItemChecked(5, Convert.ToBoolean(_dane._regulacja7_aktywa6));
                    checkedListBoxAktywa7.SetItemChecked(6, Convert.ToBoolean(_dane._regulacja7_aktywa7));
                    checkedListBoxAktywa7.SetItemChecked(7, Convert.ToBoolean(_dane._regulacja7_aktywa8));
                    checkedListBoxAktywa7.SetItemChecked(8, Convert.ToBoolean(_dane._regulacja7_aktywa9));
                    checkedListBoxAktywa7.SetItemChecked(9, Convert.ToBoolean(_dane._regulacja7_aktywa10));

                    //----------------
                    labelRegulacja8.Text = _dane._regulacja8;

                    checkedListBoxAktywa8.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa8.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa8.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa8.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa8.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa8.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa8.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa8.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa8.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa8.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa8.SetItemChecked(0, Convert.ToBoolean(_dane._regulacja8_aktywa1));
                    checkedListBoxAktywa8.SetItemChecked(1, Convert.ToBoolean(_dane._regulacja8_aktywa2));
                    checkedListBoxAktywa8.SetItemChecked(2, Convert.ToBoolean(_dane._regulacja8_aktywa3));
                    checkedListBoxAktywa8.SetItemChecked(3, Convert.ToBoolean(_dane._regulacja8_aktywa4));
                    checkedListBoxAktywa8.SetItemChecked(4, Convert.ToBoolean(_dane._regulacja8_aktywa5));
                    checkedListBoxAktywa8.SetItemChecked(5, Convert.ToBoolean(_dane._regulacja8_aktywa6));
                    checkedListBoxAktywa8.SetItemChecked(6, Convert.ToBoolean(_dane._regulacja8_aktywa7));
                    checkedListBoxAktywa8.SetItemChecked(7, Convert.ToBoolean(_dane._regulacja8_aktywa8));
                    checkedListBoxAktywa8.SetItemChecked(8, Convert.ToBoolean(_dane._regulacja8_aktywa9));
                    checkedListBoxAktywa8.SetItemChecked(9, Convert.ToBoolean(_dane._regulacja8_aktywa10));

                    //----------------
                    labelRegulacja9.Text = _dane._regulacja9;

                    checkedListBoxAktywa9.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa9.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa9.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa9.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa9.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa9.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa9.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa9.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa9.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa9.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa9.SetItemChecked(0, Convert.ToBoolean(_dane._regulacja9_aktywa1));
                    checkedListBoxAktywa9.SetItemChecked(1, Convert.ToBoolean(_dane._regulacja9_aktywa2));
                    checkedListBoxAktywa9.SetItemChecked(2, Convert.ToBoolean(_dane._regulacja9_aktywa3));
                    checkedListBoxAktywa9.SetItemChecked(3, Convert.ToBoolean(_dane._regulacja9_aktywa4));
                    checkedListBoxAktywa9.SetItemChecked(4, Convert.ToBoolean(_dane._regulacja9_aktywa5));
                    checkedListBoxAktywa9.SetItemChecked(5, Convert.ToBoolean(_dane._regulacja9_aktywa6));
                    checkedListBoxAktywa9.SetItemChecked(6, Convert.ToBoolean(_dane._regulacja9_aktywa7));
                    checkedListBoxAktywa9.SetItemChecked(7, Convert.ToBoolean(_dane._regulacja9_aktywa8));
                    checkedListBoxAktywa9.SetItemChecked(8, Convert.ToBoolean(_dane._regulacja9_aktywa9));
                    checkedListBoxAktywa9.SetItemChecked(9, Convert.ToBoolean(_dane._regulacja9_aktywa10));

                    //----------------
                    labelRegulacja10.Text = _dane._regulacja10;

                    checkedListBoxAktywa10.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa10.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa10.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa10.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa10.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa10.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa10.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa10.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa10.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa10.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa10.SetItemChecked(0, Convert.ToBoolean(_dane._regulacja10_aktywa1));
                    checkedListBoxAktywa10.SetItemChecked(1, Convert.ToBoolean(_dane._regulacja10_aktywa2));
                    checkedListBoxAktywa10.SetItemChecked(2, Convert.ToBoolean(_dane._regulacja10_aktywa3));
                    checkedListBoxAktywa10.SetItemChecked(3, Convert.ToBoolean(_dane._regulacja10_aktywa4));
                    checkedListBoxAktywa10.SetItemChecked(4, Convert.ToBoolean(_dane._regulacja10_aktywa5));
                    checkedListBoxAktywa10.SetItemChecked(5, Convert.ToBoolean(_dane._regulacja10_aktywa6));
                    checkedListBoxAktywa10.SetItemChecked(6, Convert.ToBoolean(_dane._regulacja10_aktywa7));
                    checkedListBoxAktywa10.SetItemChecked(7, Convert.ToBoolean(_dane._regulacja10_aktywa8));
                    checkedListBoxAktywa10.SetItemChecked(8, Convert.ToBoolean(_dane._regulacja10_aktywa9));
                    checkedListBoxAktywa10.SetItemChecked(9, Convert.ToBoolean(_dane._regulacja10_aktywa10));

                    //------------------------------ Aktywa - Wł. ochrony
                    labelAktywa1.Text = _dane._aktywa1;

                    checkedListBoxWlasnosc1.Items[0] = _dane._wlasnosc1;
                    checkedListBoxWlasnosc1.Items[1] = _dane._wlasnosc2;
                    checkedListBoxWlasnosc1.Items[2] = _dane._wlasnosc3;
                    checkedListBoxWlasnosc1.Items[3] = _dane._wlasnosc4;
                    checkedListBoxWlasnosc1.Items[4] = _dane._wlasnosc5;
                    checkedListBoxWlasnosc1.Items[5] = _dane._wlasnosc6;
                    checkedListBoxWlasnosc1.Items[6] = _dane._wlasnosc7;
                    checkedListBoxWlasnosc1.Items[7] = _dane._wlasnosc8;
                    checkedListBoxWlasnosc1.Items[8] = _dane._wlasnosc9;
                    checkedListBoxWlasnosc1.Items[9] = _dane._wlasnosc10;

                    checkedListBoxWlasnosc1.SetItemChecked(0, Convert.ToBoolean(_dane._aktywa1_wlasnosc1));
                    checkedListBoxWlasnosc1.SetItemChecked(1, Convert.ToBoolean(_dane._aktywa1_wlasnosc2));
                    checkedListBoxWlasnosc1.SetItemChecked(2, Convert.ToBoolean(_dane._aktywa1_wlasnosc3));
                    checkedListBoxWlasnosc1.SetItemChecked(3, Convert.ToBoolean(_dane._aktywa1_wlasnosc4));
                    checkedListBoxWlasnosc1.SetItemChecked(4, Convert.ToBoolean(_dane._aktywa1_wlasnosc5));
                    checkedListBoxWlasnosc1.SetItemChecked(5, Convert.ToBoolean(_dane._aktywa1_wlasnosc6));
                    checkedListBoxWlasnosc1.SetItemChecked(6, Convert.ToBoolean(_dane._aktywa1_wlasnosc7));
                    checkedListBoxWlasnosc1.SetItemChecked(7, Convert.ToBoolean(_dane._aktywa1_wlasnosc8));
                    checkedListBoxWlasnosc1.SetItemChecked(8, Convert.ToBoolean(_dane._aktywa1_wlasnosc9));
                    checkedListBoxWlasnosc1.SetItemChecked(9, Convert.ToBoolean(_dane._aktywa1_wlasnosc10));

                    //----------------
                    labelAktywa2.Text = _dane._aktywa2;

                    checkedListBoxWlasnosc2.Items[0] = _dane._wlasnosc1;
                    checkedListBoxWlasnosc2.Items[1] = _dane._wlasnosc2;
                    checkedListBoxWlasnosc2.Items[2] = _dane._wlasnosc3;
                    checkedListBoxWlasnosc2.Items[3] = _dane._wlasnosc4;
                    checkedListBoxWlasnosc2.Items[4] = _dane._wlasnosc5;
                    checkedListBoxWlasnosc2.Items[5] = _dane._wlasnosc6;
                    checkedListBoxWlasnosc2.Items[6] = _dane._wlasnosc7;
                    checkedListBoxWlasnosc2.Items[7] = _dane._wlasnosc8;
                    checkedListBoxWlasnosc2.Items[8] = _dane._wlasnosc9;
                    checkedListBoxWlasnosc2.Items[9] = _dane._wlasnosc10;

                    checkedListBoxWlasnosc2.SetItemChecked(0, Convert.ToBoolean(_dane._aktywa2_wlasnosc1));
                    checkedListBoxWlasnosc2.SetItemChecked(1, Convert.ToBoolean(_dane._aktywa2_wlasnosc2));
                    checkedListBoxWlasnosc2.SetItemChecked(2, Convert.ToBoolean(_dane._aktywa2_wlasnosc3));
                    checkedListBoxWlasnosc2.SetItemChecked(3, Convert.ToBoolean(_dane._aktywa2_wlasnosc4));
                    checkedListBoxWlasnosc2.SetItemChecked(4, Convert.ToBoolean(_dane._aktywa2_wlasnosc5));
                    checkedListBoxWlasnosc2.SetItemChecked(5, Convert.ToBoolean(_dane._aktywa2_wlasnosc6));
                    checkedListBoxWlasnosc2.SetItemChecked(6, Convert.ToBoolean(_dane._aktywa2_wlasnosc7));
                    checkedListBoxWlasnosc2.SetItemChecked(7, Convert.ToBoolean(_dane._aktywa2_wlasnosc8));
                    checkedListBoxWlasnosc2.SetItemChecked(8, Convert.ToBoolean(_dane._aktywa2_wlasnosc9));
                    checkedListBoxWlasnosc2.SetItemChecked(9, Convert.ToBoolean(_dane._aktywa2_wlasnosc10));

                    //----------------
                    labelAktywa3.Text = _dane._aktywa3;

                    checkedListBoxWlasnosc3.Items[0] = _dane._wlasnosc1;
                    checkedListBoxWlasnosc3.Items[1] = _dane._wlasnosc2;
                    checkedListBoxWlasnosc3.Items[2] = _dane._wlasnosc3;
                    checkedListBoxWlasnosc3.Items[3] = _dane._wlasnosc4;
                    checkedListBoxWlasnosc3.Items[4] = _dane._wlasnosc5;
                    checkedListBoxWlasnosc3.Items[5] = _dane._wlasnosc6;
                    checkedListBoxWlasnosc3.Items[6] = _dane._wlasnosc7;
                    checkedListBoxWlasnosc3.Items[7] = _dane._wlasnosc8;
                    checkedListBoxWlasnosc3.Items[8] = _dane._wlasnosc9;
                    checkedListBoxWlasnosc3.Items[9] = _dane._wlasnosc10;

                    checkedListBoxWlasnosc3.SetItemChecked(0, Convert.ToBoolean(_dane._aktywa3_wlasnosc1));
                    checkedListBoxWlasnosc3.SetItemChecked(1, Convert.ToBoolean(_dane._aktywa3_wlasnosc2));
                    checkedListBoxWlasnosc3.SetItemChecked(2, Convert.ToBoolean(_dane._aktywa3_wlasnosc3));
                    checkedListBoxWlasnosc3.SetItemChecked(3, Convert.ToBoolean(_dane._aktywa3_wlasnosc4));
                    checkedListBoxWlasnosc3.SetItemChecked(4, Convert.ToBoolean(_dane._aktywa3_wlasnosc5));
                    checkedListBoxWlasnosc3.SetItemChecked(5, Convert.ToBoolean(_dane._aktywa3_wlasnosc6));
                    checkedListBoxWlasnosc3.SetItemChecked(6, Convert.ToBoolean(_dane._aktywa3_wlasnosc7));
                    checkedListBoxWlasnosc3.SetItemChecked(7, Convert.ToBoolean(_dane._aktywa3_wlasnosc8));
                    checkedListBoxWlasnosc3.SetItemChecked(8, Convert.ToBoolean(_dane._aktywa3_wlasnosc9));
                    checkedListBoxWlasnosc3.SetItemChecked(9, Convert.ToBoolean(_dane._aktywa3_wlasnosc10));

                    //----------------
                    labelAktywa4.Text = _dane._aktywa4;

                    checkedListBoxWlasnosc4.Items[0] = _dane._wlasnosc1;
                    checkedListBoxWlasnosc4.Items[1] = _dane._wlasnosc2;
                    checkedListBoxWlasnosc4.Items[2] = _dane._wlasnosc3;
                    checkedListBoxWlasnosc4.Items[3] = _dane._wlasnosc4;
                    checkedListBoxWlasnosc4.Items[4] = _dane._wlasnosc5;
                    checkedListBoxWlasnosc4.Items[5] = _dane._wlasnosc6;
                    checkedListBoxWlasnosc4.Items[6] = _dane._wlasnosc7;
                    checkedListBoxWlasnosc4.Items[7] = _dane._wlasnosc8;
                    checkedListBoxWlasnosc4.Items[8] = _dane._wlasnosc9;
                    checkedListBoxWlasnosc4.Items[9] = _dane._wlasnosc10;

                    checkedListBoxWlasnosc4.SetItemChecked(0, Convert.ToBoolean(_dane._aktywa4_wlasnosc1));
                    checkedListBoxWlasnosc4.SetItemChecked(1, Convert.ToBoolean(_dane._aktywa4_wlasnosc2));
                    checkedListBoxWlasnosc4.SetItemChecked(2, Convert.ToBoolean(_dane._aktywa4_wlasnosc3));
                    checkedListBoxWlasnosc4.SetItemChecked(3, Convert.ToBoolean(_dane._aktywa4_wlasnosc4));
                    checkedListBoxWlasnosc4.SetItemChecked(4, Convert.ToBoolean(_dane._aktywa4_wlasnosc5));
                    checkedListBoxWlasnosc4.SetItemChecked(5, Convert.ToBoolean(_dane._aktywa4_wlasnosc6));
                    checkedListBoxWlasnosc4.SetItemChecked(6, Convert.ToBoolean(_dane._aktywa4_wlasnosc7));
                    checkedListBoxWlasnosc4.SetItemChecked(7, Convert.ToBoolean(_dane._aktywa4_wlasnosc8));
                    checkedListBoxWlasnosc4.SetItemChecked(8, Convert.ToBoolean(_dane._aktywa4_wlasnosc9));
                    checkedListBoxWlasnosc4.SetItemChecked(9, Convert.ToBoolean(_dane._aktywa4_wlasnosc10));

                    //----------------
                    labelAktywa5.Text = _dane._aktywa5;

                    checkedListBoxWlasnosc5.Items[0] = _dane._wlasnosc1;
                    checkedListBoxWlasnosc5.Items[1] = _dane._wlasnosc2;
                    checkedListBoxWlasnosc5.Items[2] = _dane._wlasnosc3;
                    checkedListBoxWlasnosc5.Items[3] = _dane._wlasnosc4;
                    checkedListBoxWlasnosc5.Items[4] = _dane._wlasnosc5;
                    checkedListBoxWlasnosc5.Items[5] = _dane._wlasnosc6;
                    checkedListBoxWlasnosc5.Items[6] = _dane._wlasnosc7;
                    checkedListBoxWlasnosc5.Items[7] = _dane._wlasnosc8;
                    checkedListBoxWlasnosc5.Items[8] = _dane._wlasnosc9;
                    checkedListBoxWlasnosc5.Items[9] = _dane._wlasnosc10;

                    checkedListBoxWlasnosc5.SetItemChecked(0, Convert.ToBoolean(_dane._aktywa5_wlasnosc1));
                    checkedListBoxWlasnosc5.SetItemChecked(1, Convert.ToBoolean(_dane._aktywa5_wlasnosc2));
                    checkedListBoxWlasnosc5.SetItemChecked(2, Convert.ToBoolean(_dane._aktywa5_wlasnosc3));
                    checkedListBoxWlasnosc5.SetItemChecked(3, Convert.ToBoolean(_dane._aktywa5_wlasnosc4));
                    checkedListBoxWlasnosc5.SetItemChecked(4, Convert.ToBoolean(_dane._aktywa5_wlasnosc5));
                    checkedListBoxWlasnosc5.SetItemChecked(5, Convert.ToBoolean(_dane._aktywa5_wlasnosc6));
                    checkedListBoxWlasnosc5.SetItemChecked(6, Convert.ToBoolean(_dane._aktywa5_wlasnosc7));
                    checkedListBoxWlasnosc5.SetItemChecked(7, Convert.ToBoolean(_dane._aktywa5_wlasnosc8));
                    checkedListBoxWlasnosc5.SetItemChecked(8, Convert.ToBoolean(_dane._aktywa5_wlasnosc9));
                    checkedListBoxWlasnosc5.SetItemChecked(9, Convert.ToBoolean(_dane._aktywa5_wlasnosc10));

                    //----------------
                    labelAktywa6.Text = _dane._aktywa6;

                    checkedListBoxWlasnosc6.Items[0] = _dane._wlasnosc1;
                    checkedListBoxWlasnosc6.Items[1] = _dane._wlasnosc2;
                    checkedListBoxWlasnosc6.Items[2] = _dane._wlasnosc3;
                    checkedListBoxWlasnosc6.Items[3] = _dane._wlasnosc4;
                    checkedListBoxWlasnosc6.Items[4] = _dane._wlasnosc5;
                    checkedListBoxWlasnosc6.Items[5] = _dane._wlasnosc6;
                    checkedListBoxWlasnosc6.Items[6] = _dane._wlasnosc7;
                    checkedListBoxWlasnosc6.Items[7] = _dane._wlasnosc8;
                    checkedListBoxWlasnosc6.Items[8] = _dane._wlasnosc9;
                    checkedListBoxWlasnosc6.Items[9] = _dane._wlasnosc10;

                    checkedListBoxWlasnosc6.SetItemChecked(0, Convert.ToBoolean(_dane._aktywa6_wlasnosc1));
                    checkedListBoxWlasnosc6.SetItemChecked(1, Convert.ToBoolean(_dane._aktywa6_wlasnosc2));
                    checkedListBoxWlasnosc6.SetItemChecked(2, Convert.ToBoolean(_dane._aktywa6_wlasnosc3));
                    checkedListBoxWlasnosc6.SetItemChecked(3, Convert.ToBoolean(_dane._aktywa6_wlasnosc4));
                    checkedListBoxWlasnosc6.SetItemChecked(4, Convert.ToBoolean(_dane._aktywa6_wlasnosc5));
                    checkedListBoxWlasnosc6.SetItemChecked(5, Convert.ToBoolean(_dane._aktywa6_wlasnosc6));
                    checkedListBoxWlasnosc6.SetItemChecked(6, Convert.ToBoolean(_dane._aktywa6_wlasnosc7));
                    checkedListBoxWlasnosc6.SetItemChecked(7, Convert.ToBoolean(_dane._aktywa6_wlasnosc8));
                    checkedListBoxWlasnosc6.SetItemChecked(8, Convert.ToBoolean(_dane._aktywa6_wlasnosc9));
                    checkedListBoxWlasnosc6.SetItemChecked(9, Convert.ToBoolean(_dane._aktywa6_wlasnosc10));

                    //----------------
                    labelAktywa7.Text = _dane._aktywa7;

                    checkedListBoxWlasnosc7.Items[0] = _dane._wlasnosc1;
                    checkedListBoxWlasnosc7.Items[1] = _dane._wlasnosc2;
                    checkedListBoxWlasnosc7.Items[2] = _dane._wlasnosc3;
                    checkedListBoxWlasnosc7.Items[3] = _dane._wlasnosc4;
                    checkedListBoxWlasnosc7.Items[4] = _dane._wlasnosc5;
                    checkedListBoxWlasnosc7.Items[5] = _dane._wlasnosc6;
                    checkedListBoxWlasnosc7.Items[6] = _dane._wlasnosc7;
                    checkedListBoxWlasnosc7.Items[7] = _dane._wlasnosc8;
                    checkedListBoxWlasnosc7.Items[8] = _dane._wlasnosc9;
                    checkedListBoxWlasnosc7.Items[9] = _dane._wlasnosc10;

                    checkedListBoxWlasnosc7.SetItemChecked(0, Convert.ToBoolean(_dane._aktywa7_wlasnosc1));
                    checkedListBoxWlasnosc7.SetItemChecked(1, Convert.ToBoolean(_dane._aktywa7_wlasnosc2));
                    checkedListBoxWlasnosc7.SetItemChecked(2, Convert.ToBoolean(_dane._aktywa7_wlasnosc3));
                    checkedListBoxWlasnosc7.SetItemChecked(3, Convert.ToBoolean(_dane._aktywa7_wlasnosc4));
                    checkedListBoxWlasnosc7.SetItemChecked(4, Convert.ToBoolean(_dane._aktywa7_wlasnosc5));
                    checkedListBoxWlasnosc7.SetItemChecked(5, Convert.ToBoolean(_dane._aktywa7_wlasnosc6));
                    checkedListBoxWlasnosc7.SetItemChecked(6, Convert.ToBoolean(_dane._aktywa7_wlasnosc7));
                    checkedListBoxWlasnosc7.SetItemChecked(7, Convert.ToBoolean(_dane._aktywa7_wlasnosc8));
                    checkedListBoxWlasnosc7.SetItemChecked(8, Convert.ToBoolean(_dane._aktywa7_wlasnosc9));
                    checkedListBoxWlasnosc7.SetItemChecked(9, Convert.ToBoolean(_dane._aktywa7_wlasnosc10));

                    //----------------
                    labelAktywa8.Text = _dane._aktywa8;

                    checkedListBoxWlasnosc8.Items[0] = _dane._wlasnosc1;
                    checkedListBoxWlasnosc8.Items[1] = _dane._wlasnosc2;
                    checkedListBoxWlasnosc8.Items[2] = _dane._wlasnosc3;
                    checkedListBoxWlasnosc8.Items[3] = _dane._wlasnosc4;
                    checkedListBoxWlasnosc8.Items[4] = _dane._wlasnosc5;
                    checkedListBoxWlasnosc8.Items[5] = _dane._wlasnosc6;
                    checkedListBoxWlasnosc8.Items[6] = _dane._wlasnosc7;
                    checkedListBoxWlasnosc8.Items[7] = _dane._wlasnosc8;
                    checkedListBoxWlasnosc8.Items[8] = _dane._wlasnosc9;
                    checkedListBoxWlasnosc8.Items[9] = _dane._wlasnosc10;

                    checkedListBoxWlasnosc8.SetItemChecked(0, Convert.ToBoolean(_dane._aktywa8_wlasnosc1));
                    checkedListBoxWlasnosc8.SetItemChecked(1, Convert.ToBoolean(_dane._aktywa8_wlasnosc2));
                    checkedListBoxWlasnosc8.SetItemChecked(2, Convert.ToBoolean(_dane._aktywa8_wlasnosc3));
                    checkedListBoxWlasnosc8.SetItemChecked(3, Convert.ToBoolean(_dane._aktywa8_wlasnosc4));
                    checkedListBoxWlasnosc8.SetItemChecked(4, Convert.ToBoolean(_dane._aktywa8_wlasnosc5));
                    checkedListBoxWlasnosc8.SetItemChecked(5, Convert.ToBoolean(_dane._aktywa8_wlasnosc6));
                    checkedListBoxWlasnosc8.SetItemChecked(6, Convert.ToBoolean(_dane._aktywa8_wlasnosc7));
                    checkedListBoxWlasnosc8.SetItemChecked(7, Convert.ToBoolean(_dane._aktywa8_wlasnosc8));
                    checkedListBoxWlasnosc8.SetItemChecked(8, Convert.ToBoolean(_dane._aktywa8_wlasnosc9));
                    checkedListBoxWlasnosc8.SetItemChecked(9, Convert.ToBoolean(_dane._aktywa8_wlasnosc10));

                    //----------------
                    labelAktywa9.Text = _dane._aktywa9;

                    checkedListBoxWlasnosc9.Items[0] = _dane._wlasnosc1;
                    checkedListBoxWlasnosc9.Items[1] = _dane._wlasnosc2;
                    checkedListBoxWlasnosc9.Items[2] = _dane._wlasnosc3;
                    checkedListBoxWlasnosc9.Items[3] = _dane._wlasnosc4;
                    checkedListBoxWlasnosc9.Items[4] = _dane._wlasnosc5;
                    checkedListBoxWlasnosc9.Items[5] = _dane._wlasnosc6;
                    checkedListBoxWlasnosc9.Items[6] = _dane._wlasnosc7;
                    checkedListBoxWlasnosc9.Items[7] = _dane._wlasnosc8;
                    checkedListBoxWlasnosc9.Items[8] = _dane._wlasnosc9;
                    checkedListBoxWlasnosc9.Items[9] = _dane._wlasnosc10;

                    checkedListBoxWlasnosc9.SetItemChecked(0, Convert.ToBoolean(_dane._aktywa9_wlasnosc1));
                    checkedListBoxWlasnosc9.SetItemChecked(1, Convert.ToBoolean(_dane._aktywa9_wlasnosc2));
                    checkedListBoxWlasnosc9.SetItemChecked(2, Convert.ToBoolean(_dane._aktywa9_wlasnosc3));
                    checkedListBoxWlasnosc9.SetItemChecked(3, Convert.ToBoolean(_dane._aktywa9_wlasnosc4));
                    checkedListBoxWlasnosc9.SetItemChecked(4, Convert.ToBoolean(_dane._aktywa9_wlasnosc5));
                    checkedListBoxWlasnosc9.SetItemChecked(5, Convert.ToBoolean(_dane._aktywa9_wlasnosc6));
                    checkedListBoxWlasnosc9.SetItemChecked(6, Convert.ToBoolean(_dane._aktywa9_wlasnosc7));
                    checkedListBoxWlasnosc9.SetItemChecked(7, Convert.ToBoolean(_dane._aktywa9_wlasnosc8));
                    checkedListBoxWlasnosc9.SetItemChecked(8, Convert.ToBoolean(_dane._aktywa9_wlasnosc9));
                    checkedListBoxWlasnosc9.SetItemChecked(9, Convert.ToBoolean(_dane._aktywa9_wlasnosc10));

                    //----------------
                    labelAktywa10.Text = _dane._aktywa10;

                    checkedListBoxWlasnosc10.Items[0] = _dane._wlasnosc1;
                    checkedListBoxWlasnosc10.Items[1] = _dane._wlasnosc2;
                    checkedListBoxWlasnosc10.Items[2] = _dane._wlasnosc3;
                    checkedListBoxWlasnosc10.Items[3] = _dane._wlasnosc4;
                    checkedListBoxWlasnosc10.Items[4] = _dane._wlasnosc5;
                    checkedListBoxWlasnosc10.Items[5] = _dane._wlasnosc6;
                    checkedListBoxWlasnosc10.Items[6] = _dane._wlasnosc7;
                    checkedListBoxWlasnosc10.Items[7] = _dane._wlasnosc8;
                    checkedListBoxWlasnosc10.Items[8] = _dane._wlasnosc9;
                    checkedListBoxWlasnosc10.Items[9] = _dane._wlasnosc10;

                    checkedListBoxWlasnosc10.SetItemChecked(0, Convert.ToBoolean(_dane._aktywa10_wlasnosc1));
                    checkedListBoxWlasnosc10.SetItemChecked(1, Convert.ToBoolean(_dane._aktywa10_wlasnosc2));
                    checkedListBoxWlasnosc10.SetItemChecked(2, Convert.ToBoolean(_dane._aktywa10_wlasnosc3));
                    checkedListBoxWlasnosc10.SetItemChecked(3, Convert.ToBoolean(_dane._aktywa10_wlasnosc4));
                    checkedListBoxWlasnosc10.SetItemChecked(4, Convert.ToBoolean(_dane._aktywa10_wlasnosc5));
                    checkedListBoxWlasnosc10.SetItemChecked(5, Convert.ToBoolean(_dane._aktywa10_wlasnosc6));
                    checkedListBoxWlasnosc10.SetItemChecked(6, Convert.ToBoolean(_dane._aktywa10_wlasnosc7));
                    checkedListBoxWlasnosc10.SetItemChecked(7, Convert.ToBoolean(_dane._aktywa10_wlasnosc8));
                    checkedListBoxWlasnosc10.SetItemChecked(8, Convert.ToBoolean(_dane._aktywa10_wlasnosc9));
                    checkedListBoxWlasnosc10.SetItemChecked(9, Convert.ToBoolean(_dane._aktywa10_wlasnosc10));

                    //------------------------------ Atak - Aktywa
                    labelAtak1.Text = _dane._atak1;

                    checkedListBoxAktywa11.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa11.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa11.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa11.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa11.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa11.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa11.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa11.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa11.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa11.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa11.SetItemChecked(0, Convert.ToBoolean(_dane._atak1_aktywa1));
                    checkedListBoxAktywa11.SetItemChecked(1, Convert.ToBoolean(_dane._atak1_aktywa2));
                    checkedListBoxAktywa11.SetItemChecked(2, Convert.ToBoolean(_dane._atak1_aktywa3));
                    checkedListBoxAktywa11.SetItemChecked(3, Convert.ToBoolean(_dane._atak1_aktywa4));
                    checkedListBoxAktywa11.SetItemChecked(4, Convert.ToBoolean(_dane._atak1_aktywa5));
                    checkedListBoxAktywa11.SetItemChecked(5, Convert.ToBoolean(_dane._atak1_aktywa6));
                    checkedListBoxAktywa11.SetItemChecked(6, Convert.ToBoolean(_dane._atak1_aktywa7));
                    checkedListBoxAktywa11.SetItemChecked(7, Convert.ToBoolean(_dane._atak1_aktywa8));
                    checkedListBoxAktywa11.SetItemChecked(8, Convert.ToBoolean(_dane._atak1_aktywa9));
                    checkedListBoxAktywa11.SetItemChecked(9, Convert.ToBoolean(_dane._atak1_aktywa10));

                    //----------------

                    labelAtak2.Text = _dane._atak2;

                    checkedListBoxAktywa12.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa12.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa12.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa12.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa12.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa12.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa12.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa12.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa12.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa12.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa12.SetItemChecked(0, Convert.ToBoolean(_dane._atak2_aktywa1));
                    checkedListBoxAktywa12.SetItemChecked(1, Convert.ToBoolean(_dane._atak2_aktywa2));
                    checkedListBoxAktywa12.SetItemChecked(2, Convert.ToBoolean(_dane._atak2_aktywa3));
                    checkedListBoxAktywa12.SetItemChecked(3, Convert.ToBoolean(_dane._atak2_aktywa4));
                    checkedListBoxAktywa12.SetItemChecked(4, Convert.ToBoolean(_dane._atak2_aktywa5));
                    checkedListBoxAktywa12.SetItemChecked(5, Convert.ToBoolean(_dane._atak2_aktywa6));
                    checkedListBoxAktywa12.SetItemChecked(6, Convert.ToBoolean(_dane._atak2_aktywa7));
                    checkedListBoxAktywa12.SetItemChecked(7, Convert.ToBoolean(_dane._atak2_aktywa8));
                    checkedListBoxAktywa12.SetItemChecked(8, Convert.ToBoolean(_dane._atak2_aktywa9));
                    checkedListBoxAktywa12.SetItemChecked(9, Convert.ToBoolean(_dane._atak2_aktywa10));

                    //----------------

                    labelAtak3.Text = _dane._atak3;

                    checkedListBoxAktywa13.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa13.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa13.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa13.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa13.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa13.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa13.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa13.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa13.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa13.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa13.SetItemChecked(0, Convert.ToBoolean(_dane._atak3_aktywa1));
                    checkedListBoxAktywa13.SetItemChecked(1, Convert.ToBoolean(_dane._atak3_aktywa2));
                    checkedListBoxAktywa13.SetItemChecked(2, Convert.ToBoolean(_dane._atak3_aktywa3));
                    checkedListBoxAktywa13.SetItemChecked(3, Convert.ToBoolean(_dane._atak3_aktywa4));
                    checkedListBoxAktywa13.SetItemChecked(4, Convert.ToBoolean(_dane._atak3_aktywa5));
                    checkedListBoxAktywa13.SetItemChecked(5, Convert.ToBoolean(_dane._atak3_aktywa6));
                    checkedListBoxAktywa13.SetItemChecked(6, Convert.ToBoolean(_dane._atak3_aktywa7));
                    checkedListBoxAktywa13.SetItemChecked(7, Convert.ToBoolean(_dane._atak3_aktywa8));
                    checkedListBoxAktywa13.SetItemChecked(8, Convert.ToBoolean(_dane._atak3_aktywa9));
                    checkedListBoxAktywa13.SetItemChecked(9, Convert.ToBoolean(_dane._atak3_aktywa10));

                    //----------------

                    labelAtak4.Text = _dane._atak4;

                    checkedListBoxAktywa14.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa14.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa14.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa14.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa14.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa14.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa14.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa14.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa14.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa14.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa14.SetItemChecked(0, Convert.ToBoolean(_dane._atak4_aktywa1));
                    checkedListBoxAktywa14.SetItemChecked(1, Convert.ToBoolean(_dane._atak4_aktywa2));
                    checkedListBoxAktywa14.SetItemChecked(2, Convert.ToBoolean(_dane._atak4_aktywa3));
                    checkedListBoxAktywa14.SetItemChecked(3, Convert.ToBoolean(_dane._atak4_aktywa4));
                    checkedListBoxAktywa14.SetItemChecked(4, Convert.ToBoolean(_dane._atak4_aktywa5));
                    checkedListBoxAktywa14.SetItemChecked(5, Convert.ToBoolean(_dane._atak4_aktywa6));
                    checkedListBoxAktywa14.SetItemChecked(6, Convert.ToBoolean(_dane._atak4_aktywa7));
                    checkedListBoxAktywa14.SetItemChecked(7, Convert.ToBoolean(_dane._atak4_aktywa8));
                    checkedListBoxAktywa14.SetItemChecked(8, Convert.ToBoolean(_dane._atak4_aktywa9));
                    checkedListBoxAktywa14.SetItemChecked(9, Convert.ToBoolean(_dane._atak4_aktywa10));

                    //----------------

                    labelAtak5.Text = _dane._atak5;

                    checkedListBoxAktywa15.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa15.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa15.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa15.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa15.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa15.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa15.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa15.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa15.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa15.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa15.SetItemChecked(0, Convert.ToBoolean(_dane._atak5_aktywa1));
                    checkedListBoxAktywa15.SetItemChecked(1, Convert.ToBoolean(_dane._atak5_aktywa2));
                    checkedListBoxAktywa15.SetItemChecked(2, Convert.ToBoolean(_dane._atak5_aktywa3));
                    checkedListBoxAktywa15.SetItemChecked(3, Convert.ToBoolean(_dane._atak5_aktywa4));
                    checkedListBoxAktywa15.SetItemChecked(4, Convert.ToBoolean(_dane._atak5_aktywa5));
                    checkedListBoxAktywa15.SetItemChecked(5, Convert.ToBoolean(_dane._atak5_aktywa6));
                    checkedListBoxAktywa15.SetItemChecked(6, Convert.ToBoolean(_dane._atak5_aktywa7));
                    checkedListBoxAktywa15.SetItemChecked(7, Convert.ToBoolean(_dane._atak5_aktywa8));
                    checkedListBoxAktywa15.SetItemChecked(8, Convert.ToBoolean(_dane._atak5_aktywa9));
                    checkedListBoxAktywa15.SetItemChecked(9, Convert.ToBoolean(_dane._atak5_aktywa10));

                    //----------------

                    labelAtak6.Text = _dane._atak6;

                    checkedListBoxAktywa16.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa16.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa16.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa16.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa16.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa16.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa16.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa16.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa16.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa16.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa16.SetItemChecked(0, Convert.ToBoolean(_dane._atak6_aktywa1));
                    checkedListBoxAktywa16.SetItemChecked(1, Convert.ToBoolean(_dane._atak6_aktywa2));
                    checkedListBoxAktywa16.SetItemChecked(2, Convert.ToBoolean(_dane._atak6_aktywa3));
                    checkedListBoxAktywa16.SetItemChecked(3, Convert.ToBoolean(_dane._atak6_aktywa4));
                    checkedListBoxAktywa16.SetItemChecked(4, Convert.ToBoolean(_dane._atak6_aktywa5));
                    checkedListBoxAktywa16.SetItemChecked(5, Convert.ToBoolean(_dane._atak6_aktywa6));
                    checkedListBoxAktywa16.SetItemChecked(6, Convert.ToBoolean(_dane._atak6_aktywa7));
                    checkedListBoxAktywa16.SetItemChecked(7, Convert.ToBoolean(_dane._atak6_aktywa8));
                    checkedListBoxAktywa16.SetItemChecked(8, Convert.ToBoolean(_dane._atak6_aktywa9));
                    checkedListBoxAktywa16.SetItemChecked(9, Convert.ToBoolean(_dane._atak6_aktywa10));

                    //----------------

                    labelAtak7.Text = _dane._atak7;

                    checkedListBoxAktywa17.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa17.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa17.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa17.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa17.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa17.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa17.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa17.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa17.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa17.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa17.SetItemChecked(0, Convert.ToBoolean(_dane._atak7_aktywa1));
                    checkedListBoxAktywa17.SetItemChecked(1, Convert.ToBoolean(_dane._atak7_aktywa2));
                    checkedListBoxAktywa17.SetItemChecked(2, Convert.ToBoolean(_dane._atak7_aktywa3));
                    checkedListBoxAktywa17.SetItemChecked(3, Convert.ToBoolean(_dane._atak7_aktywa4));
                    checkedListBoxAktywa17.SetItemChecked(4, Convert.ToBoolean(_dane._atak7_aktywa5));
                    checkedListBoxAktywa17.SetItemChecked(5, Convert.ToBoolean(_dane._atak7_aktywa6));
                    checkedListBoxAktywa17.SetItemChecked(6, Convert.ToBoolean(_dane._atak7_aktywa7));
                    checkedListBoxAktywa17.SetItemChecked(7, Convert.ToBoolean(_dane._atak7_aktywa8));
                    checkedListBoxAktywa17.SetItemChecked(8, Convert.ToBoolean(_dane._atak7_aktywa9));
                    checkedListBoxAktywa17.SetItemChecked(9, Convert.ToBoolean(_dane._atak7_aktywa10));

                    //----------------

                    labelAtak8.Text = _dane._atak8;

                    checkedListBoxAktywa18.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa18.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa18.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa18.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa18.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa18.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa18.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa18.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa18.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa18.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa18.SetItemChecked(0, Convert.ToBoolean(_dane._atak8_aktywa1));
                    checkedListBoxAktywa18.SetItemChecked(1, Convert.ToBoolean(_dane._atak8_aktywa2));
                    checkedListBoxAktywa18.SetItemChecked(2, Convert.ToBoolean(_dane._atak8_aktywa3));
                    checkedListBoxAktywa18.SetItemChecked(3, Convert.ToBoolean(_dane._atak8_aktywa4));
                    checkedListBoxAktywa18.SetItemChecked(4, Convert.ToBoolean(_dane._atak8_aktywa5));
                    checkedListBoxAktywa18.SetItemChecked(5, Convert.ToBoolean(_dane._atak8_aktywa6));
                    checkedListBoxAktywa18.SetItemChecked(6, Convert.ToBoolean(_dane._atak8_aktywa7));
                    checkedListBoxAktywa18.SetItemChecked(7, Convert.ToBoolean(_dane._atak8_aktywa8));
                    checkedListBoxAktywa18.SetItemChecked(8, Convert.ToBoolean(_dane._atak8_aktywa9));
                    checkedListBoxAktywa18.SetItemChecked(9, Convert.ToBoolean(_dane._atak8_aktywa10));

                    //----------------
                    labelAtak9.Text = _dane._atak9;

                    checkedListBoxAktywa19.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa19.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa19.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa19.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa19.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa19.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa19.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa19.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa19.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa19.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa19.SetItemChecked(0, Convert.ToBoolean(_dane._atak9_aktywa1));
                    checkedListBoxAktywa19.SetItemChecked(1, Convert.ToBoolean(_dane._atak9_aktywa2));
                    checkedListBoxAktywa19.SetItemChecked(2, Convert.ToBoolean(_dane._atak9_aktywa3));
                    checkedListBoxAktywa19.SetItemChecked(3, Convert.ToBoolean(_dane._atak9_aktywa4));
                    checkedListBoxAktywa19.SetItemChecked(4, Convert.ToBoolean(_dane._atak9_aktywa5));
                    checkedListBoxAktywa19.SetItemChecked(5, Convert.ToBoolean(_dane._atak9_aktywa6));
                    checkedListBoxAktywa19.SetItemChecked(6, Convert.ToBoolean(_dane._atak9_aktywa7));
                    checkedListBoxAktywa19.SetItemChecked(7, Convert.ToBoolean(_dane._atak9_aktywa8));
                    checkedListBoxAktywa19.SetItemChecked(8, Convert.ToBoolean(_dane._atak9_aktywa9));
                    checkedListBoxAktywa19.SetItemChecked(9, Convert.ToBoolean(_dane._atak9_aktywa10));

                    //----------------
                    labelAtak1.Text = _dane._atak1;

                    checkedListBoxAktywa110.Items[0] = _dane._aktywa1;
                    checkedListBoxAktywa110.Items[1] = _dane._aktywa2;
                    checkedListBoxAktywa110.Items[2] = _dane._aktywa3;
                    checkedListBoxAktywa110.Items[3] = _dane._aktywa4;
                    checkedListBoxAktywa110.Items[4] = _dane._aktywa5;
                    checkedListBoxAktywa110.Items[5] = _dane._aktywa6;
                    checkedListBoxAktywa110.Items[6] = _dane._aktywa7;
                    checkedListBoxAktywa110.Items[7] = _dane._aktywa8;
                    checkedListBoxAktywa110.Items[8] = _dane._aktywa9;
                    checkedListBoxAktywa110.Items[9] = _dane._aktywa10;

                    checkedListBoxAktywa110.SetItemChecked(0, Convert.ToBoolean(_dane._atak10_aktywa1));
                    checkedListBoxAktywa110.SetItemChecked(1, Convert.ToBoolean(_dane._atak10_aktywa2));
                    checkedListBoxAktywa110.SetItemChecked(2, Convert.ToBoolean(_dane._atak10_aktywa3));
                    checkedListBoxAktywa110.SetItemChecked(3, Convert.ToBoolean(_dane._atak10_aktywa4));
                    checkedListBoxAktywa110.SetItemChecked(4, Convert.ToBoolean(_dane._atak10_aktywa5));
                    checkedListBoxAktywa110.SetItemChecked(5, Convert.ToBoolean(_dane._atak10_aktywa6));
                    checkedListBoxAktywa110.SetItemChecked(6, Convert.ToBoolean(_dane._atak10_aktywa7));
                    checkedListBoxAktywa110.SetItemChecked(7, Convert.ToBoolean(_dane._atak10_aktywa8));
                    checkedListBoxAktywa110.SetItemChecked(8, Convert.ToBoolean(_dane._atak10_aktywa9));
                    checkedListBoxAktywa110.SetItemChecked(9, Convert.ToBoolean(_dane._atak10_aktywa10));

                    //------------------------------ Atak - Zagrożenie
                    labelAtak11.Text = _dane._atak1;

                    checkedListBoxZagrozenie1.Items[0] = _dane._szkoda1;
                    checkedListBoxZagrozenie1.Items[1] = _dane._szkoda2;
                    checkedListBoxZagrozenie1.Items[2] = _dane._szkoda3;
                    checkedListBoxZagrozenie1.Items[3] = _dane._szkoda4;
                    checkedListBoxZagrozenie1.Items[4] = _dane._szkoda5;
                    checkedListBoxZagrozenie1.Items[5] = _dane._szkoda6;
                    checkedListBoxZagrozenie1.Items[6] = _dane._szkoda7;
                    checkedListBoxZagrozenie1.Items[7] = _dane._szkoda8;
                    checkedListBoxZagrozenie1.Items[8] = _dane._szkoda9;
                    checkedListBoxZagrozenie1.Items[9] = _dane._szkoda10;

                    checkedListBoxZagrozenie1.SetItemChecked(0, Convert.ToBoolean(_dane._atak1_szkoda1));
                    checkedListBoxZagrozenie1.SetItemChecked(1, Convert.ToBoolean(_dane._atak1_szkoda2));
                    checkedListBoxZagrozenie1.SetItemChecked(2, Convert.ToBoolean(_dane._atak1_szkoda3));
                    checkedListBoxZagrozenie1.SetItemChecked(3, Convert.ToBoolean(_dane._atak1_szkoda4));
                    checkedListBoxZagrozenie1.SetItemChecked(4, Convert.ToBoolean(_dane._atak1_szkoda5));
                    checkedListBoxZagrozenie1.SetItemChecked(5, Convert.ToBoolean(_dane._atak1_szkoda6));
                    checkedListBoxZagrozenie1.SetItemChecked(6, Convert.ToBoolean(_dane._atak1_szkoda7));
                    checkedListBoxZagrozenie1.SetItemChecked(7, Convert.ToBoolean(_dane._atak1_szkoda8));
                    checkedListBoxZagrozenie1.SetItemChecked(8, Convert.ToBoolean(_dane._atak1_szkoda9));
                    checkedListBoxZagrozenie1.SetItemChecked(9, Convert.ToBoolean(_dane._atak1_szkoda10));

                    //----------------

                    labelAtak12.Text = _dane._atak2;

                    checkedListBoxZagrozenie2.Items[0] = _dane._szkoda1;
                    checkedListBoxZagrozenie2.Items[1] = _dane._szkoda2;
                    checkedListBoxZagrozenie2.Items[2] = _dane._szkoda3;
                    checkedListBoxZagrozenie2.Items[3] = _dane._szkoda4;
                    checkedListBoxZagrozenie2.Items[4] = _dane._szkoda5;
                    checkedListBoxZagrozenie2.Items[5] = _dane._szkoda6;
                    checkedListBoxZagrozenie2.Items[6] = _dane._szkoda7;
                    checkedListBoxZagrozenie2.Items[7] = _dane._szkoda8;
                    checkedListBoxZagrozenie2.Items[8] = _dane._szkoda9;
                    checkedListBoxZagrozenie2.Items[9] = _dane._szkoda10;

                    checkedListBoxZagrozenie2.SetItemChecked(0, Convert.ToBoolean(_dane._atak2_szkoda1));
                    checkedListBoxZagrozenie2.SetItemChecked(1, Convert.ToBoolean(_dane._atak2_szkoda2));
                    checkedListBoxZagrozenie2.SetItemChecked(2, Convert.ToBoolean(_dane._atak2_szkoda3));
                    checkedListBoxZagrozenie2.SetItemChecked(3, Convert.ToBoolean(_dane._atak2_szkoda4));
                    checkedListBoxZagrozenie2.SetItemChecked(4, Convert.ToBoolean(_dane._atak2_szkoda5));
                    checkedListBoxZagrozenie2.SetItemChecked(5, Convert.ToBoolean(_dane._atak2_szkoda6));
                    checkedListBoxZagrozenie2.SetItemChecked(6, Convert.ToBoolean(_dane._atak2_szkoda7));
                    checkedListBoxZagrozenie2.SetItemChecked(7, Convert.ToBoolean(_dane._atak2_szkoda8));
                    checkedListBoxZagrozenie2.SetItemChecked(8, Convert.ToBoolean(_dane._atak2_szkoda9));
                    checkedListBoxZagrozenie2.SetItemChecked(9, Convert.ToBoolean(_dane._atak2_szkoda10));

                    //----------------
                    labelAtak13.Text = _dane._atak3;

                    checkedListBoxZagrozenie3.Items[0] = _dane._szkoda1;
                    checkedListBoxZagrozenie3.Items[1] = _dane._szkoda2;
                    checkedListBoxZagrozenie3.Items[2] = _dane._szkoda3;
                    checkedListBoxZagrozenie3.Items[3] = _dane._szkoda4;
                    checkedListBoxZagrozenie3.Items[4] = _dane._szkoda5;
                    checkedListBoxZagrozenie3.Items[5] = _dane._szkoda6;
                    checkedListBoxZagrozenie3.Items[6] = _dane._szkoda7;
                    checkedListBoxZagrozenie3.Items[7] = _dane._szkoda8;
                    checkedListBoxZagrozenie3.Items[8] = _dane._szkoda9;
                    checkedListBoxZagrozenie3.Items[9] = _dane._szkoda10;

                    checkedListBoxZagrozenie3.SetItemChecked(0, Convert.ToBoolean(_dane._atak3_szkoda1));
                    checkedListBoxZagrozenie3.SetItemChecked(1, Convert.ToBoolean(_dane._atak3_szkoda2));
                    checkedListBoxZagrozenie3.SetItemChecked(2, Convert.ToBoolean(_dane._atak3_szkoda3));
                    checkedListBoxZagrozenie3.SetItemChecked(3, Convert.ToBoolean(_dane._atak3_szkoda4));
                    checkedListBoxZagrozenie3.SetItemChecked(4, Convert.ToBoolean(_dane._atak3_szkoda5));
                    checkedListBoxZagrozenie3.SetItemChecked(5, Convert.ToBoolean(_dane._atak3_szkoda6));
                    checkedListBoxZagrozenie3.SetItemChecked(6, Convert.ToBoolean(_dane._atak3_szkoda7));
                    checkedListBoxZagrozenie3.SetItemChecked(7, Convert.ToBoolean(_dane._atak3_szkoda8));
                    checkedListBoxZagrozenie3.SetItemChecked(8, Convert.ToBoolean(_dane._atak3_szkoda9));
                    checkedListBoxZagrozenie3.SetItemChecked(9, Convert.ToBoolean(_dane._atak3_szkoda10));

                    //----------------
                    labelAtak14.Text = _dane._atak4;

                    checkedListBoxZagrozenie4.Items[0] = _dane._szkoda1;
                    checkedListBoxZagrozenie4.Items[1] = _dane._szkoda2;
                    checkedListBoxZagrozenie4.Items[2] = _dane._szkoda3;
                    checkedListBoxZagrozenie4.Items[3] = _dane._szkoda4;
                    checkedListBoxZagrozenie4.Items[4] = _dane._szkoda5;
                    checkedListBoxZagrozenie4.Items[5] = _dane._szkoda6;
                    checkedListBoxZagrozenie4.Items[6] = _dane._szkoda7;
                    checkedListBoxZagrozenie4.Items[7] = _dane._szkoda8;
                    checkedListBoxZagrozenie4.Items[8] = _dane._szkoda9;
                    checkedListBoxZagrozenie4.Items[9] = _dane._szkoda10;

                    checkedListBoxZagrozenie4.SetItemChecked(0, Convert.ToBoolean(_dane._atak4_szkoda1));
                    checkedListBoxZagrozenie4.SetItemChecked(1, Convert.ToBoolean(_dane._atak4_szkoda2));
                    checkedListBoxZagrozenie4.SetItemChecked(2, Convert.ToBoolean(_dane._atak4_szkoda3));
                    checkedListBoxZagrozenie4.SetItemChecked(3, Convert.ToBoolean(_dane._atak4_szkoda4));
                    checkedListBoxZagrozenie4.SetItemChecked(4, Convert.ToBoolean(_dane._atak4_szkoda5));
                    checkedListBoxZagrozenie4.SetItemChecked(5, Convert.ToBoolean(_dane._atak4_szkoda6));
                    checkedListBoxZagrozenie4.SetItemChecked(6, Convert.ToBoolean(_dane._atak4_szkoda7));
                    checkedListBoxZagrozenie4.SetItemChecked(7, Convert.ToBoolean(_dane._atak4_szkoda8));
                    checkedListBoxZagrozenie4.SetItemChecked(8, Convert.ToBoolean(_dane._atak4_szkoda9));
                    checkedListBoxZagrozenie4.SetItemChecked(9, Convert.ToBoolean(_dane._atak4_szkoda10));

                    //----------------
                    labelAtak15.Text = _dane._atak5;

                    checkedListBoxZagrozenie5.Items[0] = _dane._szkoda1;
                    checkedListBoxZagrozenie5.Items[1] = _dane._szkoda2;
                    checkedListBoxZagrozenie5.Items[2] = _dane._szkoda3;
                    checkedListBoxZagrozenie5.Items[3] = _dane._szkoda4;
                    checkedListBoxZagrozenie5.Items[4] = _dane._szkoda5;
                    checkedListBoxZagrozenie5.Items[5] = _dane._szkoda6;
                    checkedListBoxZagrozenie5.Items[6] = _dane._szkoda7;
                    checkedListBoxZagrozenie5.Items[7] = _dane._szkoda8;
                    checkedListBoxZagrozenie5.Items[8] = _dane._szkoda9;
                    checkedListBoxZagrozenie5.Items[9] = _dane._szkoda10;

                    checkedListBoxZagrozenie5.SetItemChecked(0, Convert.ToBoolean(_dane._atak5_szkoda1));
                    checkedListBoxZagrozenie5.SetItemChecked(1, Convert.ToBoolean(_dane._atak5_szkoda2));
                    checkedListBoxZagrozenie5.SetItemChecked(2, Convert.ToBoolean(_dane._atak5_szkoda3));
                    checkedListBoxZagrozenie5.SetItemChecked(3, Convert.ToBoolean(_dane._atak5_szkoda4));
                    checkedListBoxZagrozenie5.SetItemChecked(4, Convert.ToBoolean(_dane._atak5_szkoda5));
                    checkedListBoxZagrozenie5.SetItemChecked(5, Convert.ToBoolean(_dane._atak5_szkoda6));
                    checkedListBoxZagrozenie5.SetItemChecked(6, Convert.ToBoolean(_dane._atak5_szkoda7));
                    checkedListBoxZagrozenie5.SetItemChecked(7, Convert.ToBoolean(_dane._atak5_szkoda8));
                    checkedListBoxZagrozenie5.SetItemChecked(8, Convert.ToBoolean(_dane._atak5_szkoda9));
                    checkedListBoxZagrozenie5.SetItemChecked(9, Convert.ToBoolean(_dane._atak5_szkoda10));

                    //----------------
                    labelAtak16.Text = _dane._atak6;

                    checkedListBoxZagrozenie6.Items[0] = _dane._szkoda1;
                    checkedListBoxZagrozenie6.Items[1] = _dane._szkoda2;
                    checkedListBoxZagrozenie6.Items[2] = _dane._szkoda3;
                    checkedListBoxZagrozenie6.Items[3] = _dane._szkoda4;
                    checkedListBoxZagrozenie6.Items[4] = _dane._szkoda5;
                    checkedListBoxZagrozenie6.Items[5] = _dane._szkoda6;
                    checkedListBoxZagrozenie6.Items[6] = _dane._szkoda7;
                    checkedListBoxZagrozenie6.Items[7] = _dane._szkoda8;
                    checkedListBoxZagrozenie6.Items[8] = _dane._szkoda9;
                    checkedListBoxZagrozenie6.Items[9] = _dane._szkoda10;

                    checkedListBoxZagrozenie6.SetItemChecked(0, Convert.ToBoolean(_dane._atak6_szkoda1));
                    checkedListBoxZagrozenie6.SetItemChecked(1, Convert.ToBoolean(_dane._atak6_szkoda2));
                    checkedListBoxZagrozenie6.SetItemChecked(2, Convert.ToBoolean(_dane._atak6_szkoda3));
                    checkedListBoxZagrozenie6.SetItemChecked(3, Convert.ToBoolean(_dane._atak6_szkoda4));
                    checkedListBoxZagrozenie6.SetItemChecked(4, Convert.ToBoolean(_dane._atak6_szkoda5));
                    checkedListBoxZagrozenie6.SetItemChecked(5, Convert.ToBoolean(_dane._atak6_szkoda6));
                    checkedListBoxZagrozenie6.SetItemChecked(6, Convert.ToBoolean(_dane._atak6_szkoda7));
                    checkedListBoxZagrozenie6.SetItemChecked(7, Convert.ToBoolean(_dane._atak6_szkoda8));
                    checkedListBoxZagrozenie6.SetItemChecked(8, Convert.ToBoolean(_dane._atak6_szkoda9));
                    checkedListBoxZagrozenie6.SetItemChecked(9, Convert.ToBoolean(_dane._atak6_szkoda10));

                    //----------------
                    labelAtak17.Text = _dane._atak7;

                    checkedListBoxZagrozenie7.Items[0] = _dane._szkoda1;
                    checkedListBoxZagrozenie7.Items[1] = _dane._szkoda2;
                    checkedListBoxZagrozenie7.Items[2] = _dane._szkoda3;
                    checkedListBoxZagrozenie7.Items[3] = _dane._szkoda4;
                    checkedListBoxZagrozenie7.Items[4] = _dane._szkoda5;
                    checkedListBoxZagrozenie7.Items[5] = _dane._szkoda6;
                    checkedListBoxZagrozenie7.Items[6] = _dane._szkoda7;
                    checkedListBoxZagrozenie7.Items[7] = _dane._szkoda8;
                    checkedListBoxZagrozenie7.Items[8] = _dane._szkoda9;
                    checkedListBoxZagrozenie7.Items[9] = _dane._szkoda10;

                    checkedListBoxZagrozenie7.SetItemChecked(0, Convert.ToBoolean(_dane._atak7_szkoda1));
                    checkedListBoxZagrozenie7.SetItemChecked(1, Convert.ToBoolean(_dane._atak7_szkoda2));
                    checkedListBoxZagrozenie7.SetItemChecked(2, Convert.ToBoolean(_dane._atak7_szkoda3));
                    checkedListBoxZagrozenie7.SetItemChecked(3, Convert.ToBoolean(_dane._atak7_szkoda4));
                    checkedListBoxZagrozenie7.SetItemChecked(4, Convert.ToBoolean(_dane._atak7_szkoda5));
                    checkedListBoxZagrozenie7.SetItemChecked(5, Convert.ToBoolean(_dane._atak7_szkoda6));
                    checkedListBoxZagrozenie7.SetItemChecked(6, Convert.ToBoolean(_dane._atak7_szkoda7));
                    checkedListBoxZagrozenie7.SetItemChecked(7, Convert.ToBoolean(_dane._atak7_szkoda8));
                    checkedListBoxZagrozenie7.SetItemChecked(8, Convert.ToBoolean(_dane._atak7_szkoda9));
                    checkedListBoxZagrozenie7.SetItemChecked(9, Convert.ToBoolean(_dane._atak7_szkoda10));

                    //----------------
                    labelAtak18.Text = _dane._atak8;

                    checkedListBoxZagrozenie8.Items[0] = _dane._szkoda1;
                    checkedListBoxZagrozenie8.Items[1] = _dane._szkoda2;
                    checkedListBoxZagrozenie8.Items[2] = _dane._szkoda3;
                    checkedListBoxZagrozenie8.Items[3] = _dane._szkoda4;
                    checkedListBoxZagrozenie8.Items[4] = _dane._szkoda5;
                    checkedListBoxZagrozenie8.Items[5] = _dane._szkoda6;
                    checkedListBoxZagrozenie8.Items[6] = _dane._szkoda7;
                    checkedListBoxZagrozenie8.Items[7] = _dane._szkoda8;
                    checkedListBoxZagrozenie8.Items[8] = _dane._szkoda9;
                    checkedListBoxZagrozenie8.Items[9] = _dane._szkoda10;

                    checkedListBoxZagrozenie8.SetItemChecked(0, Convert.ToBoolean(_dane._atak8_szkoda1));
                    checkedListBoxZagrozenie8.SetItemChecked(1, Convert.ToBoolean(_dane._atak8_szkoda2));
                    checkedListBoxZagrozenie8.SetItemChecked(2, Convert.ToBoolean(_dane._atak8_szkoda3));
                    checkedListBoxZagrozenie8.SetItemChecked(3, Convert.ToBoolean(_dane._atak8_szkoda4));
                    checkedListBoxZagrozenie8.SetItemChecked(4, Convert.ToBoolean(_dane._atak8_szkoda5));
                    checkedListBoxZagrozenie8.SetItemChecked(5, Convert.ToBoolean(_dane._atak8_szkoda6));
                    checkedListBoxZagrozenie8.SetItemChecked(6, Convert.ToBoolean(_dane._atak8_szkoda7));
                    checkedListBoxZagrozenie8.SetItemChecked(7, Convert.ToBoolean(_dane._atak8_szkoda8));
                    checkedListBoxZagrozenie8.SetItemChecked(8, Convert.ToBoolean(_dane._atak8_szkoda9));
                    checkedListBoxZagrozenie8.SetItemChecked(9, Convert.ToBoolean(_dane._atak8_szkoda10));

                    //----------------
                    labelAtak19.Text = _dane._atak9;

                    checkedListBoxZagrozenie9.Items[0] = _dane._szkoda1;
                    checkedListBoxZagrozenie9.Items[1] = _dane._szkoda2;
                    checkedListBoxZagrozenie9.Items[2] = _dane._szkoda3;
                    checkedListBoxZagrozenie9.Items[3] = _dane._szkoda4;
                    checkedListBoxZagrozenie9.Items[4] = _dane._szkoda5;
                    checkedListBoxZagrozenie9.Items[5] = _dane._szkoda6;
                    checkedListBoxZagrozenie9.Items[6] = _dane._szkoda7;
                    checkedListBoxZagrozenie9.Items[7] = _dane._szkoda8;
                    checkedListBoxZagrozenie9.Items[8] = _dane._szkoda9;
                    checkedListBoxZagrozenie9.Items[9] = _dane._szkoda10;

                    checkedListBoxZagrozenie9.SetItemChecked(0, Convert.ToBoolean(_dane._atak9_szkoda1));
                    checkedListBoxZagrozenie9.SetItemChecked(1, Convert.ToBoolean(_dane._atak9_szkoda2));
                    checkedListBoxZagrozenie9.SetItemChecked(2, Convert.ToBoolean(_dane._atak9_szkoda3));
                    checkedListBoxZagrozenie9.SetItemChecked(3, Convert.ToBoolean(_dane._atak9_szkoda4));
                    checkedListBoxZagrozenie9.SetItemChecked(4, Convert.ToBoolean(_dane._atak9_szkoda5));
                    checkedListBoxZagrozenie9.SetItemChecked(5, Convert.ToBoolean(_dane._atak9_szkoda6));
                    checkedListBoxZagrozenie9.SetItemChecked(6, Convert.ToBoolean(_dane._atak9_szkoda7));
                    checkedListBoxZagrozenie9.SetItemChecked(7, Convert.ToBoolean(_dane._atak9_szkoda8));
                    checkedListBoxZagrozenie9.SetItemChecked(8, Convert.ToBoolean(_dane._atak9_szkoda9));
                    checkedListBoxZagrozenie9.SetItemChecked(9, Convert.ToBoolean(_dane._atak9_szkoda10));

                    //----------------
                    labelAtak10.Text = _dane._atak10;

                    checkedListBoxZagrozenie10.Items[0] = _dane._szkoda1;
                    checkedListBoxZagrozenie10.Items[1] = _dane._szkoda2;
                    checkedListBoxZagrozenie10.Items[2] = _dane._szkoda3;
                    checkedListBoxZagrozenie10.Items[3] = _dane._szkoda4;
                    checkedListBoxZagrozenie10.Items[4] = _dane._szkoda5;
                    checkedListBoxZagrozenie10.Items[5] = _dane._szkoda6;
                    checkedListBoxZagrozenie10.Items[6] = _dane._szkoda7;
                    checkedListBoxZagrozenie10.Items[7] = _dane._szkoda8;
                    checkedListBoxZagrozenie10.Items[8] = _dane._szkoda9;
                    checkedListBoxZagrozenie10.Items[9] = _dane._szkoda10;

                    checkedListBoxZagrozenie10.SetItemChecked(0, Convert.ToBoolean(_dane._atak10_szkoda1));
                    checkedListBoxZagrozenie10.SetItemChecked(1, Convert.ToBoolean(_dane._atak10_szkoda2));
                    checkedListBoxZagrozenie10.SetItemChecked(2, Convert.ToBoolean(_dane._atak10_szkoda3));
                    checkedListBoxZagrozenie10.SetItemChecked(3, Convert.ToBoolean(_dane._atak10_szkoda4));
                    checkedListBoxZagrozenie10.SetItemChecked(4, Convert.ToBoolean(_dane._atak10_szkoda5));
                    checkedListBoxZagrozenie10.SetItemChecked(5, Convert.ToBoolean(_dane._atak10_szkoda6));
                    checkedListBoxZagrozenie10.SetItemChecked(6, Convert.ToBoolean(_dane._atak10_szkoda7));
                    checkedListBoxZagrozenie10.SetItemChecked(7, Convert.ToBoolean(_dane._atak10_szkoda8));
                    checkedListBoxZagrozenie10.SetItemChecked(8, Convert.ToBoolean(_dane._atak10_szkoda9));
                    checkedListBoxZagrozenie10.SetItemChecked(9, Convert.ToBoolean(_dane._atak10_szkoda10));

                    //---------------- Atak - Wykonawca
                    labelAtak21.Text = _dane._atak1;

                    checkedListBoxWykonawca1.Items[0] = _dane._wykonawca1;
                    checkedListBoxWykonawca1.Items[1] = _dane._wykonawca2;
                    checkedListBoxWykonawca1.Items[2] = _dane._wykonawca3;
                    checkedListBoxWykonawca1.Items[3] = _dane._wykonawca4;
                    checkedListBoxWykonawca1.Items[4] = _dane._wykonawca5;
                    checkedListBoxWykonawca1.Items[5] = _dane._wykonawca6;
                    checkedListBoxWykonawca1.Items[6] = _dane._wykonawca7;
                    checkedListBoxWykonawca1.Items[7] = _dane._wykonawca8;
                    checkedListBoxWykonawca1.Items[8] = _dane._wykonawca9;
                    checkedListBoxWykonawca1.Items[9] = _dane._wykonawca10;

                    checkedListBoxWykonawca1.SetItemChecked(0, Convert.ToBoolean(_dane._atak1_wykonawca1));
                    checkedListBoxWykonawca1.SetItemChecked(1, Convert.ToBoolean(_dane._atak1_wykonawca2));
                    checkedListBoxWykonawca1.SetItemChecked(2, Convert.ToBoolean(_dane._atak1_wykonawca3));
                    checkedListBoxWykonawca1.SetItemChecked(3, Convert.ToBoolean(_dane._atak1_wykonawca4));
                    checkedListBoxWykonawca1.SetItemChecked(4, Convert.ToBoolean(_dane._atak1_wykonawca5));
                    checkedListBoxWykonawca1.SetItemChecked(5, Convert.ToBoolean(_dane._atak1_wykonawca6));
                    checkedListBoxWykonawca1.SetItemChecked(6, Convert.ToBoolean(_dane._atak1_wykonawca7));
                    checkedListBoxWykonawca1.SetItemChecked(7, Convert.ToBoolean(_dane._atak1_wykonawca8));
                    checkedListBoxWykonawca1.SetItemChecked(8, Convert.ToBoolean(_dane._atak1_wykonawca9));
                    checkedListBoxWykonawca1.SetItemChecked(9, Convert.ToBoolean(_dane._atak1_wykonawca10));

                    //-----------
                    labelAtak22.Text = _dane._atak2;

                    checkedListBoxWykonawca2.Items[0] = _dane._wykonawca1;
                    checkedListBoxWykonawca2.Items[1] = _dane._wykonawca2;
                    checkedListBoxWykonawca2.Items[2] = _dane._wykonawca3;
                    checkedListBoxWykonawca2.Items[3] = _dane._wykonawca4;
                    checkedListBoxWykonawca2.Items[4] = _dane._wykonawca5;
                    checkedListBoxWykonawca2.Items[5] = _dane._wykonawca6;
                    checkedListBoxWykonawca2.Items[6] = _dane._wykonawca7;
                    checkedListBoxWykonawca2.Items[7] = _dane._wykonawca8;
                    checkedListBoxWykonawca2.Items[8] = _dane._wykonawca9;
                    checkedListBoxWykonawca2.Items[9] = _dane._wykonawca10;

                    checkedListBoxWykonawca2.SetItemChecked(0, Convert.ToBoolean(_dane._atak2_wykonawca1));
                    checkedListBoxWykonawca2.SetItemChecked(1, Convert.ToBoolean(_dane._atak2_wykonawca2));
                    checkedListBoxWykonawca2.SetItemChecked(2, Convert.ToBoolean(_dane._atak2_wykonawca3));
                    checkedListBoxWykonawca2.SetItemChecked(3, Convert.ToBoolean(_dane._atak2_wykonawca4));
                    checkedListBoxWykonawca2.SetItemChecked(4, Convert.ToBoolean(_dane._atak2_wykonawca5));
                    checkedListBoxWykonawca2.SetItemChecked(5, Convert.ToBoolean(_dane._atak2_wykonawca6));
                    checkedListBoxWykonawca2.SetItemChecked(6, Convert.ToBoolean(_dane._atak2_wykonawca7));
                    checkedListBoxWykonawca2.SetItemChecked(7, Convert.ToBoolean(_dane._atak2_wykonawca8));
                    checkedListBoxWykonawca2.SetItemChecked(8, Convert.ToBoolean(_dane._atak2_wykonawca9));
                    checkedListBoxWykonawca2.SetItemChecked(9, Convert.ToBoolean(_dane._atak2_wykonawca10));

                    //-----------
                    labelAtak23.Text = _dane._atak3;

                    checkedListBoxWykonawca3.Items[0] = _dane._wykonawca1;
                    checkedListBoxWykonawca3.Items[1] = _dane._wykonawca2;
                    checkedListBoxWykonawca3.Items[2] = _dane._wykonawca3;
                    checkedListBoxWykonawca3.Items[3] = _dane._wykonawca4;
                    checkedListBoxWykonawca3.Items[4] = _dane._wykonawca5;
                    checkedListBoxWykonawca3.Items[5] = _dane._wykonawca6;
                    checkedListBoxWykonawca3.Items[6] = _dane._wykonawca7;
                    checkedListBoxWykonawca3.Items[7] = _dane._wykonawca8;
                    checkedListBoxWykonawca3.Items[8] = _dane._wykonawca9;
                    checkedListBoxWykonawca3.Items[9] = _dane._wykonawca10;

                    checkedListBoxWykonawca3.SetItemChecked(0, Convert.ToBoolean(_dane._atak3_wykonawca1));
                    checkedListBoxWykonawca3.SetItemChecked(1, Convert.ToBoolean(_dane._atak3_wykonawca2));
                    checkedListBoxWykonawca3.SetItemChecked(2, Convert.ToBoolean(_dane._atak3_wykonawca3));
                    checkedListBoxWykonawca3.SetItemChecked(3, Convert.ToBoolean(_dane._atak3_wykonawca4));
                    checkedListBoxWykonawca3.SetItemChecked(4, Convert.ToBoolean(_dane._atak3_wykonawca5));
                    checkedListBoxWykonawca3.SetItemChecked(5, Convert.ToBoolean(_dane._atak3_wykonawca6));
                    checkedListBoxWykonawca3.SetItemChecked(6, Convert.ToBoolean(_dane._atak3_wykonawca7));
                    checkedListBoxWykonawca3.SetItemChecked(7, Convert.ToBoolean(_dane._atak3_wykonawca8));
                    checkedListBoxWykonawca3.SetItemChecked(8, Convert.ToBoolean(_dane._atak3_wykonawca9));
                    checkedListBoxWykonawca3.SetItemChecked(9, Convert.ToBoolean(_dane._atak3_wykonawca10));

                    //-----------
                    labelAtak24.Text = _dane._atak4;

                    checkedListBoxWykonawca4.Items[0] = _dane._wykonawca1;
                    checkedListBoxWykonawca4.Items[1] = _dane._wykonawca2;
                    checkedListBoxWykonawca4.Items[2] = _dane._wykonawca3;
                    checkedListBoxWykonawca4.Items[3] = _dane._wykonawca4;
                    checkedListBoxWykonawca4.Items[4] = _dane._wykonawca5;
                    checkedListBoxWykonawca4.Items[5] = _dane._wykonawca6;
                    checkedListBoxWykonawca4.Items[6] = _dane._wykonawca7;
                    checkedListBoxWykonawca4.Items[7] = _dane._wykonawca8;
                    checkedListBoxWykonawca4.Items[8] = _dane._wykonawca9;
                    checkedListBoxWykonawca4.Items[9] = _dane._wykonawca10;

                    checkedListBoxWykonawca4.SetItemChecked(0, Convert.ToBoolean(_dane._atak4_wykonawca1));
                    checkedListBoxWykonawca4.SetItemChecked(1, Convert.ToBoolean(_dane._atak4_wykonawca2));
                    checkedListBoxWykonawca4.SetItemChecked(2, Convert.ToBoolean(_dane._atak4_wykonawca3));
                    checkedListBoxWykonawca4.SetItemChecked(3, Convert.ToBoolean(_dane._atak4_wykonawca4));
                    checkedListBoxWykonawca4.SetItemChecked(4, Convert.ToBoolean(_dane._atak4_wykonawca5));
                    checkedListBoxWykonawca4.SetItemChecked(5, Convert.ToBoolean(_dane._atak4_wykonawca6));
                    checkedListBoxWykonawca4.SetItemChecked(6, Convert.ToBoolean(_dane._atak4_wykonawca7));
                    checkedListBoxWykonawca4.SetItemChecked(7, Convert.ToBoolean(_dane._atak4_wykonawca8));
                    checkedListBoxWykonawca4.SetItemChecked(8, Convert.ToBoolean(_dane._atak4_wykonawca9));
                    checkedListBoxWykonawca4.SetItemChecked(9, Convert.ToBoolean(_dane._atak4_wykonawca10));
                    //-----------
                    labelAtak25.Text = _dane._atak5;

                    checkedListBoxWykonawca5.Items[0] = _dane._wykonawca1;
                    checkedListBoxWykonawca5.Items[1] = _dane._wykonawca2;
                    checkedListBoxWykonawca5.Items[2] = _dane._wykonawca3;
                    checkedListBoxWykonawca5.Items[3] = _dane._wykonawca4;
                    checkedListBoxWykonawca5.Items[4] = _dane._wykonawca5;
                    checkedListBoxWykonawca5.Items[5] = _dane._wykonawca6;
                    checkedListBoxWykonawca5.Items[6] = _dane._wykonawca7;
                    checkedListBoxWykonawca5.Items[7] = _dane._wykonawca8;
                    checkedListBoxWykonawca5.Items[8] = _dane._wykonawca9;
                    checkedListBoxWykonawca5.Items[9] = _dane._wykonawca10;

                    checkedListBoxWykonawca5.SetItemChecked(0, Convert.ToBoolean(_dane._atak5_wykonawca1));
                    checkedListBoxWykonawca5.SetItemChecked(1, Convert.ToBoolean(_dane._atak5_wykonawca2));
                    checkedListBoxWykonawca5.SetItemChecked(2, Convert.ToBoolean(_dane._atak5_wykonawca3));
                    checkedListBoxWykonawca5.SetItemChecked(3, Convert.ToBoolean(_dane._atak5_wykonawca4));
                    checkedListBoxWykonawca5.SetItemChecked(4, Convert.ToBoolean(_dane._atak5_wykonawca5));
                    checkedListBoxWykonawca5.SetItemChecked(5, Convert.ToBoolean(_dane._atak5_wykonawca6));
                    checkedListBoxWykonawca5.SetItemChecked(6, Convert.ToBoolean(_dane._atak5_wykonawca7));
                    checkedListBoxWykonawca5.SetItemChecked(7, Convert.ToBoolean(_dane._atak5_wykonawca8));
                    checkedListBoxWykonawca5.SetItemChecked(8, Convert.ToBoolean(_dane._atak5_wykonawca9));
                    checkedListBoxWykonawca5.SetItemChecked(9, Convert.ToBoolean(_dane._atak5_wykonawca10));
                    //-----------
                    labelAtak26.Text = _dane._atak6;

                    checkedListBoxWykonawca6.Items[0] = _dane._wykonawca1;
                    checkedListBoxWykonawca6.Items[1] = _dane._wykonawca2;
                    checkedListBoxWykonawca6.Items[2] = _dane._wykonawca3;
                    checkedListBoxWykonawca6.Items[3] = _dane._wykonawca4;
                    checkedListBoxWykonawca6.Items[4] = _dane._wykonawca5;
                    checkedListBoxWykonawca6.Items[5] = _dane._wykonawca6;
                    checkedListBoxWykonawca6.Items[6] = _dane._wykonawca7;
                    checkedListBoxWykonawca6.Items[7] = _dane._wykonawca8;
                    checkedListBoxWykonawca6.Items[8] = _dane._wykonawca9;
                    checkedListBoxWykonawca6.Items[9] = _dane._wykonawca10;

                    checkedListBoxWykonawca6.SetItemChecked(0, Convert.ToBoolean(_dane._atak6_wykonawca1));
                    checkedListBoxWykonawca6.SetItemChecked(1, Convert.ToBoolean(_dane._atak6_wykonawca2));
                    checkedListBoxWykonawca6.SetItemChecked(2, Convert.ToBoolean(_dane._atak6_wykonawca3));
                    checkedListBoxWykonawca6.SetItemChecked(3, Convert.ToBoolean(_dane._atak6_wykonawca4));
                    checkedListBoxWykonawca6.SetItemChecked(4, Convert.ToBoolean(_dane._atak6_wykonawca5));
                    checkedListBoxWykonawca6.SetItemChecked(5, Convert.ToBoolean(_dane._atak6_wykonawca6));
                    checkedListBoxWykonawca6.SetItemChecked(6, Convert.ToBoolean(_dane._atak6_wykonawca7));
                    checkedListBoxWykonawca6.SetItemChecked(7, Convert.ToBoolean(_dane._atak6_wykonawca8));
                    checkedListBoxWykonawca6.SetItemChecked(8, Convert.ToBoolean(_dane._atak6_wykonawca9));
                    checkedListBoxWykonawca6.SetItemChecked(9, Convert.ToBoolean(_dane._atak6_wykonawca10));

                    //-----------
                    labelAtak27.Text = _dane._atak7;

                    checkedListBoxWykonawca7.Items[0] = _dane._wykonawca1;
                    checkedListBoxWykonawca7.Items[1] = _dane._wykonawca2;
                    checkedListBoxWykonawca7.Items[2] = _dane._wykonawca3;
                    checkedListBoxWykonawca7.Items[3] = _dane._wykonawca4;
                    checkedListBoxWykonawca7.Items[4] = _dane._wykonawca5;
                    checkedListBoxWykonawca7.Items[5] = _dane._wykonawca6;
                    checkedListBoxWykonawca7.Items[6] = _dane._wykonawca7;
                    checkedListBoxWykonawca7.Items[7] = _dane._wykonawca8;
                    checkedListBoxWykonawca7.Items[8] = _dane._wykonawca9;
                    checkedListBoxWykonawca7.Items[9] = _dane._wykonawca10;

                    checkedListBoxWykonawca7.SetItemChecked(0, Convert.ToBoolean(_dane._atak7_wykonawca1));
                    checkedListBoxWykonawca7.SetItemChecked(1, Convert.ToBoolean(_dane._atak7_wykonawca2));
                    checkedListBoxWykonawca7.SetItemChecked(2, Convert.ToBoolean(_dane._atak7_wykonawca3));
                    checkedListBoxWykonawca7.SetItemChecked(3, Convert.ToBoolean(_dane._atak7_wykonawca4));
                    checkedListBoxWykonawca7.SetItemChecked(4, Convert.ToBoolean(_dane._atak7_wykonawca5));
                    checkedListBoxWykonawca7.SetItemChecked(5, Convert.ToBoolean(_dane._atak7_wykonawca6));
                    checkedListBoxWykonawca7.SetItemChecked(6, Convert.ToBoolean(_dane._atak7_wykonawca7));
                    checkedListBoxWykonawca7.SetItemChecked(7, Convert.ToBoolean(_dane._atak7_wykonawca8));
                    checkedListBoxWykonawca7.SetItemChecked(8, Convert.ToBoolean(_dane._atak7_wykonawca9));
                    checkedListBoxWykonawca7.SetItemChecked(9, Convert.ToBoolean(_dane._atak7_wykonawca10));

                    //-----------
                    labelAtak28.Text = _dane._atak8;

                    checkedListBoxWykonawca8.Items[0] = _dane._wykonawca1;
                    checkedListBoxWykonawca8.Items[1] = _dane._wykonawca2;
                    checkedListBoxWykonawca8.Items[2] = _dane._wykonawca3;
                    checkedListBoxWykonawca8.Items[3] = _dane._wykonawca4;
                    checkedListBoxWykonawca8.Items[4] = _dane._wykonawca5;
                    checkedListBoxWykonawca8.Items[5] = _dane._wykonawca6;
                    checkedListBoxWykonawca8.Items[6] = _dane._wykonawca7;
                    checkedListBoxWykonawca8.Items[7] = _dane._wykonawca8;
                    checkedListBoxWykonawca8.Items[8] = _dane._wykonawca9;
                    checkedListBoxWykonawca8.Items[9] = _dane._wykonawca10;

                    checkedListBoxWykonawca8.SetItemChecked(0, Convert.ToBoolean(_dane._atak8_wykonawca1));
                    checkedListBoxWykonawca8.SetItemChecked(1, Convert.ToBoolean(_dane._atak8_wykonawca2));
                    checkedListBoxWykonawca8.SetItemChecked(2, Convert.ToBoolean(_dane._atak8_wykonawca3));
                    checkedListBoxWykonawca8.SetItemChecked(3, Convert.ToBoolean(_dane._atak8_wykonawca4));
                    checkedListBoxWykonawca8.SetItemChecked(4, Convert.ToBoolean(_dane._atak8_wykonawca5));
                    checkedListBoxWykonawca8.SetItemChecked(5, Convert.ToBoolean(_dane._atak8_wykonawca6));
                    checkedListBoxWykonawca8.SetItemChecked(6, Convert.ToBoolean(_dane._atak8_wykonawca7));
                    checkedListBoxWykonawca8.SetItemChecked(7, Convert.ToBoolean(_dane._atak8_wykonawca8));
                    checkedListBoxWykonawca8.SetItemChecked(8, Convert.ToBoolean(_dane._atak8_wykonawca9));
                    checkedListBoxWykonawca8.SetItemChecked(9, Convert.ToBoolean(_dane._atak8_wykonawca10));

                    //-----------
                    labelAtak29.Text = _dane._atak9;

                    checkedListBoxWykonawca9.Items[0] = _dane._wykonawca1;
                    checkedListBoxWykonawca9.Items[1] = _dane._wykonawca2;
                    checkedListBoxWykonawca9.Items[2] = _dane._wykonawca3;
                    checkedListBoxWykonawca9.Items[3] = _dane._wykonawca4;
                    checkedListBoxWykonawca9.Items[4] = _dane._wykonawca5;
                    checkedListBoxWykonawca9.Items[5] = _dane._wykonawca6;
                    checkedListBoxWykonawca9.Items[6] = _dane._wykonawca7;
                    checkedListBoxWykonawca9.Items[7] = _dane._wykonawca8;
                    checkedListBoxWykonawca9.Items[8] = _dane._wykonawca9;
                    checkedListBoxWykonawca9.Items[9] = _dane._wykonawca10;

                    checkedListBoxWykonawca9.SetItemChecked(0, Convert.ToBoolean(_dane._atak9_wykonawca1));
                    checkedListBoxWykonawca9.SetItemChecked(1, Convert.ToBoolean(_dane._atak9_wykonawca2));
                    checkedListBoxWykonawca9.SetItemChecked(2, Convert.ToBoolean(_dane._atak9_wykonawca3));
                    checkedListBoxWykonawca9.SetItemChecked(3, Convert.ToBoolean(_dane._atak9_wykonawca4));
                    checkedListBoxWykonawca9.SetItemChecked(4, Convert.ToBoolean(_dane._atak9_wykonawca5));
                    checkedListBoxWykonawca9.SetItemChecked(5, Convert.ToBoolean(_dane._atak9_wykonawca6));
                    checkedListBoxWykonawca9.SetItemChecked(6, Convert.ToBoolean(_dane._atak9_wykonawca7));
                    checkedListBoxWykonawca9.SetItemChecked(7, Convert.ToBoolean(_dane._atak9_wykonawca8));
                    checkedListBoxWykonawca9.SetItemChecked(8, Convert.ToBoolean(_dane._atak9_wykonawca9));
                    checkedListBoxWykonawca9.SetItemChecked(9, Convert.ToBoolean(_dane._atak9_wykonawca10));

                    //-----------
                    labelAtak210.Text = _dane._atak10;

                    checkedListBoxWykonawca10.Items[0] = _dane._wykonawca1;
                    checkedListBoxWykonawca10.Items[1] = _dane._wykonawca2;
                    checkedListBoxWykonawca10.Items[2] = _dane._wykonawca3;
                    checkedListBoxWykonawca10.Items[3] = _dane._wykonawca4;
                    checkedListBoxWykonawca10.Items[4] = _dane._wykonawca5;
                    checkedListBoxWykonawca10.Items[5] = _dane._wykonawca6;
                    checkedListBoxWykonawca10.Items[6] = _dane._wykonawca7;
                    checkedListBoxWykonawca10.Items[7] = _dane._wykonawca8;
                    checkedListBoxWykonawca10.Items[8] = _dane._wykonawca9;
                    checkedListBoxWykonawca10.Items[9] = _dane._wykonawca10;

                    checkedListBoxWykonawca10.SetItemChecked(0, Convert.ToBoolean(_dane._atak10_wykonawca1));
                    checkedListBoxWykonawca10.SetItemChecked(1, Convert.ToBoolean(_dane._atak10_wykonawca2));
                    checkedListBoxWykonawca10.SetItemChecked(2, Convert.ToBoolean(_dane._atak10_wykonawca3));
                    checkedListBoxWykonawca10.SetItemChecked(3, Convert.ToBoolean(_dane._atak10_wykonawca4));
                    checkedListBoxWykonawca10.SetItemChecked(4, Convert.ToBoolean(_dane._atak10_wykonawca5));
                    checkedListBoxWykonawca10.SetItemChecked(5, Convert.ToBoolean(_dane._atak10_wykonawca6));
                    checkedListBoxWykonawca10.SetItemChecked(6, Convert.ToBoolean(_dane._atak10_wykonawca7));
                    checkedListBoxWykonawca10.SetItemChecked(7, Convert.ToBoolean(_dane._atak10_wykonawca8));
                    checkedListBoxWykonawca10.SetItemChecked(8, Convert.ToBoolean(_dane._atak10_wykonawca9));
                    checkedListBoxWykonawca10.SetItemChecked(9, Convert.ToBoolean(_dane._atak10_wykonawca10));

                    //---------------- Atak - Ryzyko
                    labelAtak31.Text = textBoxAtak1.Text;
                    trackBarCzas1.Value = _dane._czas1;
                    trackBarKwalifikacje1.Value = _dane._kwalifikacje1;
                    trackBarWiedza1.Value = _dane._wiedza1;
                    trackBarWyposazenie1.Value = _dane._wyposazenie1;
                    trackBarDostep1.Value = _dane._dostep1;
                    trackBarRyzyko1.Value = _dane._ryzyko1;

                    labelAtak32.Text = textBoxAtak2.Text;
                    trackBarCzas2.Value = _dane._czas2;
                    trackBarKwalifikacje2.Value = _dane._kwalifikacje2;
                    trackBarWiedza2.Value = _dane._wiedza2;
                    trackBarWyposazenie2.Value = _dane._wyposazenie2;
                    trackBarDostep2.Value = _dane._dostep2;
                    trackBarRyzyko2.Value = _dane._ryzyko2;

                    labelAtak33.Text = textBoxAtak3.Text;
                    trackBarCzas3.Value = _dane._czas3;
                    trackBarKwalifikacje3.Value = _dane._kwalifikacje3;
                    trackBarWiedza3.Value = _dane._wiedza3;
                    trackBarWyposazenie3.Value = _dane._wyposazenie3;
                    trackBarDostep3.Value = _dane._dostep3;
                    trackBarRyzyko3.Value = _dane._ryzyko3;

                    labelAtak34.Text = textBoxAtak4.Text;
                    trackBarCzas4.Value = _dane._czas4;
                    trackBarKwalifikacje4.Value = _dane._kwalifikacje4;
                    trackBarWiedza4.Value = _dane._wiedza4;
                    trackBarWyposazenie4.Value = _dane._wyposazenie4;
                    trackBarDostep4.Value = _dane._dostep4;
                    trackBarRyzyko4.Value = _dane._ryzyko4;

                    labelAtak35.Text = textBoxAtak5.Text;
                    trackBarCzas5.Value = _dane._czas5;
                    trackBarKwalifikacje5.Value = _dane._kwalifikacje5;
                    trackBarWiedza5.Value = _dane._wiedza5;
                    trackBarWyposazenie5.Value = _dane._wyposazenie5;
                    trackBarDostep5.Value = _dane._dostep5;
                    trackBarRyzyko5.Value = _dane._ryzyko5;

                    labelAtak36.Text = textBoxAtak6.Text;
                    trackBarCzas6.Value = _dane._czas6;
                    trackBarKwalifikacje6.Value = _dane._kwalifikacje6;
                    trackBarWiedza6.Value = _dane._wiedza6;
                    trackBarWyposazenie6.Value = _dane._wyposazenie6;
                    trackBarDostep6.Value = _dane._dostep6;
                    trackBarRyzyko6.Value = _dane._ryzyko6;

                    labelAtak37.Text = textBoxAtak7.Text;
                    trackBarCzas7.Value = _dane._czas7;
                    trackBarKwalifikacje7.Value = _dane._kwalifikacje7;
                    trackBarWiedza7.Value = _dane._wiedza7;
                    trackBarWyposazenie7.Value = _dane._wyposazenie7;
                    trackBarDostep7.Value = _dane._dostep7;
                    trackBarRyzyko7.Value = _dane._ryzyko7;

                    labelAtak38.Text = textBoxAtak8.Text;
                    trackBarCzas8.Value = _dane._czas8;
                    trackBarKwalifikacje8.Value = _dane._kwalifikacje8;
                    trackBarWiedza8.Value = _dane._wiedza8;
                    trackBarWyposazenie8.Value = _dane._wyposazenie8;
                    trackBarDostep8.Value = _dane._dostep8;
                    trackBarRyzyko8.Value = _dane._ryzyko8;

                    labelAtak39.Text = textBoxAtak9.Text;
                    trackBarCzas9.Value = _dane._czas9;
                    trackBarKwalifikacje9.Value = _dane._kwalifikacje9;
                    trackBarWiedza9.Value = _dane._wiedza9;
                    trackBarWyposazenie9.Value = _dane._wyposazenie9;
                    trackBarDostep9.Value = _dane._dostep9;
                    trackBarRyzyko9.Value = _dane._ryzyko9;

                    labelAtak310.Text = textBoxAtak10.Text;
                    trackBarCzas10.Value = _dane._czas10;
                    trackBarKwalifikacje10.Value = _dane._kwalifikacje10;
                    trackBarWiedza10.Value = _dane._wiedza10;
                    trackBarWyposazenie10.Value = _dane._wyposazenie10;
                    trackBarDostep10.Value = _dane._dostep10;
                    trackBarRyzyko10.Value = _dane._ryzyko10;

                    pokazParametryRyzyka1();
                    pokazParametryRyzyka2();
                    pokazParametryRyzyka3();
                    pokazParametryRyzyka4();
                    pokazParametryRyzyka5();
                    pokazParametryRyzyka6();
                    pokazParametryRyzyka7();
                    pokazParametryRyzyka8();
                    pokazParametryRyzyka9();
                    pokazParametryRyzyka10();

                    _suma0 = sumaWartosci();
                    _czynnosc = (int)_enum.otwarty;
                    ustawDostep();
                    pokazTytul();
                    tabControl1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }//otworzToolStripMenuItem_Click


        /// <summary>
        /// Aktualizuje wartości label'ów i checkBox'ów.
        /// </summary>
        private void aktualizuj()
        {
            //------------------------------ Regulacja / Aktywa

            labelRegulacja1.Text = textBoxRegulacja1.Text;
            checkedListBoxAktywa1.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa1.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa1.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa1.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa1.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa1.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa1.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa1.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa1.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa1.Items[9] = textBoxAktywa10.Text;

            labelRegulacja2.Text = textBoxRegulacja2.Text;
            checkedListBoxAktywa2.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa2.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa2.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa2.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa2.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa2.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa2.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa2.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa2.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa2.Items[9] = textBoxAktywa10.Text;

            labelRegulacja3.Text = textBoxRegulacja3.Text;
            checkedListBoxAktywa3.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa3.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa3.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa3.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa3.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa3.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa3.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa3.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa3.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa3.Items[9] = textBoxAktywa10.Text;

            labelRegulacja4.Text = textBoxRegulacja4.Text;
            checkedListBoxAktywa4.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa4.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa4.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa4.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa4.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa4.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa4.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa4.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa4.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa4.Items[9] = textBoxAktywa10.Text;

            labelRegulacja5.Text = textBoxRegulacja5.Text;
            checkedListBoxAktywa5.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa5.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa5.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa5.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa5.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa5.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa5.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa5.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa5.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa5.Items[9] = textBoxAktywa10.Text;

            labelRegulacja6.Text = textBoxRegulacja6.Text;
            checkedListBoxAktywa6.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa6.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa6.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa6.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa6.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa6.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa6.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa6.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa6.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa6.Items[9] = textBoxAktywa10.Text;

            labelRegulacja7.Text = textBoxRegulacja7.Text;
            checkedListBoxAktywa7.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa7.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa7.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa7.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa7.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa7.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa7.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa7.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa7.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa7.Items[9] = textBoxAktywa10.Text;

            labelRegulacja8.Text = textBoxRegulacja8.Text;
            checkedListBoxAktywa8.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa8.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa8.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa8.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa8.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa8.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa8.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa8.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa8.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa8.Items[9] = textBoxAktywa10.Text;

            labelRegulacja9.Text = textBoxRegulacja9.Text;
            checkedListBoxAktywa9.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa9.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa9.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa9.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa9.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa9.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa9.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa9.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa9.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa9.Items[9] = textBoxAktywa10.Text;

            labelRegulacja10.Text = textBoxRegulacja10.Text;
            checkedListBoxAktywa10.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa10.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa10.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa10.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa10.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa10.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa10.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa10.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa10.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa10.Items[9] = textBoxAktywa10.Text;

            //------------------------------ Aktywa - Własnosci

            labelAktywa1.Text = textBoxAktywa1.Text;
            checkedListBoxWlasnosc1.Items[0] = textBoxWlasnosc1.Text;
            checkedListBoxWlasnosc1.Items[1] = textBoxWlasnosc2.Text;
            checkedListBoxWlasnosc1.Items[2] = textBoxWlasnosc3.Text;
            checkedListBoxWlasnosc1.Items[3] = textBoxWlasnosc4.Text;
            checkedListBoxWlasnosc1.Items[4] = textBoxWlasnosc5.Text;
            checkedListBoxWlasnosc1.Items[5] = textBoxWlasnosc6.Text;
            checkedListBoxWlasnosc1.Items[6] = textBoxWlasnosc7.Text;
            checkedListBoxWlasnosc1.Items[7] = textBoxWlasnosc8.Text;
            checkedListBoxWlasnosc1.Items[8] = textBoxWlasnosc9.Text;
            checkedListBoxWlasnosc1.Items[9] = textBoxWlasnosc10.Text;

            labelAktywa2.Text = textBoxAktywa2.Text;
            checkedListBoxWlasnosc2.Items[0] = textBoxWlasnosc1.Text;
            checkedListBoxWlasnosc2.Items[1] = textBoxWlasnosc2.Text;
            checkedListBoxWlasnosc2.Items[2] = textBoxWlasnosc3.Text;
            checkedListBoxWlasnosc2.Items[3] = textBoxWlasnosc4.Text;
            checkedListBoxWlasnosc2.Items[4] = textBoxWlasnosc5.Text;
            checkedListBoxWlasnosc2.Items[5] = textBoxWlasnosc6.Text;
            checkedListBoxWlasnosc2.Items[6] = textBoxWlasnosc7.Text;
            checkedListBoxWlasnosc2.Items[7] = textBoxWlasnosc8.Text;
            checkedListBoxWlasnosc2.Items[8] = textBoxWlasnosc9.Text;
            checkedListBoxWlasnosc2.Items[9] = textBoxWlasnosc10.Text;

            labelAktywa3.Text = textBoxAktywa3.Text;
            checkedListBoxWlasnosc3.Items[0] = textBoxWlasnosc1.Text;
            checkedListBoxWlasnosc3.Items[1] = textBoxWlasnosc2.Text;
            checkedListBoxWlasnosc3.Items[2] = textBoxWlasnosc3.Text;
            checkedListBoxWlasnosc3.Items[3] = textBoxWlasnosc4.Text;
            checkedListBoxWlasnosc3.Items[4] = textBoxWlasnosc5.Text;
            checkedListBoxWlasnosc3.Items[5] = textBoxWlasnosc6.Text;
            checkedListBoxWlasnosc3.Items[6] = textBoxWlasnosc7.Text;
            checkedListBoxWlasnosc3.Items[7] = textBoxWlasnosc8.Text;
            checkedListBoxWlasnosc3.Items[8] = textBoxWlasnosc9.Text;
            checkedListBoxWlasnosc3.Items[9] = textBoxWlasnosc10.Text;

            labelAktywa4.Text = textBoxAktywa4.Text;
            checkedListBoxWlasnosc4.Items[0] = textBoxWlasnosc1.Text;
            checkedListBoxWlasnosc4.Items[1] = textBoxWlasnosc2.Text;
            checkedListBoxWlasnosc4.Items[2] = textBoxWlasnosc3.Text;
            checkedListBoxWlasnosc4.Items[3] = textBoxWlasnosc4.Text;
            checkedListBoxWlasnosc4.Items[4] = textBoxWlasnosc5.Text;
            checkedListBoxWlasnosc4.Items[5] = textBoxWlasnosc6.Text;
            checkedListBoxWlasnosc4.Items[6] = textBoxWlasnosc7.Text;
            checkedListBoxWlasnosc4.Items[7] = textBoxWlasnosc8.Text;
            checkedListBoxWlasnosc4.Items[8] = textBoxWlasnosc9.Text;
            checkedListBoxWlasnosc4.Items[9] = textBoxWlasnosc10.Text;

            labelAktywa5.Text = textBoxAktywa5.Text;
            checkedListBoxWlasnosc5.Items[0] = textBoxWlasnosc1.Text;
            checkedListBoxWlasnosc5.Items[1] = textBoxWlasnosc2.Text;
            checkedListBoxWlasnosc5.Items[2] = textBoxWlasnosc3.Text;
            checkedListBoxWlasnosc5.Items[3] = textBoxWlasnosc4.Text;
            checkedListBoxWlasnosc5.Items[4] = textBoxWlasnosc5.Text;
            checkedListBoxWlasnosc5.Items[5] = textBoxWlasnosc6.Text;
            checkedListBoxWlasnosc5.Items[6] = textBoxWlasnosc7.Text;
            checkedListBoxWlasnosc5.Items[7] = textBoxWlasnosc8.Text;
            checkedListBoxWlasnosc5.Items[8] = textBoxWlasnosc9.Text;
            checkedListBoxWlasnosc5.Items[9] = textBoxWlasnosc10.Text;

            labelAktywa6.Text = textBoxAktywa6.Text;
            checkedListBoxWlasnosc6.Items[0] = textBoxWlasnosc1.Text;
            checkedListBoxWlasnosc6.Items[1] = textBoxWlasnosc2.Text;
            checkedListBoxWlasnosc6.Items[2] = textBoxWlasnosc3.Text;
            checkedListBoxWlasnosc6.Items[3] = textBoxWlasnosc4.Text;
            checkedListBoxWlasnosc6.Items[4] = textBoxWlasnosc5.Text;
            checkedListBoxWlasnosc6.Items[5] = textBoxWlasnosc6.Text;
            checkedListBoxWlasnosc6.Items[6] = textBoxWlasnosc7.Text;
            checkedListBoxWlasnosc6.Items[7] = textBoxWlasnosc8.Text;
            checkedListBoxWlasnosc6.Items[8] = textBoxWlasnosc9.Text;
            checkedListBoxWlasnosc6.Items[9] = textBoxWlasnosc10.Text;

            labelAktywa7.Text = textBoxAktywa7.Text;
            checkedListBoxWlasnosc7.Items[0] = textBoxWlasnosc1.Text;
            checkedListBoxWlasnosc7.Items[1] = textBoxWlasnosc2.Text;
            checkedListBoxWlasnosc7.Items[2] = textBoxWlasnosc3.Text;
            checkedListBoxWlasnosc7.Items[3] = textBoxWlasnosc4.Text;
            checkedListBoxWlasnosc7.Items[4] = textBoxWlasnosc5.Text;
            checkedListBoxWlasnosc7.Items[5] = textBoxWlasnosc6.Text;
            checkedListBoxWlasnosc7.Items[6] = textBoxWlasnosc7.Text;
            checkedListBoxWlasnosc7.Items[7] = textBoxWlasnosc8.Text;
            checkedListBoxWlasnosc7.Items[8] = textBoxWlasnosc9.Text;
            checkedListBoxWlasnosc7.Items[9] = textBoxWlasnosc10.Text;

            labelAktywa8.Text = textBoxAktywa8.Text;
            checkedListBoxWlasnosc8.Items[0] = textBoxWlasnosc1.Text;
            checkedListBoxWlasnosc8.Items[1] = textBoxWlasnosc2.Text;
            checkedListBoxWlasnosc8.Items[2] = textBoxWlasnosc3.Text;
            checkedListBoxWlasnosc8.Items[3] = textBoxWlasnosc4.Text;
            checkedListBoxWlasnosc8.Items[4] = textBoxWlasnosc5.Text;
            checkedListBoxWlasnosc8.Items[5] = textBoxWlasnosc6.Text;
            checkedListBoxWlasnosc8.Items[6] = textBoxWlasnosc7.Text;
            checkedListBoxWlasnosc8.Items[7] = textBoxWlasnosc8.Text;
            checkedListBoxWlasnosc8.Items[8] = textBoxWlasnosc9.Text;
            checkedListBoxWlasnosc8.Items[9] = textBoxWlasnosc10.Text;

            labelAktywa9.Text = textBoxAktywa9.Text;
            checkedListBoxWlasnosc9.Items[0] = textBoxWlasnosc1.Text;
            checkedListBoxWlasnosc9.Items[1] = textBoxWlasnosc2.Text;
            checkedListBoxWlasnosc9.Items[2] = textBoxWlasnosc3.Text;
            checkedListBoxWlasnosc9.Items[3] = textBoxWlasnosc4.Text;
            checkedListBoxWlasnosc9.Items[4] = textBoxWlasnosc5.Text;
            checkedListBoxWlasnosc9.Items[5] = textBoxWlasnosc6.Text;
            checkedListBoxWlasnosc9.Items[6] = textBoxWlasnosc7.Text;
            checkedListBoxWlasnosc9.Items[7] = textBoxWlasnosc8.Text;
            checkedListBoxWlasnosc9.Items[8] = textBoxWlasnosc9.Text;
            checkedListBoxWlasnosc9.Items[9] = textBoxWlasnosc10.Text;

            labelAktywa10.Text = textBoxAktywa10.Text;
            checkedListBoxWlasnosc10.Items[0] = textBoxWlasnosc1.Text;
            checkedListBoxWlasnosc10.Items[1] = textBoxWlasnosc2.Text;
            checkedListBoxWlasnosc10.Items[2] = textBoxWlasnosc3.Text;
            checkedListBoxWlasnosc10.Items[3] = textBoxWlasnosc4.Text;
            checkedListBoxWlasnosc10.Items[4] = textBoxWlasnosc5.Text;
            checkedListBoxWlasnosc10.Items[5] = textBoxWlasnosc6.Text;
            checkedListBoxWlasnosc10.Items[6] = textBoxWlasnosc7.Text;
            checkedListBoxWlasnosc10.Items[7] = textBoxWlasnosc8.Text;
            checkedListBoxWlasnosc10.Items[8] = textBoxWlasnosc9.Text;
            checkedListBoxWlasnosc10.Items[9] = textBoxWlasnosc10.Text;

            //------------------------------ Atak - Aktywa
            labelAtak1.Text = textBoxAtak1.Text;
            checkedListBoxAktywa11.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa11.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa11.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa11.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa11.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa11.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa11.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa11.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa11.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa11.Items[9] = textBoxAktywa10.Text;

            labelAtak2.Text = textBoxAtak2.Text;
            checkedListBoxAktywa12.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa12.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa12.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa12.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa12.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa12.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa12.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa12.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa12.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa12.Items[9] = textBoxAktywa10.Text;

            labelAtak3.Text = textBoxAtak3.Text;
            checkedListBoxAktywa13.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa13.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa13.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa13.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa13.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa13.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa13.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa13.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa13.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa13.Items[9] = textBoxAktywa10.Text;

            labelAtak4.Text = textBoxAtak4.Text;
            checkedListBoxAktywa14.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa14.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa14.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa14.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa14.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa14.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa14.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa14.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa14.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa14.Items[9] = textBoxAktywa10.Text;

            labelAtak5.Text = textBoxAtak5.Text;
            checkedListBoxAktywa15.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa15.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa15.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa15.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa15.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa15.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa15.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa15.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa15.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa15.Items[9] = textBoxAktywa10.Text;

            labelAtak6.Text = textBoxAtak6.Text;
            checkedListBoxAktywa16.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa16.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa16.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa16.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa16.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa16.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa16.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa16.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa16.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa16.Items[9] = textBoxAktywa10.Text;

            labelAtak7.Text = textBoxAtak7.Text;
            checkedListBoxAktywa17.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa17.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa17.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa17.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa17.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa17.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa17.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa17.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa17.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa17.Items[9] = textBoxAktywa10.Text;

            labelAtak8.Text = textBoxAtak8.Text;
            checkedListBoxAktywa18.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa18.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa18.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa18.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa18.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa18.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa18.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa18.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa18.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa18.Items[9] = textBoxAktywa10.Text;

            labelAtak9.Text = textBoxAtak9.Text;
            checkedListBoxAktywa19.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa19.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa19.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa19.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa19.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa19.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa19.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa19.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa19.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa19.Items[9] = textBoxAktywa10.Text;

            labelAtak10.Text = textBoxAtak10.Text;
            checkedListBoxAktywa110.Items[0] = textBoxAktywa1.Text;
            checkedListBoxAktywa110.Items[1] = textBoxAktywa2.Text;
            checkedListBoxAktywa110.Items[2] = textBoxAktywa3.Text;
            checkedListBoxAktywa110.Items[3] = textBoxAktywa4.Text;
            checkedListBoxAktywa110.Items[4] = textBoxAktywa5.Text;
            checkedListBoxAktywa110.Items[5] = textBoxAktywa6.Text;
            checkedListBoxAktywa110.Items[6] = textBoxAktywa7.Text;
            checkedListBoxAktywa110.Items[7] = textBoxAktywa8.Text;
            checkedListBoxAktywa110.Items[8] = textBoxAktywa9.Text;
            checkedListBoxAktywa110.Items[9] = textBoxAktywa10.Text;

            //------------------------------ Atak - Zagrożenie
            labelAtak11.Text = textBoxAtak1.Text;
            checkedListBoxZagrozenie1.Items[0] = textBoxZagrozenie1.Text;
            checkedListBoxZagrozenie1.Items[1] = textBoxZagrozenie2.Text;
            checkedListBoxZagrozenie1.Items[2] = textBoxZagrozenie3.Text;
            checkedListBoxZagrozenie1.Items[3] = textBoxZagrozenie4.Text;
            checkedListBoxZagrozenie1.Items[4] = textBoxZagrozenie5.Text;
            checkedListBoxZagrozenie1.Items[5] = textBoxZagrozenie6.Text;
            checkedListBoxZagrozenie1.Items[6] = textBoxZagrozenie7.Text;
            checkedListBoxZagrozenie1.Items[7] = textBoxZagrozenie8.Text;
            checkedListBoxZagrozenie1.Items[8] = textBoxZagrozenie9.Text;
            checkedListBoxZagrozenie1.Items[9] = textBoxZagrozenie10.Text;

            labelAtak12.Text = textBoxAtak2.Text;
            checkedListBoxZagrozenie2.Items[0] = textBoxZagrozenie1.Text;
            checkedListBoxZagrozenie2.Items[1] = textBoxZagrozenie2.Text;
            checkedListBoxZagrozenie2.Items[2] = textBoxZagrozenie3.Text;
            checkedListBoxZagrozenie2.Items[3] = textBoxZagrozenie4.Text;
            checkedListBoxZagrozenie2.Items[4] = textBoxZagrozenie5.Text;
            checkedListBoxZagrozenie2.Items[5] = textBoxZagrozenie6.Text;
            checkedListBoxZagrozenie2.Items[6] = textBoxZagrozenie7.Text;
            checkedListBoxZagrozenie2.Items[7] = textBoxZagrozenie8.Text;
            checkedListBoxZagrozenie2.Items[8] = textBoxZagrozenie9.Text;
            checkedListBoxZagrozenie2.Items[9] = textBoxZagrozenie10.Text;

            labelAtak13.Text = textBoxAtak3.Text;
            checkedListBoxZagrozenie3.Items[0] = textBoxZagrozenie1.Text;
            checkedListBoxZagrozenie3.Items[1] = textBoxZagrozenie2.Text;
            checkedListBoxZagrozenie3.Items[2] = textBoxZagrozenie3.Text;
            checkedListBoxZagrozenie3.Items[3] = textBoxZagrozenie4.Text;
            checkedListBoxZagrozenie3.Items[4] = textBoxZagrozenie5.Text;
            checkedListBoxZagrozenie3.Items[5] = textBoxZagrozenie6.Text;
            checkedListBoxZagrozenie3.Items[6] = textBoxZagrozenie7.Text;
            checkedListBoxZagrozenie3.Items[7] = textBoxZagrozenie8.Text;
            checkedListBoxZagrozenie3.Items[8] = textBoxZagrozenie9.Text;
            checkedListBoxZagrozenie3.Items[9] = textBoxZagrozenie10.Text;

            labelAtak14.Text = textBoxAtak4.Text;
            checkedListBoxZagrozenie4.Items[0] = textBoxZagrozenie1.Text;
            checkedListBoxZagrozenie4.Items[1] = textBoxZagrozenie2.Text;
            checkedListBoxZagrozenie4.Items[2] = textBoxZagrozenie3.Text;
            checkedListBoxZagrozenie4.Items[3] = textBoxZagrozenie4.Text;
            checkedListBoxZagrozenie4.Items[4] = textBoxZagrozenie5.Text;
            checkedListBoxZagrozenie4.Items[5] = textBoxZagrozenie6.Text;
            checkedListBoxZagrozenie4.Items[6] = textBoxZagrozenie7.Text;
            checkedListBoxZagrozenie4.Items[7] = textBoxZagrozenie8.Text;
            checkedListBoxZagrozenie4.Items[8] = textBoxZagrozenie9.Text;
            checkedListBoxZagrozenie4.Items[9] = textBoxZagrozenie10.Text;

            labelAtak15.Text = textBoxAtak5.Text;
            checkedListBoxZagrozenie5.Items[0] = textBoxZagrozenie1.Text;
            checkedListBoxZagrozenie5.Items[1] = textBoxZagrozenie2.Text;
            checkedListBoxZagrozenie5.Items[2] = textBoxZagrozenie3.Text;
            checkedListBoxZagrozenie5.Items[3] = textBoxZagrozenie4.Text;
            checkedListBoxZagrozenie5.Items[4] = textBoxZagrozenie5.Text;
            checkedListBoxZagrozenie5.Items[5] = textBoxZagrozenie6.Text;
            checkedListBoxZagrozenie5.Items[6] = textBoxZagrozenie7.Text;
            checkedListBoxZagrozenie5.Items[7] = textBoxZagrozenie8.Text;
            checkedListBoxZagrozenie5.Items[8] = textBoxZagrozenie9.Text;
            checkedListBoxZagrozenie5.Items[9] = textBoxZagrozenie10.Text;

            labelAtak16.Text = textBoxAtak6.Text;
            checkedListBoxZagrozenie6.Items[0] = textBoxZagrozenie1.Text;
            checkedListBoxZagrozenie6.Items[1] = textBoxZagrozenie2.Text;
            checkedListBoxZagrozenie6.Items[2] = textBoxZagrozenie3.Text;
            checkedListBoxZagrozenie6.Items[3] = textBoxZagrozenie4.Text;
            checkedListBoxZagrozenie6.Items[4] = textBoxZagrozenie5.Text;
            checkedListBoxZagrozenie6.Items[5] = textBoxZagrozenie6.Text;
            checkedListBoxZagrozenie6.Items[6] = textBoxZagrozenie7.Text;
            checkedListBoxZagrozenie6.Items[7] = textBoxZagrozenie8.Text;
            checkedListBoxZagrozenie6.Items[8] = textBoxZagrozenie9.Text;
            checkedListBoxZagrozenie6.Items[9] = textBoxZagrozenie10.Text;

            labelAtak17.Text = textBoxAtak7.Text;
            checkedListBoxZagrozenie7.Items[0] = textBoxZagrozenie1.Text;
            checkedListBoxZagrozenie7.Items[1] = textBoxZagrozenie2.Text;
            checkedListBoxZagrozenie7.Items[2] = textBoxZagrozenie3.Text;
            checkedListBoxZagrozenie7.Items[3] = textBoxZagrozenie4.Text;
            checkedListBoxZagrozenie7.Items[4] = textBoxZagrozenie5.Text;
            checkedListBoxZagrozenie7.Items[5] = textBoxZagrozenie6.Text;
            checkedListBoxZagrozenie7.Items[6] = textBoxZagrozenie7.Text;
            checkedListBoxZagrozenie7.Items[7] = textBoxZagrozenie8.Text;
            checkedListBoxZagrozenie7.Items[8] = textBoxZagrozenie9.Text;
            checkedListBoxZagrozenie7.Items[9] = textBoxZagrozenie10.Text;

            labelAtak18.Text = textBoxAtak8.Text;
            checkedListBoxZagrozenie8.Items[0] = textBoxZagrozenie1.Text;
            checkedListBoxZagrozenie8.Items[1] = textBoxZagrozenie2.Text;
            checkedListBoxZagrozenie8.Items[2] = textBoxZagrozenie3.Text;
            checkedListBoxZagrozenie8.Items[3] = textBoxZagrozenie4.Text;
            checkedListBoxZagrozenie8.Items[4] = textBoxZagrozenie5.Text;
            checkedListBoxZagrozenie8.Items[5] = textBoxZagrozenie6.Text;
            checkedListBoxZagrozenie8.Items[6] = textBoxZagrozenie7.Text;
            checkedListBoxZagrozenie8.Items[7] = textBoxZagrozenie8.Text;
            checkedListBoxZagrozenie8.Items[8] = textBoxZagrozenie9.Text;
            checkedListBoxZagrozenie8.Items[9] = textBoxZagrozenie10.Text;

            labelAtak19.Text = textBoxAtak9.Text;
            checkedListBoxZagrozenie9.Items[0] = textBoxZagrozenie1.Text;
            checkedListBoxZagrozenie9.Items[1] = textBoxZagrozenie2.Text;
            checkedListBoxZagrozenie9.Items[2] = textBoxZagrozenie3.Text;
            checkedListBoxZagrozenie9.Items[3] = textBoxZagrozenie4.Text;
            checkedListBoxZagrozenie9.Items[4] = textBoxZagrozenie5.Text;
            checkedListBoxZagrozenie9.Items[5] = textBoxZagrozenie6.Text;
            checkedListBoxZagrozenie9.Items[6] = textBoxZagrozenie7.Text;
            checkedListBoxZagrozenie9.Items[7] = textBoxZagrozenie8.Text;
            checkedListBoxZagrozenie9.Items[8] = textBoxZagrozenie9.Text;
            checkedListBoxZagrozenie9.Items[9] = textBoxZagrozenie10.Text;

            labelAtak110.Text = textBoxAtak10.Text;
            checkedListBoxZagrozenie10.Items[0] = textBoxZagrozenie1.Text;
            checkedListBoxZagrozenie10.Items[1] = textBoxZagrozenie2.Text;
            checkedListBoxZagrozenie10.Items[2] = textBoxZagrozenie3.Text;
            checkedListBoxZagrozenie10.Items[3] = textBoxZagrozenie4.Text;
            checkedListBoxZagrozenie10.Items[4] = textBoxZagrozenie5.Text;
            checkedListBoxZagrozenie10.Items[5] = textBoxZagrozenie6.Text;
            checkedListBoxZagrozenie10.Items[6] = textBoxZagrozenie7.Text;
            checkedListBoxZagrozenie10.Items[7] = textBoxZagrozenie8.Text;
            checkedListBoxZagrozenie10.Items[8] = textBoxZagrozenie9.Text;
            checkedListBoxZagrozenie10.Items[9] = textBoxZagrozenie10.Text;

            //------------------------------ Atak - Wykonawca
            labelAtak21.Text = textBoxAtak1.Text;
            checkedListBoxWykonawca1.Items[0] = textBoxWykonawca1.Text;
            checkedListBoxWykonawca1.Items[1] = textBoxWykonawca2.Text;
            checkedListBoxWykonawca1.Items[2] = textBoxWykonawca3.Text;
            checkedListBoxWykonawca1.Items[3] = textBoxWykonawca4.Text;
            checkedListBoxWykonawca1.Items[4] = textBoxWykonawca5.Text;
            checkedListBoxWykonawca1.Items[5] = textBoxWykonawca6.Text;
            checkedListBoxWykonawca1.Items[6] = textBoxWykonawca7.Text;
            checkedListBoxWykonawca1.Items[7] = textBoxWykonawca8.Text;
            checkedListBoxWykonawca1.Items[8] = textBoxWykonawca9.Text;
            checkedListBoxWykonawca1.Items[9] = textBoxWykonawca10.Text;

            labelAtak22.Text = textBoxAtak2.Text;
            checkedListBoxWykonawca2.Items[0] = textBoxWykonawca1.Text;
            checkedListBoxWykonawca2.Items[1] = textBoxWykonawca2.Text;
            checkedListBoxWykonawca2.Items[2] = textBoxWykonawca3.Text;
            checkedListBoxWykonawca2.Items[3] = textBoxWykonawca4.Text;
            checkedListBoxWykonawca2.Items[4] = textBoxWykonawca5.Text;
            checkedListBoxWykonawca2.Items[5] = textBoxWykonawca6.Text;
            checkedListBoxWykonawca2.Items[6] = textBoxWykonawca7.Text;
            checkedListBoxWykonawca2.Items[7] = textBoxWykonawca8.Text;
            checkedListBoxWykonawca2.Items[8] = textBoxWykonawca9.Text;
            checkedListBoxWykonawca2.Items[9] = textBoxWykonawca10.Text;

            labelAtak23.Text = textBoxAtak3.Text;
            checkedListBoxWykonawca3.Items[0] = textBoxWykonawca1.Text;
            checkedListBoxWykonawca3.Items[1] = textBoxWykonawca2.Text;
            checkedListBoxWykonawca3.Items[2] = textBoxWykonawca3.Text;
            checkedListBoxWykonawca3.Items[3] = textBoxWykonawca4.Text;
            checkedListBoxWykonawca3.Items[4] = textBoxWykonawca5.Text;
            checkedListBoxWykonawca3.Items[5] = textBoxWykonawca6.Text;
            checkedListBoxWykonawca3.Items[6] = textBoxWykonawca7.Text;
            checkedListBoxWykonawca3.Items[7] = textBoxWykonawca8.Text;
            checkedListBoxWykonawca3.Items[8] = textBoxWykonawca9.Text;
            checkedListBoxWykonawca3.Items[9] = textBoxWykonawca10.Text;

            labelAtak24.Text = textBoxAtak4.Text;
            checkedListBoxWykonawca4.Items[0] = textBoxWykonawca1.Text;
            checkedListBoxWykonawca4.Items[1] = textBoxWykonawca2.Text;
            checkedListBoxWykonawca4.Items[2] = textBoxWykonawca3.Text;
            checkedListBoxWykonawca4.Items[3] = textBoxWykonawca4.Text;
            checkedListBoxWykonawca4.Items[4] = textBoxWykonawca5.Text;
            checkedListBoxWykonawca4.Items[5] = textBoxWykonawca6.Text;
            checkedListBoxWykonawca4.Items[6] = textBoxWykonawca7.Text;
            checkedListBoxWykonawca4.Items[7] = textBoxWykonawca8.Text;
            checkedListBoxWykonawca4.Items[8] = textBoxWykonawca9.Text;
            checkedListBoxWykonawca4.Items[9] = textBoxWykonawca10.Text;

            labelAtak25.Text = textBoxAtak5.Text;
            checkedListBoxWykonawca5.Items[0] = textBoxWykonawca1.Text;
            checkedListBoxWykonawca5.Items[1] = textBoxWykonawca2.Text;
            checkedListBoxWykonawca5.Items[2] = textBoxWykonawca3.Text;
            checkedListBoxWykonawca5.Items[3] = textBoxWykonawca4.Text;
            checkedListBoxWykonawca5.Items[4] = textBoxWykonawca5.Text;
            checkedListBoxWykonawca5.Items[5] = textBoxWykonawca6.Text;
            checkedListBoxWykonawca5.Items[6] = textBoxWykonawca7.Text;
            checkedListBoxWykonawca5.Items[7] = textBoxWykonawca8.Text;
            checkedListBoxWykonawca5.Items[8] = textBoxWykonawca9.Text;
            checkedListBoxWykonawca5.Items[9] = textBoxWykonawca10.Text;

            labelAtak26.Text = textBoxAtak6.Text;
            checkedListBoxWykonawca6.Items[0] = textBoxWykonawca1.Text;
            checkedListBoxWykonawca6.Items[1] = textBoxWykonawca2.Text;
            checkedListBoxWykonawca6.Items[2] = textBoxWykonawca3.Text;
            checkedListBoxWykonawca6.Items[3] = textBoxWykonawca4.Text;
            checkedListBoxWykonawca6.Items[4] = textBoxWykonawca5.Text;
            checkedListBoxWykonawca6.Items[5] = textBoxWykonawca6.Text;
            checkedListBoxWykonawca6.Items[6] = textBoxWykonawca7.Text;
            checkedListBoxWykonawca6.Items[7] = textBoxWykonawca8.Text;
            checkedListBoxWykonawca6.Items[8] = textBoxWykonawca9.Text;
            checkedListBoxWykonawca6.Items[9] = textBoxWykonawca10.Text;

            labelAtak27.Text = textBoxAtak7.Text;
            checkedListBoxWykonawca7.Items[0] = textBoxWykonawca1.Text;
            checkedListBoxWykonawca7.Items[1] = textBoxWykonawca2.Text;
            checkedListBoxWykonawca7.Items[2] = textBoxWykonawca3.Text;
            checkedListBoxWykonawca7.Items[3] = textBoxWykonawca4.Text;
            checkedListBoxWykonawca7.Items[4] = textBoxWykonawca5.Text;
            checkedListBoxWykonawca7.Items[5] = textBoxWykonawca6.Text;
            checkedListBoxWykonawca7.Items[6] = textBoxWykonawca7.Text;
            checkedListBoxWykonawca7.Items[7] = textBoxWykonawca8.Text;
            checkedListBoxWykonawca7.Items[8] = textBoxWykonawca9.Text;
            checkedListBoxWykonawca7.Items[9] = textBoxWykonawca10.Text;

            labelAtak28.Text = textBoxAtak8.Text;
            checkedListBoxWykonawca8.Items[0] = textBoxWykonawca1.Text;
            checkedListBoxWykonawca8.Items[1] = textBoxWykonawca2.Text;
            checkedListBoxWykonawca8.Items[2] = textBoxWykonawca3.Text;
            checkedListBoxWykonawca8.Items[3] = textBoxWykonawca4.Text;
            checkedListBoxWykonawca8.Items[4] = textBoxWykonawca5.Text;
            checkedListBoxWykonawca8.Items[5] = textBoxWykonawca6.Text;
            checkedListBoxWykonawca8.Items[6] = textBoxWykonawca7.Text;
            checkedListBoxWykonawca8.Items[7] = textBoxWykonawca8.Text;
            checkedListBoxWykonawca8.Items[8] = textBoxWykonawca9.Text;
            checkedListBoxWykonawca8.Items[9] = textBoxWykonawca10.Text;

            labelAtak29.Text = textBoxAtak9.Text;
            checkedListBoxWykonawca9.Items[0] = textBoxWykonawca1.Text;
            checkedListBoxWykonawca9.Items[1] = textBoxWykonawca2.Text;
            checkedListBoxWykonawca9.Items[2] = textBoxWykonawca3.Text;
            checkedListBoxWykonawca9.Items[3] = textBoxWykonawca4.Text;
            checkedListBoxWykonawca9.Items[4] = textBoxWykonawca5.Text;
            checkedListBoxWykonawca9.Items[5] = textBoxWykonawca6.Text;
            checkedListBoxWykonawca9.Items[6] = textBoxWykonawca7.Text;
            checkedListBoxWykonawca9.Items[7] = textBoxWykonawca8.Text;
            checkedListBoxWykonawca9.Items[8] = textBoxWykonawca9.Text;
            checkedListBoxWykonawca9.Items[9] = textBoxWykonawca10.Text;

            labelAtak210.Text = textBoxAtak10.Text;
            checkedListBoxWykonawca10.Items[0] = textBoxWykonawca1.Text;
            checkedListBoxWykonawca10.Items[1] = textBoxWykonawca2.Text;
            checkedListBoxWykonawca10.Items[2] = textBoxWykonawca3.Text;
            checkedListBoxWykonawca10.Items[3] = textBoxWykonawca4.Text;
            checkedListBoxWykonawca10.Items[4] = textBoxWykonawca5.Text;
            checkedListBoxWykonawca10.Items[5] = textBoxWykonawca6.Text;
            checkedListBoxWykonawca10.Items[6] = textBoxWykonawca7.Text;
            checkedListBoxWykonawca10.Items[7] = textBoxWykonawca8.Text;
            checkedListBoxWykonawca10.Items[8] = textBoxWykonawca9.Text;
            checkedListBoxWykonawca10.Items[9] = textBoxWykonawca10.Text;

            //------------------------------ Atak - Ryzyko
            labelAtak31.Text = textBoxAtak1.Text;
            labelAtak32.Text = textBoxAtak2.Text;
            labelAtak33.Text = textBoxAtak3.Text;
            labelAtak34.Text = textBoxAtak4.Text;
            labelAtak35.Text = textBoxAtak5.Text;
            labelAtak36.Text = textBoxAtak6.Text;
            labelAtak37.Text = textBoxAtak7.Text;
            labelAtak38.Text = textBoxAtak8.Text;
            labelAtak39.Text = textBoxAtak9.Text;
            labelAtak310.Text = textBoxAtak10.Text;

        }//aktualizuj

        //Zapisuje plik z danymi.
        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zapiszJako();
        }//zapiszJakoToolStripMenuItem_Click

        /// <summary>
        /// Zapisuje plik w dialogu wyboru nazwy pliku.
        /// </summary>
        private void zapiszJako()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|*.xml";
            sfd.DefaultExt = "xml";
            sfd.Title = "Zapis pliku XML";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                zapisz(sfd.FileName);
                _plik = sfd.FileName;

                _czynnosc = (int)_enum.zapisJako;
                ustawDostep();
                pokazTytul();
                _suma0 = sumaWartosci();
            }
        }//zapiszJako

        /// <summary>
        /// Zapisuje do istniejacego pliku.
        /// </summary>
        private void zapisz()
        {
             
            if (File.Exists(_plik))
            {
                zapisz(_plik);

                _czynnosc = (int)_enum.zapisz;
                ustawDostep();
                _suma0 = sumaWartosci();
                // okienko komunikatu o zapisie
                //MessageBox.Show(_tlumacz.zmien("Dane zapisano poprawnie"), "Rami",
                //  MessageBoxButtons.OK, MessageBoxIcon.None);
                //return;

                // okienko komunikatu o zapisie pojawiające się na kilka sekund
                Frame frame = new Frame(_tlumacz.zmien("Zmiany zostały zapisane poprawnie w XML."));
                frame.Show();
                frame.Refresh();
                Thread.Sleep(2000);
                frame.Close();
                frame.Dispose();
            }
        }//zapisz

        /// <summary>
        /// Zapisuje plik.
        /// </summary>
        /// <param name="nazwaPliku">Nazwa pliku.</param>
        private void zapisz(string nazwaPliku)
        {
            try
            {
                _dane = new nsDane.dane();

                _dane._nazwa = textBoxNazwa.Text;
                _dane._opis = textBoxOpis.Text;

                _dane._isEn = toolStripComboBoxJezyk.SelectedIndex == 1;

                _dane._regulacja1 = textBoxRegulacja1.Text;
                _dane._regulacja2 = textBoxRegulacja2.Text;
                _dane._regulacja3 = textBoxRegulacja3.Text;
                _dane._regulacja4 = textBoxRegulacja4.Text;
                _dane._regulacja5 = textBoxRegulacja5.Text;
                _dane._regulacja6 = textBoxRegulacja6.Text;
                _dane._regulacja7 = textBoxRegulacja7.Text;
                _dane._regulacja8 = textBoxRegulacja8.Text;
                _dane._regulacja9 = textBoxRegulacja9.Text;
                _dane._regulacja10 = textBoxRegulacja10.Text;

                _dane._wplyw1 = trackBarWplyw1.Value;
                _dane._wplyw2 = trackBarWplyw2.Value;
                _dane._wplyw3 = trackBarWplyw3.Value;
                _dane._wplyw4 = trackBarWplyw4.Value;
                _dane._wplyw5 = trackBarWplyw5.Value;
                _dane._wplyw6 = trackBarWplyw6.Value;
                _dane._wplyw7 = trackBarWplyw7.Value;
                _dane._wplyw8 = trackBarWplyw8.Value;
                _dane._wplyw9 = trackBarWplyw9.Value;
                _dane._wplyw10 = trackBarWplyw10.Value;

                _dane._aktywa1 = textBoxAktywa1.Text;
                _dane._aktywa2 = textBoxAktywa2.Text;
                _dane._aktywa3 = textBoxAktywa3.Text;
                _dane._aktywa4 = textBoxAktywa4.Text;
                _dane._aktywa5 = textBoxAktywa5.Text;
                _dane._aktywa6 = textBoxAktywa6.Text;
                _dane._aktywa7 = textBoxAktywa7.Text;
                _dane._aktywa8 = textBoxAktywa8.Text;
                _dane._aktywa9 = textBoxAktywa9.Text;
                _dane._aktywa10 = textBoxAktywa10.Text;

                _dane._wlasnosc1 = textBoxWlasnosc1.Text;
                _dane._wlasnosc2 = textBoxWlasnosc2.Text;
                _dane._wlasnosc3 = textBoxWlasnosc3.Text;
                _dane._wlasnosc4 = textBoxWlasnosc4.Text;
                _dane._wlasnosc5 = textBoxWlasnosc5.Text;
                _dane._wlasnosc6 = textBoxWlasnosc6.Text;
                _dane._wlasnosc7 = textBoxWlasnosc7.Text;
                _dane._wlasnosc8 = textBoxWlasnosc8.Text;
                _dane._wlasnosc9 = textBoxWlasnosc9.Text;
                _dane._wlasnosc10 = textBoxWlasnosc10.Text;

                _dane._szkoda1 = textBoxZagrozenie1.Text;
                _dane._szkoda2 = textBoxZagrozenie2.Text;
                _dane._szkoda3 = textBoxZagrozenie3.Text;
                _dane._szkoda4 = textBoxZagrozenie4.Text;
                _dane._szkoda5 = textBoxZagrozenie5.Text;
                _dane._szkoda6 = textBoxZagrozenie6.Text;
                _dane._szkoda7 = textBoxZagrozenie7.Text;
                _dane._szkoda8 = textBoxZagrozenie8.Text;
                _dane._szkoda9 = textBoxZagrozenie9.Text;
                _dane._szkoda10 = textBoxZagrozenie10.Text;

                _dane._atak1 = textBoxAtak1.Text;
                _dane._atak2 = textBoxAtak2.Text;
                _dane._atak3 = textBoxAtak3.Text;
                _dane._atak4 = textBoxAtak4.Text;
                _dane._atak5 = textBoxAtak5.Text;
                _dane._atak6 = textBoxAtak6.Text;
                _dane._atak7 = textBoxAtak7.Text;
                _dane._atak8 = textBoxAtak8.Text;
                _dane._atak9 = textBoxAtak9.Text;
                _dane._atak10 = textBoxAtak10.Text;

                _dane._wykonawca1 = textBoxWykonawca1.Text;
                _dane._wykonawca2 = textBoxWykonawca2.Text;
                _dane._wykonawca3 = textBoxWykonawca3.Text;
                _dane._wykonawca4 = textBoxWykonawca4.Text;
                _dane._wykonawca5 = textBoxWykonawca5.Text;
                _dane._wykonawca6 = textBoxWykonawca6.Text;
                _dane._wykonawca7 = textBoxWykonawca7.Text;
                _dane._wykonawca8 = textBoxWykonawca8.Text;
                _dane._wykonawca9 = textBoxWykonawca9.Text;
                _dane._wykonawca10 = textBoxWykonawca10.Text;

                //---------------- Regulacja - Aktywa

                _dane._regulacja1_aktywa1 = checkedListBoxAktywa1.GetItemChecked(0);
                _dane._regulacja1_aktywa2 = checkedListBoxAktywa1.GetItemChecked(1);
                _dane._regulacja1_aktywa3 = checkedListBoxAktywa1.GetItemChecked(2);
                _dane._regulacja1_aktywa4 = checkedListBoxAktywa1.GetItemChecked(3);
                _dane._regulacja1_aktywa5 = checkedListBoxAktywa1.GetItemChecked(4);
                _dane._regulacja1_aktywa6 = checkedListBoxAktywa1.GetItemChecked(5);
                _dane._regulacja1_aktywa7 = checkedListBoxAktywa1.GetItemChecked(6);
                _dane._regulacja1_aktywa8 = checkedListBoxAktywa1.GetItemChecked(7);
                _dane._regulacja1_aktywa9 = checkedListBoxAktywa1.GetItemChecked(8);
                _dane._regulacja1_aktywa10 = checkedListBoxAktywa1.GetItemChecked(9);

                _dane._regulacja2_aktywa1 = checkedListBoxAktywa2.GetItemChecked(0);
                _dane._regulacja2_aktywa2 = checkedListBoxAktywa2.GetItemChecked(1);
                _dane._regulacja2_aktywa3 = checkedListBoxAktywa2.GetItemChecked(2);
                _dane._regulacja2_aktywa4 = checkedListBoxAktywa2.GetItemChecked(3);
                _dane._regulacja2_aktywa5 = checkedListBoxAktywa2.GetItemChecked(4);
                _dane._regulacja2_aktywa6 = checkedListBoxAktywa2.GetItemChecked(5);
                _dane._regulacja2_aktywa7 = checkedListBoxAktywa2.GetItemChecked(6);
                _dane._regulacja2_aktywa8 = checkedListBoxAktywa2.GetItemChecked(7);
                _dane._regulacja2_aktywa9 = checkedListBoxAktywa2.GetItemChecked(8);
                _dane._regulacja2_aktywa10 = checkedListBoxAktywa2.GetItemChecked(9);

                _dane._regulacja3_aktywa1 = checkedListBoxAktywa3.GetItemChecked(0);
                _dane._regulacja3_aktywa2 = checkedListBoxAktywa3.GetItemChecked(1);
                _dane._regulacja3_aktywa3 = checkedListBoxAktywa3.GetItemChecked(2);
                _dane._regulacja3_aktywa4 = checkedListBoxAktywa3.GetItemChecked(3);
                _dane._regulacja3_aktywa5 = checkedListBoxAktywa3.GetItemChecked(4);
                _dane._regulacja3_aktywa6 = checkedListBoxAktywa3.GetItemChecked(5);
                _dane._regulacja3_aktywa7 = checkedListBoxAktywa3.GetItemChecked(6);
                _dane._regulacja3_aktywa8 = checkedListBoxAktywa3.GetItemChecked(7);
                _dane._regulacja3_aktywa9 = checkedListBoxAktywa3.GetItemChecked(8);
                _dane._regulacja3_aktywa10 = checkedListBoxAktywa3.GetItemChecked(9);

                _dane._regulacja4_aktywa1 = checkedListBoxAktywa4.GetItemChecked(0);
                _dane._regulacja4_aktywa2 = checkedListBoxAktywa4.GetItemChecked(1);
                _dane._regulacja4_aktywa3 = checkedListBoxAktywa4.GetItemChecked(2);
                _dane._regulacja4_aktywa4 = checkedListBoxAktywa4.GetItemChecked(3);
                _dane._regulacja4_aktywa5 = checkedListBoxAktywa4.GetItemChecked(4);
                _dane._regulacja4_aktywa6 = checkedListBoxAktywa4.GetItemChecked(5);
                _dane._regulacja4_aktywa7 = checkedListBoxAktywa4.GetItemChecked(6);
                _dane._regulacja4_aktywa8 = checkedListBoxAktywa4.GetItemChecked(7);
                _dane._regulacja4_aktywa9 = checkedListBoxAktywa4.GetItemChecked(8);
                _dane._regulacja4_aktywa10 = checkedListBoxAktywa4.GetItemChecked(9);

                _dane._regulacja5_aktywa1 = checkedListBoxAktywa5.GetItemChecked(0);
                _dane._regulacja5_aktywa2 = checkedListBoxAktywa5.GetItemChecked(1);
                _dane._regulacja5_aktywa3 = checkedListBoxAktywa5.GetItemChecked(2);
                _dane._regulacja5_aktywa4 = checkedListBoxAktywa5.GetItemChecked(3);
                _dane._regulacja5_aktywa5 = checkedListBoxAktywa5.GetItemChecked(4);
                _dane._regulacja5_aktywa6 = checkedListBoxAktywa5.GetItemChecked(5);
                _dane._regulacja5_aktywa7 = checkedListBoxAktywa5.GetItemChecked(6);
                _dane._regulacja5_aktywa8 = checkedListBoxAktywa5.GetItemChecked(7);
                _dane._regulacja5_aktywa9 = checkedListBoxAktywa5.GetItemChecked(8);
                _dane._regulacja5_aktywa10 = checkedListBoxAktywa5.GetItemChecked(9);

                _dane._regulacja6_aktywa1 = checkedListBoxAktywa6.GetItemChecked(0);
                _dane._regulacja6_aktywa2 = checkedListBoxAktywa6.GetItemChecked(1);
                _dane._regulacja6_aktywa3 = checkedListBoxAktywa6.GetItemChecked(2);
                _dane._regulacja6_aktywa4 = checkedListBoxAktywa6.GetItemChecked(3);
                _dane._regulacja6_aktywa5 = checkedListBoxAktywa6.GetItemChecked(4);
                _dane._regulacja6_aktywa6 = checkedListBoxAktywa6.GetItemChecked(5);
                _dane._regulacja6_aktywa7 = checkedListBoxAktywa6.GetItemChecked(6);
                _dane._regulacja6_aktywa8 = checkedListBoxAktywa6.GetItemChecked(7);
                _dane._regulacja6_aktywa9 = checkedListBoxAktywa6.GetItemChecked(8);
                _dane._regulacja6_aktywa10 = checkedListBoxAktywa6.GetItemChecked(9);

                _dane._regulacja7_aktywa1 = checkedListBoxAktywa7.GetItemChecked(0);
                _dane._regulacja7_aktywa2 = checkedListBoxAktywa7.GetItemChecked(1);
                _dane._regulacja7_aktywa3 = checkedListBoxAktywa7.GetItemChecked(2);
                _dane._regulacja7_aktywa4 = checkedListBoxAktywa7.GetItemChecked(3);
                _dane._regulacja7_aktywa5 = checkedListBoxAktywa7.GetItemChecked(4);
                _dane._regulacja7_aktywa6 = checkedListBoxAktywa7.GetItemChecked(5);
                _dane._regulacja7_aktywa7 = checkedListBoxAktywa7.GetItemChecked(6);
                _dane._regulacja7_aktywa8 = checkedListBoxAktywa7.GetItemChecked(7);
                _dane._regulacja7_aktywa9 = checkedListBoxAktywa7.GetItemChecked(8);
                _dane._regulacja7_aktywa10 = checkedListBoxAktywa7.GetItemChecked(9);

                _dane._regulacja8_aktywa1 = checkedListBoxAktywa8.GetItemChecked(0);
                _dane._regulacja8_aktywa2 = checkedListBoxAktywa8.GetItemChecked(1);
                _dane._regulacja8_aktywa3 = checkedListBoxAktywa8.GetItemChecked(2);
                _dane._regulacja8_aktywa4 = checkedListBoxAktywa8.GetItemChecked(3);
                _dane._regulacja8_aktywa5 = checkedListBoxAktywa8.GetItemChecked(4);
                _dane._regulacja8_aktywa6 = checkedListBoxAktywa8.GetItemChecked(5);
                _dane._regulacja8_aktywa7 = checkedListBoxAktywa8.GetItemChecked(6);
                _dane._regulacja8_aktywa8 = checkedListBoxAktywa8.GetItemChecked(7);
                _dane._regulacja8_aktywa9 = checkedListBoxAktywa8.GetItemChecked(8);
                _dane._regulacja8_aktywa10 = checkedListBoxAktywa8.GetItemChecked(9);

                _dane._regulacja9_aktywa1 = checkedListBoxAktywa9.GetItemChecked(0);
                _dane._regulacja9_aktywa2 = checkedListBoxAktywa9.GetItemChecked(1);
                _dane._regulacja9_aktywa3 = checkedListBoxAktywa9.GetItemChecked(2);
                _dane._regulacja9_aktywa4 = checkedListBoxAktywa9.GetItemChecked(3);
                _dane._regulacja9_aktywa5 = checkedListBoxAktywa9.GetItemChecked(4);
                _dane._regulacja9_aktywa6 = checkedListBoxAktywa9.GetItemChecked(5);
                _dane._regulacja9_aktywa7 = checkedListBoxAktywa9.GetItemChecked(6);
                _dane._regulacja9_aktywa8 = checkedListBoxAktywa9.GetItemChecked(7);
                _dane._regulacja9_aktywa9 = checkedListBoxAktywa9.GetItemChecked(8);
                _dane._regulacja9_aktywa10 = checkedListBoxAktywa9.GetItemChecked(9);

                _dane._regulacja10_aktywa1 = checkedListBoxAktywa10.GetItemChecked(0);
                _dane._regulacja10_aktywa2 = checkedListBoxAktywa10.GetItemChecked(1);
                _dane._regulacja10_aktywa3 = checkedListBoxAktywa10.GetItemChecked(2);
                _dane._regulacja10_aktywa4 = checkedListBoxAktywa10.GetItemChecked(3);
                _dane._regulacja10_aktywa5 = checkedListBoxAktywa10.GetItemChecked(4);
                _dane._regulacja10_aktywa6 = checkedListBoxAktywa10.GetItemChecked(5);
                _dane._regulacja10_aktywa7 = checkedListBoxAktywa10.GetItemChecked(6);
                _dane._regulacja10_aktywa8 = checkedListBoxAktywa10.GetItemChecked(7);
                _dane._regulacja10_aktywa9 = checkedListBoxAktywa10.GetItemChecked(8);
                _dane._regulacja10_aktywa10 = checkedListBoxAktywa10.GetItemChecked(9);

                //---------------- Aktywa - Wł. ochrony

                _dane._aktywa1_wlasnosc1 = checkedListBoxWlasnosc1.GetItemChecked(0);
                _dane._aktywa1_wlasnosc2 = checkedListBoxWlasnosc1.GetItemChecked(1);
                _dane._aktywa1_wlasnosc3 = checkedListBoxWlasnosc1.GetItemChecked(2);
                _dane._aktywa1_wlasnosc4 = checkedListBoxWlasnosc1.GetItemChecked(3);
                _dane._aktywa1_wlasnosc5 = checkedListBoxWlasnosc1.GetItemChecked(4);
                _dane._aktywa1_wlasnosc6 = checkedListBoxWlasnosc1.GetItemChecked(5);
                _dane._aktywa1_wlasnosc7 = checkedListBoxWlasnosc1.GetItemChecked(6);
                _dane._aktywa1_wlasnosc8 = checkedListBoxWlasnosc1.GetItemChecked(7);
                _dane._aktywa1_wlasnosc9 = checkedListBoxWlasnosc1.GetItemChecked(8);
                _dane._aktywa1_wlasnosc10 = checkedListBoxWlasnosc1.GetItemChecked(9);

                _dane._aktywa2_wlasnosc1 = checkedListBoxWlasnosc2.GetItemChecked(0);
                _dane._aktywa2_wlasnosc2 = checkedListBoxWlasnosc2.GetItemChecked(1);
                _dane._aktywa2_wlasnosc3 = checkedListBoxWlasnosc2.GetItemChecked(2);
                _dane._aktywa2_wlasnosc4 = checkedListBoxWlasnosc2.GetItemChecked(3);
                _dane._aktywa2_wlasnosc5 = checkedListBoxWlasnosc2.GetItemChecked(4);
                _dane._aktywa2_wlasnosc6 = checkedListBoxWlasnosc2.GetItemChecked(5);
                _dane._aktywa2_wlasnosc7 = checkedListBoxWlasnosc2.GetItemChecked(6);
                _dane._aktywa2_wlasnosc8 = checkedListBoxWlasnosc2.GetItemChecked(7);
                _dane._aktywa2_wlasnosc9 = checkedListBoxWlasnosc2.GetItemChecked(8);
                _dane._aktywa2_wlasnosc10 = checkedListBoxWlasnosc2.GetItemChecked(9);

                _dane._aktywa3_wlasnosc1 = checkedListBoxWlasnosc3.GetItemChecked(0);
                _dane._aktywa3_wlasnosc2 = checkedListBoxWlasnosc3.GetItemChecked(1);
                _dane._aktywa3_wlasnosc3 = checkedListBoxWlasnosc3.GetItemChecked(2);
                _dane._aktywa3_wlasnosc4 = checkedListBoxWlasnosc3.GetItemChecked(3);
                _dane._aktywa3_wlasnosc5 = checkedListBoxWlasnosc3.GetItemChecked(4);
                _dane._aktywa3_wlasnosc6 = checkedListBoxWlasnosc3.GetItemChecked(5);
                _dane._aktywa3_wlasnosc7 = checkedListBoxWlasnosc3.GetItemChecked(6);
                _dane._aktywa3_wlasnosc8 = checkedListBoxWlasnosc3.GetItemChecked(7);
                _dane._aktywa3_wlasnosc9 = checkedListBoxWlasnosc3.GetItemChecked(8);
                _dane._aktywa3_wlasnosc10 = checkedListBoxWlasnosc3.GetItemChecked(9);

                _dane._aktywa4_wlasnosc1 = checkedListBoxWlasnosc4.GetItemChecked(0);
                _dane._aktywa4_wlasnosc2 = checkedListBoxWlasnosc4.GetItemChecked(1);
                _dane._aktywa4_wlasnosc3 = checkedListBoxWlasnosc4.GetItemChecked(2);
                _dane._aktywa4_wlasnosc4 = checkedListBoxWlasnosc4.GetItemChecked(3);
                _dane._aktywa4_wlasnosc5 = checkedListBoxWlasnosc4.GetItemChecked(4);
                _dane._aktywa4_wlasnosc6 = checkedListBoxWlasnosc4.GetItemChecked(5);
                _dane._aktywa4_wlasnosc7 = checkedListBoxWlasnosc4.GetItemChecked(6);
                _dane._aktywa4_wlasnosc8 = checkedListBoxWlasnosc4.GetItemChecked(7);
                _dane._aktywa4_wlasnosc9 = checkedListBoxWlasnosc4.GetItemChecked(8);
                _dane._aktywa4_wlasnosc10 = checkedListBoxWlasnosc4.GetItemChecked(9);

                _dane._aktywa5_wlasnosc1 = checkedListBoxWlasnosc5.GetItemChecked(0);
                _dane._aktywa5_wlasnosc2 = checkedListBoxWlasnosc5.GetItemChecked(1);
                _dane._aktywa5_wlasnosc3 = checkedListBoxWlasnosc5.GetItemChecked(2);
                _dane._aktywa5_wlasnosc4 = checkedListBoxWlasnosc5.GetItemChecked(3);
                _dane._aktywa5_wlasnosc5 = checkedListBoxWlasnosc5.GetItemChecked(4);
                _dane._aktywa5_wlasnosc6 = checkedListBoxWlasnosc5.GetItemChecked(5);
                _dane._aktywa5_wlasnosc7 = checkedListBoxWlasnosc5.GetItemChecked(6);
                _dane._aktywa5_wlasnosc8 = checkedListBoxWlasnosc5.GetItemChecked(7);
                _dane._aktywa5_wlasnosc9 = checkedListBoxWlasnosc5.GetItemChecked(8);
                _dane._aktywa5_wlasnosc10 = checkedListBoxWlasnosc5.GetItemChecked(9);

                _dane._aktywa6_wlasnosc1 = checkedListBoxWlasnosc6.GetItemChecked(0);
                _dane._aktywa6_wlasnosc2 = checkedListBoxWlasnosc6.GetItemChecked(1);
                _dane._aktywa6_wlasnosc3 = checkedListBoxWlasnosc6.GetItemChecked(2);
                _dane._aktywa6_wlasnosc4 = checkedListBoxWlasnosc6.GetItemChecked(3);
                _dane._aktywa6_wlasnosc5 = checkedListBoxWlasnosc6.GetItemChecked(4);
                _dane._aktywa6_wlasnosc6 = checkedListBoxWlasnosc6.GetItemChecked(5);
                _dane._aktywa6_wlasnosc7 = checkedListBoxWlasnosc6.GetItemChecked(6);
                _dane._aktywa6_wlasnosc8 = checkedListBoxWlasnosc6.GetItemChecked(7);
                _dane._aktywa6_wlasnosc9 = checkedListBoxWlasnosc6.GetItemChecked(8);
                _dane._aktywa6_wlasnosc10 = checkedListBoxWlasnosc6.GetItemChecked(9);

                _dane._aktywa7_wlasnosc1 = checkedListBoxWlasnosc7.GetItemChecked(0);
                _dane._aktywa7_wlasnosc2 = checkedListBoxWlasnosc7.GetItemChecked(1);
                _dane._aktywa7_wlasnosc3 = checkedListBoxWlasnosc7.GetItemChecked(2);
                _dane._aktywa7_wlasnosc4 = checkedListBoxWlasnosc7.GetItemChecked(3);
                _dane._aktywa7_wlasnosc5 = checkedListBoxWlasnosc7.GetItemChecked(4);
                _dane._aktywa7_wlasnosc6 = checkedListBoxWlasnosc7.GetItemChecked(5);
                _dane._aktywa7_wlasnosc7 = checkedListBoxWlasnosc7.GetItemChecked(6);
                _dane._aktywa7_wlasnosc8 = checkedListBoxWlasnosc7.GetItemChecked(7);
                _dane._aktywa7_wlasnosc9 = checkedListBoxWlasnosc7.GetItemChecked(8);
                _dane._aktywa7_wlasnosc10 = checkedListBoxWlasnosc7.GetItemChecked(9);

                _dane._aktywa8_wlasnosc1 = checkedListBoxWlasnosc8.GetItemChecked(0);
                _dane._aktywa8_wlasnosc2 = checkedListBoxWlasnosc8.GetItemChecked(1);
                _dane._aktywa8_wlasnosc3 = checkedListBoxWlasnosc8.GetItemChecked(2);
                _dane._aktywa8_wlasnosc4 = checkedListBoxWlasnosc8.GetItemChecked(3);
                _dane._aktywa8_wlasnosc5 = checkedListBoxWlasnosc8.GetItemChecked(4);
                _dane._aktywa8_wlasnosc6 = checkedListBoxWlasnosc8.GetItemChecked(5);
                _dane._aktywa8_wlasnosc7 = checkedListBoxWlasnosc8.GetItemChecked(6);
                _dane._aktywa8_wlasnosc8 = checkedListBoxWlasnosc8.GetItemChecked(7);
                _dane._aktywa8_wlasnosc9 = checkedListBoxWlasnosc8.GetItemChecked(8);
                _dane._aktywa8_wlasnosc10 = checkedListBoxWlasnosc8.GetItemChecked(9);

                _dane._aktywa9_wlasnosc1 = checkedListBoxWlasnosc9.GetItemChecked(0);
                _dane._aktywa9_wlasnosc2 = checkedListBoxWlasnosc9.GetItemChecked(1);
                _dane._aktywa9_wlasnosc3 = checkedListBoxWlasnosc9.GetItemChecked(2);
                _dane._aktywa9_wlasnosc4 = checkedListBoxWlasnosc9.GetItemChecked(3);
                _dane._aktywa9_wlasnosc5 = checkedListBoxWlasnosc9.GetItemChecked(4);
                _dane._aktywa9_wlasnosc6 = checkedListBoxWlasnosc9.GetItemChecked(5);
                _dane._aktywa9_wlasnosc7 = checkedListBoxWlasnosc9.GetItemChecked(6);
                _dane._aktywa9_wlasnosc8 = checkedListBoxWlasnosc9.GetItemChecked(7);
                _dane._aktywa9_wlasnosc9 = checkedListBoxWlasnosc9.GetItemChecked(8);
                _dane._aktywa9_wlasnosc10 = checkedListBoxWlasnosc9.GetItemChecked(9);

                _dane._aktywa10_wlasnosc1 = checkedListBoxWlasnosc10.GetItemChecked(0);
                _dane._aktywa10_wlasnosc2 = checkedListBoxWlasnosc10.GetItemChecked(1);
                _dane._aktywa10_wlasnosc3 = checkedListBoxWlasnosc10.GetItemChecked(2);
                _dane._aktywa10_wlasnosc4 = checkedListBoxWlasnosc10.GetItemChecked(3);
                _dane._aktywa10_wlasnosc5 = checkedListBoxWlasnosc10.GetItemChecked(4);
                _dane._aktywa10_wlasnosc6 = checkedListBoxWlasnosc10.GetItemChecked(5);
                _dane._aktywa10_wlasnosc7 = checkedListBoxWlasnosc10.GetItemChecked(6);
                _dane._aktywa10_wlasnosc8 = checkedListBoxWlasnosc10.GetItemChecked(7);
                _dane._aktywa10_wlasnosc9 = checkedListBoxWlasnosc10.GetItemChecked(8);
                _dane._aktywa10_wlasnosc10 = checkedListBoxWlasnosc10.GetItemChecked(9);

                //---------------- Atak - Aktywa

                _dane._atak1_aktywa1 = checkedListBoxAktywa11.GetItemChecked(0);
                _dane._atak1_aktywa2 = checkedListBoxAktywa11.GetItemChecked(1);
                _dane._atak1_aktywa3 = checkedListBoxAktywa11.GetItemChecked(2);
                _dane._atak1_aktywa4 = checkedListBoxAktywa11.GetItemChecked(3);
                _dane._atak1_aktywa5 = checkedListBoxAktywa11.GetItemChecked(4);
                _dane._atak1_aktywa6 = checkedListBoxAktywa11.GetItemChecked(5);
                _dane._atak1_aktywa7 = checkedListBoxAktywa11.GetItemChecked(6);
                _dane._atak1_aktywa8 = checkedListBoxAktywa11.GetItemChecked(7);
                _dane._atak1_aktywa9 = checkedListBoxAktywa11.GetItemChecked(8);
                _dane._atak1_aktywa10 = checkedListBoxAktywa11.GetItemChecked(9);

                _dane._atak2_aktywa1 = checkedListBoxAktywa12.GetItemChecked(0);
                _dane._atak2_aktywa2 = checkedListBoxAktywa12.GetItemChecked(1);
                _dane._atak2_aktywa3 = checkedListBoxAktywa12.GetItemChecked(2);
                _dane._atak2_aktywa4 = checkedListBoxAktywa12.GetItemChecked(3);
                _dane._atak2_aktywa5 = checkedListBoxAktywa12.GetItemChecked(4);
                _dane._atak2_aktywa6 = checkedListBoxAktywa12.GetItemChecked(5);
                _dane._atak2_aktywa7 = checkedListBoxAktywa12.GetItemChecked(6);
                _dane._atak2_aktywa8 = checkedListBoxAktywa12.GetItemChecked(7);
                _dane._atak2_aktywa9 = checkedListBoxAktywa12.GetItemChecked(8);
                _dane._atak2_aktywa10 = checkedListBoxAktywa12.GetItemChecked(9);

                _dane._atak3_aktywa1 = checkedListBoxAktywa13.GetItemChecked(0);
                _dane._atak3_aktywa2 = checkedListBoxAktywa13.GetItemChecked(1);
                _dane._atak3_aktywa3 = checkedListBoxAktywa13.GetItemChecked(2);
                _dane._atak3_aktywa4 = checkedListBoxAktywa13.GetItemChecked(3);
                _dane._atak3_aktywa5 = checkedListBoxAktywa13.GetItemChecked(4);
                _dane._atak3_aktywa6 = checkedListBoxAktywa13.GetItemChecked(5);
                _dane._atak3_aktywa7 = checkedListBoxAktywa13.GetItemChecked(6);
                _dane._atak3_aktywa8 = checkedListBoxAktywa13.GetItemChecked(7);
                _dane._atak3_aktywa9 = checkedListBoxAktywa13.GetItemChecked(8);
                _dane._atak3_aktywa10 = checkedListBoxAktywa13.GetItemChecked(9);

                _dane._atak4_aktywa1 = checkedListBoxAktywa14.GetItemChecked(0);
                _dane._atak4_aktywa2 = checkedListBoxAktywa14.GetItemChecked(1);
                _dane._atak4_aktywa3 = checkedListBoxAktywa14.GetItemChecked(2);
                _dane._atak4_aktywa4 = checkedListBoxAktywa14.GetItemChecked(3);
                _dane._atak4_aktywa5 = checkedListBoxAktywa14.GetItemChecked(4);
                _dane._atak4_aktywa6 = checkedListBoxAktywa14.GetItemChecked(5);
                _dane._atak4_aktywa7 = checkedListBoxAktywa14.GetItemChecked(6);
                _dane._atak4_aktywa8 = checkedListBoxAktywa14.GetItemChecked(7);
                _dane._atak4_aktywa9 = checkedListBoxAktywa14.GetItemChecked(8);
                _dane._atak4_aktywa10 = checkedListBoxAktywa14.GetItemChecked(9);

                _dane._atak5_aktywa1 = checkedListBoxAktywa15.GetItemChecked(0);
                _dane._atak5_aktywa2 = checkedListBoxAktywa15.GetItemChecked(1);
                _dane._atak5_aktywa3 = checkedListBoxAktywa15.GetItemChecked(2);
                _dane._atak5_aktywa4 = checkedListBoxAktywa15.GetItemChecked(3);
                _dane._atak5_aktywa5 = checkedListBoxAktywa15.GetItemChecked(4);
                _dane._atak5_aktywa6 = checkedListBoxAktywa15.GetItemChecked(5);
                _dane._atak5_aktywa7 = checkedListBoxAktywa15.GetItemChecked(6);
                _dane._atak5_aktywa8 = checkedListBoxAktywa15.GetItemChecked(7);
                _dane._atak5_aktywa9 = checkedListBoxAktywa15.GetItemChecked(8);
                _dane._atak5_aktywa10 = checkedListBoxAktywa15.GetItemChecked(9);

                _dane._atak6_aktywa1 = checkedListBoxAktywa16.GetItemChecked(0);
                _dane._atak6_aktywa2 = checkedListBoxAktywa16.GetItemChecked(1);
                _dane._atak6_aktywa3 = checkedListBoxAktywa16.GetItemChecked(2);
                _dane._atak6_aktywa4 = checkedListBoxAktywa16.GetItemChecked(3);
                _dane._atak6_aktywa5 = checkedListBoxAktywa16.GetItemChecked(4);
                _dane._atak6_aktywa6 = checkedListBoxAktywa16.GetItemChecked(5);
                _dane._atak6_aktywa7 = checkedListBoxAktywa16.GetItemChecked(6);
                _dane._atak6_aktywa8 = checkedListBoxAktywa16.GetItemChecked(7);
                _dane._atak6_aktywa9 = checkedListBoxAktywa16.GetItemChecked(8);
                _dane._atak6_aktywa10 = checkedListBoxAktywa16.GetItemChecked(9);

                _dane._atak7_aktywa1 = checkedListBoxAktywa17.GetItemChecked(0);
                _dane._atak7_aktywa2 = checkedListBoxAktywa17.GetItemChecked(1);
                _dane._atak7_aktywa3 = checkedListBoxAktywa17.GetItemChecked(2);
                _dane._atak7_aktywa4 = checkedListBoxAktywa17.GetItemChecked(3);
                _dane._atak7_aktywa5 = checkedListBoxAktywa17.GetItemChecked(4);
                _dane._atak7_aktywa6 = checkedListBoxAktywa17.GetItemChecked(5);
                _dane._atak7_aktywa7 = checkedListBoxAktywa17.GetItemChecked(6);
                _dane._atak7_aktywa8 = checkedListBoxAktywa17.GetItemChecked(7);
                _dane._atak7_aktywa9 = checkedListBoxAktywa17.GetItemChecked(8);
                _dane._atak7_aktywa10 = checkedListBoxAktywa17.GetItemChecked(9);

                _dane._atak8_aktywa1 = checkedListBoxAktywa18.GetItemChecked(0);
                _dane._atak8_aktywa2 = checkedListBoxAktywa18.GetItemChecked(1);
                _dane._atak8_aktywa3 = checkedListBoxAktywa18.GetItemChecked(2);
                _dane._atak8_aktywa4 = checkedListBoxAktywa18.GetItemChecked(3);
                _dane._atak8_aktywa5 = checkedListBoxAktywa18.GetItemChecked(4);
                _dane._atak8_aktywa6 = checkedListBoxAktywa18.GetItemChecked(5);
                _dane._atak8_aktywa7 = checkedListBoxAktywa18.GetItemChecked(6);
                _dane._atak8_aktywa8 = checkedListBoxAktywa18.GetItemChecked(7);
                _dane._atak8_aktywa9 = checkedListBoxAktywa18.GetItemChecked(8);
                _dane._atak8_aktywa10 = checkedListBoxAktywa18.GetItemChecked(9);

                _dane._atak9_aktywa1 = checkedListBoxAktywa19.GetItemChecked(0);
                _dane._atak9_aktywa2 = checkedListBoxAktywa19.GetItemChecked(1);
                _dane._atak9_aktywa3 = checkedListBoxAktywa19.GetItemChecked(2);
                _dane._atak9_aktywa4 = checkedListBoxAktywa19.GetItemChecked(3);
                _dane._atak9_aktywa5 = checkedListBoxAktywa19.GetItemChecked(4);
                _dane._atak9_aktywa6 = checkedListBoxAktywa19.GetItemChecked(5);
                _dane._atak9_aktywa7 = checkedListBoxAktywa19.GetItemChecked(6);
                _dane._atak9_aktywa8 = checkedListBoxAktywa19.GetItemChecked(7);
                _dane._atak9_aktywa9 = checkedListBoxAktywa19.GetItemChecked(8);
                _dane._atak9_aktywa10 = checkedListBoxAktywa19.GetItemChecked(9);

                _dane._atak10_aktywa1 = checkedListBoxAktywa110.GetItemChecked(0);
                _dane._atak10_aktywa2 = checkedListBoxAktywa110.GetItemChecked(1);
                _dane._atak10_aktywa3 = checkedListBoxAktywa110.GetItemChecked(2);
                _dane._atak10_aktywa4 = checkedListBoxAktywa110.GetItemChecked(3);
                _dane._atak10_aktywa5 = checkedListBoxAktywa110.GetItemChecked(4);
                _dane._atak10_aktywa6 = checkedListBoxAktywa110.GetItemChecked(5);
                _dane._atak10_aktywa7 = checkedListBoxAktywa110.GetItemChecked(6);
                _dane._atak10_aktywa8 = checkedListBoxAktywa110.GetItemChecked(7);
                _dane._atak10_aktywa9 = checkedListBoxAktywa110.GetItemChecked(8);
                _dane._atak10_aktywa10 = checkedListBoxAktywa110.GetItemChecked(9);

                //---------------- Atak - Szkoda

                _dane._atak1_szkoda1 = checkedListBoxZagrozenie1.GetItemChecked(0);
                _dane._atak1_szkoda2 = checkedListBoxZagrozenie1.GetItemChecked(1);
                _dane._atak1_szkoda3 = checkedListBoxZagrozenie1.GetItemChecked(2);
                _dane._atak1_szkoda4 = checkedListBoxZagrozenie1.GetItemChecked(3);
                _dane._atak1_szkoda5 = checkedListBoxZagrozenie1.GetItemChecked(4);
                _dane._atak1_szkoda6 = checkedListBoxZagrozenie1.GetItemChecked(5);
                _dane._atak1_szkoda7 = checkedListBoxZagrozenie1.GetItemChecked(6);
                _dane._atak1_szkoda8 = checkedListBoxZagrozenie1.GetItemChecked(7);
                _dane._atak1_szkoda9 = checkedListBoxZagrozenie1.GetItemChecked(8);
                _dane._atak1_szkoda10 = checkedListBoxZagrozenie1.GetItemChecked(9);

                _dane._atak2_szkoda1 = checkedListBoxZagrozenie2.GetItemChecked(0);
                _dane._atak2_szkoda2 = checkedListBoxZagrozenie2.GetItemChecked(1);
                _dane._atak2_szkoda3 = checkedListBoxZagrozenie2.GetItemChecked(2);
                _dane._atak2_szkoda4 = checkedListBoxZagrozenie2.GetItemChecked(3);
                _dane._atak2_szkoda5 = checkedListBoxZagrozenie2.GetItemChecked(4);
                _dane._atak2_szkoda6 = checkedListBoxZagrozenie2.GetItemChecked(5);
                _dane._atak2_szkoda7 = checkedListBoxZagrozenie2.GetItemChecked(6);
                _dane._atak2_szkoda8 = checkedListBoxZagrozenie2.GetItemChecked(7);
                _dane._atak2_szkoda9 = checkedListBoxZagrozenie2.GetItemChecked(8);
                _dane._atak2_szkoda10 = checkedListBoxZagrozenie2.GetItemChecked(9);

                _dane._atak3_szkoda1 = checkedListBoxZagrozenie3.GetItemChecked(0);
                _dane._atak3_szkoda2 = checkedListBoxZagrozenie3.GetItemChecked(1);
                _dane._atak3_szkoda3 = checkedListBoxZagrozenie3.GetItemChecked(2);
                _dane._atak3_szkoda4 = checkedListBoxZagrozenie3.GetItemChecked(3);
                _dane._atak3_szkoda5 = checkedListBoxZagrozenie3.GetItemChecked(4);
                _dane._atak3_szkoda6 = checkedListBoxZagrozenie3.GetItemChecked(5);
                _dane._atak3_szkoda7 = checkedListBoxZagrozenie3.GetItemChecked(6);
                _dane._atak3_szkoda8 = checkedListBoxZagrozenie3.GetItemChecked(7);
                _dane._atak3_szkoda9 = checkedListBoxZagrozenie3.GetItemChecked(8);
                _dane._atak3_szkoda10 = checkedListBoxZagrozenie3.GetItemChecked(9);

                _dane._atak4_szkoda1 = checkedListBoxZagrozenie4.GetItemChecked(0);
                _dane._atak4_szkoda2 = checkedListBoxZagrozenie4.GetItemChecked(1);
                _dane._atak4_szkoda3 = checkedListBoxZagrozenie4.GetItemChecked(2);
                _dane._atak4_szkoda4 = checkedListBoxZagrozenie4.GetItemChecked(3);
                _dane._atak4_szkoda5 = checkedListBoxZagrozenie4.GetItemChecked(4);
                _dane._atak4_szkoda6 = checkedListBoxZagrozenie4.GetItemChecked(5);
                _dane._atak4_szkoda7 = checkedListBoxZagrozenie4.GetItemChecked(6);
                _dane._atak4_szkoda8 = checkedListBoxZagrozenie4.GetItemChecked(7);
                _dane._atak4_szkoda9 = checkedListBoxZagrozenie4.GetItemChecked(8);
                _dane._atak4_szkoda10 = checkedListBoxZagrozenie4.GetItemChecked(9);

                _dane._atak5_szkoda1 = checkedListBoxZagrozenie5.GetItemChecked(0);
                _dane._atak5_szkoda2 = checkedListBoxZagrozenie5.GetItemChecked(1);
                _dane._atak5_szkoda3 = checkedListBoxZagrozenie5.GetItemChecked(2);
                _dane._atak5_szkoda4 = checkedListBoxZagrozenie5.GetItemChecked(3);
                _dane._atak5_szkoda5 = checkedListBoxZagrozenie5.GetItemChecked(4);
                _dane._atak5_szkoda6 = checkedListBoxZagrozenie5.GetItemChecked(5);
                _dane._atak5_szkoda7 = checkedListBoxZagrozenie5.GetItemChecked(6);
                _dane._atak5_szkoda8 = checkedListBoxZagrozenie5.GetItemChecked(7);
                _dane._atak5_szkoda9 = checkedListBoxZagrozenie5.GetItemChecked(8);
                _dane._atak5_szkoda10 = checkedListBoxZagrozenie5.GetItemChecked(9);

                _dane._atak6_szkoda1 = checkedListBoxZagrozenie6.GetItemChecked(0);
                _dane._atak6_szkoda2 = checkedListBoxZagrozenie6.GetItemChecked(1);
                _dane._atak6_szkoda3 = checkedListBoxZagrozenie6.GetItemChecked(2);
                _dane._atak6_szkoda4 = checkedListBoxZagrozenie6.GetItemChecked(3);
                _dane._atak6_szkoda5 = checkedListBoxZagrozenie6.GetItemChecked(4);
                _dane._atak6_szkoda6 = checkedListBoxZagrozenie6.GetItemChecked(5);
                _dane._atak6_szkoda7 = checkedListBoxZagrozenie6.GetItemChecked(6);
                _dane._atak6_szkoda8 = checkedListBoxZagrozenie6.GetItemChecked(7);
                _dane._atak6_szkoda9 = checkedListBoxZagrozenie6.GetItemChecked(8);
                _dane._atak6_szkoda10 = checkedListBoxZagrozenie6.GetItemChecked(9);

                _dane._atak7_szkoda1 = checkedListBoxZagrozenie7.GetItemChecked(0);
                _dane._atak7_szkoda2 = checkedListBoxZagrozenie7.GetItemChecked(1);
                _dane._atak7_szkoda3 = checkedListBoxZagrozenie7.GetItemChecked(2);
                _dane._atak7_szkoda4 = checkedListBoxZagrozenie7.GetItemChecked(3);
                _dane._atak7_szkoda5 = checkedListBoxZagrozenie7.GetItemChecked(4);
                _dane._atak7_szkoda6 = checkedListBoxZagrozenie7.GetItemChecked(5);
                _dane._atak7_szkoda7 = checkedListBoxZagrozenie7.GetItemChecked(6);
                _dane._atak7_szkoda8 = checkedListBoxZagrozenie7.GetItemChecked(7);
                _dane._atak7_szkoda9 = checkedListBoxZagrozenie7.GetItemChecked(8);
                _dane._atak7_szkoda10 = checkedListBoxZagrozenie7.GetItemChecked(9);

                _dane._atak8_szkoda1 = checkedListBoxZagrozenie8.GetItemChecked(0);
                _dane._atak8_szkoda2 = checkedListBoxZagrozenie8.GetItemChecked(1);
                _dane._atak8_szkoda3 = checkedListBoxZagrozenie8.GetItemChecked(2);
                _dane._atak8_szkoda4 = checkedListBoxZagrozenie8.GetItemChecked(3);
                _dane._atak8_szkoda5 = checkedListBoxZagrozenie8.GetItemChecked(4);
                _dane._atak8_szkoda6 = checkedListBoxZagrozenie8.GetItemChecked(5);
                _dane._atak8_szkoda7 = checkedListBoxZagrozenie8.GetItemChecked(6);
                _dane._atak8_szkoda8 = checkedListBoxZagrozenie8.GetItemChecked(7);
                _dane._atak8_szkoda9 = checkedListBoxZagrozenie8.GetItemChecked(8);
                _dane._atak8_szkoda10 = checkedListBoxZagrozenie8.GetItemChecked(9);

                _dane._atak9_szkoda1 = checkedListBoxZagrozenie9.GetItemChecked(0);
                _dane._atak9_szkoda2 = checkedListBoxZagrozenie9.GetItemChecked(1);
                _dane._atak9_szkoda3 = checkedListBoxZagrozenie9.GetItemChecked(2);
                _dane._atak9_szkoda4 = checkedListBoxZagrozenie9.GetItemChecked(3);
                _dane._atak9_szkoda5 = checkedListBoxZagrozenie9.GetItemChecked(4);
                _dane._atak9_szkoda6 = checkedListBoxZagrozenie9.GetItemChecked(5);
                _dane._atak9_szkoda7 = checkedListBoxZagrozenie9.GetItemChecked(6);
                _dane._atak9_szkoda8 = checkedListBoxZagrozenie9.GetItemChecked(7);
                _dane._atak9_szkoda9 = checkedListBoxZagrozenie9.GetItemChecked(8);
                _dane._atak9_szkoda10 = checkedListBoxZagrozenie9.GetItemChecked(9);

                _dane._atak10_szkoda1 = checkedListBoxZagrozenie10.GetItemChecked(0);
                _dane._atak10_szkoda2 = checkedListBoxZagrozenie10.GetItemChecked(1);
                _dane._atak10_szkoda3 = checkedListBoxZagrozenie10.GetItemChecked(2);
                _dane._atak10_szkoda4 = checkedListBoxZagrozenie10.GetItemChecked(3);
                _dane._atak10_szkoda5 = checkedListBoxZagrozenie10.GetItemChecked(4);
                _dane._atak10_szkoda6 = checkedListBoxZagrozenie10.GetItemChecked(5);
                _dane._atak10_szkoda7 = checkedListBoxZagrozenie10.GetItemChecked(6);
                _dane._atak10_szkoda8 = checkedListBoxZagrozenie10.GetItemChecked(7);
                _dane._atak10_szkoda9 = checkedListBoxZagrozenie10.GetItemChecked(8);
                _dane._atak10_szkoda10 = checkedListBoxZagrozenie10.GetItemChecked(9);

                //---------------- Atak - Wykonawca

                _dane._atak1_wykonawca1 = checkedListBoxWykonawca1.GetItemChecked(0);
                _dane._atak1_wykonawca2 = checkedListBoxWykonawca1.GetItemChecked(1);
                _dane._atak1_wykonawca3 = checkedListBoxWykonawca1.GetItemChecked(2);
                _dane._atak1_wykonawca4 = checkedListBoxWykonawca1.GetItemChecked(3);
                _dane._atak1_wykonawca5 = checkedListBoxWykonawca1.GetItemChecked(4);
                _dane._atak1_wykonawca6 = checkedListBoxWykonawca1.GetItemChecked(5);
                _dane._atak1_wykonawca7 = checkedListBoxWykonawca1.GetItemChecked(6);
                _dane._atak1_wykonawca8 = checkedListBoxWykonawca1.GetItemChecked(7);
                _dane._atak1_wykonawca9 = checkedListBoxWykonawca1.GetItemChecked(8);
                _dane._atak1_wykonawca10 = checkedListBoxWykonawca1.GetItemChecked(9);

                _dane._atak2_wykonawca1 = checkedListBoxWykonawca2.GetItemChecked(0);
                _dane._atak2_wykonawca2 = checkedListBoxWykonawca2.GetItemChecked(1);
                _dane._atak2_wykonawca3 = checkedListBoxWykonawca2.GetItemChecked(2);
                _dane._atak2_wykonawca4 = checkedListBoxWykonawca2.GetItemChecked(3);
                _dane._atak2_wykonawca5 = checkedListBoxWykonawca2.GetItemChecked(4);
                _dane._atak2_wykonawca6 = checkedListBoxWykonawca2.GetItemChecked(5);
                _dane._atak2_wykonawca7 = checkedListBoxWykonawca2.GetItemChecked(6);
                _dane._atak2_wykonawca8 = checkedListBoxWykonawca2.GetItemChecked(7);
                _dane._atak2_wykonawca9 = checkedListBoxWykonawca2.GetItemChecked(8);
                _dane._atak2_wykonawca10 = checkedListBoxWykonawca2.GetItemChecked(9);

                _dane._atak3_wykonawca1 = checkedListBoxWykonawca3.GetItemChecked(0);
                _dane._atak3_wykonawca2 = checkedListBoxWykonawca3.GetItemChecked(1);
                _dane._atak3_wykonawca3 = checkedListBoxWykonawca3.GetItemChecked(2);
                _dane._atak3_wykonawca4 = checkedListBoxWykonawca3.GetItemChecked(3);
                _dane._atak3_wykonawca5 = checkedListBoxWykonawca3.GetItemChecked(4);
                _dane._atak3_wykonawca6 = checkedListBoxWykonawca3.GetItemChecked(5);
                _dane._atak3_wykonawca7 = checkedListBoxWykonawca3.GetItemChecked(6);
                _dane._atak3_wykonawca8 = checkedListBoxWykonawca3.GetItemChecked(7);
                _dane._atak3_wykonawca9 = checkedListBoxWykonawca3.GetItemChecked(8);
                _dane._atak3_wykonawca10 = checkedListBoxWykonawca3.GetItemChecked(9);

                _dane._atak4_wykonawca1 = checkedListBoxWykonawca4.GetItemChecked(0);
                _dane._atak4_wykonawca2 = checkedListBoxWykonawca4.GetItemChecked(1);
                _dane._atak4_wykonawca3 = checkedListBoxWykonawca4.GetItemChecked(2);
                _dane._atak4_wykonawca4 = checkedListBoxWykonawca4.GetItemChecked(3);
                _dane._atak4_wykonawca5 = checkedListBoxWykonawca4.GetItemChecked(4);
                _dane._atak4_wykonawca6 = checkedListBoxWykonawca4.GetItemChecked(5);
                _dane._atak4_wykonawca7 = checkedListBoxWykonawca4.GetItemChecked(6);
                _dane._atak4_wykonawca8 = checkedListBoxWykonawca4.GetItemChecked(7);
                _dane._atak4_wykonawca9 = checkedListBoxWykonawca4.GetItemChecked(8);
                _dane._atak4_wykonawca10 = checkedListBoxWykonawca4.GetItemChecked(9);

                _dane._atak5_wykonawca1 = checkedListBoxWykonawca5.GetItemChecked(0);
                _dane._atak5_wykonawca2 = checkedListBoxWykonawca5.GetItemChecked(1);
                _dane._atak5_wykonawca3 = checkedListBoxWykonawca5.GetItemChecked(2);
                _dane._atak5_wykonawca4 = checkedListBoxWykonawca5.GetItemChecked(3);
                _dane._atak5_wykonawca5 = checkedListBoxWykonawca5.GetItemChecked(4);
                _dane._atak5_wykonawca6 = checkedListBoxWykonawca5.GetItemChecked(5);
                _dane._atak5_wykonawca7 = checkedListBoxWykonawca5.GetItemChecked(6);
                _dane._atak5_wykonawca8 = checkedListBoxWykonawca5.GetItemChecked(7);
                _dane._atak5_wykonawca9 = checkedListBoxWykonawca5.GetItemChecked(8);
                _dane._atak5_wykonawca10 = checkedListBoxWykonawca5.GetItemChecked(9);

                _dane._atak6_wykonawca1 = checkedListBoxWykonawca6.GetItemChecked(0);
                _dane._atak6_wykonawca2 = checkedListBoxWykonawca6.GetItemChecked(1);
                _dane._atak6_wykonawca3 = checkedListBoxWykonawca6.GetItemChecked(2);
                _dane._atak6_wykonawca4 = checkedListBoxWykonawca6.GetItemChecked(3);
                _dane._atak6_wykonawca5 = checkedListBoxWykonawca6.GetItemChecked(4);
                _dane._atak6_wykonawca6 = checkedListBoxWykonawca6.GetItemChecked(5);
                _dane._atak6_wykonawca7 = checkedListBoxWykonawca6.GetItemChecked(6);
                _dane._atak6_wykonawca8 = checkedListBoxWykonawca6.GetItemChecked(7);
                _dane._atak6_wykonawca9 = checkedListBoxWykonawca6.GetItemChecked(8);
                _dane._atak6_wykonawca10 = checkedListBoxWykonawca6.GetItemChecked(9);

                _dane._atak7_wykonawca1 = checkedListBoxWykonawca7.GetItemChecked(0);
                _dane._atak7_wykonawca2 = checkedListBoxWykonawca7.GetItemChecked(1);
                _dane._atak7_wykonawca3 = checkedListBoxWykonawca7.GetItemChecked(2);
                _dane._atak7_wykonawca4 = checkedListBoxWykonawca7.GetItemChecked(3);
                _dane._atak7_wykonawca5 = checkedListBoxWykonawca7.GetItemChecked(4);
                _dane._atak7_wykonawca6 = checkedListBoxWykonawca7.GetItemChecked(5);
                _dane._atak7_wykonawca7 = checkedListBoxWykonawca7.GetItemChecked(6);
                _dane._atak7_wykonawca8 = checkedListBoxWykonawca7.GetItemChecked(7);
                _dane._atak7_wykonawca9 = checkedListBoxWykonawca7.GetItemChecked(8);
                _dane._atak7_wykonawca10 = checkedListBoxWykonawca7.GetItemChecked(9);

                _dane._atak8_wykonawca1 = checkedListBoxWykonawca8.GetItemChecked(0);
                _dane._atak8_wykonawca2 = checkedListBoxWykonawca8.GetItemChecked(1);
                _dane._atak8_wykonawca3 = checkedListBoxWykonawca8.GetItemChecked(2);
                _dane._atak8_wykonawca4 = checkedListBoxWykonawca8.GetItemChecked(3);
                _dane._atak8_wykonawca5 = checkedListBoxWykonawca8.GetItemChecked(4);
                _dane._atak8_wykonawca6 = checkedListBoxWykonawca8.GetItemChecked(5);
                _dane._atak8_wykonawca7 = checkedListBoxWykonawca8.GetItemChecked(6);
                _dane._atak8_wykonawca8 = checkedListBoxWykonawca8.GetItemChecked(7);
                _dane._atak8_wykonawca9 = checkedListBoxWykonawca8.GetItemChecked(8);
                _dane._atak8_wykonawca10 = checkedListBoxWykonawca8.GetItemChecked(9);

                _dane._atak9_wykonawca1 = checkedListBoxWykonawca9.GetItemChecked(0);
                _dane._atak9_wykonawca2 = checkedListBoxWykonawca9.GetItemChecked(1);
                _dane._atak9_wykonawca3 = checkedListBoxWykonawca9.GetItemChecked(2);
                _dane._atak9_wykonawca4 = checkedListBoxWykonawca9.GetItemChecked(3);
                _dane._atak9_wykonawca5 = checkedListBoxWykonawca9.GetItemChecked(4);
                _dane._atak9_wykonawca6 = checkedListBoxWykonawca9.GetItemChecked(5);
                _dane._atak9_wykonawca7 = checkedListBoxWykonawca9.GetItemChecked(6);
                _dane._atak9_wykonawca8 = checkedListBoxWykonawca9.GetItemChecked(7);
                _dane._atak9_wykonawca9 = checkedListBoxWykonawca9.GetItemChecked(8);
                _dane._atak9_wykonawca10 = checkedListBoxWykonawca9.GetItemChecked(9);

                _dane._atak10_wykonawca1 = checkedListBoxWykonawca10.GetItemChecked(0);
                _dane._atak10_wykonawca2 = checkedListBoxWykonawca10.GetItemChecked(1);
                _dane._atak10_wykonawca3 = checkedListBoxWykonawca10.GetItemChecked(2);
                _dane._atak10_wykonawca4 = checkedListBoxWykonawca10.GetItemChecked(3);
                _dane._atak10_wykonawca5 = checkedListBoxWykonawca10.GetItemChecked(4);
                _dane._atak10_wykonawca6 = checkedListBoxWykonawca10.GetItemChecked(5);
                _dane._atak10_wykonawca7 = checkedListBoxWykonawca10.GetItemChecked(6);
                _dane._atak10_wykonawca8 = checkedListBoxWykonawca10.GetItemChecked(7);
                _dane._atak10_wykonawca9 = checkedListBoxWykonawca10.GetItemChecked(8);
                _dane._atak10_wykonawca10 = checkedListBoxWykonawca10.GetItemChecked(9);

                //---------------- Atak - Ryzyko
                _dane._czas1 = trackBarCzas1.Value;
                _dane._kwalifikacje1 = trackBarKwalifikacje1.Value;
                _dane._wiedza1 = trackBarWiedza1.Value;
                _dane._wyposazenie1 = trackBarWyposazenie1.Value;
                _dane._dostep1 = trackBarDostep1.Value;
                _dane._ryzyko1 = trackBarRyzyko1.Value;

                _dane._czas2 = trackBarCzas2.Value;
                _dane._kwalifikacje2 = trackBarKwalifikacje2.Value;
                _dane._wiedza2 = trackBarWiedza2.Value;
                _dane._wyposazenie2 = trackBarWyposazenie2.Value;
                _dane._dostep2 = trackBarDostep2.Value;
                _dane._ryzyko2 = trackBarRyzyko2.Value;

                _dane._czas3 = trackBarCzas3.Value;
                _dane._kwalifikacje3 = trackBarKwalifikacje3.Value;
                _dane._wiedza3 = trackBarWiedza3.Value;
                _dane._wyposazenie3 = trackBarWyposazenie3.Value;
                _dane._dostep3 = trackBarDostep3.Value;
                _dane._ryzyko3 = trackBarRyzyko3.Value;

                _dane._czas4 = trackBarCzas4.Value;
                _dane._kwalifikacje4 = trackBarKwalifikacje4.Value;
                _dane._wiedza4 = trackBarWiedza4.Value;
                _dane._wyposazenie4 = trackBarWyposazenie4.Value;
                _dane._dostep4 = trackBarDostep4.Value;
                _dane._ryzyko4 = trackBarRyzyko4.Value;

                _dane._czas5 = trackBarCzas5.Value;
                _dane._kwalifikacje5 = trackBarKwalifikacje5.Value;
                _dane._wiedza5 = trackBarWiedza5.Value;
                _dane._wyposazenie5 = trackBarWyposazenie5.Value;
                _dane._dostep5 = trackBarDostep5.Value;
                _dane._ryzyko5 = trackBarRyzyko5.Value;

                _dane._czas6 = trackBarCzas6.Value;
                _dane._kwalifikacje6 = trackBarKwalifikacje6.Value;
                _dane._wiedza6 = trackBarWiedza6.Value;
                _dane._wyposazenie6 = trackBarWyposazenie6.Value;
                _dane._dostep6 = trackBarDostep6.Value;
                _dane._ryzyko6 = trackBarRyzyko6.Value;

                _dane._czas7 = trackBarCzas7.Value;
                _dane._kwalifikacje7 = trackBarKwalifikacje7.Value;
                _dane._wiedza7 = trackBarWiedza7.Value;
                _dane._wyposazenie7 = trackBarWyposazenie7.Value;
                _dane._dostep7 = trackBarDostep7.Value;
                _dane._ryzyko7 = trackBarRyzyko7.Value;

                _dane._czas8 = trackBarCzas8.Value;
                _dane._kwalifikacje8 = trackBarKwalifikacje8.Value;
                _dane._wiedza8 = trackBarWiedza8.Value;
                _dane._wyposazenie8 = trackBarWyposazenie8.Value;
                _dane._dostep8 = trackBarDostep8.Value;
                _dane._ryzyko8 = trackBarRyzyko8.Value;

                _dane._czas9 = trackBarCzas9.Value;
                _dane._kwalifikacje9 = trackBarKwalifikacje9.Value;
                _dane._wiedza9 = trackBarWiedza9.Value;
                _dane._wyposazenie9 = trackBarWyposazenie9.Value;
                _dane._dostep9 = trackBarDostep9.Value;
                _dane._ryzyko9 = trackBarRyzyko9.Value;

                _dane._czas10 = trackBarCzas10.Value;
                _dane._kwalifikacje10 = trackBarKwalifikacje10.Value;
                _dane._wiedza10 = trackBarWiedza10.Value;
                _dane._wyposazenie10 = trackBarWyposazenie10.Value;
                _dane._dostep10 = trackBarDostep10.Value;
                _dane._ryzyko10 = trackBarRyzyko10.Value;

                _dane.write(nazwaPliku);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//zapisz

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            czyZapisacZmiany();
            czysc();
            _suma0 = sumaWartosci();
            _plik = string.Empty;
            _czynnosc = (int)_enum.zamknij;
            ustawDostep();
            pokazTytul();
            tabControl1.SelectedIndex = 0;
        }//zamknijToolStripMenuItem_Click

        /// <summary>
        /// Czynności zwiazane z zapisem zmian.
        /// </summary>
        private void czyZapisacZmiany()
        {
            if (_suma0 != sumaWartosci())
            {
                if (DialogResult.Yes == MessageBox.Show(_tlumacz.zmien("Czy zapisać zmiany?"), "Rami",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (File.Exists(_plik))
                        zapisz();
                    else
                        zapiszJako();
                }
            }
        }//czyZapisacZmiany

        private void sprawdzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (!czyJestRegulacja())
            {
                MessageBox.Show(_tlumacz.zmien("Brak regulacji."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            if (!czyJestAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Brak aktywa."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            if (!czyJestWlasnosc())
            {
                MessageBox.Show(_tlumacz.zmien("Brak własności ochrony."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            if (!czyJestSzkoda())
            {
                MessageBox.Show(_tlumacz.zmien("Brak szkody."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            if (!czyJestAtak())
            {
                MessageBox.Show(_tlumacz.zmien("Brak ataku."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            if (!czyJestWykonawca())
            {
                MessageBox.Show(_tlumacz.zmien("Brak wykonawcy ataku."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }



            

            //----------------

            if (!czyRegulacja1MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Regulacja 1 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyRegulacja2MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Regulacja 2 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyRegulacja3MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Regulacja 3 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyRegulacja4MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Regulacja 4 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyRegulacja5MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Regulacja 5 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyRegulacja6MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Regulacja 6 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyRegulacja7MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Regulacja 7 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyRegulacja8MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Regulacja 8 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyRegulacja9MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Regulacja 9 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyRegulacja10MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Regulacja 10 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //----------------

            if (!czyAktywa1MaWlasnosc())
            {
                MessageBox.Show(_tlumacz.zmien("Aktywa 1 nie ma przypisanych własności ochrony."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAktywa2MaWlasnosc())
            {
                MessageBox.Show(_tlumacz.zmien("Aktywa 2 nie ma przypisanych własności ochrony."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAktywa3MaWlasnosc())
            {
                MessageBox.Show(_tlumacz.zmien("Aktywa 3 nie ma przypisanych własności ochrony."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAktywa4MaWlasnosc())
            {
                MessageBox.Show(_tlumacz.zmien("Aktywa 4 nie ma przypisanych własności ochrony."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAktywa5MaWlasnosc())
            {
                MessageBox.Show(_tlumacz.zmien("Aktywa 5 nie ma przypisanych własności ochrony."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAktywa6MaWlasnosc())
            {
                MessageBox.Show(_tlumacz.zmien("Aktywa 6 nie ma przypisanych własności ochrony."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAktywa7MaWlasnosc())
            {
                MessageBox.Show(_tlumacz.zmien("Aktywa 7 nie ma przypisanych własności ochrony."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAktywa8MaWlasnosc())
            {
                MessageBox.Show(_tlumacz.zmien("Aktywa 8 nie ma przypisanych własności ochrony."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAktywa9MaWlasnosc())
            {
                MessageBox.Show(_tlumacz.zmien("Aktywa 9 nie ma przypisanych własności ochrony."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAktywa10MaWlasnosc())
            {
                MessageBox.Show(_tlumacz.zmien("Aktywa 10 nie ma przypisanych własności ochrony."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //----------------

            if (!czyAtak1MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 1 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak2MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 2 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak3MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 3 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak4MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 4 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak5MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 5 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak6MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 6 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak7MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 7 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak8MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 8 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak9MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 9 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak10MaAktywa())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 10 nie ma przypisanych aktywów."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //----------------

            if (!czyAtak1MaZagrozenie())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 1 nie ma przypisanych zagrożeń."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak2MaZagrozenie())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 2 nie ma przypisanych zagrożeń."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak3MaZagrozenie())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 3 nie ma przypisanych zagrożeń."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak4MaZagrozenie())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 4 nie ma przypisanych zagrożeń."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak5MaZagrozenie())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 5 nie ma przypisanych zagrożeń."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak6MaZagrozenie())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 6 nie ma przypisanych zagrożeń."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak7MaZagrozenie())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 7 nie ma przypisanych zagrożeń."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak8MaZagrozenie())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 8 nie ma przypisanych zagrożeń."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak9MaZagrozenie())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 9 nie ma przypisanych zagrożeń."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak10MaZagrozenie())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 10 nie ma przypisanych zagrożeń."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //----------------

            if (!czyAtak1MaWykonawce())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 1 nie ma przypisanych wykonawców."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak2MaWykonawce())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 2 nie ma przypisanych wykonawców."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak3MaWykonawce())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 3 nie ma przypisanych wykonawców."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak4MaWykonawce())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 4 nie ma przypisanych wykonawców."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak5MaWykonawce())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 5 nie ma przypisanych wykonawców."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak6MaWykonawce())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 6 nie ma przypisanych wykonawców."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak7MaWykonawce())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 7 nie ma przypisanych wykonawców."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak8MaWykonawce())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 8 nie ma przypisanych wykonawców."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak9MaWykonawce())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 9 nie ma przypisanych wykonawców."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!czyAtak10MaWykonawce())
            {
                MessageBox.Show(_tlumacz.zmien("Atak 10 nie ma przypisanych wykonawców."), "Rami",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //----------------

            
            if (textBoxAktywa1.Text != string.Empty)
            {
                if (!czyAktywaMaRegulacje(0))
                {
                    MessageBox.Show(_tlumacz.zmien("Aktywa 1 nie występują w żadnej regulacji."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxAktywa2.Text != string.Empty)
            {
                if (!czyAktywaMaRegulacje(1))
                {
                    MessageBox.Show(_tlumacz.zmien("Aktywa 2 nie występują w żadnej regulacji."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxAktywa3.Text != string.Empty)
            {
                if (!czyAktywaMaRegulacje(2))
                {
                    MessageBox.Show(_tlumacz.zmien("Aktywa 3 nie występują w żadnej regulacji."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxAktywa4.Text != string.Empty)
            {
                if (!czyAktywaMaRegulacje(3))
                {
                    MessageBox.Show(_tlumacz.zmien("Aktywa 4 nie występują w żadnej regulacji."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxAktywa5.Text != string.Empty)
            {
                if (!czyAktywaMaRegulacje(4))
                {
                    MessageBox.Show(_tlumacz.zmien("Aktywa 5 nie występują w żadnej regulacji."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxAktywa6.Text != string.Empty)
            {
                if (!czyAktywaMaRegulacje(5))
                {
                    MessageBox.Show(_tlumacz.zmien("Aktywa 6 nie występują w żadnej regulacji."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxAktywa7.Text != string.Empty)
            {
                if (!czyAktywaMaRegulacje(6))
                {
                    MessageBox.Show(_tlumacz.zmien("Aktywa 7 nie występują w żadnej regulacji."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxAktywa8.Text != string.Empty)
            {
                if (!czyAktywaMaRegulacje(7))
                {
                    MessageBox.Show(_tlumacz.zmien("Aktywa 8 nie występują w żadnej regulacji."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxAktywa9.Text != string.Empty)
            {
                if (!czyAktywaMaRegulacje(8))
                {
                    MessageBox.Show(_tlumacz.zmien("Aktywa 9 nie występują w żadnej regulacji."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxAktywa10.Text != string.Empty)
            {
                if (!czyAktywaMaRegulacje(9))
                {
                    MessageBox.Show(_tlumacz.zmien("Aktywa 10 nie występują w żadnej regulacji."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //----------------

            if (textBoxWlasnosc1.Text != string.Empty)
            {
                if (!czyWlasnoscMaAktywa(0))
                {
                    MessageBox.Show(_tlumacz.zmien("Wlasność 1 nie występuje w żadnym aktywie."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWlasnosc2.Text != string.Empty)
            {
                if (!czyWlasnoscMaAktywa(1))
                {
                    MessageBox.Show(_tlumacz.zmien("Wlasność 2 nie występuje w żadnym aktywie."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWlasnosc3.Text != string.Empty)
            {
                if (!czyWlasnoscMaAktywa(2))
                {
                    MessageBox.Show(_tlumacz.zmien("Wlasność 3 nie występuje w żadnym aktywie."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWlasnosc4.Text != string.Empty)
            {
                if (!czyWlasnoscMaAktywa(3))
                {
                    MessageBox.Show(_tlumacz.zmien("Wlasność 4 nie występuje w żadnym aktywie."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWlasnosc5.Text != string.Empty)
            {
                if (!czyWlasnoscMaAktywa(4))
                {
                    MessageBox.Show(_tlumacz.zmien("Wlasność 5 nie występuje w żadnym aktywie."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWlasnosc6.Text != string.Empty)
            {
                if (!czyWlasnoscMaAktywa(5))
                {
                    MessageBox.Show(_tlumacz.zmien("Wlasność 6 nie występuje w żadnym aktywie."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWlasnosc7.Text != string.Empty)
            {
                if (!czyWlasnoscMaAktywa(6))
                {
                    MessageBox.Show(_tlumacz.zmien("Wlasność 7 nie występuje w żadnym aktywie."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWlasnosc8.Text != string.Empty)
            {
                if (!czyWlasnoscMaAktywa(7))
                {
                    MessageBox.Show(_tlumacz.zmien("Wlasność 8 nie występuje w żadnym aktywie."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWlasnosc9.Text != string.Empty)
            {
                if (!czyWlasnoscMaAktywa(8))
                {
                    MessageBox.Show(_tlumacz.zmien("Wlasność 9 nie występuje w żadnym aktywie."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWlasnosc10.Text != string.Empty)
            {
                if (!czyWlasnoscMaAktywa(9))
                {
                    MessageBox.Show(_tlumacz.zmien("Wlasność 10 nie występuje w żadnym aktywie."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //---------------- Nie sprawdzam czy kazde aktywa ma powiązany co najmniej jeden atak.
            

            //----------------Czy zagrożenie ma chociaż jeden atak

            if (textBoxZagrozenie1.Text != string.Empty)
            {
                if (!czyZagrozenieMaAtak(0))
                {
                    MessageBox.Show(_tlumacz.zmien("Zagrożenie 1 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxZagrozenie2.Text != string.Empty)
            {
                if (!czyZagrozenieMaAtak(1))
                {
                    MessageBox.Show(_tlumacz.zmien("Zagrożenie 2 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxZagrozenie3.Text != string.Empty)
            {
                if (!czyZagrozenieMaAtak(2))
                {
                    MessageBox.Show(_tlumacz.zmien("Zagrożenie 3 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxZagrozenie4.Text != string.Empty)
            {
                if (!czyZagrozenieMaAtak(3))
                {
                    MessageBox.Show(_tlumacz.zmien("Zagrożenie 4 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxZagrozenie5.Text != string.Empty)
            {
                if (!czyZagrozenieMaAtak(4))
                {
                    MessageBox.Show(_tlumacz.zmien("Zagrożenie 5 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxZagrozenie6.Text != string.Empty)
            {
                if (!czyZagrozenieMaAtak(5))
                {
                    MessageBox.Show(_tlumacz.zmien("Zagrożenie 6 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxZagrozenie7.Text != string.Empty)
            {
                if (!czyZagrozenieMaAtak(6))
                {
                    MessageBox.Show(_tlumacz.zmien("Zagrożenie 7 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxZagrozenie8.Text != string.Empty)
            {
                if (!czyZagrozenieMaAtak(7))
                {
                    MessageBox.Show(_tlumacz.zmien("Zagrożenie 8 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxZagrozenie9.Text != string.Empty)
            {
                if (!czyZagrozenieMaAtak(8))
                {
                    MessageBox.Show(_tlumacz.zmien("Zagrożenie 9 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxZagrozenie10.Text != string.Empty)
            {
                if (!czyZagrozenieMaAtak(9))
                {
                    MessageBox.Show(_tlumacz.zmien("Zagrożenie 10 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //----------------Czy do wykonawcy przypisano chociaż jeden atak

            if (textBoxWykonawca1.Text != string.Empty)
            {
                if (!czyWykonawcaMaAtak(0))
                {
                    MessageBox.Show(_tlumacz.zmien("Wykonawca 1 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWykonawca2.Text != string.Empty)
            {
                if (!czyWykonawcaMaAtak(1))
                {
                    MessageBox.Show(_tlumacz.zmien("Wykonawca 2 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWykonawca3.Text != string.Empty)
            {
                if (!czyWykonawcaMaAtak(2))
                {
                    MessageBox.Show(_tlumacz.zmien("Wykonawca 3 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWykonawca4.Text != string.Empty)
            {
                if (!czyWykonawcaMaAtak(3))
                {
                    MessageBox.Show(_tlumacz.zmien("Wykonawca 4 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWykonawca5.Text != string.Empty)
            {
                if (!czyWykonawcaMaAtak(4))
                {
                    MessageBox.Show(_tlumacz.zmien("Wykonawca 5 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWykonawca6.Text != string.Empty)
            {
                if (!czyWykonawcaMaAtak(5))
                {
                    MessageBox.Show(_tlumacz.zmien("Wykonawca 6 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWykonawca7.Text != string.Empty)
            {
                if (!czyWykonawcaMaAtak(6))
                {
                    MessageBox.Show(_tlumacz.zmien("Wykonawca 7 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWykonawca8.Text != string.Empty)
            {
                if (!czyWykonawcaMaAtak(7))
                {
                    MessageBox.Show(_tlumacz.zmien("Wykonawca 8 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWykonawca9.Text != string.Empty)
            {
                if (!czyWykonawcaMaAtak(8))
                {
                    MessageBox.Show(_tlumacz.zmien("Wykonawca 9 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textBoxWykonawca10.Text != string.Empty)
            {
                if (!czyWykonawcaMaAtak(9))
                {
                    MessageBox.Show(_tlumacz.zmien("Wykonawca 10 nie występuje w żadnym ataku."), "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
           
            MessageBox.Show(_tlumacz.zmien("Dane są spójne."), "Rami",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }//sprawdzToolStripMenuItem_Click

        /// <summary>
        /// Sprawdza czy dla wskazanego aktywa występuje co najmniej jedna regulacja.
        /// </summary>
        /// <param name="idx">Index aktywa.</param>
        /// <returns>Wartość logiczna sprawdzenia.</returns>
        private bool czyAktywaMaRegulacje(int idx)
        {
            return czyWybranoPozycje(checkedListBoxAktywa1, idx) |
                czyWybranoPozycje(checkedListBoxAktywa2, idx) |
                czyWybranoPozycje(checkedListBoxAktywa3, idx) |
                czyWybranoPozycje(checkedListBoxAktywa4, idx) |
                czyWybranoPozycje(checkedListBoxAktywa5, idx) |
                czyWybranoPozycje(checkedListBoxAktywa6, idx) |
                czyWybranoPozycje(checkedListBoxAktywa7, idx) |
                czyWybranoPozycje(checkedListBoxAktywa8, idx) |
                czyWybranoPozycje(checkedListBoxAktywa9, idx) |
                czyWybranoPozycje(checkedListBoxAktywa10, idx);
        }//czyAktywaMaRegulacje

        /// <summary>
        /// Sprawdza czy dla wskazanej wlasnosci występuje co najmniej jedno aktywa.
        /// </summary>
        /// <param name="idx">Index wlasnosci.</param>
        /// <returns>Wartość logiczna sprawdzenia.</returns>
        private bool czyWlasnoscMaAktywa(int idx)
        {
            return czyWybranoPozycje(checkedListBoxWlasnosc1, idx) |
                czyWybranoPozycje(checkedListBoxWlasnosc2, idx) |
                czyWybranoPozycje(checkedListBoxWlasnosc3, idx) |
                czyWybranoPozycje(checkedListBoxWlasnosc4, idx) |
                czyWybranoPozycje(checkedListBoxWlasnosc5, idx) |
                czyWybranoPozycje(checkedListBoxWlasnosc6, idx) |
                czyWybranoPozycje(checkedListBoxWlasnosc7, idx) |
                czyWybranoPozycje(checkedListBoxWlasnosc8, idx) |
                czyWybranoPozycje(checkedListBoxWlasnosc9, idx) |
                czyWybranoPozycje(checkedListBoxWlasnosc10, idx);
        }//czyWlasnoscMaAktywa

        /// <summary>
        /// Sprawdza czy dla wskazanej zagrożenia występuje co najmniej jeden atak.
        /// </summary>
        /// <param name="idx">Index zagrożenia.</param>
        /// <returns>Wartość logiczna sprawdzenia.</returns>
        private bool czyZagrozenieMaAtak(int idx)
        {
            return czyWybranoPozycje(checkedListBoxZagrozenie1, idx) |
                czyWybranoPozycje(checkedListBoxZagrozenie2, idx) |
                czyWybranoPozycje(checkedListBoxZagrozenie3, idx) |
                czyWybranoPozycje(checkedListBoxZagrozenie4, idx) |
                czyWybranoPozycje(checkedListBoxZagrozenie5, idx) |
                czyWybranoPozycje(checkedListBoxZagrozenie6, idx) |
                czyWybranoPozycje(checkedListBoxZagrozenie7, idx) |
                czyWybranoPozycje(checkedListBoxZagrozenie8, idx) |
                czyWybranoPozycje(checkedListBoxZagrozenie9, idx) |
                czyWybranoPozycje(checkedListBoxZagrozenie10, idx);
        }//czyZagrozenieMaAtak

        /// <summary>
        /// Sprawdza czy dla wskazanego wykonawcy występuje co najmniej jeden atak.
        /// </summary>
        /// <param name="idx">Index wykonawcy.</param>
        /// <returns>Wartość logiczna sprawdzenia.</returns>
        private bool czyWykonawcaMaAtak(int idx)
        {
            return czyWybranoPozycje(checkedListBoxWykonawca1, idx) |
                czyWybranoPozycje(checkedListBoxWykonawca2, idx) |
                czyWybranoPozycje(checkedListBoxWykonawca3, idx) |
                czyWybranoPozycje(checkedListBoxWykonawca4, idx) |
                czyWybranoPozycje(checkedListBoxWykonawca5, idx) |
                czyWybranoPozycje(checkedListBoxWykonawca6, idx) |
                czyWybranoPozycje(checkedListBoxWykonawca7, idx) |
                czyWybranoPozycje(checkedListBoxWykonawca8, idx) |
                czyWybranoPozycje(checkedListBoxWykonawca9, idx) |
                czyWybranoPozycje(checkedListBoxWykonawca10, idx);
        }//czyWykonawcaMaAtak

        /// <summary>
        /// Sprawdza czy we wskazanych CheckedListBox i na jej pozycji dokonano wyboru.
        /// </summary>
        /// <param name="clb">CheckedListBox.</param>
        /// <param name="idx">Indeks pozycji.</param>
        /// <returns>Wynik sprawdzenia.</returns>
        private bool czyWybranoPozycje(CheckedListBox clb, int idx)
        {
            if (clb.GetItemText(clb.Items[idx]) == string.Empty) return true;
            else
                return clb.GetItemChecked(idx);
        }//czyWybranoPozycje

        /// <summary>
        /// Sprawdza czy istnieje chociaż jedna regulacja.
        /// </summary>
        /// <returns>Wartość logiczna sprawdzenia.</returns>
        private bool czyJestRegulacja()
        {
            if (textBoxRegulacja1.Text != string.Empty) return true;
            if (textBoxRegulacja2.Text != string.Empty) return true;
            if (textBoxRegulacja3.Text != string.Empty) return true;
            if (textBoxRegulacja4.Text != string.Empty) return true;
            if (textBoxRegulacja5.Text != string.Empty) return true;
            if (textBoxRegulacja6.Text != string.Empty) return true;
            if (textBoxRegulacja7.Text != string.Empty) return true;
            if (textBoxRegulacja8.Text != string.Empty) return true;
            if (textBoxRegulacja9.Text != string.Empty) return true;
            if (textBoxRegulacja10.Text != string.Empty) return true;
            return false;
        }//czyJestRegulacja

        /// <summary>
        /// Sprawdza czy istnieje chociaż jedno aktywa.
        /// </summary>
        /// <returns>Wartość logiczna sprawdzenia.</returns>
        private bool czyJestAktywa()
        {
            if (textBoxAktywa1.Text != string.Empty) return true;
            if (textBoxAktywa2.Text != string.Empty) return true;
            if (textBoxAktywa3.Text != string.Empty) return true;
            if (textBoxAktywa4.Text != string.Empty) return true;
            if (textBoxAktywa5.Text != string.Empty) return true;
            if (textBoxAktywa6.Text != string.Empty) return true;
            if (textBoxAktywa7.Text != string.Empty) return true;
            if (textBoxAktywa8.Text != string.Empty) return true;
            if (textBoxAktywa9.Text != string.Empty) return true;
            if (textBoxAktywa10.Text != string.Empty) return true;
            return false;
        }//czyJestAktywa

        /// <summary>
        /// Sprawdza czy istnieje chociaż jedna własność ochrony.
        /// </summary>
        /// <returns>Wartość logiczna sprawdzenia.</returns>
        private bool czyJestWlasnosc()
        {
            if (textBoxWlasnosc1.Text != string.Empty) return true;
            if (textBoxWlasnosc2.Text != string.Empty) return true;
            if (textBoxWlasnosc3.Text != string.Empty) return true;
            if (textBoxWlasnosc4.Text != string.Empty) return true;
            if (textBoxWlasnosc5.Text != string.Empty) return true;
            if (textBoxWlasnosc6.Text != string.Empty) return true;
            if (textBoxWlasnosc7.Text != string.Empty) return true;
            if (textBoxWlasnosc8.Text != string.Empty) return true;
            if (textBoxWlasnosc9.Text != string.Empty) return true;
            if (textBoxWlasnosc10.Text != string.Empty) return true;
            return false;
        }//czyJestWlasnosc

        /// <summary>
        /// Sprawdza czy istnieje chociaż jedna szkoda.
        /// </summary>
        /// <returns>Wartość logiczna sprawdzenia.</returns>
        private bool czyJestSzkoda()
        {
            if (textBoxZagrozenie1.Text != string.Empty) return true;
            if (textBoxZagrozenie2.Text != string.Empty) return true;
            if (textBoxZagrozenie3.Text != string.Empty) return true;
            if (textBoxZagrozenie4.Text != string.Empty) return true;
            if (textBoxZagrozenie5.Text != string.Empty) return true;
            if (textBoxZagrozenie6.Text != string.Empty) return true;
            if (textBoxZagrozenie7.Text != string.Empty) return true;
            if (textBoxZagrozenie8.Text != string.Empty) return true;
            if (textBoxZagrozenie9.Text != string.Empty) return true;
            if (textBoxZagrozenie10.Text != string.Empty) return true;
            return false;
        }//czyJestSzkoda

        /// <summary>
        /// Sprawdza czy istnieje chociaż jeden atak.
        /// </summary>
        /// <returns>Wartość logiczna sprawdzenia.</returns>
        private bool czyJestAtak()
        {
            if (textBoxAtak1.Text != string.Empty) return true;
            if (textBoxAtak2.Text != string.Empty) return true;
            if (textBoxAtak3.Text != string.Empty) return true;
            if (textBoxAtak4.Text != string.Empty) return true;
            if (textBoxAtak5.Text != string.Empty) return true;
            if (textBoxAtak6.Text != string.Empty) return true;
            if (textBoxAtak7.Text != string.Empty) return true;
            if (textBoxAtak8.Text != string.Empty) return true;
            if (textBoxAtak9.Text != string.Empty) return true;
            if (textBoxAtak10.Text != string.Empty) return true;

            return false;
        }//czyJestAtak


        /// <summary>
        /// Sprawdza czy istnieje chociaż jeden wykonawca.
        /// </summary>
        /// <returns>Wartość logiczna sprawdzenia.</returns>
        private bool czyJestWykonawca()
        {
            if (textBoxWykonawca1.Text != string.Empty) return true;
            if (textBoxWykonawca2.Text != string.Empty) return true;
            if (textBoxWykonawca3.Text != string.Empty) return true;
            if (textBoxWykonawca4.Text != string.Empty) return true;
            if (textBoxWykonawca5.Text != string.Empty) return true;
            if (textBoxWykonawca6.Text != string.Empty) return true;
            if (textBoxWykonawca7.Text != string.Empty) return true;
            if (textBoxWykonawca8.Text != string.Empty) return true;
            if (textBoxWykonawca9.Text != string.Empty) return true;
            if (textBoxWykonawca10.Text != string.Empty) return true;

            return false;
        }//czyJestWykonawca

        /// <summary>
        /// Sprawdza czy regulacja 1 jest niepusta i ma aktywa.
        /// </summary>
        private bool czyRegulacja1MaAktywa()
        {
            if (textBoxRegulacja1.Text != string.Empty)
            {
                return checkedListBoxAktywa1.CheckedItems.Count > 0;
            }
            return true;
        }//czyRegulacja1MaAktywa

        /// <summary>
        /// Sprawdza czy regulacja 2 jest niepusta i ma aktywa.
        /// </summary>
        private bool czyRegulacja2MaAktywa()
        {
            if (textBoxRegulacja2.Text != string.Empty)
            {
                return checkedListBoxAktywa2.CheckedItems.Count > 0;
            }
            return true;
        }//czyRegulacja2MaAktywa

        /// <summary>
        /// Sprawdza czy regulacja 3 jest niepusta i ma aktywa.
        /// </summary>
        private bool czyRegulacja3MaAktywa()
        {
            if (textBoxRegulacja3.Text != string.Empty)
            {
                return checkedListBoxAktywa3.CheckedItems.Count > 0;
            }
            return true;
        }//czyRegulacja3MaAktywa

        /// <summary>
        /// Sprawdza czy regulacja 4 jest niepusta i ma aktywa.
        /// </summary>
        private bool czyRegulacja4MaAktywa()
        {
            if (textBoxRegulacja4.Text != string.Empty)
            {
                return checkedListBoxAktywa4.CheckedItems.Count > 0;
            }
            return true;
        }//czyRegulacja4MaAktywa

        /// <summary>
        /// Sprawdza czy regulacja 5 jest niepusta i ma aktywa.
        /// </summary>
        private bool czyRegulacja5MaAktywa()
        {
            if (textBoxRegulacja5.Text != string.Empty)
            {
                return checkedListBoxAktywa5.CheckedItems.Count > 0;
            }
            return true;
        }//czyRegulacja5MaAktywa

        /// <summary>
        /// Sprawdza czy regulacja 6 jest niepusta i ma aktywa.
        /// </summary>
        private bool czyRegulacja6MaAktywa()
        {
            if (textBoxRegulacja6.Text != string.Empty)
            {
                return checkedListBoxAktywa6.CheckedItems.Count > 0;
            }
            return true;
        }//czyRegulacja6MaAktywa

        /// <summary>
        /// Sprawdza czy regulacja 7 jest niepusta i ma aktywa.
        /// </summary>
        private bool czyRegulacja7MaAktywa()
        {
            if (textBoxRegulacja7.Text != string.Empty)
            {
                return checkedListBoxAktywa7.CheckedItems.Count > 0;
            }
            return true;
        }//czyRegulacja7MaAktywa

        /// <summary>
        /// Sprawdza czy regulacja 8 jest niepusta i ma aktywa.
        /// </summary>
        private bool czyRegulacja8MaAktywa()
        {
            if (textBoxRegulacja8.Text != string.Empty)
            {
                return checkedListBoxAktywa8.CheckedItems.Count > 0;
            }
            return true;
        }//czyRegulacja8MaAktywa

        /// <summary>
        /// Sprawdza czy regulacja 9 jest niepusta i ma aktywa.
        /// </summary>
        private bool czyRegulacja9MaAktywa()
        {
            if (textBoxRegulacja9.Text != string.Empty)
            {
                return checkedListBoxAktywa9.CheckedItems.Count > 0;
            }
            return true;
        }//czyRegulacja9MaAktywa


        /// <summary>
        /// Sprawdza czy regulacja 10 jest niepusta i ma aktywa.
        /// </summary>
        private bool czyRegulacja10MaAktywa()
        {
            if (textBoxRegulacja10.Text != string.Empty)
            {
                return checkedListBoxAktywa10.CheckedItems.Count > 0;
            }
            return true;
        }//czyRegulacja10MaAktywa

        //--------------------------

        /// <summary>
        /// Sprawdza czy aktywa 1 jest niepusta i ma własnosc ochrony.
        /// </summary>
        private bool czyAktywa1MaWlasnosc()
        {
            if (textBoxAktywa1.Text != string.Empty)
            {
                return checkedListBoxWlasnosc1.CheckedItems.Count > 0;
            }
            return true;
        }//czyAktywa1MaWlasnosc

        /// <summary>
        /// Sprawdza czy aktywa 2 jest niepusta i ma własnosc ochrony.
        /// </summary>
        private bool czyAktywa2MaWlasnosc()
        {
            if (textBoxAktywa2.Text != string.Empty)
            {
                return checkedListBoxWlasnosc2.CheckedItems.Count > 0;
            }
            return true;
        }//czyAktywa2MaWlasnosc

        /// <summary>
        /// Sprawdza czy aktywa 3 jest niepusta i ma własnosc ochrony.
        /// </summary>
        private bool czyAktywa3MaWlasnosc()
        {
            if (textBoxAktywa3.Text != string.Empty)
            {
                return checkedListBoxWlasnosc3.CheckedItems.Count > 0;
            }
            return true;
        }//czyAktywa3MaWlasnosc

        /// <summary>
        /// Sprawdza czy aktywa 4 jest niepusta i ma własnosc ochrony.
        /// </summary>
        private bool czyAktywa4MaWlasnosc()
        {
            if (textBoxAktywa4.Text != string.Empty)
            {
                return checkedListBoxWlasnosc4.CheckedItems.Count > 0;
            }
            return true;
        }//czyAktywa4MaWlasnosc

        /// <summary>
        /// Sprawdza czy aktywa 5 jest niepusta i ma własnosc ochrony.
        /// </summary>
        private bool czyAktywa5MaWlasnosc()
        {
            if (textBoxAktywa5.Text != string.Empty)
            {
                return checkedListBoxWlasnosc5.CheckedItems.Count > 0;
            }
            return true;
        }//czyAktywa5MaWlasnosc

        /// <summary>
        /// Sprawdza czy aktywa 6 jest niepusta i ma własnosc ochrony.
        /// </summary>
        private bool czyAktywa6MaWlasnosc()
        {
            if (textBoxAktywa6.Text != string.Empty)
            {
                return checkedListBoxWlasnosc6.CheckedItems.Count > 0;
            }
            return true;
        }//czyAktywa6MaWlasnosc

        /// <summary>
        /// Sprawdza czy aktywa 7 jest niepusta i ma własnosc ochrony.
        /// </summary>
        private bool czyAktywa7MaWlasnosc()
        {
            if (textBoxAktywa7.Text != string.Empty)
            {
                return checkedListBoxWlasnosc7.CheckedItems.Count > 0;
            }
            return true;
        }//czyAktywa7MaWlasnosc

        /// <summary>
        /// Sprawdza czy aktywa 8 jest niepusta i ma własnosc ochrony.
        /// </summary>
        private bool czyAktywa8MaWlasnosc()
        {
            if (textBoxAktywa8.Text != string.Empty)
            {
                return checkedListBoxWlasnosc8.CheckedItems.Count > 0;
            }
            return true;
        }//czyAktywa8MaWlasnosc

        /// <summary>
        /// Sprawdza czy aktywa 9 jest niepusta i ma własnosc ochrony.
        /// </summary>
        private bool czyAktywa9MaWlasnosc()
        {
            if (textBoxAktywa9.Text != string.Empty)
            {
                return checkedListBoxWlasnosc9.CheckedItems.Count > 0;
            }
            return true;
        }//czyAktywa9MaWlasnosc

        /// <summary>
        /// Sprawdza czy aktywa 10 jest niepusta i ma własnosc ochrony.
        /// </summary>
        private bool czyAktywa10MaWlasnosc()
        {
            if (textBoxAktywa10.Text != string.Empty)
            {
                return checkedListBoxWlasnosc10.CheckedItems.Count > 0;
            }
            return true;
        }//czyAktywa10MaWlasnosc

        /// <summary>
        /// Sprawdza czy atak 1 jest niepusty i ma aktywa.
        /// </summary>
        private bool czyAtak1MaAktywa()
        {
            if (textBoxAtak1.Text != string.Empty)
            {
                return checkedListBoxAktywa11.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak1MaAktywa

        /// <summary>
        /// Sprawdza czy atak 2 jest niepusty i ma aktywa.
        /// </summary>
        private bool czyAtak2MaAktywa()
        {
            if (textBoxAtak2.Text != string.Empty)
            {
                return checkedListBoxAktywa12.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak2MaAktywa

        /// <summary>
        /// Sprawdza czy atak 2 jest niepusty i ma aktywa.
        /// </summary>
        private bool czyAtak3MaAktywa()
        {
            if (textBoxAtak3.Text != string.Empty)
            {
                return checkedListBoxAktywa13.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak3MaAktywa

        /// <summary>
        /// Sprawdza czy atak 4 jest niepusty i ma aktywa.
        /// </summary>
        private bool czyAtak4MaAktywa()
        {
            if (textBoxAtak4.Text != string.Empty)
            {
                return checkedListBoxAktywa14.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak4MaAktywa

        /// <summary>
        /// Sprawdza czy atak 5 jest niepusty i ma aktywa.
        /// </summary>
        private bool czyAtak5MaAktywa()
        {
            if (textBoxAtak5.Text != string.Empty)
            {
                return checkedListBoxAktywa15.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak5MaAktywa

        /// <summary>
        /// Sprawdza czy atak 6 jest niepusty i ma aktywa.
        /// </summary>
        private bool czyAtak6MaAktywa()
        {
            if (textBoxAtak6.Text != string.Empty)
            {
                return checkedListBoxAktywa16.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak6MaAktywa

        /// <summary>
        /// Sprawdza czy atak 7 jest niepusty i ma aktywa.
        /// </summary>
        private bool czyAtak7MaAktywa()
        {
            if (textBoxAtak7.Text != string.Empty)
            {
                return checkedListBoxAktywa17.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak7MaAktywa

        /// <summary>
        /// Sprawdza czy atak 8 jest niepusty i ma aktywa.
        /// </summary>
        private bool czyAtak8MaAktywa()
        {
            if (textBoxAtak8.Text != string.Empty)
            {
                return checkedListBoxAktywa18.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak8MaAktywa

        /// <summary>
        /// Sprawdza czy atak 9 jest niepusty i ma aktywa.
        /// </summary>
        private bool czyAtak9MaAktywa()
        {
            if (textBoxAtak9.Text != string.Empty)
            {
                return checkedListBoxAktywa19.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak9MaAktywa

        /// <summary>
        /// Sprawdza czy atak 10jest niepusty i ma aktywa.
        /// </summary>
        private bool czyAtak10MaAktywa()
        {
            if (textBoxAtak10.Text != string.Empty)
            {
                return checkedListBoxAktywa110.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak10MaAktywa

        /// <summary>
        /// Sprawdza czy atak 1 jest niepusty i ma powiązane zgrożenie.
        /// </summary>
        private bool czyAtak1MaZagrozenie()
        {
            if (textBoxAtak1.Text != string.Empty)
            {
                return checkedListBoxZagrozenie1.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak1MaSzkody

        /// <summary>
        /// Sprawdza czy atak 2 jest niepusty i ma powiązane zgrożenie.
        /// </summary>
        private bool czyAtak2MaZagrozenie()
        {
            if (textBoxAtak2.Text != string.Empty)
            {
                return checkedListBoxZagrozenie2.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak2MaSzkody

        /// <summary>
        /// Sprawdza czy atak 3 jest niepusty i ma powiązane zgrożenie.
        /// </summary>
        private bool czyAtak3MaZagrozenie()
        {
            if (textBoxAtak3.Text != string.Empty)
            {
                return checkedListBoxZagrozenie3.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak3MaSzkody

        /// <summary>
        /// Sprawdza czy atak 4 jest niepusty i ma powiązane zgrożenie.
        /// </summary>
        private bool czyAtak4MaZagrozenie()
        {
            if (textBoxAtak4.Text != string.Empty)
            {
                return checkedListBoxZagrozenie4.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak4MaSzkody

        /// <summary>
        /// Sprawdza czy atak 5 jest niepusty i ma powiązane zgrożenie.
        /// </summary>
        private bool czyAtak5MaZagrozenie()
        {
            if (textBoxAtak5.Text != string.Empty)
            {
                return checkedListBoxZagrozenie5.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak5MaSzkody

        /// <summary>
        /// Sprawdza czy atak 6 jest niepusty i ma powiązane zgrożenie.
        /// </summary>
        private bool czyAtak6MaZagrozenie()
        {
            if (textBoxAtak6.Text != string.Empty)
            {
                return checkedListBoxZagrozenie6.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak6MaSzkody

        /// <summary>
        /// Sprawdza czy atak 7 jest niepusty i ma powiązane zgrożenie.
        /// </summary>
        private bool czyAtak7MaZagrozenie()
        {
            if (textBoxAtak7.Text != string.Empty)
            {
                return checkedListBoxZagrozenie7.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak7MaSzkody

        /// <summary>
        /// Sprawdza czy atak 8 jest niepusty i ma powiązane zgrożenie.
        /// </summary>
        private bool czyAtak8MaZagrozenie()
        {
            if (textBoxAtak8.Text != string.Empty)
            {
                return checkedListBoxZagrozenie8.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak8MaSzkody

        /// <summary>
        /// Sprawdza czy atak 9 jest niepusty i ma powiązane zgrożenie.
        /// </summary>
        private bool czyAtak9MaZagrozenie()
        {
            if (textBoxAtak9.Text != string.Empty)
            {
                return checkedListBoxZagrozenie9.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak9MaSzkody

        /// <summary>
        /// Sprawdza czy atak 10 jest niepusty i ma powiązane zgrożenie.
        /// </summary>
        private bool czyAtak10MaZagrozenie()
        {
            if (textBoxAtak10.Text != string.Empty)
            {
                return checkedListBoxZagrozenie10.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak10MaSzkody

        /// <summary>
        /// Sprawdza czy atak 1 jest niepusty i ma przypisanego wykonawcę.
        /// </summary>
        private bool czyAtak1MaWykonawce()
        {
            if (textBoxAtak1.Text != string.Empty)
            {
                return checkedListBoxWykonawca1.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak1MaWykonawce

        /// <summary>
        /// Sprawdza czy atak 2 jest niepusty i ma przypisanego wykonawcę.
        /// </summary>
        private bool czyAtak2MaWykonawce()
        {
            if (textBoxAtak2.Text != string.Empty)
            {
                return checkedListBoxWykonawca2.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak2MaWykonawce

        /// <summary>
        /// Sprawdza czy atak 3 jest niepusty i ma przypisanego wykonawcę.
        /// </summary>
        private bool czyAtak3MaWykonawce()
        {
            if (textBoxAtak3.Text != string.Empty)
            {
                return checkedListBoxWykonawca3.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak3MaWykonawce

        /// <summary>
        /// Sprawdza czy atak 4 jest niepusty i ma przypisanego wykonawcę.
        /// </summary>
        private bool czyAtak4MaWykonawce()
        {
            if (textBoxAtak4.Text != string.Empty)
            {
                return checkedListBoxWykonawca4.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak4MaWykonawce

        /// <summary>
        /// Sprawdza czy atak 5 jest niepusty i ma przypisanego wykonawcę.
        /// </summary>
        private bool czyAtak5MaWykonawce()
        {
            if (textBoxAtak5.Text != string.Empty)
            {
                return checkedListBoxWykonawca5.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak5MaWykonawce

        /// <summary>
        /// Sprawdza czy atak 6 jest niepusty i ma przypisanego wykonawcę.
        /// </summary>
        private bool czyAtak6MaWykonawce()
        {
            if (textBoxAtak6.Text != string.Empty)
            {
                return checkedListBoxWykonawca6.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak6MaWykonawce

        /// <summary>
        /// Sprawdza czy atak 7 jest niepusty i ma przypisanego wykonawcę.
        /// </summary>
        private bool czyAtak7MaWykonawce()
        {
            if (textBoxAtak7.Text != string.Empty)
            {
                return checkedListBoxWykonawca7.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak7MaWykonawce

        /// <summary>
        /// Sprawdza czy atak 8 jest niepusty i ma przypisanego wykonawcę.
        /// </summary>
        private bool czyAtak8MaWykonawce()
        {
            if (textBoxAtak8.Text != string.Empty)
            {
                return checkedListBoxWykonawca8.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak8MaWykonawce

        /// <summary>
        /// Sprawdza czy atak 9 jest niepusty i ma przypisanego wykonawcę.
        /// </summary>
        private bool czyAtak9MaWykonawce()
        {
            if (textBoxAtak9.Text != string.Empty)
            {
                return checkedListBoxWykonawca9.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak9MaWykonawce

        /// <summary>
        /// Sprawdza czy atak 10 jest niepusty i ma przypisanego wykonawcę.
        /// </summary>
        private bool czyAtak10MaWykonawce()
        {
            if (textBoxAtak1.Text != string.Empty)
            {
                return checkedListBoxWykonawca10.CheckedItems.Count > 0;
            }
            return true;
        }//czyAtak10MaWykonawce

        private void FormRami_FormClosing(object sender, FormClosingEventArgs e)
        {
            czyZapisacZmiany();
        }//FormRami_FormClosing

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FormAbout(Application.StartupPath + "\\BI.png");
            frm.ShowDialog();
            frm.Dispose();
        }//oProgramieToolStripMenuItem_Click

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            aktualizuj();
        }//tabControl1_SelectedIndexChanged


       // wybór języka pomocy 

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripComboBoxJezyk.SelectedIndex == 0)
            {
                if (File.Exists(_helpFile))
                {
                    Help.ShowHelp(this, _helpFile);
                }
                else
                {
                    MessageBox.Show("Plik pomocy RamiHelp.chm nie istnieje w katalogu Rami.", "Rami",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else 
            {
                if (File.Exists(_helpFileA))
                {
                    Help.ShowHelp(this, _helpFileA);
                }
                else
                {
                    MessageBox.Show("Plik pomocy RamiHelpA.chm nie istnieje w katalogu Rami.", "Rami",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }//pomocToolStripMenuItem_Click

        private void toolStripComboBoxJezyk_SelectedIndexChanged(object sender, EventArgs e)
        {

            //_tlumacz.ustawAng = true;
            //return;

            if (toolStripComboBoxJezyk.SelectedIndex == 0)
            {
                _tlumacz.ustawAng = false;
                ustawPodpowiedzi();
                ustawWlasnosci();
                aktualizuj();// dodaje check-boxy
                


                pokazParametryRyzyka1();
                pokazParametryRyzyka2();
                pokazParametryRyzyka3();
                pokazParametryRyzyka4();
                pokazParametryRyzyka5();
                pokazParametryRyzyka6();
                pokazParametryRyzyka7();
                pokazParametryRyzyka8();
                pokazParametryRyzyka9();
                pokazParametryRyzyka10();

                labelWplyw1.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw1.Value.ToString();
                labelWplyw2.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw2.Value.ToString();
                labelWplyw3.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw3.Value.ToString();
                labelWplyw4.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw4.Value.ToString();
                labelWplyw5.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw5.Value.ToString();
                labelWplyw6.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw6.Value.ToString();
                labelWplyw7.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw7.Value.ToString();
                labelWplyw8.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw8.Value.ToString();
                labelWplyw9.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw9.Value.ToString();
               labelWplyw10.Text = _tlumacz.zmien("Wpływ: ") + trackBarWplyw10.Value.ToString();

            }
            if (toolStripComboBoxJezyk.SelectedIndex == 1)
            {
                _tlumacz.ustawAng = true;
                ustawPodpowiedzi();
                ustawWlasnosci();
                aktualizuj();// dodaje check-boxy
               

                pokazParametryRyzyka1();
                pokazParametryRyzyka1();
                pokazParametryRyzyka2();
                pokazParametryRyzyka3();
                pokazParametryRyzyka4();
                pokazParametryRyzyka5();
                pokazParametryRyzyka6();
                pokazParametryRyzyka7();
                pokazParametryRyzyka8();
                pokazParametryRyzyka9();
                pokazParametryRyzyka10();
                
                labelWplyw1.Text = _tlumacz.zmien("Impact: ") + trackBarWplyw1.Value.ToString();
                labelWplyw2.Text = _tlumacz.zmien("Impact: ") + trackBarWplyw2.Value.ToString();
                labelWplyw3.Text = _tlumacz.zmien("Impact: ") + trackBarWplyw3.Value.ToString();
                labelWplyw4.Text = _tlumacz.zmien("Impact: ") + trackBarWplyw4.Value.ToString();
                labelWplyw5.Text = _tlumacz.zmien("Impact: ") + trackBarWplyw5.Value.ToString();
                labelWplyw6.Text = _tlumacz.zmien("Impact: ") + trackBarWplyw6.Value.ToString();
                labelWplyw7.Text = _tlumacz.zmien("Impact: ") + trackBarWplyw7.Value.ToString();
                labelWplyw8.Text = _tlumacz.zmien("Impact: ") + trackBarWplyw8.Value.ToString();
                labelWplyw9.Text = _tlumacz.zmien("Impact: ") + trackBarWplyw9.Value.ToString();
                labelWplyw10.Text = _tlumacz.zmien("Impact: ") + trackBarWplyw10.Value.ToString();

                //MessageBox.Show("Zmiana wersji językowej widoczna będzie po ponownym uruchomieniu Rami.", "Rami", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zapisz();
        }

    }//class FormRami : Form

}//namespace Rami
