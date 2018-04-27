using System;
using System.Xml;

namespace nsDane
{
    public class dane
    {
        private string _fileName = string.Empty;

<<<<<<< HEAD
        public bool _isEn = false;

=======
>>>>>>> 0412c3c6613d615f52418e74019f13b8b3dcb13a
        public string _nazwa = string.Empty;
        public string _opis = string.Empty;

        //---------------------słowniki
        public string _regulacja1 = string.Empty;
        public string _regulacja2 = string.Empty;
        public string _regulacja3 = string.Empty;
        public string _regulacja4 = string.Empty;
        public string _regulacja5 = string.Empty;
        public string _regulacja6 = string.Empty;
        public string _regulacja7 = string.Empty;
        public string _regulacja8 = string.Empty;
        public string _regulacja9 = string.Empty;
        public string _regulacja10 = string.Empty;

        public int _wplyw1 = 1;
        public int _wplyw2 = 1;
        public int _wplyw3 = 1;
        public int _wplyw4 = 1;
        public int _wplyw5 = 1;
        public int _wplyw6 = 1;
        public int _wplyw7 = 1;
        public int _wplyw8 = 1;
        public int _wplyw9 = 1;
        public int _wplyw10 = 1;

        public string _aktywa1 = string.Empty;
        public string _aktywa2 = string.Empty;
        public string _aktywa3 = string.Empty;
        public string _aktywa4 = string.Empty;
        public string _aktywa5 = string.Empty;
        public string _aktywa6 = string.Empty;
        public string _aktywa7 = string.Empty;
        public string _aktywa8 = string.Empty;
        public string _aktywa9 = string.Empty;
        public string _aktywa10 = string.Empty;

        public string _wlasnosc1 = string.Empty;
        public string _wlasnosc2 = string.Empty;
        public string _wlasnosc3 = string.Empty;
        public string _wlasnosc4 = string.Empty;
        public string _wlasnosc5 = string.Empty;
        public string _wlasnosc6 = string.Empty;
        public string _wlasnosc7 = string.Empty;
        public string _wlasnosc8 = string.Empty;
        public string _wlasnosc9 = string.Empty;
        public string _wlasnosc10 = string.Empty;

        public string _szkoda1 = string.Empty;
        public string _szkoda2 = string.Empty;
        public string _szkoda3 = string.Empty;
        public string _szkoda4 = string.Empty;
        public string _szkoda5 = string.Empty;
        public string _szkoda6 = string.Empty;
        public string _szkoda7 = string.Empty;
        public string _szkoda8 = string.Empty;
        public string _szkoda9 = string.Empty;
        public string _szkoda10 = string.Empty;

        public string _atak1 = string.Empty;
        public string _atak2 = string.Empty;
        public string _atak3 = string.Empty;
        public string _atak4 = string.Empty;
        public string _atak5 = string.Empty;
        public string _atak6 = string.Empty;
        public string _atak7 = string.Empty;
        public string _atak8 = string.Empty;
        public string _atak9 = string.Empty;
        public string _atak10 = string.Empty;

        public string _wykonawca1 = string.Empty;
        public string _wykonawca2 = string.Empty;
        public string _wykonawca3 = string.Empty;
        public string _wykonawca4 = string.Empty;
        public string _wykonawca5 = string.Empty;
        public string _wykonawca6 = string.Empty;
        public string _wykonawca7 = string.Empty;
        public string _wykonawca8 = string.Empty;
        public string _wykonawca9 = string.Empty;
        public string _wykonawca10 = string.Empty;

        //------------------Relacje
        public bool _regulacja1_aktywa1 = false;
        public bool _regulacja1_aktywa2 = false;
        public bool _regulacja1_aktywa3 = false;
        public bool _regulacja1_aktywa4 = false;
        public bool _regulacja1_aktywa5 = false;
        public bool _regulacja1_aktywa6 = false;
        public bool _regulacja1_aktywa7 = false;
        public bool _regulacja1_aktywa8 = false;
        public bool _regulacja1_aktywa9 = false;
        public bool _regulacja1_aktywa10 = false;

        public bool _regulacja2_aktywa1 = false;
        public bool _regulacja2_aktywa2 = false;
        public bool _regulacja2_aktywa3 = false;
        public bool _regulacja2_aktywa4 = false;
        public bool _regulacja2_aktywa5 = false;
        public bool _regulacja2_aktywa6 = false;
        public bool _regulacja2_aktywa7 = false;
        public bool _regulacja2_aktywa8 = false;
        public bool _regulacja2_aktywa9 = false;
        public bool _regulacja2_aktywa10 = false;

        public bool _regulacja3_aktywa1 = false;
        public bool _regulacja3_aktywa2 = false;
        public bool _regulacja3_aktywa3 = false;
        public bool _regulacja3_aktywa4 = false;
        public bool _regulacja3_aktywa5 = false;
        public bool _regulacja3_aktywa6 = false;
        public bool _regulacja3_aktywa7 = false;
        public bool _regulacja3_aktywa8 = false;
        public bool _regulacja3_aktywa9 = false;
        public bool _regulacja3_aktywa10 = false;

        public bool _regulacja4_aktywa1 = false;
        public bool _regulacja4_aktywa2 = false;
        public bool _regulacja4_aktywa3 = false;
        public bool _regulacja4_aktywa4 = false;
        public bool _regulacja4_aktywa5 = false;
        public bool _regulacja4_aktywa6 = false;
        public bool _regulacja4_aktywa7 = false;
        public bool _regulacja4_aktywa8 = false;
        public bool _regulacja4_aktywa9 = false;
        public bool _regulacja4_aktywa10 = false;

        public bool _regulacja5_aktywa1 = false;
        public bool _regulacja5_aktywa2 = false;
        public bool _regulacja5_aktywa3 = false;
        public bool _regulacja5_aktywa4 = false;
        public bool _regulacja5_aktywa5 = false;
        public bool _regulacja5_aktywa6 = false;
        public bool _regulacja5_aktywa7 = false;
        public bool _regulacja5_aktywa8 = false;
        public bool _regulacja5_aktywa9 = false;
        public bool _regulacja5_aktywa10 = false;

        public bool _regulacja6_aktywa1 = false;
        public bool _regulacja6_aktywa2 = false;
        public bool _regulacja6_aktywa3 = false;
        public bool _regulacja6_aktywa4 = false;
        public bool _regulacja6_aktywa5 = false;
        public bool _regulacja6_aktywa6 = false;
        public bool _regulacja6_aktywa7 = false;
        public bool _regulacja6_aktywa8 = false;
        public bool _regulacja6_aktywa9 = false;
        public bool _regulacja6_aktywa10 = false;

        public bool _regulacja7_aktywa1 = false;
        public bool _regulacja7_aktywa2 = false;
        public bool _regulacja7_aktywa3 = false;
        public bool _regulacja7_aktywa4 = false;
        public bool _regulacja7_aktywa5 = false;
        public bool _regulacja7_aktywa6 = false;
        public bool _regulacja7_aktywa7 = false;
        public bool _regulacja7_aktywa8 = false;
        public bool _regulacja7_aktywa9 = false;
        public bool _regulacja7_aktywa10 = false;

        public bool _regulacja8_aktywa1 = false;
        public bool _regulacja8_aktywa2 = false;
        public bool _regulacja8_aktywa3 = false;
        public bool _regulacja8_aktywa4 = false;
        public bool _regulacja8_aktywa5 = false;
        public bool _regulacja8_aktywa6 = false;
        public bool _regulacja8_aktywa7 = false;
        public bool _regulacja8_aktywa8 = false;
        public bool _regulacja8_aktywa9 = false;
        public bool _regulacja8_aktywa10 = false;

        public bool _regulacja9_aktywa1 = false;
        public bool _regulacja9_aktywa2 = false;
        public bool _regulacja9_aktywa3 = false;
        public bool _regulacja9_aktywa4 = false;
        public bool _regulacja9_aktywa5 = false;
        public bool _regulacja9_aktywa6 = false;
        public bool _regulacja9_aktywa7 = false;
        public bool _regulacja9_aktywa8 = false;
        public bool _regulacja9_aktywa9 = false;
        public bool _regulacja9_aktywa10 = false;

        public bool _regulacja10_aktywa1 = false;
        public bool _regulacja10_aktywa2 = false;
        public bool _regulacja10_aktywa3 = false;
        public bool _regulacja10_aktywa4 = false;
        public bool _regulacja10_aktywa5 = false;
        public bool _regulacja10_aktywa6 = false;
        public bool _regulacja10_aktywa7 = false;
        public bool _regulacja10_aktywa8 = false;
        public bool _regulacja10_aktywa9 = false;
        public bool _regulacja10_aktywa10 = false;

        //------------------
        public bool _aktywa1_wlasnosc1 = false;
        public bool _aktywa1_wlasnosc2 = false;
        public bool _aktywa1_wlasnosc3 = false;
        public bool _aktywa1_wlasnosc4 = false;
        public bool _aktywa1_wlasnosc5 = false;
        public bool _aktywa1_wlasnosc6 = false;
        public bool _aktywa1_wlasnosc7 = false;
        public bool _aktywa1_wlasnosc8 = false;
        public bool _aktywa1_wlasnosc9 = false;
        public bool _aktywa1_wlasnosc10 = false;

        public bool _aktywa2_wlasnosc1 = false;
        public bool _aktywa2_wlasnosc2 = false;
        public bool _aktywa2_wlasnosc3 = false;
        public bool _aktywa2_wlasnosc4 = false;
        public bool _aktywa2_wlasnosc5 = false;
        public bool _aktywa2_wlasnosc6 = false;
        public bool _aktywa2_wlasnosc7 = false;
        public bool _aktywa2_wlasnosc8 = false;
        public bool _aktywa2_wlasnosc9 = false;
        public bool _aktywa2_wlasnosc10 = false;

        public bool _aktywa3_wlasnosc1 = false;
        public bool _aktywa3_wlasnosc2 = false;
        public bool _aktywa3_wlasnosc3 = false;
        public bool _aktywa3_wlasnosc4 = false;
        public bool _aktywa3_wlasnosc5 = false;
        public bool _aktywa3_wlasnosc6 = false;
        public bool _aktywa3_wlasnosc7 = false;
        public bool _aktywa3_wlasnosc8 = false;
        public bool _aktywa3_wlasnosc9 = false;
        public bool _aktywa3_wlasnosc10 = false;

        public bool _aktywa4_wlasnosc1 = false;
        public bool _aktywa4_wlasnosc2 = false;
        public bool _aktywa4_wlasnosc3 = false;
        public bool _aktywa4_wlasnosc4 = false;
        public bool _aktywa4_wlasnosc5 = false;
        public bool _aktywa4_wlasnosc6 = false;
        public bool _aktywa4_wlasnosc7 = false;
        public bool _aktywa4_wlasnosc8 = false;
        public bool _aktywa4_wlasnosc9 = false;
        public bool _aktywa4_wlasnosc10 = false;

        public bool _aktywa5_wlasnosc1 = false;
        public bool _aktywa5_wlasnosc2 = false;
        public bool _aktywa5_wlasnosc3 = false;
        public bool _aktywa5_wlasnosc4 = false;
        public bool _aktywa5_wlasnosc5 = false;
        public bool _aktywa5_wlasnosc6 = false;
        public bool _aktywa5_wlasnosc7 = false;
        public bool _aktywa5_wlasnosc8 = false;
        public bool _aktywa5_wlasnosc9 = false;
        public bool _aktywa5_wlasnosc10 = false;

        public bool _aktywa6_wlasnosc1 = false;
        public bool _aktywa6_wlasnosc2 = false;
        public bool _aktywa6_wlasnosc3 = false;
        public bool _aktywa6_wlasnosc4 = false;
        public bool _aktywa6_wlasnosc5 = false;
        public bool _aktywa6_wlasnosc6 = false;
        public bool _aktywa6_wlasnosc7 = false;
        public bool _aktywa6_wlasnosc8 = false;
        public bool _aktywa6_wlasnosc9 = false;
        public bool _aktywa6_wlasnosc10 = false;

        public bool _aktywa7_wlasnosc1 = false;
        public bool _aktywa7_wlasnosc2 = false;
        public bool _aktywa7_wlasnosc3 = false;
        public bool _aktywa7_wlasnosc4 = false;
        public bool _aktywa7_wlasnosc5 = false;
        public bool _aktywa7_wlasnosc6 = false;
        public bool _aktywa7_wlasnosc7 = false;
        public bool _aktywa7_wlasnosc8 = false;
        public bool _aktywa7_wlasnosc9 = false;
        public bool _aktywa7_wlasnosc10 = false;

        public bool _aktywa8_wlasnosc1 = false;
        public bool _aktywa8_wlasnosc2 = false;
        public bool _aktywa8_wlasnosc3 = false;
        public bool _aktywa8_wlasnosc4 = false;
        public bool _aktywa8_wlasnosc5 = false;
        public bool _aktywa8_wlasnosc6 = false;
        public bool _aktywa8_wlasnosc7 = false;
        public bool _aktywa8_wlasnosc8 = false;
        public bool _aktywa8_wlasnosc9 = false;
        public bool _aktywa8_wlasnosc10 = false;

        public bool _aktywa9_wlasnosc1 = false;
        public bool _aktywa9_wlasnosc2 = false;
        public bool _aktywa9_wlasnosc3 = false;
        public bool _aktywa9_wlasnosc4 = false;
        public bool _aktywa9_wlasnosc5 = false;
        public bool _aktywa9_wlasnosc6 = false;
        public bool _aktywa9_wlasnosc7 = false;
        public bool _aktywa9_wlasnosc8 = false;
        public bool _aktywa9_wlasnosc9 = false;
        public bool _aktywa9_wlasnosc10 = false;

        public bool _aktywa10_wlasnosc1 = false;
        public bool _aktywa10_wlasnosc2 = false;
        public bool _aktywa10_wlasnosc3 = false;
        public bool _aktywa10_wlasnosc4 = false;
        public bool _aktywa10_wlasnosc5 = false;
        public bool _aktywa10_wlasnosc6 = false;
        public bool _aktywa10_wlasnosc7 = false;
        public bool _aktywa10_wlasnosc8 = false;
        public bool _aktywa10_wlasnosc9 = false;
        public bool _aktywa10_wlasnosc10 = false;

        //------------------
        public bool _atak1_aktywa1 = false;
        public bool _atak1_aktywa2 = false;
        public bool _atak1_aktywa3= false;
        public bool _atak1_aktywa4 = false;
        public bool _atak1_aktywa5 = false;
        public bool _atak1_aktywa6 = false;
        public bool _atak1_aktywa7 = false;
        public bool _atak1_aktywa8 = false;
        public bool _atak1_aktywa9 = false;
        public bool _atak1_aktywa10 = false;

        public bool _atak2_aktywa1 = false;
        public bool _atak2_aktywa2 = false;
        public bool _atak2_aktywa3 = false;
        public bool _atak2_aktywa4 = false;
        public bool _atak2_aktywa5 = false;
        public bool _atak2_aktywa6 = false;
        public bool _atak2_aktywa7 = false;
        public bool _atak2_aktywa8 = false;
        public bool _atak2_aktywa9 = false;
        public bool _atak2_aktywa10 = false;

        public bool _atak3_aktywa1 = false;
        public bool _atak3_aktywa2 = false;
        public bool _atak3_aktywa3 = false;
        public bool _atak3_aktywa4 = false;
        public bool _atak3_aktywa5 = false;
        public bool _atak3_aktywa6 = false;
        public bool _atak3_aktywa7 = false;
        public bool _atak3_aktywa8 = false;
        public bool _atak3_aktywa9 = false;
        public bool _atak3_aktywa10 = false;

        public bool _atak4_aktywa1 = false;
        public bool _atak4_aktywa2 = false;
        public bool _atak4_aktywa3 = false;
        public bool _atak4_aktywa4 = false;
        public bool _atak4_aktywa5 = false;
        public bool _atak4_aktywa6 = false;
        public bool _atak4_aktywa7 = false;
        public bool _atak4_aktywa8 = false;
        public bool _atak4_aktywa9 = false;
        public bool _atak4_aktywa10 = false;

        public bool _atak5_aktywa1 = false;
        public bool _atak5_aktywa2 = false;
        public bool _atak5_aktywa3 = false;
        public bool _atak5_aktywa4 = false;
        public bool _atak5_aktywa5 = false;
        public bool _atak5_aktywa6 = false;
        public bool _atak5_aktywa7 = false;
        public bool _atak5_aktywa8 = false;
        public bool _atak5_aktywa9 = false;
        public bool _atak5_aktywa10 = false;

        public bool _atak6_aktywa1 = false;
        public bool _atak6_aktywa2 = false;
        public bool _atak6_aktywa3 = false;
        public bool _atak6_aktywa4 = false;
        public bool _atak6_aktywa5 = false;
        public bool _atak6_aktywa6 = false;
        public bool _atak6_aktywa7 = false;
        public bool _atak6_aktywa8 = false;
        public bool _atak6_aktywa9 = false;
        public bool _atak6_aktywa10 = false;

        public bool _atak7_aktywa1 = false;
        public bool _atak7_aktywa2 = false;
        public bool _atak7_aktywa3 = false;
        public bool _atak7_aktywa4 = false;
        public bool _atak7_aktywa5 = false;
        public bool _atak7_aktywa6 = false;
        public bool _atak7_aktywa7 = false;
        public bool _atak7_aktywa8 = false;
        public bool _atak7_aktywa9 = false;
        public bool _atak7_aktywa10 = false;

        public bool _atak8_aktywa1 = false;
        public bool _atak8_aktywa2 = false;
        public bool _atak8_aktywa3 = false;
        public bool _atak8_aktywa4 = false;
        public bool _atak8_aktywa5 = false;
        public bool _atak8_aktywa6 = false;
        public bool _atak8_aktywa7 = false;
        public bool _atak8_aktywa8 = false;
        public bool _atak8_aktywa9 = false;
        public bool _atak8_aktywa10 = false;

        public bool _atak9_aktywa1 = false;
        public bool _atak9_aktywa2 = false;
        public bool _atak9_aktywa3 = false;
        public bool _atak9_aktywa4 = false;
        public bool _atak9_aktywa5 = false;
        public bool _atak9_aktywa6 = false;
        public bool _atak9_aktywa7 = false;
        public bool _atak9_aktywa8 = false;
        public bool _atak9_aktywa9 = false;
        public bool _atak9_aktywa10 = false;

        public bool _atak10_aktywa1 = false;
        public bool _atak10_aktywa2 = false;
        public bool _atak10_aktywa3 = false;
        public bool _atak10_aktywa4 = false;
        public bool _atak10_aktywa5 = false;
        public bool _atak10_aktywa6 = false;
        public bool _atak10_aktywa7 = false;
        public bool _atak10_aktywa8 = false;
        public bool _atak10_aktywa9 = false;
        public bool _atak10_aktywa10 = false;

        //------------------
        public bool _atak1_szkoda1 = false;
        public bool _atak1_szkoda2 = false;
        public bool _atak1_szkoda3 = false;
        public bool _atak1_szkoda4 = false;
        public bool _atak1_szkoda5 = false;
        public bool _atak1_szkoda6 = false;
        public bool _atak1_szkoda7 = false;
        public bool _atak1_szkoda8 = false;
        public bool _atak1_szkoda9 = false;
        public bool _atak1_szkoda10 = false;

        public bool _atak2_szkoda1 = false;
        public bool _atak2_szkoda2 = false;
        public bool _atak2_szkoda3 = false;
        public bool _atak2_szkoda4 = false;
        public bool _atak2_szkoda5 = false;
        public bool _atak2_szkoda6 = false;
        public bool _atak2_szkoda7 = false;
        public bool _atak2_szkoda8 = false;
        public bool _atak2_szkoda9 = false;
        public bool _atak2_szkoda10 = false;

        public bool _atak3_szkoda1 = false;
        public bool _atak3_szkoda2 = false;
        public bool _atak3_szkoda3 = false;
        public bool _atak3_szkoda4 = false;
        public bool _atak3_szkoda5 = false;
        public bool _atak3_szkoda6 = false;
        public bool _atak3_szkoda7 = false;
        public bool _atak3_szkoda8 = false;
        public bool _atak3_szkoda9 = false;
        public bool _atak3_szkoda10 = false;

        public bool _atak4_szkoda1 = false;
        public bool _atak4_szkoda2 = false;
        public bool _atak4_szkoda3 = false;
        public bool _atak4_szkoda4 = false;
        public bool _atak4_szkoda5 = false;
        public bool _atak4_szkoda6 = false;
        public bool _atak4_szkoda7 = false;
        public bool _atak4_szkoda8 = false;
        public bool _atak4_szkoda9 = false;
        public bool _atak4_szkoda10 = false;

        public bool _atak5_szkoda1 = false;
        public bool _atak5_szkoda2 = false;
        public bool _atak5_szkoda3 = false;
        public bool _atak5_szkoda4 = false;
        public bool _atak5_szkoda5 = false;
        public bool _atak5_szkoda6 = false;
        public bool _atak5_szkoda7 = false;
        public bool _atak5_szkoda8 = false;
        public bool _atak5_szkoda9 = false;
        public bool _atak5_szkoda10 = false;

        public bool _atak6_szkoda1 = false;
        public bool _atak6_szkoda2 = false;
        public bool _atak6_szkoda3 = false;
        public bool _atak6_szkoda4 = false;
        public bool _atak6_szkoda5 = false;
        public bool _atak6_szkoda6 = false;
        public bool _atak6_szkoda7 = false;
        public bool _atak6_szkoda8 = false;
        public bool _atak6_szkoda9 = false;
        public bool _atak6_szkoda10 = false;

        public bool _atak7_szkoda1 = false;
        public bool _atak7_szkoda2 = false;
        public bool _atak7_szkoda3 = false;
        public bool _atak7_szkoda4 = false;
        public bool _atak7_szkoda5 = false;
        public bool _atak7_szkoda6 = false;
        public bool _atak7_szkoda7 = false;
        public bool _atak7_szkoda8 = false;
        public bool _atak7_szkoda9 = false;
        public bool _atak7_szkoda10 = false;

        public bool _atak8_szkoda1 = false;
        public bool _atak8_szkoda2 = false;
        public bool _atak8_szkoda3 = false;
        public bool _atak8_szkoda4 = false;
        public bool _atak8_szkoda5 = false;
        public bool _atak8_szkoda6 = false;
        public bool _atak8_szkoda7 = false;
        public bool _atak8_szkoda8 = false;
        public bool _atak8_szkoda9 = false;
        public bool _atak8_szkoda10 = false;

        public bool _atak9_szkoda1 = false;
        public bool _atak9_szkoda2 = false;
        public bool _atak9_szkoda3 = false;
        public bool _atak9_szkoda4 = false;
        public bool _atak9_szkoda5 = false;
        public bool _atak9_szkoda6 = false;
        public bool _atak9_szkoda7 = false;
        public bool _atak9_szkoda8 = false;
        public bool _atak9_szkoda9 = false;
        public bool _atak9_szkoda10 = false;

        public bool _atak10_szkoda1 = false;
        public bool _atak10_szkoda2 = false;
        public bool _atak10_szkoda3 = false;
        public bool _atak10_szkoda4 = false;
        public bool _atak10_szkoda5 = false;
        public bool _atak10_szkoda6 = false;
        public bool _atak10_szkoda7 = false;
        public bool _atak10_szkoda8 = false;
        public bool _atak10_szkoda9 = false;
        public bool _atak10_szkoda10 = false;

        //------------------
        public bool _atak1_wykonawca1 = false;
        public bool _atak1_wykonawca2 = false;
        public bool _atak1_wykonawca3 = false;
        public bool _atak1_wykonawca4 = false;
        public bool _atak1_wykonawca5 = false;
        public bool _atak1_wykonawca6 = false;
        public bool _atak1_wykonawca7 = false;
        public bool _atak1_wykonawca8 = false;
        public bool _atak1_wykonawca9 = false;
        public bool _atak1_wykonawca10 = false;

        public bool _atak2_wykonawca1 = false;
        public bool _atak2_wykonawca2 = false;
        public bool _atak2_wykonawca3 = false;
        public bool _atak2_wykonawca4 = false;
        public bool _atak2_wykonawca5 = false;
        public bool _atak2_wykonawca6 = false;
        public bool _atak2_wykonawca7 = false;
        public bool _atak2_wykonawca8 = false;
        public bool _atak2_wykonawca9 = false;
        public bool _atak2_wykonawca10 = false;

        public bool _atak3_wykonawca1 = false;
        public bool _atak3_wykonawca2 = false;
        public bool _atak3_wykonawca3 = false;
        public bool _atak3_wykonawca4 = false;
        public bool _atak3_wykonawca5 = false;
        public bool _atak3_wykonawca6 = false;
        public bool _atak3_wykonawca7 = false;
        public bool _atak3_wykonawca8 = false;
        public bool _atak3_wykonawca9 = false;
        public bool _atak3_wykonawca10 = false;

        public bool _atak4_wykonawca1 = false;
        public bool _atak4_wykonawca2 = false;
        public bool _atak4_wykonawca3 = false;
        public bool _atak4_wykonawca4 = false;
        public bool _atak4_wykonawca5 = false;
        public bool _atak4_wykonawca6 = false;
        public bool _atak4_wykonawca7 = false;
        public bool _atak4_wykonawca8 = false;
        public bool _atak4_wykonawca9 = false;
        public bool _atak4_wykonawca10 = false;

        public bool _atak5_wykonawca1 = false;
        public bool _atak5_wykonawca2 = false;
        public bool _atak5_wykonawca3 = false;
        public bool _atak5_wykonawca4 = false;
        public bool _atak5_wykonawca5 = false;
        public bool _atak5_wykonawca6 = false;
        public bool _atak5_wykonawca7 = false;
        public bool _atak5_wykonawca8 = false;
        public bool _atak5_wykonawca9 = false;
        public bool _atak5_wykonawca10 = false;

        public bool _atak6_wykonawca1 = false;
        public bool _atak6_wykonawca2 = false;
        public bool _atak6_wykonawca3 = false;
        public bool _atak6_wykonawca4 = false;
        public bool _atak6_wykonawca5 = false;
        public bool _atak6_wykonawca6 = false;
        public bool _atak6_wykonawca7 = false;
        public bool _atak6_wykonawca8 = false;
        public bool _atak6_wykonawca9 = false;
        public bool _atak6_wykonawca10 = false;

        public bool _atak7_wykonawca1 = false;
        public bool _atak7_wykonawca2 = false;
        public bool _atak7_wykonawca3 = false;
        public bool _atak7_wykonawca4 = false;
        public bool _atak7_wykonawca5 = false;
        public bool _atak7_wykonawca6 = false;
        public bool _atak7_wykonawca7 = false;
        public bool _atak7_wykonawca8 = false;
        public bool _atak7_wykonawca9 = false;
        public bool _atak7_wykonawca10 = false;

        public bool _atak8_wykonawca1 = false;
        public bool _atak8_wykonawca2 = false;
        public bool _atak8_wykonawca3 = false;
        public bool _atak8_wykonawca4 = false;
        public bool _atak8_wykonawca5 = false;
        public bool _atak8_wykonawca6 = false;
        public bool _atak8_wykonawca7 = false;
        public bool _atak8_wykonawca8 = false;
        public bool _atak8_wykonawca9 = false;
        public bool _atak8_wykonawca10 = false;

        public bool _atak9_wykonawca1 = false;
        public bool _atak9_wykonawca2 = false;
        public bool _atak9_wykonawca3 = false;
        public bool _atak9_wykonawca4 = false;
        public bool _atak9_wykonawca5 = false;
        public bool _atak9_wykonawca6 = false;
        public bool _atak9_wykonawca7 = false;
        public bool _atak9_wykonawca8 = false;
        public bool _atak9_wykonawca9 = false;
        public bool _atak9_wykonawca10 = false;

        public bool _atak10_wykonawca1 = false;
        public bool _atak10_wykonawca2 = false;
        public bool _atak10_wykonawca3 = false;
        public bool _atak10_wykonawca4 = false;
        public bool _atak10_wykonawca5 = false;
        public bool _atak10_wykonawca6 = false;
        public bool _atak10_wykonawca7 = false;
        public bool _atak10_wykonawca8 = false;
        public bool _atak10_wykonawca9 = false;
        public bool _atak10_wykonawca10 = false;

        //------------------
        public int _czas1 = 0;
        public int _kwalifikacje1 = 0;
        public int _wiedza1 = 0;
        public int _wyposazenie1 = 0;
        public int _dostep1 = 0;
        public int _ryzyko1 = 1;

        public int _czas2 = 0;
        public int _kwalifikacje2 = 0;
        public int _wiedza2 = 0;
        public int _wyposazenie2 = 0;
        public int _dostep2 = 0;
        public int _ryzyko2 = 1;

        public int _czas3 = 0;
        public int _kwalifikacje3 = 0;
        public int _wiedza3 = 0;
        public int _wyposazenie3 = 0;
        public int _dostep3 = 0;
        public int _ryzyko3 = 1;

        public int _czas4 = 0;
        public int _kwalifikacje4 = 0;
        public int _wiedza4 = 0;
        public int _wyposazenie4 = 0;
        public int _dostep4 = 0;
        public int _ryzyko4 = 1;

        public int _czas5 = 0;
        public int _kwalifikacje5 = 0;
        public int _wiedza5 = 0;
        public int _wyposazenie5 = 0;
        public int _dostep5 = 0;
        public int _ryzyko5 = 1;

        public int _czas6 = 0;
        public int _kwalifikacje6 = 0;
        public int _wiedza6 = 0;
        public int _wyposazenie6 = 0;
        public int _dostep6 = 0;
        public int _ryzyko6 = 1;

        public int _czas7 = 0;
        public int _kwalifikacje7 = 0;
        public int _wiedza7 = 0;
        public int _wyposazenie7 = 0;
        public int _dostep7 = 0;
        public int _ryzyko7 = 1;

        public int _czas8 = 0;
        public int _kwalifikacje8 = 0;
        public int _wiedza8 = 0;
        public int _wyposazenie8 = 0;
        public int _dostep8 = 0;
        public int _ryzyko8 = 1;

        public int _czas9 = 0;
        public int _kwalifikacje9 = 0;
        public int _wiedza9 = 0;
        public int _wyposazenie9 = 0;
        public int _dostep9 = 0;
        public int _ryzyko9 = 1;

        public int _czas10 = 0;
        public int _kwalifikacje10 = 0;
        public int _wiedza10 = 0;
        public int _wyposazenie10 = 0;
        public int _dostep10 = 0;
        public int _ryzyko10 = 1;

        public dane()
        {
        }

        /// <summary>
        /// Zapisuje do pliku.
        /// </summary>
        public void write(string fileName)
        {
            try
            {
                _fileName = fileName;

                XmlTextWriter writer = new XmlTextWriter(_fileName, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();

                writer.WriteStartElement("Rami");
<<<<<<< HEAD

                writer.WriteElementString("wersjaAngielska", _isEn.ToString());

=======
>>>>>>> 0412c3c6613d615f52418e74019f13b8b3dcb13a
                writer.WriteElementString("nazwa", _nazwa.ToString());
                writer.WriteElementString("opis", _opis.ToString());

                writer.WriteElementString("regulacja1", _regulacja1.ToString());
                writer.WriteElementString("wplyw1", _wplyw1.ToString());

                writer.WriteElementString("regulacja2", _regulacja2.ToString());
                writer.WriteElementString("wplyw2", _wplyw2.ToString());

                writer.WriteElementString("regulacja3", _regulacja3.ToString());
                writer.WriteElementString("wplyw3", _wplyw3.ToString());

                writer.WriteElementString("regulacja4", _regulacja4.ToString());
                writer.WriteElementString("wplyw4", _wplyw4.ToString());

                writer.WriteElementString("regulacja5", _regulacja5.ToString());
                writer.WriteElementString("wplyw5", _wplyw5.ToString());

                writer.WriteElementString("regulacja6", _regulacja6.ToString());
                writer.WriteElementString("wplyw6", _wplyw6.ToString());

                writer.WriteElementString("regulacja7", _regulacja7.ToString());
                writer.WriteElementString("wplyw7", _wplyw7.ToString());

                writer.WriteElementString("regulacja8", _regulacja8.ToString());
                writer.WriteElementString("wplyw8", _wplyw8.ToString());

                writer.WriteElementString("regulacja9", _regulacja9.ToString());
                writer.WriteElementString("wplyw9", _wplyw9.ToString());

                writer.WriteElementString("regulacja10", _regulacja10.ToString());
                writer.WriteElementString("wplyw10", _wplyw10.ToString());

                writer.WriteElementString("aktywa1", _aktywa1.ToString());
                writer.WriteElementString("aktywa2", _aktywa2.ToString());
                writer.WriteElementString("aktywa3", _aktywa3.ToString());
                writer.WriteElementString("aktywa4", _aktywa4.ToString());
                writer.WriteElementString("aktywa5", _aktywa5.ToString());
                writer.WriteElementString("aktywa6", _aktywa6.ToString());
                writer.WriteElementString("aktywa7", _aktywa7.ToString());
                writer.WriteElementString("aktywa8", _aktywa8.ToString());
                writer.WriteElementString("aktywa9", _aktywa9.ToString());
                writer.WriteElementString("aktywa10", _aktywa10.ToString());

                writer.WriteElementString("wlasnosc1", _wlasnosc1.ToString());
                writer.WriteElementString("wlasnosc2", _wlasnosc2.ToString());
                writer.WriteElementString("wlasnosc3", _wlasnosc3.ToString());
                writer.WriteElementString("wlasnosc4", _wlasnosc4.ToString());
                writer.WriteElementString("wlasnosc5", _wlasnosc5.ToString());
                writer.WriteElementString("wlasnosc6", _wlasnosc6.ToString());
                writer.WriteElementString("wlasnosc7", _wlasnosc7.ToString());
                writer.WriteElementString("wlasnosc8", _wlasnosc8.ToString());
                writer.WriteElementString("wlasnosc9", _wlasnosc9.ToString());
                writer.WriteElementString("wlasnosc10", _wlasnosc10.ToString());

                writer.WriteElementString("szkoda1", _szkoda1.ToString());
                writer.WriteElementString("szkoda2", _szkoda2.ToString());
                writer.WriteElementString("szkoda3", _szkoda3.ToString());
                writer.WriteElementString("szkoda4", _szkoda4.ToString());
                writer.WriteElementString("szkoda5", _szkoda5.ToString());
                writer.WriteElementString("szkoda6", _szkoda6.ToString());
                writer.WriteElementString("szkoda7", _szkoda7.ToString());
                writer.WriteElementString("szkoda8", _szkoda8.ToString());
                writer.WriteElementString("szkoda9", _szkoda9.ToString());
                writer.WriteElementString("szkoda10", _szkoda10.ToString());

                writer.WriteElementString("atak1", _atak1.ToString());
                writer.WriteElementString("atak2", _atak2.ToString());
                writer.WriteElementString("atak3", _atak3.ToString());
                writer.WriteElementString("atak4", _atak4.ToString());
                writer.WriteElementString("atak5", _atak5.ToString());
                writer.WriteElementString("atak6", _atak6.ToString());
                writer.WriteElementString("atak7", _atak7.ToString());
                writer.WriteElementString("atak8", _atak8.ToString());
                writer.WriteElementString("atak9", _atak9.ToString());
                writer.WriteElementString("atak10", _atak10.ToString());

                writer.WriteElementString("wykonawca1", _wykonawca1.ToString());
                writer.WriteElementString("wykonawca2", _wykonawca2.ToString());
                writer.WriteElementString("wykonawca3", _wykonawca3.ToString());
                writer.WriteElementString("wykonawca4", _wykonawca4.ToString());
                writer.WriteElementString("wykonawca5", _wykonawca5.ToString());
                writer.WriteElementString("wykonawca6", _wykonawca6.ToString());
                writer.WriteElementString("wykonawca7", _wykonawca7.ToString());
                writer.WriteElementString("wykonawca8", _wykonawca8.ToString());
                writer.WriteElementString("wykonawca9", _wykonawca9.ToString());
                writer.WriteElementString("wykonawca10", _wykonawca10.ToString());

                //------------- Regulacja - Aktywa
                writer.WriteElementString("regulacja1_aktywa1", _regulacja1_aktywa1.ToString());
                writer.WriteElementString("regulacja1_aktywa2", _regulacja1_aktywa2.ToString());
                writer.WriteElementString("regulacja1_aktywa3", _regulacja1_aktywa3.ToString());
                writer.WriteElementString("regulacja1_aktywa4", _regulacja1_aktywa4.ToString());
                writer.WriteElementString("regulacja1_aktywa5", _regulacja1_aktywa5.ToString());
                writer.WriteElementString("regulacja1_aktywa6", _regulacja1_aktywa6.ToString());
                writer.WriteElementString("regulacja1_aktywa7", _regulacja1_aktywa7.ToString());
                writer.WriteElementString("regulacja1_aktywa8", _regulacja1_aktywa8.ToString());
                writer.WriteElementString("regulacja1_aktywa9", _regulacja1_aktywa9.ToString());
                writer.WriteElementString("regulacja1_aktywa10", _regulacja1_aktywa10.ToString());

                writer.WriteElementString("regulacja2_aktywa1", _regulacja2_aktywa1.ToString());
                writer.WriteElementString("regulacja2_aktywa2", _regulacja2_aktywa2.ToString());
                writer.WriteElementString("regulacja2_aktywa3", _regulacja2_aktywa3.ToString());
                writer.WriteElementString("regulacja2_aktywa4", _regulacja2_aktywa4.ToString());
                writer.WriteElementString("regulacja2_aktywa5", _regulacja2_aktywa5.ToString());
                writer.WriteElementString("regulacja2_aktywa6", _regulacja2_aktywa6.ToString());
                writer.WriteElementString("regulacja2_aktywa7", _regulacja2_aktywa7.ToString());
                writer.WriteElementString("regulacja2_aktywa8", _regulacja2_aktywa8.ToString());
                writer.WriteElementString("regulacja2_aktywa9", _regulacja2_aktywa9.ToString());
                writer.WriteElementString("regulacja2_aktywa10", _regulacja2_aktywa10.ToString());

                writer.WriteElementString("regulacja3_aktywa1", _regulacja3_aktywa1.ToString());
                writer.WriteElementString("regulacja3_aktywa2", _regulacja3_aktywa2.ToString());
                writer.WriteElementString("regulacja3_aktywa3", _regulacja3_aktywa3.ToString());
                writer.WriteElementString("regulacja3_aktywa4", _regulacja3_aktywa4.ToString());
                writer.WriteElementString("regulacja3_aktywa5", _regulacja3_aktywa5.ToString());
                writer.WriteElementString("regulacja3_aktywa6", _regulacja3_aktywa6.ToString());
                writer.WriteElementString("regulacja3_aktywa7", _regulacja3_aktywa7.ToString());
                writer.WriteElementString("regulacja3_aktywa8", _regulacja3_aktywa8.ToString());
                writer.WriteElementString("regulacja3_aktywa9", _regulacja3_aktywa9.ToString());
                writer.WriteElementString("regulacja3_aktywa10", _regulacja3_aktywa10.ToString());

                writer.WriteElementString("regulacja4_aktywa1", _regulacja4_aktywa1.ToString());
                writer.WriteElementString("regulacja4_aktywa2", _regulacja4_aktywa2.ToString());
                writer.WriteElementString("regulacja4_aktywa3", _regulacja4_aktywa3.ToString());
                writer.WriteElementString("regulacja4_aktywa4", _regulacja4_aktywa4.ToString());
                writer.WriteElementString("regulacja4_aktywa5", _regulacja4_aktywa5.ToString());
                writer.WriteElementString("regulacja4_aktywa6", _regulacja4_aktywa6.ToString());
                writer.WriteElementString("regulacja4_aktywa7", _regulacja4_aktywa7.ToString());
                writer.WriteElementString("regulacja4_aktywa8", _regulacja4_aktywa8.ToString());
                writer.WriteElementString("regulacja4_aktywa9", _regulacja4_aktywa9.ToString());
                writer.WriteElementString("regulacja4_aktywa10", _regulacja4_aktywa10.ToString());

                writer.WriteElementString("regulacja5_aktywa1", _regulacja5_aktywa1.ToString());
                writer.WriteElementString("regulacja5_aktywa2", _regulacja5_aktywa2.ToString());
                writer.WriteElementString("regulacja5_aktywa3", _regulacja5_aktywa3.ToString());
                writer.WriteElementString("regulacja5_aktywa4", _regulacja5_aktywa4.ToString());
                writer.WriteElementString("regulacja5_aktywa5", _regulacja5_aktywa5.ToString());
                writer.WriteElementString("regulacja5_aktywa6", _regulacja5_aktywa6.ToString());
                writer.WriteElementString("regulacja5_aktywa7", _regulacja5_aktywa7.ToString());
                writer.WriteElementString("regulacja5_aktywa8", _regulacja5_aktywa8.ToString());
                writer.WriteElementString("regulacja5_aktywa9", _regulacja5_aktywa9.ToString());
                writer.WriteElementString("regulacja5_aktywa10", _regulacja5_aktywa10.ToString());

                writer.WriteElementString("regulacja6_aktywa1", _regulacja6_aktywa1.ToString());
                writer.WriteElementString("regulacja6_aktywa2", _regulacja6_aktywa2.ToString());
                writer.WriteElementString("regulacja6_aktywa3", _regulacja6_aktywa3.ToString());
                writer.WriteElementString("regulacja6_aktywa4", _regulacja6_aktywa4.ToString());
                writer.WriteElementString("regulacja6_aktywa5", _regulacja6_aktywa5.ToString());
                writer.WriteElementString("regulacja6_aktywa6", _regulacja6_aktywa6.ToString());
                writer.WriteElementString("regulacja6_aktywa7", _regulacja6_aktywa7.ToString());
                writer.WriteElementString("regulacja6_aktywa8", _regulacja6_aktywa8.ToString());
                writer.WriteElementString("regulacja6_aktywa9", _regulacja6_aktywa9.ToString());
                writer.WriteElementString("regulacja6_aktywa10", _regulacja6_aktywa10.ToString());

                writer.WriteElementString("regulacja7_aktywa1", _regulacja7_aktywa1.ToString());
                writer.WriteElementString("regulacja7_aktywa2", _regulacja7_aktywa2.ToString());
                writer.WriteElementString("regulacja7_aktywa3", _regulacja7_aktywa3.ToString());
                writer.WriteElementString("regulacja7_aktywa4", _regulacja7_aktywa4.ToString());
                writer.WriteElementString("regulacja7_aktywa5", _regulacja7_aktywa5.ToString());
                writer.WriteElementString("regulacja7_aktywa6", _regulacja7_aktywa6.ToString());
                writer.WriteElementString("regulacja7_aktywa7", _regulacja7_aktywa7.ToString());
                writer.WriteElementString("regulacja7_aktywa8", _regulacja7_aktywa8.ToString());
                writer.WriteElementString("regulacja7_aktywa9", _regulacja7_aktywa9.ToString());
                writer.WriteElementString("regulacja7_aktywa10", _regulacja7_aktywa10.ToString());

                writer.WriteElementString("regulacja8_aktywa1", _regulacja8_aktywa1.ToString());
                writer.WriteElementString("regulacja8_aktywa2", _regulacja8_aktywa2.ToString());
                writer.WriteElementString("regulacja8_aktywa3", _regulacja8_aktywa3.ToString());
                writer.WriteElementString("regulacja8_aktywa4", _regulacja8_aktywa4.ToString());
                writer.WriteElementString("regulacja8_aktywa5", _regulacja8_aktywa5.ToString());
                writer.WriteElementString("regulacja8_aktywa6", _regulacja8_aktywa6.ToString());
                writer.WriteElementString("regulacja8_aktywa7", _regulacja8_aktywa7.ToString());
                writer.WriteElementString("regulacja8_aktywa8", _regulacja8_aktywa8.ToString());
                writer.WriteElementString("regulacja8_aktywa9", _regulacja8_aktywa9.ToString());
                writer.WriteElementString("regulacja8_aktywa10", _regulacja8_aktywa10.ToString());

                writer.WriteElementString("regulacja9_aktywa1", _regulacja9_aktywa1.ToString());
                writer.WriteElementString("regulacja9_aktywa2", _regulacja9_aktywa2.ToString());
                writer.WriteElementString("regulacja9_aktywa3", _regulacja9_aktywa3.ToString());
                writer.WriteElementString("regulacja9_aktywa4", _regulacja9_aktywa4.ToString());
                writer.WriteElementString("regulacja9_aktywa5", _regulacja9_aktywa5.ToString());
                writer.WriteElementString("regulacja9_aktywa6", _regulacja9_aktywa6.ToString());
                writer.WriteElementString("regulacja9_aktywa7", _regulacja9_aktywa7.ToString());
                writer.WriteElementString("regulacja9_aktywa8", _regulacja9_aktywa8.ToString());
                writer.WriteElementString("regulacja9_aktywa9", _regulacja9_aktywa9.ToString());
                writer.WriteElementString("regulacja9_aktywa10", _regulacja9_aktywa10.ToString());

                writer.WriteElementString("regulacja10_aktywa1", _regulacja10_aktywa1.ToString());
                writer.WriteElementString("regulacja10_aktywa2", _regulacja10_aktywa2.ToString());
                writer.WriteElementString("regulacja10_aktywa3", _regulacja10_aktywa3.ToString());
                writer.WriteElementString("regulacja10_aktywa4", _regulacja10_aktywa4.ToString());
                writer.WriteElementString("regulacja10_aktywa5", _regulacja10_aktywa5.ToString());
                writer.WriteElementString("regulacja10_aktywa6", _regulacja10_aktywa6.ToString());
                writer.WriteElementString("regulacja10_aktywa7", _regulacja10_aktywa7.ToString());
                writer.WriteElementString("regulacja10_aktywa8", _regulacja10_aktywa8.ToString());
                writer.WriteElementString("regulacja10_aktywa9", _regulacja10_aktywa9.ToString());
                writer.WriteElementString("regulacja10_aktywa10", _regulacja10_aktywa10.ToString());

                //-------------
                writer.WriteElementString("aktywa1_wlasnosc1", _aktywa1_wlasnosc1.ToString());
                writer.WriteElementString("aktywa1_wlasnosc2", _aktywa1_wlasnosc2.ToString());
                writer.WriteElementString("aktywa1_wlasnosc3", _aktywa1_wlasnosc3.ToString());
                writer.WriteElementString("aktywa1_wlasnosc4", _aktywa1_wlasnosc4.ToString());
                writer.WriteElementString("aktywa1_wlasnosc5", _aktywa1_wlasnosc5.ToString());
                writer.WriteElementString("aktywa1_wlasnosc6", _aktywa1_wlasnosc6.ToString());
                writer.WriteElementString("aktywa1_wlasnosc7", _aktywa1_wlasnosc7.ToString());
                writer.WriteElementString("aktywa1_wlasnosc8", _aktywa1_wlasnosc8.ToString());
                writer.WriteElementString("aktywa1_wlasnosc9", _aktywa1_wlasnosc9.ToString());
                writer.WriteElementString("aktywa1_wlasnosc10", _aktywa1_wlasnosc10.ToString());

                writer.WriteElementString("aktywa2_wlasnosc1", _aktywa2_wlasnosc1.ToString());
                writer.WriteElementString("aktywa2_wlasnosc2", _aktywa2_wlasnosc2.ToString());
                writer.WriteElementString("aktywa2_wlasnosc3", _aktywa2_wlasnosc3.ToString());
                writer.WriteElementString("aktywa2_wlasnosc4", _aktywa2_wlasnosc4.ToString());
                writer.WriteElementString("aktywa2_wlasnosc5", _aktywa2_wlasnosc5.ToString());
                writer.WriteElementString("aktywa2_wlasnosc6", _aktywa2_wlasnosc6.ToString());
                writer.WriteElementString("aktywa2_wlasnosc7", _aktywa2_wlasnosc7.ToString());
                writer.WriteElementString("aktywa2_wlasnosc8", _aktywa2_wlasnosc8.ToString());
                writer.WriteElementString("aktywa2_wlasnosc9", _aktywa2_wlasnosc9.ToString());
                writer.WriteElementString("aktywa2_wlasnosc10", _aktywa2_wlasnosc10.ToString());

                writer.WriteElementString("aktywa3_wlasnosc1", _aktywa3_wlasnosc1.ToString());
                writer.WriteElementString("aktywa3_wlasnosc2", _aktywa3_wlasnosc2.ToString());
                writer.WriteElementString("aktywa3_wlasnosc3", _aktywa3_wlasnosc3.ToString());
                writer.WriteElementString("aktywa3_wlasnosc4", _aktywa3_wlasnosc4.ToString());
                writer.WriteElementString("aktywa3_wlasnosc5", _aktywa3_wlasnosc5.ToString());
                writer.WriteElementString("aktywa3_wlasnosc6", _aktywa3_wlasnosc6.ToString());
                writer.WriteElementString("aktywa3_wlasnosc7", _aktywa3_wlasnosc7.ToString());
                writer.WriteElementString("aktywa3_wlasnosc8", _aktywa3_wlasnosc8.ToString());
                writer.WriteElementString("aktywa3_wlasnosc9", _aktywa3_wlasnosc9.ToString());
                writer.WriteElementString("aktywa3_wlasnosc10", _aktywa3_wlasnosc10.ToString());

                writer.WriteElementString("aktywa4_wlasnosc1", _aktywa4_wlasnosc1.ToString());
                writer.WriteElementString("aktywa4_wlasnosc2", _aktywa4_wlasnosc2.ToString());
                writer.WriteElementString("aktywa4_wlasnosc3", _aktywa4_wlasnosc3.ToString());
                writer.WriteElementString("aktywa4_wlasnosc4", _aktywa4_wlasnosc4.ToString());
                writer.WriteElementString("aktywa4_wlasnosc5", _aktywa4_wlasnosc5.ToString());
                writer.WriteElementString("aktywa4_wlasnosc6", _aktywa4_wlasnosc6.ToString());
                writer.WriteElementString("aktywa4_wlasnosc7", _aktywa4_wlasnosc7.ToString());
                writer.WriteElementString("aktywa4_wlasnosc8", _aktywa4_wlasnosc8.ToString());
                writer.WriteElementString("aktywa4_wlasnosc9", _aktywa4_wlasnosc9.ToString());
                writer.WriteElementString("aktywa4_wlasnosc10", _aktywa4_wlasnosc10.ToString());

                writer.WriteElementString("aktywa5_wlasnosc1", _aktywa5_wlasnosc1.ToString());
                writer.WriteElementString("aktywa5_wlasnosc2", _aktywa5_wlasnosc2.ToString());
                writer.WriteElementString("aktywa5_wlasnosc3", _aktywa5_wlasnosc3.ToString());
                writer.WriteElementString("aktywa5_wlasnosc4", _aktywa5_wlasnosc4.ToString());
                writer.WriteElementString("aktywa5_wlasnosc5", _aktywa5_wlasnosc5.ToString());
                writer.WriteElementString("aktywa5_wlasnosc6", _aktywa5_wlasnosc6.ToString());
                writer.WriteElementString("aktywa5_wlasnosc7", _aktywa5_wlasnosc7.ToString());
                writer.WriteElementString("aktywa5_wlasnosc8", _aktywa5_wlasnosc8.ToString());
                writer.WriteElementString("aktywa5_wlasnosc9", _aktywa5_wlasnosc9.ToString());
                writer.WriteElementString("aktywa5_wlasnosc10", _aktywa5_wlasnosc10.ToString());

                writer.WriteElementString("aktywa6_wlasnosc1", _aktywa6_wlasnosc1.ToString());
                writer.WriteElementString("aktywa6_wlasnosc2", _aktywa6_wlasnosc2.ToString());
                writer.WriteElementString("aktywa6_wlasnosc3", _aktywa6_wlasnosc3.ToString());
                writer.WriteElementString("aktywa6_wlasnosc4", _aktywa6_wlasnosc4.ToString());
                writer.WriteElementString("aktywa6_wlasnosc5", _aktywa6_wlasnosc5.ToString());
                writer.WriteElementString("aktywa6_wlasnosc6", _aktywa6_wlasnosc6.ToString());
                writer.WriteElementString("aktywa6_wlasnosc7", _aktywa6_wlasnosc7.ToString());
                writer.WriteElementString("aktywa6_wlasnosc8", _aktywa6_wlasnosc8.ToString());
                writer.WriteElementString("aktywa6_wlasnosc9", _aktywa6_wlasnosc9.ToString());
                writer.WriteElementString("aktywa6_wlasnosc10", _aktywa6_wlasnosc10.ToString());

                writer.WriteElementString("aktywa7_wlasnosc1", _aktywa7_wlasnosc1.ToString());
                writer.WriteElementString("aktywa7_wlasnosc2", _aktywa7_wlasnosc2.ToString());
                writer.WriteElementString("aktywa7_wlasnosc3", _aktywa7_wlasnosc3.ToString());
                writer.WriteElementString("aktywa7_wlasnosc4", _aktywa7_wlasnosc4.ToString());
                writer.WriteElementString("aktywa7_wlasnosc5", _aktywa7_wlasnosc5.ToString());
                writer.WriteElementString("aktywa7_wlasnosc6", _aktywa7_wlasnosc6.ToString());
                writer.WriteElementString("aktywa7_wlasnosc7", _aktywa7_wlasnosc7.ToString());
                writer.WriteElementString("aktywa7_wlasnosc8", _aktywa7_wlasnosc8.ToString());
                writer.WriteElementString("aktywa7_wlasnosc9", _aktywa7_wlasnosc9.ToString());
                writer.WriteElementString("aktywa7_wlasnosc10", _aktywa7_wlasnosc10.ToString());

                writer.WriteElementString("aktywa8_wlasnosc1", _aktywa8_wlasnosc1.ToString());
                writer.WriteElementString("aktywa8_wlasnosc2", _aktywa8_wlasnosc2.ToString());
                writer.WriteElementString("aktywa8_wlasnosc3", _aktywa8_wlasnosc3.ToString());
                writer.WriteElementString("aktywa8_wlasnosc4", _aktywa8_wlasnosc4.ToString());
                writer.WriteElementString("aktywa8_wlasnosc5", _aktywa8_wlasnosc5.ToString());
                writer.WriteElementString("aktywa8_wlasnosc6", _aktywa8_wlasnosc6.ToString());
                writer.WriteElementString("aktywa8_wlasnosc7", _aktywa8_wlasnosc7.ToString());
                writer.WriteElementString("aktywa8_wlasnosc8", _aktywa8_wlasnosc8.ToString());
                writer.WriteElementString("aktywa8_wlasnosc9", _aktywa8_wlasnosc9.ToString());
                writer.WriteElementString("aktywa8_wlasnosc10", _aktywa8_wlasnosc10.ToString());

                writer.WriteElementString("aktywa9_wlasnosc1", _aktywa9_wlasnosc1.ToString());
                writer.WriteElementString("aktywa9_wlasnosc2", _aktywa9_wlasnosc2.ToString());
                writer.WriteElementString("aktywa9_wlasnosc3", _aktywa9_wlasnosc3.ToString());
                writer.WriteElementString("aktywa9_wlasnosc4", _aktywa9_wlasnosc4.ToString());
                writer.WriteElementString("aktywa9_wlasnosc5", _aktywa9_wlasnosc5.ToString());
                writer.WriteElementString("aktywa9_wlasnosc6", _aktywa9_wlasnosc6.ToString());
                writer.WriteElementString("aktywa9_wlasnosc7", _aktywa9_wlasnosc7.ToString());
                writer.WriteElementString("aktywa9_wlasnosc8", _aktywa9_wlasnosc8.ToString());
                writer.WriteElementString("aktywa9_wlasnosc9", _aktywa9_wlasnosc9.ToString());
                writer.WriteElementString("aktywa9_wlasnosc10", _aktywa9_wlasnosc10.ToString());

                writer.WriteElementString("aktywa10_wlasnosc1", _aktywa10_wlasnosc1.ToString());
                writer.WriteElementString("aktywa10_wlasnosc2", _aktywa10_wlasnosc2.ToString());
                writer.WriteElementString("aktywa10_wlasnosc3", _aktywa10_wlasnosc3.ToString());
                writer.WriteElementString("aktywa10_wlasnosc4", _aktywa10_wlasnosc4.ToString());
                writer.WriteElementString("aktywa10_wlasnosc5", _aktywa10_wlasnosc5.ToString());
                writer.WriteElementString("aktywa10_wlasnosc6", _aktywa10_wlasnosc6.ToString());
                writer.WriteElementString("aktywa10_wlasnosc7", _aktywa10_wlasnosc7.ToString());
                writer.WriteElementString("aktywa10_wlasnosc8", _aktywa10_wlasnosc8.ToString());
                writer.WriteElementString("aktywa10_wlasnosc9", _aktywa10_wlasnosc9.ToString());
                writer.WriteElementString("aktywa10_wlasnosc10", _aktywa10_wlasnosc10.ToString());

                //-------------
                writer.WriteElementString("atak1_aktywa1", _atak1_aktywa1.ToString());
                writer.WriteElementString("atak1_aktywa2", _atak1_aktywa2.ToString());
                writer.WriteElementString("atak1_aktywa3", _atak1_aktywa3.ToString());
                writer.WriteElementString("atak1_aktywa4", _atak1_aktywa4.ToString());
                writer.WriteElementString("atak1_aktywa5", _atak1_aktywa5.ToString());
                writer.WriteElementString("atak1_aktywa6", _atak1_aktywa6.ToString());
                writer.WriteElementString("atak1_aktywa7", _atak1_aktywa7.ToString());
                writer.WriteElementString("atak1_aktywa8", _atak1_aktywa8.ToString());
                writer.WriteElementString("atak1_aktywa9", _atak1_aktywa9.ToString());
                writer.WriteElementString("atak1_aktywa10", _atak1_aktywa10.ToString());

                writer.WriteElementString("atak2_aktywa1", _atak2_aktywa1.ToString());
                writer.WriteElementString("atak2_aktywa2", _atak2_aktywa2.ToString());
                writer.WriteElementString("atak2_aktywa3", _atak2_aktywa3.ToString());
                writer.WriteElementString("atak2_aktywa4", _atak2_aktywa4.ToString());
                writer.WriteElementString("atak2_aktywa5", _atak2_aktywa5.ToString());
                writer.WriteElementString("atak2_aktywa6", _atak2_aktywa6.ToString());
                writer.WriteElementString("atak2_aktywa7", _atak2_aktywa7.ToString());
                writer.WriteElementString("atak2_aktywa8", _atak2_aktywa8.ToString());
                writer.WriteElementString("atak2_aktywa9", _atak2_aktywa9.ToString());
                writer.WriteElementString("atak2_aktywa10", _atak2_aktywa10.ToString());

                writer.WriteElementString("atak3_aktywa1", _atak3_aktywa1.ToString());
                writer.WriteElementString("atak3_aktywa2", _atak3_aktywa2.ToString());
                writer.WriteElementString("atak3_aktywa3", _atak3_aktywa3.ToString());
                writer.WriteElementString("atak3_aktywa4", _atak3_aktywa4.ToString());
                writer.WriteElementString("atak3_aktywa5", _atak3_aktywa5.ToString());
                writer.WriteElementString("atak3_aktywa6", _atak3_aktywa6.ToString());
                writer.WriteElementString("atak3_aktywa7", _atak3_aktywa7.ToString());
                writer.WriteElementString("atak3_aktywa8", _atak3_aktywa8.ToString());
                writer.WriteElementString("atak3_aktywa9", _atak3_aktywa9.ToString());
                writer.WriteElementString("atak3_aktywa10", _atak3_aktywa10.ToString());

                writer.WriteElementString("atak4_aktywa1", _atak4_aktywa1.ToString());
                writer.WriteElementString("atak4_aktywa2", _atak4_aktywa2.ToString());
                writer.WriteElementString("atak4_aktywa3", _atak4_aktywa3.ToString());
                writer.WriteElementString("atak4_aktywa4", _atak4_aktywa4.ToString());
                writer.WriteElementString("atak4_aktywa5", _atak4_aktywa5.ToString());
                writer.WriteElementString("atak4_aktywa6", _atak4_aktywa6.ToString());
                writer.WriteElementString("atak4_aktywa7", _atak4_aktywa7.ToString());
                writer.WriteElementString("atak4_aktywa8", _atak4_aktywa8.ToString());
                writer.WriteElementString("atak4_aktywa9", _atak4_aktywa9.ToString());
                writer.WriteElementString("atak4_aktywa10", _atak4_aktywa10.ToString());

                writer.WriteElementString("atak5_aktywa1", _atak5_aktywa1.ToString());
                writer.WriteElementString("atak5_aktywa2", _atak5_aktywa2.ToString());
                writer.WriteElementString("atak5_aktywa3", _atak5_aktywa3.ToString());
                writer.WriteElementString("atak5_aktywa4", _atak5_aktywa4.ToString());
                writer.WriteElementString("atak5_aktywa5", _atak5_aktywa5.ToString());
                writer.WriteElementString("atak5_aktywa6", _atak5_aktywa6.ToString());
                writer.WriteElementString("atak5_aktywa7", _atak5_aktywa7.ToString());
                writer.WriteElementString("atak5_aktywa8", _atak5_aktywa8.ToString());
                writer.WriteElementString("atak5_aktywa9", _atak5_aktywa9.ToString());
                writer.WriteElementString("atak5_aktywa10", _atak5_aktywa10.ToString());

                writer.WriteElementString("atak6_aktywa1", _atak6_aktywa1.ToString());
                writer.WriteElementString("atak6_aktywa2", _atak6_aktywa2.ToString());
                writer.WriteElementString("atak6_aktywa3", _atak6_aktywa3.ToString());
                writer.WriteElementString("atak6_aktywa4", _atak6_aktywa4.ToString());
                writer.WriteElementString("atak6_aktywa5", _atak6_aktywa5.ToString());
                writer.WriteElementString("atak6_aktywa6", _atak6_aktywa6.ToString());
                writer.WriteElementString("atak6_aktywa7", _atak6_aktywa7.ToString());
                writer.WriteElementString("atak6_aktywa8", _atak6_aktywa8.ToString());
                writer.WriteElementString("atak6_aktywa9", _atak6_aktywa9.ToString());
                writer.WriteElementString("atak6_aktywa10", _atak6_aktywa10.ToString());

                writer.WriteElementString("atak7_aktywa1", _atak7_aktywa1.ToString());
                writer.WriteElementString("atak7_aktywa2", _atak7_aktywa2.ToString());
                writer.WriteElementString("atak7_aktywa3", _atak7_aktywa3.ToString());
                writer.WriteElementString("atak7_aktywa4", _atak7_aktywa4.ToString());
                writer.WriteElementString("atak7_aktywa5", _atak7_aktywa5.ToString());
                writer.WriteElementString("atak7_aktywa6", _atak7_aktywa6.ToString());
                writer.WriteElementString("atak7_aktywa7", _atak7_aktywa7.ToString());
                writer.WriteElementString("atak7_aktywa8", _atak7_aktywa8.ToString());
                writer.WriteElementString("atak7_aktywa9", _atak7_aktywa9.ToString());
                writer.WriteElementString("atak7_aktywa10", _atak7_aktywa10.ToString());

                writer.WriteElementString("atak8_aktywa1", _atak8_aktywa1.ToString());
                writer.WriteElementString("atak8_aktywa2", _atak8_aktywa2.ToString());
                writer.WriteElementString("atak8_aktywa3", _atak8_aktywa3.ToString());
                writer.WriteElementString("atak8_aktywa4", _atak8_aktywa4.ToString());
                writer.WriteElementString("atak8_aktywa5", _atak8_aktywa5.ToString());
                writer.WriteElementString("atak8_aktywa6", _atak8_aktywa6.ToString());
                writer.WriteElementString("atak8_aktywa7", _atak8_aktywa7.ToString());
                writer.WriteElementString("atak8_aktywa8", _atak8_aktywa8.ToString());
                writer.WriteElementString("atak8_aktywa9", _atak8_aktywa9.ToString());
                writer.WriteElementString("atak8_aktywa10", _atak8_aktywa10.ToString());

                writer.WriteElementString("atak9_aktywa1", _atak9_aktywa1.ToString());
                writer.WriteElementString("atak9_aktywa2", _atak9_aktywa2.ToString());
                writer.WriteElementString("atak9_aktywa3", _atak9_aktywa3.ToString());
                writer.WriteElementString("atak9_aktywa4", _atak9_aktywa4.ToString());
                writer.WriteElementString("atak9_aktywa5", _atak9_aktywa5.ToString());
                writer.WriteElementString("atak9_aktywa6", _atak9_aktywa6.ToString());
                writer.WriteElementString("atak9_aktywa7", _atak9_aktywa7.ToString());
                writer.WriteElementString("atak9_aktywa8", _atak9_aktywa8.ToString());
                writer.WriteElementString("atak9_aktywa9", _atak9_aktywa9.ToString());
                writer.WriteElementString("atak9_aktywa10", _atak9_aktywa10.ToString());

                writer.WriteElementString("atak10_aktywa1", _atak10_aktywa1.ToString());
                writer.WriteElementString("atak10_aktywa2", _atak10_aktywa2.ToString());
                writer.WriteElementString("atak10_aktywa3", _atak10_aktywa3.ToString());
                writer.WriteElementString("atak10_aktywa4", _atak10_aktywa4.ToString());
                writer.WriteElementString("atak10_aktywa5", _atak10_aktywa5.ToString());
                writer.WriteElementString("atak10_aktywa6", _atak10_aktywa6.ToString());
                writer.WriteElementString("atak10_aktywa7", _atak10_aktywa7.ToString());
                writer.WriteElementString("atak10_aktywa8", _atak10_aktywa8.ToString());
                writer.WriteElementString("atak10_aktywa9", _atak10_aktywa9.ToString());
                writer.WriteElementString("atak10_aktywa10", _atak10_aktywa10.ToString());

                //-------------
                writer.WriteElementString("atak1_szkoda1", _atak1_szkoda1.ToString());
                writer.WriteElementString("atak1_szkoda2", _atak1_szkoda2.ToString());
                writer.WriteElementString("atak1_szkoda3", _atak1_szkoda3.ToString());
                writer.WriteElementString("atak1_szkoda4", _atak1_szkoda4.ToString());
                writer.WriteElementString("atak1_szkoda5", _atak1_szkoda5.ToString());
                writer.WriteElementString("atak1_szkoda6", _atak1_szkoda6.ToString());
                writer.WriteElementString("atak1_szkoda7", _atak1_szkoda7.ToString());
                writer.WriteElementString("atak1_szkoda8", _atak1_szkoda8.ToString());
                writer.WriteElementString("atak1_szkoda9", _atak1_szkoda9.ToString());
                writer.WriteElementString("atak1_szkoda10", _atak1_szkoda10.ToString());

                writer.WriteElementString("atak2_szkoda1", _atak2_szkoda1.ToString());
                writer.WriteElementString("atak2_szkoda2", _atak2_szkoda2.ToString());
                writer.WriteElementString("atak2_szkoda3", _atak2_szkoda3.ToString());
                writer.WriteElementString("atak2_szkoda4", _atak2_szkoda4.ToString());
                writer.WriteElementString("atak2_szkoda5", _atak2_szkoda5.ToString());
                writer.WriteElementString("atak2_szkoda6", _atak2_szkoda6.ToString());
                writer.WriteElementString("atak2_szkoda7", _atak2_szkoda7.ToString());
                writer.WriteElementString("atak2_szkoda8", _atak2_szkoda8.ToString());
                writer.WriteElementString("atak2_szkoda9", _atak2_szkoda9.ToString());
                writer.WriteElementString("atak2_szkoda10", _atak2_szkoda10.ToString());

                writer.WriteElementString("atak3_szkoda1", _atak3_szkoda1.ToString());
                writer.WriteElementString("atak3_szkoda2", _atak3_szkoda2.ToString());
                writer.WriteElementString("atak3_szkoda3", _atak3_szkoda3.ToString());
                writer.WriteElementString("atak3_szkoda4", _atak3_szkoda4.ToString());
                writer.WriteElementString("atak3_szkoda5", _atak3_szkoda5.ToString());
                writer.WriteElementString("atak3_szkoda6", _atak3_szkoda6.ToString());
                writer.WriteElementString("atak3_szkoda7", _atak3_szkoda7.ToString());
                writer.WriteElementString("atak3_szkoda8", _atak3_szkoda8.ToString());
                writer.WriteElementString("atak3_szkoda9", _atak3_szkoda9.ToString());
                writer.WriteElementString("atak3_szkoda10", _atak3_szkoda10.ToString());

                writer.WriteElementString("atak4_szkoda1", _atak4_szkoda1.ToString());
                writer.WriteElementString("atak4_szkoda2", _atak4_szkoda2.ToString());
                writer.WriteElementString("atak4_szkoda3", _atak4_szkoda3.ToString());
                writer.WriteElementString("atak4_szkoda4", _atak4_szkoda4.ToString());
                writer.WriteElementString("atak4_szkoda5", _atak4_szkoda5.ToString());
                writer.WriteElementString("atak4_szkoda6", _atak4_szkoda6.ToString());
                writer.WriteElementString("atak4_szkoda7", _atak4_szkoda7.ToString());
                writer.WriteElementString("atak4_szkoda8", _atak4_szkoda8.ToString());
                writer.WriteElementString("atak4_szkoda9", _atak4_szkoda9.ToString());
                writer.WriteElementString("atak4_szkoda10", _atak4_szkoda10.ToString());

                writer.WriteElementString("atak5_szkoda1", _atak5_szkoda1.ToString());
                writer.WriteElementString("atak5_szkoda2", _atak5_szkoda2.ToString());
                writer.WriteElementString("atak5_szkoda3", _atak5_szkoda3.ToString());
                writer.WriteElementString("atak5_szkoda4", _atak5_szkoda4.ToString());
                writer.WriteElementString("atak5_szkoda5", _atak5_szkoda5.ToString());
                writer.WriteElementString("atak5_szkoda6", _atak5_szkoda6.ToString());
                writer.WriteElementString("atak5_szkoda7", _atak5_szkoda7.ToString());
                writer.WriteElementString("atak5_szkoda8", _atak5_szkoda8.ToString());
                writer.WriteElementString("atak5_szkoda9", _atak5_szkoda9.ToString());
                writer.WriteElementString("atak5_szkoda10", _atak5_szkoda10.ToString());

                writer.WriteElementString("atak6_szkoda1", _atak6_szkoda1.ToString());
                writer.WriteElementString("atak6_szkoda2", _atak6_szkoda2.ToString());
                writer.WriteElementString("atak6_szkoda3", _atak6_szkoda3.ToString());
                writer.WriteElementString("atak6_szkoda4", _atak6_szkoda4.ToString());
                writer.WriteElementString("atak6_szkoda5", _atak6_szkoda5.ToString());
                writer.WriteElementString("atak6_szkoda6", _atak6_szkoda6.ToString());
                writer.WriteElementString("atak6_szkoda7", _atak6_szkoda7.ToString());
                writer.WriteElementString("atak6_szkoda8", _atak6_szkoda8.ToString());
                writer.WriteElementString("atak6_szkoda9", _atak6_szkoda9.ToString());
                writer.WriteElementString("atak6_szkoda10", _atak6_szkoda10.ToString());

                writer.WriteElementString("atak7_szkoda1", _atak7_szkoda1.ToString());
                writer.WriteElementString("atak7_szkoda2", _atak7_szkoda2.ToString());
                writer.WriteElementString("atak7_szkoda3", _atak7_szkoda3.ToString());
                writer.WriteElementString("atak7_szkoda4", _atak7_szkoda4.ToString());
                writer.WriteElementString("atak7_szkoda5", _atak7_szkoda5.ToString());
                writer.WriteElementString("atak7_szkoda6", _atak7_szkoda6.ToString());
                writer.WriteElementString("atak7_szkoda7", _atak7_szkoda7.ToString());
                writer.WriteElementString("atak7_szkoda8", _atak7_szkoda8.ToString());
                writer.WriteElementString("atak7_szkoda9", _atak7_szkoda9.ToString());
                writer.WriteElementString("atak7_szkoda10", _atak7_szkoda10.ToString());

                writer.WriteElementString("atak8_szkoda1", _atak8_szkoda1.ToString());
                writer.WriteElementString("atak8_szkoda2", _atak8_szkoda2.ToString());
                writer.WriteElementString("atak8_szkoda3", _atak8_szkoda3.ToString());
                writer.WriteElementString("atak8_szkoda4", _atak8_szkoda4.ToString());
                writer.WriteElementString("atak8_szkoda5", _atak8_szkoda5.ToString());
                writer.WriteElementString("atak8_szkoda6", _atak8_szkoda6.ToString());
                writer.WriteElementString("atak8_szkoda7", _atak8_szkoda7.ToString());
                writer.WriteElementString("atak8_szkoda8", _atak8_szkoda8.ToString());
                writer.WriteElementString("atak8_szkoda9", _atak8_szkoda9.ToString());
                writer.WriteElementString("atak8_szkoda10", _atak8_szkoda10.ToString());

                writer.WriteElementString("atak9_szkoda1", _atak9_szkoda1.ToString());
                writer.WriteElementString("atak9_szkoda2", _atak9_szkoda2.ToString());
                writer.WriteElementString("atak9_szkoda3", _atak9_szkoda3.ToString());
                writer.WriteElementString("atak9_szkoda4", _atak9_szkoda4.ToString());
                writer.WriteElementString("atak9_szkoda5", _atak9_szkoda5.ToString());
                writer.WriteElementString("atak9_szkoda6", _atak9_szkoda6.ToString());
                writer.WriteElementString("atak9_szkoda7", _atak9_szkoda7.ToString());
                writer.WriteElementString("atak9_szkoda8", _atak9_szkoda8.ToString());
                writer.WriteElementString("atak9_szkoda9", _atak9_szkoda9.ToString());
                writer.WriteElementString("atak9_szkoda10", _atak9_szkoda10.ToString());

                writer.WriteElementString("atak10_szkoda1", _atak10_szkoda1.ToString());
                writer.WriteElementString("atak10_szkoda2", _atak10_szkoda2.ToString());
                writer.WriteElementString("atak10_szkoda3", _atak10_szkoda3.ToString());
                writer.WriteElementString("atak10_szkoda4", _atak10_szkoda4.ToString());
                writer.WriteElementString("atak10_szkoda5", _atak10_szkoda5.ToString());
                writer.WriteElementString("atak10_szkoda6", _atak10_szkoda6.ToString());
                writer.WriteElementString("atak10_szkoda7", _atak10_szkoda7.ToString());
                writer.WriteElementString("atak10_szkoda8", _atak10_szkoda8.ToString());
                writer.WriteElementString("atak10_szkoda9", _atak10_szkoda9.ToString());
                writer.WriteElementString("atak10_szkoda10", _atak10_szkoda10.ToString());
                //-------------
                writer.WriteElementString("atak1_wykonawca1", _atak1_wykonawca1.ToString());
                writer.WriteElementString("atak1_wykonawca2", _atak1_wykonawca2.ToString());
                writer.WriteElementString("atak1_wykonawca3", _atak1_wykonawca3.ToString());
                writer.WriteElementString("atak1_wykonawca4", _atak1_wykonawca4.ToString());
                writer.WriteElementString("atak1_wykonawca5", _atak1_wykonawca5.ToString());
                writer.WriteElementString("atak1_wykonawca6", _atak1_wykonawca6.ToString());
                writer.WriteElementString("atak1_wykonawca7", _atak1_wykonawca7.ToString());
                writer.WriteElementString("atak1_wykonawca8", _atak1_wykonawca8.ToString());
                writer.WriteElementString("atak1_wykonawca9", _atak1_wykonawca9.ToString());
                writer.WriteElementString("atak1_wykonawca10", _atak1_wykonawca10.ToString());

                writer.WriteElementString("atak2_wykonawca1", _atak2_wykonawca1.ToString());
                writer.WriteElementString("atak2_wykonawca2", _atak2_wykonawca2.ToString());
                writer.WriteElementString("atak2_wykonawca3", _atak2_wykonawca3.ToString());
                writer.WriteElementString("atak2_wykonawca4", _atak2_wykonawca4.ToString());
                writer.WriteElementString("atak2_wykonawca5", _atak2_wykonawca5.ToString());
                writer.WriteElementString("atak2_wykonawca6", _atak2_wykonawca6.ToString());
                writer.WriteElementString("atak2_wykonawca7", _atak2_wykonawca7.ToString());
                writer.WriteElementString("atak2_wykonawca8", _atak2_wykonawca8.ToString());
                writer.WriteElementString("atak2_wykonawca9", _atak2_wykonawca9.ToString());
                writer.WriteElementString("atak2_wykonawca10", _atak2_wykonawca10.ToString());

                writer.WriteElementString("atak3_wykonawca1", _atak3_wykonawca1.ToString());
                writer.WriteElementString("atak3_wykonawca2", _atak3_wykonawca2.ToString());
                writer.WriteElementString("atak3_wykonawca3", _atak3_wykonawca3.ToString());
                writer.WriteElementString("atak3_wykonawca4", _atak3_wykonawca4.ToString());
                writer.WriteElementString("atak3_wykonawca5", _atak3_wykonawca5.ToString());
                writer.WriteElementString("atak3_wykonawca6", _atak3_wykonawca6.ToString());
                writer.WriteElementString("atak3_wykonawca7", _atak3_wykonawca7.ToString());
                writer.WriteElementString("atak3_wykonawca8", _atak3_wykonawca8.ToString());
                writer.WriteElementString("atak3_wykonawca9", _atak3_wykonawca9.ToString());
                writer.WriteElementString("atak3_wykonawca10", _atak3_wykonawca10.ToString());

                writer.WriteElementString("atak4_wykonawca1", _atak4_wykonawca1.ToString());
                writer.WriteElementString("atak4_wykonawca2", _atak4_wykonawca2.ToString());
                writer.WriteElementString("atak4_wykonawca3", _atak4_wykonawca3.ToString());
                writer.WriteElementString("atak4_wykonawca4", _atak4_wykonawca4.ToString());
                writer.WriteElementString("atak4_wykonawca5", _atak4_wykonawca5.ToString());
                writer.WriteElementString("atak4_wykonawca6", _atak4_wykonawca6.ToString());
                writer.WriteElementString("atak4_wykonawca7", _atak4_wykonawca7.ToString());
                writer.WriteElementString("atak4_wykonawca8", _atak4_wykonawca8.ToString());
                writer.WriteElementString("atak4_wykonawca9", _atak4_wykonawca9.ToString());
                writer.WriteElementString("atak4_wykonawca10", _atak4_wykonawca10.ToString());

                writer.WriteElementString("atak5_wykonawca1", _atak5_wykonawca1.ToString());
                writer.WriteElementString("atak5_wykonawca2", _atak5_wykonawca2.ToString());
                writer.WriteElementString("atak5_wykonawca3", _atak5_wykonawca3.ToString());
                writer.WriteElementString("atak5_wykonawca4", _atak5_wykonawca4.ToString());
                writer.WriteElementString("atak5_wykonawca5", _atak5_wykonawca5.ToString());
                writer.WriteElementString("atak5_wykonawca6", _atak5_wykonawca6.ToString());
                writer.WriteElementString("atak5_wykonawca7", _atak5_wykonawca7.ToString());
                writer.WriteElementString("atak5_wykonawca8", _atak5_wykonawca8.ToString());
                writer.WriteElementString("atak5_wykonawca9", _atak5_wykonawca9.ToString());
                writer.WriteElementString("atak5_wykonawca10", _atak5_wykonawca10.ToString());

                writer.WriteElementString("atak6_wykonawca1", _atak6_wykonawca1.ToString());
                writer.WriteElementString("atak6_wykonawca2", _atak6_wykonawca2.ToString());
                writer.WriteElementString("atak6_wykonawca3", _atak6_wykonawca3.ToString());
                writer.WriteElementString("atak6_wykonawca4", _atak6_wykonawca4.ToString());
                writer.WriteElementString("atak6_wykonawca5", _atak6_wykonawca5.ToString());
                writer.WriteElementString("atak6_wykonawca6", _atak6_wykonawca6.ToString());
                writer.WriteElementString("atak6_wykonawca7", _atak6_wykonawca7.ToString());
                writer.WriteElementString("atak6_wykonawca8", _atak6_wykonawca8.ToString());
                writer.WriteElementString("atak6_wykonawca9", _atak6_wykonawca9.ToString());
                writer.WriteElementString("atak6_wykonawca10", _atak6_wykonawca10.ToString());

                writer.WriteElementString("atak7_wykonawca1", _atak7_wykonawca1.ToString());
                writer.WriteElementString("atak7_wykonawca2", _atak7_wykonawca2.ToString());
                writer.WriteElementString("atak7_wykonawca3", _atak7_wykonawca3.ToString());
                writer.WriteElementString("atak7_wykonawca4", _atak7_wykonawca4.ToString());
                writer.WriteElementString("atak7_wykonawca5", _atak7_wykonawca5.ToString());
                writer.WriteElementString("atak7_wykonawca6", _atak7_wykonawca6.ToString());
                writer.WriteElementString("atak7_wykonawca7", _atak7_wykonawca7.ToString());
                writer.WriteElementString("atak7_wykonawca8", _atak7_wykonawca8.ToString());
                writer.WriteElementString("atak7_wykonawca9", _atak7_wykonawca9.ToString());
                writer.WriteElementString("atak7_wykonawca10", _atak7_wykonawca10.ToString());

                writer.WriteElementString("atak8_wykonawca1", _atak8_wykonawca1.ToString());
                writer.WriteElementString("atak8_wykonawca2", _atak8_wykonawca2.ToString());
                writer.WriteElementString("atak8_wykonawca3", _atak8_wykonawca3.ToString());
                writer.WriteElementString("atak8_wykonawca4", _atak8_wykonawca4.ToString());
                writer.WriteElementString("atak8_wykonawca5", _atak8_wykonawca5.ToString());
                writer.WriteElementString("atak8_wykonawca6", _atak8_wykonawca6.ToString());
                writer.WriteElementString("atak8_wykonawca7", _atak8_wykonawca7.ToString());
                writer.WriteElementString("atak8_wykonawca8", _atak8_wykonawca8.ToString());
                writer.WriteElementString("atak8_wykonawca9", _atak8_wykonawca9.ToString());
                writer.WriteElementString("atak8_wykonawca10", _atak8_wykonawca10.ToString());

                writer.WriteElementString("atak9_wykonawca1", _atak9_wykonawca1.ToString());
                writer.WriteElementString("atak9_wykonawca2", _atak9_wykonawca2.ToString());
                writer.WriteElementString("atak9_wykonawca3", _atak9_wykonawca3.ToString());
                writer.WriteElementString("atak9_wykonawca4", _atak9_wykonawca4.ToString());
                writer.WriteElementString("atak9_wykonawca5", _atak9_wykonawca5.ToString());
                writer.WriteElementString("atak9_wykonawca6", _atak9_wykonawca6.ToString());
                writer.WriteElementString("atak9_wykonawca7", _atak9_wykonawca7.ToString());
                writer.WriteElementString("atak9_wykonawca8", _atak9_wykonawca8.ToString());
                writer.WriteElementString("atak9_wykonawca9", _atak9_wykonawca9.ToString());
                writer.WriteElementString("atak9_wykonawca10", _atak9_wykonawca10.ToString());

                writer.WriteElementString("atak10_wykonawca1", _atak10_wykonawca1.ToString());
                writer.WriteElementString("atak10_wykonawca2", _atak10_wykonawca2.ToString());
                writer.WriteElementString("atak10_wykonawca3", _atak10_wykonawca3.ToString());
                writer.WriteElementString("atak10_wykonawca4", _atak10_wykonawca4.ToString());
                writer.WriteElementString("atak10_wykonawca5", _atak10_wykonawca5.ToString());
                writer.WriteElementString("atak10_wykonawca6", _atak10_wykonawca6.ToString());
                writer.WriteElementString("atak10_wykonawca7", _atak10_wykonawca7.ToString());
                writer.WriteElementString("atak10_wykonawca8", _atak10_wykonawca8.ToString());
                writer.WriteElementString("atak10_wykonawca9", _atak10_wykonawca9.ToString());
                writer.WriteElementString("atak10_wykonawca10", _atak10_wykonawca10.ToString());
                //-------------
                writer.WriteElementString("czas1", _czas1.ToString());
                writer.WriteElementString("kwalifikacje1", _kwalifikacje1.ToString());
                writer.WriteElementString("wiedza1", _wiedza1.ToString());
                writer.WriteElementString("wyposazenie1", _wyposazenie1.ToString());
                writer.WriteElementString("dostep1", _dostep1.ToString());
                writer.WriteElementString("ryzyko1", _ryzyko1.ToString());

                writer.WriteElementString("czas2", _czas2.ToString());
                writer.WriteElementString("kwalifikacje2", _kwalifikacje2.ToString());
                writer.WriteElementString("wiedza2", _wiedza2.ToString());
                writer.WriteElementString("wyposazenie2", _wyposazenie2.ToString());
                writer.WriteElementString("dostep2", _dostep2.ToString());
                writer.WriteElementString("ryzyko2", _ryzyko2.ToString());

                writer.WriteElementString("czas3", _czas3.ToString());
                writer.WriteElementString("kwalifikacje3", _kwalifikacje3.ToString());
                writer.WriteElementString("wiedza3", _wiedza3.ToString());
                writer.WriteElementString("wyposazenie3", _wyposazenie3.ToString());
                writer.WriteElementString("dostep3", _dostep3.ToString());
                writer.WriteElementString("ryzyko3", _ryzyko3.ToString());

                writer.WriteElementString("czas4", _czas4.ToString());
                writer.WriteElementString("kwalifikacje4", _kwalifikacje4.ToString());
                writer.WriteElementString("wiedza4", _wiedza4.ToString());
                writer.WriteElementString("wyposazenie4", _wyposazenie4.ToString());
                writer.WriteElementString("dostep4", _dostep4.ToString());
                writer.WriteElementString("ryzyko4", _ryzyko4.ToString());

                writer.WriteElementString("czas5", _czas5.ToString());
                writer.WriteElementString("kwalifikacje5", _kwalifikacje5.ToString());
                writer.WriteElementString("wiedza5", _wiedza5.ToString());
                writer.WriteElementString("wyposazenie5", _wyposazenie5.ToString());
                writer.WriteElementString("dostep5", _dostep5.ToString());
                writer.WriteElementString("ryzyko5", _ryzyko5.ToString());

                writer.WriteElementString("czas6", _czas6.ToString());
                writer.WriteElementString("kwalifikacje6", _kwalifikacje6.ToString());
                writer.WriteElementString("wiedza6", _wiedza6.ToString());
                writer.WriteElementString("wyposazenie6", _wyposazenie6.ToString());
                writer.WriteElementString("dostep6", _dostep6.ToString());
                writer.WriteElementString("ryzyko6", _ryzyko6.ToString());

                writer.WriteElementString("czas7", _czas7.ToString());
                writer.WriteElementString("kwalifikacje7", _kwalifikacje7.ToString());
                writer.WriteElementString("wiedza7", _wiedza7.ToString());
                writer.WriteElementString("wyposazenie7", _wyposazenie7.ToString());
                writer.WriteElementString("dostep7", _dostep7.ToString());
                writer.WriteElementString("ryzyko7", _ryzyko7.ToString());

                writer.WriteElementString("czas8", _czas8.ToString());
                writer.WriteElementString("kwalifikacje8", _kwalifikacje8.ToString());
                writer.WriteElementString("wiedza8", _wiedza8.ToString());
                writer.WriteElementString("wyposazenie8", _wyposazenie8.ToString());
                writer.WriteElementString("dostep8", _dostep8.ToString());
                writer.WriteElementString("ryzyko8", _ryzyko8.ToString());

                writer.WriteElementString("czas9", _czas9.ToString());
                writer.WriteElementString("kwalifikacje9", _kwalifikacje9.ToString());
                writer.WriteElementString("wiedza9", _wiedza9.ToString());
                writer.WriteElementString("wyposazenie9", _wyposazenie9.ToString());
                writer.WriteElementString("dostep9", _dostep9.ToString());
                writer.WriteElementString("ryzyko9", _ryzyko9.ToString());

                writer.WriteElementString("czas10", _czas10.ToString());
                writer.WriteElementString("kwalifikacje10", _kwalifikacje10.ToString());
                writer.WriteElementString("wiedza10", _wiedza10.ToString());
                writer.WriteElementString("wyposazenie10", _wyposazenie10.ToString());
                writer.WriteElementString("dostep10", _dostep10.ToString());
                writer.WriteElementString("ryzyko10", _ryzyko10.ToString());

                //-------------


                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            catch
            {
            }
        }//write


        /// <summary>
        /// Czyta z pliku.
        /// </summary>
        /// <param name="fileName">Nazwa pliku xml</param>
        public void read(string fileName)
        {
<<<<<<< HEAD

            _fileName = fileName;
=======
            _fileName = fileName;

>>>>>>> 0412c3c6613d615f52418e74019f13b8b3dcb13a
            XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(fileName);
            XmlNode node = doc.FirstChild;

            while (node != null)
            {
                if (node.Name.ToUpper() == "Rami".ToUpper()) goto RamiNode;
                node = node.NextSibling;
            }
            RamiNode:;

            node = node.FirstChild;
            while (node != null)
            {
<<<<<<< HEAD
                if (node.Name.ToUpper() == "wersjaAngielska".ToUpper()) _isEn = bool.Parse(node.InnerText);

=======
>>>>>>> 0412c3c6613d615f52418e74019f13b8b3dcb13a
                if (node.Name.ToUpper() == "nazwa".ToUpper()) _nazwa = node.InnerText;
                if (node.Name.ToUpper() == "opis".ToUpper()) _opis = node.InnerText;

                if (node.Name.ToUpper() == "regulacja1".ToUpper()) _regulacja1 = node.InnerText;
                if (node.Name.ToUpper() == "wplyw1".ToUpper()) _wplyw1 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "regulacja2".ToUpper()) _regulacja2 = node.InnerText;
                if (node.Name.ToUpper() == "wplyw2".ToUpper()) _wplyw2 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "regulacja3".ToUpper()) _regulacja3 = node.InnerText;
                if (node.Name.ToUpper() == "wplyw3".ToUpper()) _wplyw3 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "regulacja4".ToUpper()) _regulacja4 = node.InnerText;
                if (node.Name.ToUpper() == "wplyw4".ToUpper()) _wplyw4 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "regulacja5".ToUpper()) _regulacja5 = node.InnerText;
                if (node.Name.ToUpper() == "wplyw5".ToUpper()) _wplyw5 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "regulacja6".ToUpper()) _regulacja6 = node.InnerText;
                if (node.Name.ToUpper() == "wplyw6".ToUpper()) _wplyw6 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "regulacja7".ToUpper()) _regulacja7 = node.InnerText;
                if (node.Name.ToUpper() == "wplyw7".ToUpper()) _wplyw7 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "regulacja8".ToUpper()) _regulacja8 = node.InnerText;
                if (node.Name.ToUpper() == "wplyw8".ToUpper()) _wplyw8 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "regulacja9".ToUpper()) _regulacja9 = node.InnerText;
                if (node.Name.ToUpper() == "wplyw9".ToUpper()) _wplyw9 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "regulacja10".ToUpper()) _regulacja10 = node.InnerText;
                if (node.Name.ToUpper() == "wplyw10".ToUpper()) _wplyw10 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "aktywa1".ToUpper()) _aktywa1 = node.InnerText;
                if (node.Name.ToUpper() == "aktywa2".ToUpper()) _aktywa2 = node.InnerText;
                if (node.Name.ToUpper() == "aktywa3".ToUpper()) _aktywa3 = node.InnerText;
                if (node.Name.ToUpper() == "aktywa4".ToUpper()) _aktywa4 = node.InnerText;
                if (node.Name.ToUpper() == "aktywa5".ToUpper()) _aktywa5 = node.InnerText;
                if (node.Name.ToUpper() == "aktywa6".ToUpper()) _aktywa6 = node.InnerText;
                if (node.Name.ToUpper() == "aktywa7".ToUpper()) _aktywa7 = node.InnerText;
                if (node.Name.ToUpper() == "aktywa8".ToUpper()) _aktywa8 = node.InnerText;
                if (node.Name.ToUpper() == "aktywa9".ToUpper()) _aktywa9 = node.InnerText;
                if (node.Name.ToUpper() == "aktywa10".ToUpper()) _aktywa10 = node.InnerText;

                if (node.Name.ToUpper() == "wlasnosc1".ToUpper()) _wlasnosc1 = node.InnerText;
                if (node.Name.ToUpper() == "wlasnosc2".ToUpper()) _wlasnosc2 = node.InnerText;
                if (node.Name.ToUpper() == "wlasnosc3".ToUpper()) _wlasnosc3 = node.InnerText;
                if (node.Name.ToUpper() == "wlasnosc4".ToUpper()) _wlasnosc4 = node.InnerText;
                if (node.Name.ToUpper() == "wlasnosc5".ToUpper()) _wlasnosc5 = node.InnerText;
                if (node.Name.ToUpper() == "wlasnosc6".ToUpper()) _wlasnosc6 = node.InnerText;
                if (node.Name.ToUpper() == "wlasnosc7".ToUpper()) _wlasnosc7 = node.InnerText;
                if (node.Name.ToUpper() == "wlasnosc8".ToUpper()) _wlasnosc8 = node.InnerText;
                if (node.Name.ToUpper() == "wlasnosc9".ToUpper()) _wlasnosc9 = node.InnerText;
                if (node.Name.ToUpper() == "wlasnosc10".ToUpper()) _wlasnosc10 = node.InnerText;

                if (node.Name.ToUpper() == "szkoda1".ToUpper()) _szkoda1 = node.InnerText;
                if (node.Name.ToUpper() == "szkoda2".ToUpper()) _szkoda2 = node.InnerText;
                if (node.Name.ToUpper() == "szkoda3".ToUpper()) _szkoda3 = node.InnerText;
                if (node.Name.ToUpper() == "szkoda4".ToUpper()) _szkoda4 = node.InnerText;
                if (node.Name.ToUpper() == "szkoda5".ToUpper()) _szkoda5 = node.InnerText;
                if (node.Name.ToUpper() == "szkoda6".ToUpper()) _szkoda6 = node.InnerText;
                if (node.Name.ToUpper() == "szkoda7".ToUpper()) _szkoda7 = node.InnerText;
                if (node.Name.ToUpper() == "szkoda8".ToUpper()) _szkoda8 = node.InnerText;
                if (node.Name.ToUpper() == "szkoda9".ToUpper()) _szkoda9 = node.InnerText;
                if (node.Name.ToUpper() == "szkoda10".ToUpper()) _szkoda10 = node.InnerText;

                if (node.Name.ToUpper() == "atak1".ToUpper()) _atak1 = node.InnerText;
                if (node.Name.ToUpper() == "atak2".ToUpper()) _atak2 = node.InnerText;
                if (node.Name.ToUpper() == "atak3".ToUpper()) _atak3 = node.InnerText;
                if (node.Name.ToUpper() == "atak4".ToUpper()) _atak4 = node.InnerText;
                if (node.Name.ToUpper() == "atak5".ToUpper()) _atak5 = node.InnerText;
                if (node.Name.ToUpper() == "atak6".ToUpper()) _atak6 = node.InnerText;
                if (node.Name.ToUpper() == "atak7".ToUpper()) _atak7 = node.InnerText;
                if (node.Name.ToUpper() == "atak8".ToUpper()) _atak8 = node.InnerText;
                if (node.Name.ToUpper() == "atak9".ToUpper()) _atak9 = node.InnerText;
                if (node.Name.ToUpper() == "atak10".ToUpper()) _atak10 = node.InnerText;

                if (node.Name.ToUpper() == "wykonawca1".ToUpper()) _wykonawca1 = node.InnerText;
                if (node.Name.ToUpper() == "wykonawca2".ToUpper()) _wykonawca2 = node.InnerText;
                if (node.Name.ToUpper() == "wykonawca3".ToUpper()) _wykonawca3 = node.InnerText;
                if (node.Name.ToUpper() == "wykonawca4".ToUpper()) _wykonawca4 = node.InnerText;
                if (node.Name.ToUpper() == "wykonawca5".ToUpper()) _wykonawca5 = node.InnerText;
                if (node.Name.ToUpper() == "wykonawca6".ToUpper()) _wykonawca6 = node.InnerText;
                if (node.Name.ToUpper() == "wykonawca7".ToUpper()) _wykonawca7 = node.InnerText;
                if (node.Name.ToUpper() == "wykonawca8".ToUpper()) _wykonawca8 = node.InnerText;
                if (node.Name.ToUpper() == "wykonawca9".ToUpper()) _wykonawca9 = node.InnerText;
                if (node.Name.ToUpper() == "wykonawca10".ToUpper()) _wykonawca10 = node.InnerText;

                //-------------
                if (node.Name.ToUpper() == "regulacja1_aktywa1".ToUpper()) _regulacja1_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja1_aktywa2".ToUpper()) _regulacja1_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja1_aktywa3".ToUpper()) _regulacja1_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja1_aktywa4".ToUpper()) _regulacja1_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja1_aktywa5".ToUpper()) _regulacja1_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja1_aktywa6".ToUpper()) _regulacja1_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja1_aktywa7".ToUpper()) _regulacja1_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja1_aktywa8".ToUpper()) _regulacja1_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja1_aktywa9".ToUpper()) _regulacja1_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja1_aktywa10".ToUpper()) _regulacja1_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "regulacja2_aktywa1".ToUpper()) _regulacja2_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja2_aktywa2".ToUpper()) _regulacja2_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja2_aktywa3".ToUpper()) _regulacja2_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja2_aktywa4".ToUpper()) _regulacja2_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja2_aktywa5".ToUpper()) _regulacja2_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja2_aktywa6".ToUpper()) _regulacja2_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja2_aktywa7".ToUpper()) _regulacja2_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja2_aktywa8".ToUpper()) _regulacja2_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja2_aktywa9".ToUpper()) _regulacja2_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja2_aktywa10".ToUpper()) _regulacja2_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "regulacja3_aktywa1".ToUpper()) _regulacja3_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja3_aktywa2".ToUpper()) _regulacja3_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja3_aktywa3".ToUpper()) _regulacja3_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja3_aktywa4".ToUpper()) _regulacja3_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja3_aktywa5".ToUpper()) _regulacja3_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja3_aktywa6".ToUpper()) _regulacja3_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja3_aktywa7".ToUpper()) _regulacja3_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja3_aktywa8".ToUpper()) _regulacja3_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja3_aktywa9".ToUpper()) _regulacja3_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja3_aktywa10".ToUpper()) _regulacja3_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "regulacja4_aktywa1".ToUpper()) _regulacja4_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja4_aktywa2".ToUpper()) _regulacja4_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja4_aktywa3".ToUpper()) _regulacja4_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja4_aktywa4".ToUpper()) _regulacja4_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja4_aktywa5".ToUpper()) _regulacja4_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja4_aktywa6".ToUpper()) _regulacja4_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja4_aktywa7".ToUpper()) _regulacja4_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja4_aktywa8".ToUpper()) _regulacja4_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja4_aktywa9".ToUpper()) _regulacja4_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja4_aktywa10".ToUpper()) _regulacja4_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "regulacja5_aktywa1".ToUpper()) _regulacja5_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja5_aktywa2".ToUpper()) _regulacja5_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja5_aktywa3".ToUpper()) _regulacja5_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja5_aktywa4".ToUpper()) _regulacja5_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja5_aktywa5".ToUpper()) _regulacja5_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja5_aktywa6".ToUpper()) _regulacja5_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja5_aktywa7".ToUpper()) _regulacja5_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja5_aktywa8".ToUpper()) _regulacja5_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja5_aktywa9".ToUpper()) _regulacja5_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja5_aktywa10".ToUpper()) _regulacja5_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "regulacja6_aktywa1".ToUpper()) _regulacja6_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja6_aktywa2".ToUpper()) _regulacja6_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja6_aktywa3".ToUpper()) _regulacja6_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja6_aktywa4".ToUpper()) _regulacja6_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja6_aktywa5".ToUpper()) _regulacja6_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja6_aktywa6".ToUpper()) _regulacja6_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja6_aktywa7".ToUpper()) _regulacja6_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja6_aktywa8".ToUpper()) _regulacja6_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja6_aktywa9".ToUpper()) _regulacja6_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja6_aktywa10".ToUpper()) _regulacja6_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "regulacja7_aktywa1".ToUpper()) _regulacja7_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja7_aktywa2".ToUpper()) _regulacja7_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja7_aktywa3".ToUpper()) _regulacja7_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja7_aktywa4".ToUpper()) _regulacja7_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja7_aktywa5".ToUpper()) _regulacja7_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja7_aktywa6".ToUpper()) _regulacja7_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja7_aktywa7".ToUpper()) _regulacja7_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja7_aktywa8".ToUpper()) _regulacja7_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja7_aktywa9".ToUpper()) _regulacja7_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja7_aktywa10".ToUpper()) _regulacja7_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "regulacja8_aktywa1".ToUpper()) _regulacja8_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja8_aktywa2".ToUpper()) _regulacja8_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja8_aktywa3".ToUpper()) _regulacja8_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja8_aktywa4".ToUpper()) _regulacja8_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja8_aktywa5".ToUpper()) _regulacja8_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja8_aktywa6".ToUpper()) _regulacja8_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja8_aktywa7".ToUpper()) _regulacja8_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja8_aktywa8".ToUpper()) _regulacja8_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja8_aktywa9".ToUpper()) _regulacja8_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja8_aktywa10".ToUpper()) _regulacja8_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "regulacja9_aktywa1".ToUpper()) _regulacja9_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja9_aktywa2".ToUpper()) _regulacja9_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja9_aktywa3".ToUpper()) _regulacja9_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja9_aktywa4".ToUpper()) _regulacja9_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja9_aktywa5".ToUpper()) _regulacja9_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja9_aktywa6".ToUpper()) _regulacja9_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja9_aktywa7".ToUpper()) _regulacja9_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja9_aktywa8".ToUpper()) _regulacja9_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja9_aktywa9".ToUpper()) _regulacja9_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja9_aktywa10".ToUpper()) _regulacja9_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "regulacja10_aktywa1".ToUpper()) _regulacja10_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja10_aktywa2".ToUpper()) _regulacja10_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja10_aktywa3".ToUpper()) _regulacja10_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja10_aktywa4".ToUpper()) _regulacja10_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja10_aktywa5".ToUpper()) _regulacja10_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja10_aktywa6".ToUpper()) _regulacja10_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja10_aktywa7".ToUpper()) _regulacja10_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja10_aktywa8".ToUpper()) _regulacja10_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja10_aktywa9".ToUpper()) _regulacja10_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "regulacja10_aktywa10".ToUpper()) _regulacja10_aktywa10 = Convert.ToBoolean(node.InnerText);

                //-------------
                if (node.Name.ToUpper() == "aktywa1_wlasnosc1".ToUpper()) _aktywa1_wlasnosc1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa1_wlasnosc2".ToUpper()) _aktywa1_wlasnosc2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa1_wlasnosc3".ToUpper()) _aktywa1_wlasnosc3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa1_wlasnosc4".ToUpper()) _aktywa1_wlasnosc4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa1_wlasnosc5".ToUpper()) _aktywa1_wlasnosc5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa1_wlasnosc6".ToUpper()) _aktywa1_wlasnosc6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa1_wlasnosc7".ToUpper()) _aktywa1_wlasnosc7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa1_wlasnosc8".ToUpper()) _aktywa1_wlasnosc8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa1_wlasnosc9".ToUpper()) _aktywa1_wlasnosc9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa1_wlasnosc10".ToUpper()) _aktywa1_wlasnosc10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "aktywa2_wlasnosc1".ToUpper()) _aktywa2_wlasnosc1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa2_wlasnosc2".ToUpper()) _aktywa2_wlasnosc2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa2_wlasnosc3".ToUpper()) _aktywa2_wlasnosc3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa2_wlasnosc4".ToUpper()) _aktywa2_wlasnosc4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa2_wlasnosc5".ToUpper()) _aktywa2_wlasnosc5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa2_wlasnosc6".ToUpper()) _aktywa2_wlasnosc6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa2_wlasnosc7".ToUpper()) _aktywa2_wlasnosc7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa2_wlasnosc8".ToUpper()) _aktywa2_wlasnosc8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa2_wlasnosc9".ToUpper()) _aktywa2_wlasnosc9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa2_wlasnosc10".ToUpper()) _aktywa2_wlasnosc10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "aktywa3_wlasnosc1".ToUpper()) _aktywa3_wlasnosc1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa3_wlasnosc2".ToUpper()) _aktywa3_wlasnosc2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa3_wlasnosc3".ToUpper()) _aktywa3_wlasnosc3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa3_wlasnosc4".ToUpper()) _aktywa3_wlasnosc4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa3_wlasnosc5".ToUpper()) _aktywa3_wlasnosc5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa3_wlasnosc6".ToUpper()) _aktywa3_wlasnosc6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa3_wlasnosc7".ToUpper()) _aktywa3_wlasnosc7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa3_wlasnosc8".ToUpper()) _aktywa3_wlasnosc8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa3_wlasnosc9".ToUpper()) _aktywa3_wlasnosc9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa3_wlasnosc10".ToUpper()) _aktywa3_wlasnosc10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "aktywa4_wlasnosc1".ToUpper()) _aktywa4_wlasnosc1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa4_wlasnosc2".ToUpper()) _aktywa4_wlasnosc2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa4_wlasnosc3".ToUpper()) _aktywa4_wlasnosc3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa4_wlasnosc4".ToUpper()) _aktywa4_wlasnosc4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa4_wlasnosc5".ToUpper()) _aktywa4_wlasnosc5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa4_wlasnosc6".ToUpper()) _aktywa4_wlasnosc6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa4_wlasnosc7".ToUpper()) _aktywa4_wlasnosc7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa4_wlasnosc8".ToUpper()) _aktywa4_wlasnosc8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa4_wlasnosc9".ToUpper()) _aktywa4_wlasnosc9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa4_wlasnosc10".ToUpper()) _aktywa4_wlasnosc10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "aktywa5_wlasnosc1".ToUpper()) _aktywa5_wlasnosc1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa5_wlasnosc2".ToUpper()) _aktywa5_wlasnosc2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa5_wlasnosc3".ToUpper()) _aktywa5_wlasnosc3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa5_wlasnosc4".ToUpper()) _aktywa5_wlasnosc4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa5_wlasnosc5".ToUpper()) _aktywa5_wlasnosc5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa5_wlasnosc6".ToUpper()) _aktywa5_wlasnosc6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa5_wlasnosc7".ToUpper()) _aktywa5_wlasnosc7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa5_wlasnosc8".ToUpper()) _aktywa5_wlasnosc8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa5_wlasnosc9".ToUpper()) _aktywa5_wlasnosc9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa5_wlasnosc10".ToUpper()) _aktywa5_wlasnosc10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "aktywa6_wlasnosc1".ToUpper()) _aktywa6_wlasnosc1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa6_wlasnosc2".ToUpper()) _aktywa6_wlasnosc2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa6_wlasnosc3".ToUpper()) _aktywa6_wlasnosc3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa6_wlasnosc4".ToUpper()) _aktywa6_wlasnosc4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa6_wlasnosc5".ToUpper()) _aktywa6_wlasnosc5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa6_wlasnosc6".ToUpper()) _aktywa6_wlasnosc6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa6_wlasnosc7".ToUpper()) _aktywa6_wlasnosc7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa6_wlasnosc8".ToUpper()) _aktywa6_wlasnosc8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa6_wlasnosc9".ToUpper()) _aktywa6_wlasnosc9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa6_wlasnosc10".ToUpper()) _aktywa6_wlasnosc10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "aktywa7_wlasnosc1".ToUpper()) _aktywa7_wlasnosc1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa7_wlasnosc2".ToUpper()) _aktywa7_wlasnosc2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa7_wlasnosc3".ToUpper()) _aktywa7_wlasnosc3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa7_wlasnosc4".ToUpper()) _aktywa7_wlasnosc4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa7_wlasnosc5".ToUpper()) _aktywa7_wlasnosc5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa7_wlasnosc6".ToUpper()) _aktywa7_wlasnosc6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa7_wlasnosc7".ToUpper()) _aktywa7_wlasnosc7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa7_wlasnosc8".ToUpper()) _aktywa7_wlasnosc8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa7_wlasnosc9".ToUpper()) _aktywa7_wlasnosc9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa7_wlasnosc10".ToUpper()) _aktywa7_wlasnosc10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "aktywa8_wlasnosc1".ToUpper()) _aktywa8_wlasnosc1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa8_wlasnosc2".ToUpper()) _aktywa8_wlasnosc2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa8_wlasnosc3".ToUpper()) _aktywa8_wlasnosc3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa8_wlasnosc4".ToUpper()) _aktywa8_wlasnosc4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa8_wlasnosc5".ToUpper()) _aktywa8_wlasnosc5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa8_wlasnosc6".ToUpper()) _aktywa8_wlasnosc6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa8_wlasnosc7".ToUpper()) _aktywa8_wlasnosc7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa8_wlasnosc8".ToUpper()) _aktywa8_wlasnosc8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa8_wlasnosc9".ToUpper()) _aktywa8_wlasnosc9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa8_wlasnosc10".ToUpper()) _aktywa8_wlasnosc10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "aktywa9_wlasnosc1".ToUpper()) _aktywa9_wlasnosc1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa9_wlasnosc2".ToUpper()) _aktywa9_wlasnosc2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa9_wlasnosc3".ToUpper()) _aktywa9_wlasnosc3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa9_wlasnosc4".ToUpper()) _aktywa9_wlasnosc4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa9_wlasnosc5".ToUpper()) _aktywa9_wlasnosc5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa9_wlasnosc6".ToUpper()) _aktywa9_wlasnosc6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa9_wlasnosc7".ToUpper()) _aktywa9_wlasnosc7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa9_wlasnosc8".ToUpper()) _aktywa9_wlasnosc8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa9_wlasnosc9".ToUpper()) _aktywa9_wlasnosc9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa9_wlasnosc10".ToUpper()) _aktywa9_wlasnosc10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "aktywa10_wlasnosc1".ToUpper()) _aktywa10_wlasnosc1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa10_wlasnosc2".ToUpper()) _aktywa10_wlasnosc2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa10_wlasnosc3".ToUpper()) _aktywa10_wlasnosc3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa10_wlasnosc4".ToUpper()) _aktywa10_wlasnosc4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa10_wlasnosc5".ToUpper()) _aktywa10_wlasnosc5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa10_wlasnosc6".ToUpper()) _aktywa10_wlasnosc6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa10_wlasnosc7".ToUpper()) _aktywa10_wlasnosc7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa10_wlasnosc8".ToUpper()) _aktywa10_wlasnosc8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa10_wlasnosc9".ToUpper()) _aktywa10_wlasnosc9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "aktywa10_wlasnosc10".ToUpper()) _aktywa10_wlasnosc10 = Convert.ToBoolean(node.InnerText);

                //-------------
                if (node.Name.ToUpper() == "atak1_aktywa1".ToUpper()) _atak1_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_aktywa2".ToUpper()) _atak1_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_aktywa3".ToUpper()) _atak1_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_aktywa4".ToUpper()) _atak1_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_aktywa5".ToUpper()) _atak1_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_aktywa6".ToUpper()) _atak1_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_aktywa7".ToUpper()) _atak1_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_aktywa8".ToUpper()) _atak1_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_aktywa9".ToUpper()) _atak1_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_aktywa10".ToUpper()) _atak1_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak2_aktywa1".ToUpper()) _atak2_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_aktywa2".ToUpper()) _atak2_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_aktywa3".ToUpper()) _atak2_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_aktywa4".ToUpper()) _atak2_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_aktywa5".ToUpper()) _atak2_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_aktywa6".ToUpper()) _atak2_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_aktywa7".ToUpper()) _atak2_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_aktywa8".ToUpper()) _atak2_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_aktywa9".ToUpper()) _atak2_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_aktywa10".ToUpper()) _atak2_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak3_aktywa1".ToUpper()) _atak3_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_aktywa2".ToUpper()) _atak3_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_aktywa3".ToUpper()) _atak3_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_aktywa4".ToUpper()) _atak3_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_aktywa5".ToUpper()) _atak3_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_aktywa6".ToUpper()) _atak3_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_aktywa7".ToUpper()) _atak3_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_aktywa8".ToUpper()) _atak3_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_aktywa9".ToUpper()) _atak3_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_aktywa10".ToUpper()) _atak3_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak4_aktywa1".ToUpper()) _atak4_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_aktywa2".ToUpper()) _atak4_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_aktywa3".ToUpper()) _atak4_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_aktywa4".ToUpper()) _atak4_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_aktywa5".ToUpper()) _atak4_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_aktywa6".ToUpper()) _atak4_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_aktywa7".ToUpper()) _atak4_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_aktywa8".ToUpper()) _atak4_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_aktywa9".ToUpper()) _atak4_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_aktywa10".ToUpper()) _atak4_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak5_aktywa1".ToUpper()) _atak5_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_aktywa2".ToUpper()) _atak5_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_aktywa3".ToUpper()) _atak5_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_aktywa4".ToUpper()) _atak5_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_aktywa5".ToUpper()) _atak5_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_aktywa6".ToUpper()) _atak5_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_aktywa7".ToUpper()) _atak5_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_aktywa8".ToUpper()) _atak5_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_aktywa9".ToUpper()) _atak5_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_aktywa10".ToUpper()) _atak5_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak6_aktywa1".ToUpper()) _atak6_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_aktywa2".ToUpper()) _atak6_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_aktywa3".ToUpper()) _atak6_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_aktywa4".ToUpper()) _atak6_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_aktywa5".ToUpper()) _atak6_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_aktywa6".ToUpper()) _atak6_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_aktywa7".ToUpper()) _atak6_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_aktywa8".ToUpper()) _atak6_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_aktywa9".ToUpper()) _atak6_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_aktywa10".ToUpper()) _atak6_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak7_aktywa1".ToUpper()) _atak7_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_aktywa2".ToUpper()) _atak7_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_aktywa3".ToUpper()) _atak7_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_aktywa4".ToUpper()) _atak7_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_aktywa5".ToUpper()) _atak7_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_aktywa6".ToUpper()) _atak7_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_aktywa7".ToUpper()) _atak7_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_aktywa8".ToUpper()) _atak7_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_aktywa9".ToUpper()) _atak7_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_aktywa10".ToUpper()) _atak7_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak8_aktywa1".ToUpper()) _atak8_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_aktywa2".ToUpper()) _atak8_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_aktywa3".ToUpper()) _atak8_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_aktywa4".ToUpper()) _atak8_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_aktywa5".ToUpper()) _atak8_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_aktywa6".ToUpper()) _atak8_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_aktywa7".ToUpper()) _atak8_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_aktywa8".ToUpper()) _atak8_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_aktywa9".ToUpper()) _atak8_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_aktywa10".ToUpper()) _atak8_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak9_aktywa1".ToUpper()) _atak9_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_aktywa2".ToUpper()) _atak9_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_aktywa3".ToUpper()) _atak9_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_aktywa4".ToUpper()) _atak9_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_aktywa5".ToUpper()) _atak9_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_aktywa6".ToUpper()) _atak9_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_aktywa7".ToUpper()) _atak9_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_aktywa8".ToUpper()) _atak9_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_aktywa9".ToUpper()) _atak9_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_aktywa10".ToUpper()) _atak9_aktywa10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak10_aktywa1".ToUpper()) _atak10_aktywa1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_aktywa2".ToUpper()) _atak10_aktywa2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_aktywa3".ToUpper()) _atak10_aktywa3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_aktywa4".ToUpper()) _atak10_aktywa4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_aktywa5".ToUpper()) _atak10_aktywa5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_aktywa6".ToUpper()) _atak10_aktywa6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_aktywa7".ToUpper()) _atak10_aktywa7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_aktywa8".ToUpper()) _atak10_aktywa8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_aktywa9".ToUpper()) _atak10_aktywa9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_aktywa10".ToUpper()) _atak10_aktywa10 = Convert.ToBoolean(node.InnerText);

                //-------------
                if (node.Name.ToUpper() == "atak1_szkoda1".ToUpper()) _atak1_szkoda1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_szkoda2".ToUpper()) _atak1_szkoda2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_szkoda3".ToUpper()) _atak1_szkoda3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_szkoda4".ToUpper()) _atak1_szkoda4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_szkoda5".ToUpper()) _atak1_szkoda5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_szkoda6".ToUpper()) _atak1_szkoda6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_szkoda7".ToUpper()) _atak1_szkoda7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_szkoda8".ToUpper()) _atak1_szkoda8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_szkoda9".ToUpper()) _atak1_szkoda9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_szkoda10".ToUpper()) _atak1_szkoda10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak2_szkoda1".ToUpper()) _atak2_szkoda1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_szkoda2".ToUpper()) _atak2_szkoda2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_szkoda3".ToUpper()) _atak2_szkoda3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_szkoda4".ToUpper()) _atak2_szkoda4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_szkoda5".ToUpper()) _atak2_szkoda5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_szkoda6".ToUpper()) _atak2_szkoda6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_szkoda7".ToUpper()) _atak2_szkoda7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_szkoda8".ToUpper()) _atak2_szkoda8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_szkoda9".ToUpper()) _atak2_szkoda9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_szkoda10".ToUpper()) _atak2_szkoda10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak3_szkoda1".ToUpper()) _atak3_szkoda1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_szkoda2".ToUpper()) _atak3_szkoda2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_szkoda3".ToUpper()) _atak3_szkoda3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_szkoda4".ToUpper()) _atak3_szkoda4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_szkoda5".ToUpper()) _atak3_szkoda5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_szkoda6".ToUpper()) _atak3_szkoda6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_szkoda7".ToUpper()) _atak3_szkoda7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_szkoda8".ToUpper()) _atak3_szkoda8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_szkoda9".ToUpper()) _atak3_szkoda9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_szkoda10".ToUpper()) _atak3_szkoda10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak4_szkoda1".ToUpper()) _atak4_szkoda1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_szkoda2".ToUpper()) _atak4_szkoda2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_szkoda3".ToUpper()) _atak4_szkoda3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_szkoda4".ToUpper()) _atak4_szkoda4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_szkoda5".ToUpper()) _atak4_szkoda5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_szkoda6".ToUpper()) _atak4_szkoda6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_szkoda7".ToUpper()) _atak4_szkoda7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_szkoda8".ToUpper()) _atak4_szkoda8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_szkoda9".ToUpper()) _atak4_szkoda9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_szkoda10".ToUpper()) _atak4_szkoda10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak5_szkoda1".ToUpper()) _atak5_szkoda1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_szkoda2".ToUpper()) _atak5_szkoda2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_szkoda3".ToUpper()) _atak5_szkoda3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_szkoda4".ToUpper()) _atak5_szkoda4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_szkoda5".ToUpper()) _atak5_szkoda5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_szkoda6".ToUpper()) _atak5_szkoda6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_szkoda7".ToUpper()) _atak5_szkoda7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_szkoda8".ToUpper()) _atak5_szkoda8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_szkoda9".ToUpper()) _atak5_szkoda9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_szkoda10".ToUpper()) _atak5_szkoda10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak6_szkoda1".ToUpper()) _atak6_szkoda1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_szkoda2".ToUpper()) _atak6_szkoda2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_szkoda3".ToUpper()) _atak6_szkoda3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_szkoda4".ToUpper()) _atak6_szkoda4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_szkoda5".ToUpper()) _atak6_szkoda5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_szkoda6".ToUpper()) _atak6_szkoda6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_szkoda7".ToUpper()) _atak6_szkoda7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_szkoda8".ToUpper()) _atak6_szkoda8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_szkoda9".ToUpper()) _atak6_szkoda9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_szkoda10".ToUpper()) _atak6_szkoda10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak7_szkoda1".ToUpper()) _atak7_szkoda1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_szkoda2".ToUpper()) _atak7_szkoda2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_szkoda3".ToUpper()) _atak7_szkoda3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_szkoda4".ToUpper()) _atak7_szkoda4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_szkoda5".ToUpper()) _atak7_szkoda5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_szkoda6".ToUpper()) _atak7_szkoda6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_szkoda7".ToUpper()) _atak7_szkoda7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_szkoda8".ToUpper()) _atak7_szkoda8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_szkoda9".ToUpper()) _atak7_szkoda9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_szkoda10".ToUpper()) _atak7_szkoda10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak8_szkoda1".ToUpper()) _atak8_szkoda1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_szkoda2".ToUpper()) _atak8_szkoda2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_szkoda3".ToUpper()) _atak8_szkoda3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_szkoda4".ToUpper()) _atak8_szkoda4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_szkoda5".ToUpper()) _atak8_szkoda5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_szkoda6".ToUpper()) _atak8_szkoda6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_szkoda7".ToUpper()) _atak8_szkoda7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_szkoda8".ToUpper()) _atak8_szkoda8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_szkoda9".ToUpper()) _atak8_szkoda9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_szkoda10".ToUpper()) _atak8_szkoda10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak9_szkoda1".ToUpper()) _atak9_szkoda1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_szkoda2".ToUpper()) _atak9_szkoda2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_szkoda3".ToUpper()) _atak9_szkoda3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_szkoda4".ToUpper()) _atak9_szkoda4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_szkoda5".ToUpper()) _atak9_szkoda5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_szkoda6".ToUpper()) _atak9_szkoda6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_szkoda7".ToUpper()) _atak9_szkoda7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_szkoda8".ToUpper()) _atak9_szkoda8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_szkoda9".ToUpper()) _atak9_szkoda9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_szkoda10".ToUpper()) _atak9_szkoda10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak10_szkoda1".ToUpper()) _atak10_szkoda1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_szkoda2".ToUpper()) _atak10_szkoda2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_szkoda3".ToUpper()) _atak10_szkoda3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_szkoda4".ToUpper()) _atak10_szkoda4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_szkoda5".ToUpper()) _atak10_szkoda5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_szkoda6".ToUpper()) _atak10_szkoda6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_szkoda7".ToUpper()) _atak10_szkoda7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_szkoda8".ToUpper()) _atak10_szkoda8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_szkoda9".ToUpper()) _atak10_szkoda9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_szkoda10".ToUpper()) _atak10_szkoda10 = Convert.ToBoolean(node.InnerText);
                //-------------
                if (node.Name.ToUpper() == "atak1_wykonawca1".ToUpper()) _atak1_wykonawca1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_wykonawca2".ToUpper()) _atak1_wykonawca2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_wykonawca3".ToUpper()) _atak1_wykonawca3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_wykonawca4".ToUpper()) _atak1_wykonawca4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_wykonawca5".ToUpper()) _atak1_wykonawca5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_wykonawca6".ToUpper()) _atak1_wykonawca6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_wykonawca7".ToUpper()) _atak1_wykonawca7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_wykonawca8".ToUpper()) _atak1_wykonawca8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_wykonawca9".ToUpper()) _atak1_wykonawca9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak1_wykonawca10".ToUpper()) _atak1_wykonawca10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak2_wykonawca1".ToUpper()) _atak2_wykonawca1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_wykonawca2".ToUpper()) _atak2_wykonawca2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_wykonawca3".ToUpper()) _atak2_wykonawca3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_wykonawca4".ToUpper()) _atak2_wykonawca4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_wykonawca5".ToUpper()) _atak2_wykonawca5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_wykonawca6".ToUpper()) _atak2_wykonawca6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_wykonawca7".ToUpper()) _atak2_wykonawca7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_wykonawca8".ToUpper()) _atak2_wykonawca8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_wykonawca9".ToUpper()) _atak2_wykonawca9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak2_wykonawca10".ToUpper()) _atak2_wykonawca10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak3_wykonawca1".ToUpper()) _atak3_wykonawca1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_wykonawca2".ToUpper()) _atak3_wykonawca2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_wykonawca3".ToUpper()) _atak3_wykonawca3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_wykonawca4".ToUpper()) _atak3_wykonawca4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_wykonawca5".ToUpper()) _atak3_wykonawca5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_wykonawca6".ToUpper()) _atak3_wykonawca6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_wykonawca7".ToUpper()) _atak3_wykonawca7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_wykonawca8".ToUpper()) _atak3_wykonawca8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_wykonawca9".ToUpper()) _atak3_wykonawca9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak3_wykonawca10".ToUpper()) _atak3_wykonawca10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak4_wykonawca1".ToUpper()) _atak4_wykonawca1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_wykonawca2".ToUpper()) _atak4_wykonawca2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_wykonawca3".ToUpper()) _atak4_wykonawca3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_wykonawca4".ToUpper()) _atak4_wykonawca4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_wykonawca5".ToUpper()) _atak4_wykonawca5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_wykonawca6".ToUpper()) _atak4_wykonawca6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_wykonawca7".ToUpper()) _atak4_wykonawca7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_wykonawca8".ToUpper()) _atak4_wykonawca8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_wykonawca9".ToUpper()) _atak4_wykonawca9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak4_wykonawca10".ToUpper()) _atak4_wykonawca10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak5_wykonawca1".ToUpper()) _atak5_wykonawca1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_wykonawca2".ToUpper()) _atak5_wykonawca2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_wykonawca3".ToUpper()) _atak5_wykonawca3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_wykonawca4".ToUpper()) _atak5_wykonawca4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_wykonawca5".ToUpper()) _atak5_wykonawca5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_wykonawca6".ToUpper()) _atak5_wykonawca6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_wykonawca7".ToUpper()) _atak5_wykonawca7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_wykonawca8".ToUpper()) _atak5_wykonawca8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_wykonawca9".ToUpper()) _atak5_wykonawca9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak5_wykonawca10".ToUpper()) _atak5_wykonawca10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak6_wykonawca1".ToUpper()) _atak6_wykonawca1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_wykonawca2".ToUpper()) _atak6_wykonawca2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_wykonawca3".ToUpper()) _atak6_wykonawca3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_wykonawca4".ToUpper()) _atak6_wykonawca4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_wykonawca5".ToUpper()) _atak6_wykonawca5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_wykonawca6".ToUpper()) _atak6_wykonawca6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_wykonawca7".ToUpper()) _atak6_wykonawca7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_wykonawca8".ToUpper()) _atak6_wykonawca8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_wykonawca9".ToUpper()) _atak6_wykonawca9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak6_wykonawca10".ToUpper()) _atak6_wykonawca10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak7_wykonawca1".ToUpper()) _atak7_wykonawca1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_wykonawca2".ToUpper()) _atak7_wykonawca2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_wykonawca3".ToUpper()) _atak7_wykonawca3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_wykonawca4".ToUpper()) _atak7_wykonawca4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_wykonawca5".ToUpper()) _atak7_wykonawca5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_wykonawca6".ToUpper()) _atak7_wykonawca6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_wykonawca7".ToUpper()) _atak7_wykonawca7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_wykonawca8".ToUpper()) _atak7_wykonawca8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_wykonawca9".ToUpper()) _atak7_wykonawca9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak7_wykonawca10".ToUpper()) _atak7_wykonawca10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak8_wykonawca1".ToUpper()) _atak8_wykonawca1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_wykonawca2".ToUpper()) _atak8_wykonawca2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_wykonawca3".ToUpper()) _atak8_wykonawca3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_wykonawca4".ToUpper()) _atak8_wykonawca4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_wykonawca5".ToUpper()) _atak8_wykonawca5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_wykonawca6".ToUpper()) _atak8_wykonawca6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_wykonawca7".ToUpper()) _atak8_wykonawca7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_wykonawca8".ToUpper()) _atak8_wykonawca8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_wykonawca9".ToUpper()) _atak8_wykonawca9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak8_wykonawca10".ToUpper()) _atak8_wykonawca10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak9_wykonawca1".ToUpper()) _atak9_wykonawca1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_wykonawca2".ToUpper()) _atak9_wykonawca2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_wykonawca3".ToUpper()) _atak9_wykonawca3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_wykonawca4".ToUpper()) _atak9_wykonawca4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_wykonawca5".ToUpper()) _atak9_wykonawca5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_wykonawca6".ToUpper()) _atak9_wykonawca6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_wykonawca7".ToUpper()) _atak9_wykonawca7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_wykonawca8".ToUpper()) _atak9_wykonawca8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_wykonawca9".ToUpper()) _atak9_wykonawca9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak9_wykonawca10".ToUpper()) _atak9_wykonawca10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "atak10_wykonawca1".ToUpper()) _atak10_wykonawca1 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_wykonawca2".ToUpper()) _atak10_wykonawca2 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_wykonawca3".ToUpper()) _atak10_wykonawca3 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_wykonawca4".ToUpper()) _atak10_wykonawca4 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_wykonawca5".ToUpper()) _atak10_wykonawca5 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_wykonawca6".ToUpper()) _atak10_wykonawca6 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_wykonawca7".ToUpper()) _atak10_wykonawca7 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_wykonawca8".ToUpper()) _atak10_wykonawca8 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_wykonawca9".ToUpper()) _atak10_wykonawca9 = Convert.ToBoolean(node.InnerText);
                if (node.Name.ToUpper() == "atak10_wykonawca10".ToUpper()) _atak10_wykonawca10 = Convert.ToBoolean(node.InnerText);

                if (node.Name.ToUpper() == "czas1".ToUpper()) _czas1 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "kwalifikacje1".ToUpper()) _kwalifikacje1 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wiedza1".ToUpper()) _wiedza1 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wyposazenie1".ToUpper()) _wyposazenie1 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "dostep1".ToUpper()) _dostep1 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "rzyko1".ToUpper()) _ryzyko1 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "czas2".ToUpper()) _czas2 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "kwalifikacje2".ToUpper()) _kwalifikacje2 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wiedza2".ToUpper()) _wiedza2 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wyposazenie2".ToUpper()) _wyposazenie2 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "dostep2".ToUpper()) _dostep2 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "rzyko2".ToUpper()) _ryzyko2 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "czas3".ToUpper()) _czas3 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "kwalifikacje3".ToUpper()) _kwalifikacje3 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wiedza3".ToUpper()) _wiedza3 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wyposazenie3".ToUpper()) _wyposazenie3 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "dostep3".ToUpper()) _dostep3 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "rzyko3".ToUpper()) _ryzyko3 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "czas4".ToUpper()) _czas4 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "kwalifikacje4".ToUpper()) _kwalifikacje4 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wiedza4".ToUpper()) _wiedza4 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wyposazenie4".ToUpper()) _wyposazenie4 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "dostep4".ToUpper()) _dostep4 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "rzyko4".ToUpper()) _ryzyko4 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "czas5".ToUpper()) _czas5 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "kwalifikacje5".ToUpper()) _kwalifikacje5 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wiedza5".ToUpper()) _wiedza5 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wyposazenie5".ToUpper()) _wyposazenie5 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "dostep5".ToUpper()) _dostep5 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "rzyko5".ToUpper()) _ryzyko5 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "czas6".ToUpper()) _czas6 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "kwalifikacje6".ToUpper()) _kwalifikacje6 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wiedza6".ToUpper()) _wiedza6 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wyposazenie6".ToUpper()) _wyposazenie6 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "dostep6".ToUpper()) _dostep6 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "rzyko6".ToUpper()) _ryzyko6 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "czas7".ToUpper()) _czas7 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "kwalifikacje7".ToUpper()) _kwalifikacje7 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wiedza7".ToUpper()) _wiedza7 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wyposazenie7".ToUpper()) _wyposazenie7 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "dostep7".ToUpper()) _dostep7 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "rzyko7".ToUpper()) _ryzyko7 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "czas8".ToUpper()) _czas8 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "kwalifikacje8".ToUpper()) _kwalifikacje8 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wiedza8".ToUpper()) _wiedza8 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wyposazenie8".ToUpper()) _wyposazenie8 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "dostep8".ToUpper()) _dostep8 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "rzyko8".ToUpper()) _ryzyko8 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "czas9".ToUpper()) _czas9 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "kwalifikacje9".ToUpper()) _kwalifikacje9 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wiedza9".ToUpper()) _wiedza9 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wyposazenie9".ToUpper()) _wyposazenie9 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "dostep9".ToUpper()) _dostep9 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "rzyko9".ToUpper()) _ryzyko9 = Convert.ToInt32(node.InnerText);

                if (node.Name.ToUpper() == "czas10".ToUpper()) _czas10 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "kwalifikacje10".ToUpper()) _kwalifikacje10 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wiedza10".ToUpper()) _wiedza10 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "wyposazenie10".ToUpper()) _wyposazenie10 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "dostep10".ToUpper()) _dostep10 = Convert.ToInt32(node.InnerText);
                if (node.Name.ToUpper() == "rzyko10".ToUpper()) _ryzyko10 = Convert.ToInt32(node.InnerText);

                node = node.NextSibling;
            }

            //.............

        }//read

    }//class dane



}//namespace nsDane