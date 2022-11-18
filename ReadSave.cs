 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace PracticalWorkVI
{
    internal class ReadSave
    {
        public static void Read()
        {
            //Console.WriteLine("Введите путь, куда хотите сохранить");
            string path = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Сохранить в одном из форматов (txt, json, xml) - F1. Закрыть программу - Escape" +
                              "\n-------------------------------------------------------------------------------");
            //ConsoleKeyInfo key = Console.ReadKey();
            if (path.Contains(".txt"))
            {
                string[] text = File.ReadAllLines(path);
                foreach (string item in text)
                {
                    Console.WriteLine(item);
                }
            }
            else if (path.Contains(".json"))
            {
                //JsonTextReader reader = new JsonTextReader(new StringReader(path));
                //reader.SupportMultipleContent = true;
                //while (true)
                //{
                //    if (!reader.Read()) break;

                //    JsonSerializer serializer = new JsonSerializer();
                //    List<Model> model = serializer.Deserialize<List<Model>>(reader);
                //}

                string json = File.ReadAllText(path);
                List<Model> result = JsonConvert.DeserializeObject<List<Model>>(json);
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Width);
                    Console.WriteLine(item.Height);
                }
            }   
            else if (path.Contains(".xml"))
            {
                Model modelka;
                XmlSerializer xml = new XmlSerializer(typeof(List<Model>));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    modelka = (Model)xml.Deserialize(fs);
                }

            }
        }
    }
}
