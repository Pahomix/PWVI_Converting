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
    internal class Program
    {
        public static string path = " ";
        //public static List<Model> models = new List<Model>();
        static void Main(string[] args)
        {
            Greetings();
            path = Console.ReadLine();
            ReadSave.Read(path);
            //string[] text = File.ReadAllText(ReadSave.path);
            //using (var file = new StreamReader(ReadSave.path))
            //{
            //    string line = file.ReadLine();
            //}
            //Model model1 = new Model("Прямоугольник", 15, 12);
            //Model model2 = new Model("Квадрат", 7, 7);
            //Model model3 = new Model("Прямоугольник", 13, 17);
            //List<Model> models = new List<Model>(File.ReadAllText(ReadSave.path));
            //for (int i = 0; i < models.Count; i++)
            //{

            //}
            //models.Add(model1);
            //models.Add(model2);
            //models.Add(model3);
            //foreach (var iteModel in models)
            //{
            //    Console.WriteLine(iteModel);
            //}
            //Model text = ;
            //json
            //string json = JsonConvert.SerializeObject(models);
            //string path = "";
            //Console.ReadLine();
            //File.WriteAllText(path, json);
            //File.WriteAllLines("C:\\Users\\Даниил Селезнев\\Desktop\\txt.txt", models);
            //xml
            //XmlSerializer xml = new XmlSerializer(typeof(List<Model>));
            //using (FileStream fs = new FileStream("C:\\Users\\Даниил Селезнев\\Desktop\\xml.xml", FileMode.OpenOrCreate))
            //{
            //    xml.Serialize(fs, models);
            //}
        }

        static void Greetings()
        {
            Console.WriteLine("Введите путь до файла, который вы хотите открыть");
        }
    }
}
