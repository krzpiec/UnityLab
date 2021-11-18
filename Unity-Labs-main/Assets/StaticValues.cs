using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaticValues
{

    static StaticValues()
    {
        frytki = 10;
        wInoBiale = 10;
        winoCzerwone = 10;
        lapuszki = 10;
        hajsSrebrny = 10;
        hajsZloty = 10;

    }

    private static int frytki=0;
    public static int Frytki { get => frytki; set { frytki = value; updateResources(); } }
    private static int wInoBiale=0;
    public static int WInoBiale { get => wInoBiale; set { wInoBiale = value; updateResources(); } }
    private static int winoCzerwone = 0;
    public static int WinoCzerwone { get => winoCzerwone; set { winoCzerwone = value; updateResources(); } }
    private static int lapuszki = 0;
    public static int Lapuszki { get => lapuszki; set { lapuszki = value; updateResources(); } }
    private static int hajsSrebrny = 0;
    public static int HajsSrebrny { get => hajsSrebrny; set { hajsSrebrny = value; updateResources(); } }
    private static int hajsZloty = 0;
    public static int HajsZloty { get => hajsZloty; set { hajsZloty = value; updateResources(); } }

    public static event Action updateEvent;
    private static void updateResources()
    {
        updateEvent?.Invoke();
    }

}
