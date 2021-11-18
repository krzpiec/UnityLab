using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveWitcher (Witcher witcher)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/../WorldSaves/witcher.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        WitcherData data = new WitcherData(witcher);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static WitcherData LoadWitcher()
    {
        string path = Application.dataPath + "/../WorldSaves/witcher.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            WitcherData data = formatter.Deserialize(stream) as WitcherData;
            Debug.Log(data.position[1]);
            stream.Close();

            return data;

        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static void SaveZiemniak(Ziemniak ziemniak)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/../WorldSaves/ziemniak.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        ZiemniakData data = new ZiemniakData(ziemniak);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ZiemniakData LoadZiemniak()
    {
        string path = Application.dataPath + "/../WorldSaves/ziemniak.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ZiemniakData data = formatter.Deserialize(stream) as ZiemniakData;
            Debug.Log(data.position[1]);
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SavePaluch(Paluch paluch)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/../WorldSaves/paluch.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PaluchData data = new PaluchData(paluch);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PaluchData LoadPaluch()
    {
        string path = Application.dataPath + "/../WorldSaves/paluch.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PaluchData data = formatter.Deserialize(stream) as PaluchData;
            Debug.Log(data.position[1]);
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

        public static void SaveElf(Elf elf)
        {
            BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/../WorldSaves/elf.fun";
            FileStream stream = new FileStream(path, FileMode.Create);

            ElfData data = new ElfData(elf);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static ElfData LoadElf()
        {
        string path = Application.dataPath + "/../WorldSaves/elf.fun";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                ElfData data = formatter.Deserialize(stream) as ElfData;
                Debug.Log(data.position[1]);
                stream.Close();

                return data;

            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }

    public static void SaveHobbit(Hobbit hobbit)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/../WorldSaves/hobbit.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        HobbitData data = new HobbitData(hobbit);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static HobbitData LoadHobbit()
    {
        string path = Application.dataPath + "/../WorldSaves/hobbit.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HobbitData data = formatter.Deserialize(stream) as HobbitData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveWinnaBaba(WinnaBaba winnaBaba)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/../WorldSaves/winnababa.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        WinnaBabaData data = new WinnaBabaData(winnaBaba);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static WinnaBabaData LoadWinnaBaba()
    {
        string path = Application.dataPath + "/../WorldSaves/winnababa.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            WinnaBabaData data = formatter.Deserialize(stream) as WinnaBabaData;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
