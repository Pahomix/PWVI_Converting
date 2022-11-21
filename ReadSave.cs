 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

 namespace PracticalWorkVI
 {
     internal class ReadSave
     {
         public static List<Model> models = new List<Model>();

         public static void Read(string path)
         {
             //Console.WriteLine("Введите путь, куда хотите сохранить");
             List<string> lines = new List<string>();
             if (path != null && path.Contains(".txt"))
             {
                 Console.Clear();
                 Console.WriteLine();
                 Console.WriteLine();
                 foreach (var line in File.ReadAllLines(path)) lines.Add(line);
                 for (int i = 0; i < lines.Count; i += 3)
                 {
                     string Name = lines[i];
                     int Width = Convert.ToInt32(lines[i + 1]);
                     int Height = Convert.ToInt32(lines[i + 2]);
                     Model model = new Model(Name, Width, Height);
                     models.Add(model);
                 }

                 foreach (var VARIABLE in File.ReadAllLines(path)) Console.WriteLine(VARIABLE);

                 //StreamReader sr = new StreamReader(path);
                 //Console.WriteLine(sr.ReadToEnd());
                 //lines = sr.ReadToEnd().Split();

                 //using (var sr = new StreamReader(path))
                 //{
                 //    Console.WriteLine(sr.ReadToEnd());
                 //    for (int i = 0; i < sr.; i++)
                 //    {

                 //    }
                 //}
                 //string[] text = File.ReadAllLines(path);
                 //foreach (string item in text)
                 //{
                 //    Console.WriteLine(item);
                 //}
             }
             else if (path != null && path.Contains(".json"))
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
                 if (result != null)
                 {
                     Console.Clear();
                     Console.WriteLine();
                     Console.WriteLine();
                     foreach (var item in result)
                     {
                         Console.WriteLine(item.Name);
                         Console.WriteLine(item.Width);
                         Console.WriteLine(item.Height);
                         models.Add(item);
                     }
                 }
             }
             else if (path != null && path.Contains(".xml"))
             {
                 //Model modelka;
                 XmlSerializer xml = new XmlSerializer(typeof(List<Model>));
                 //using (var fs = new StreamReader(path))
                 //{
                 //    var modelka = (List<Model>)xml.Deserialize(fs);
                 //}
                 //using (FileStream fs = new FileStream(path, FileMode.Open))
                 //{
                 //    modelka = (Model)xml.Deserialize(fs);

                 //}
                 using (FileStream fs = new FileStream(path, FileMode.Open))
                 {
                     List<Model> result = xml.Deserialize(fs) as List<Model>;
                     if (result != null)
                     {
                         Console.Clear();
                         Console.WriteLine();
                         Console.WriteLine();
                         foreach (var item in result)
                         {
                             Console.WriteLine(item.Name);
                             Console.WriteLine(item.Width);
                             Console.WriteLine(item.Height);
                             models.Add(item);
                         }
                     }
                 }
             }
             //else
             //{
             //    Console.Clear();
             //    Console.WriteLine("Ошибка, попробуй еще раз, пупсик");
             //    path = Console.ReadLine();
             //}

             Save(path);
         }

         static void Save(string path)
         {
             Console.SetCursorPosition(0, 0);
             Console.WriteLine("Сохранить в одном из форматов (txt, json, xml) - F1. Закрыть программу - Escape" +
                               "\n-------------------------------------------------------------------------------");
             Console.SetCursorPosition(path.Length, 20);
             ConsoleKeyInfo key = Console.ReadKey();
             switch (key.Key)
             {
                 case ConsoleKey.F1:
                     Console.Clear();
                     Console.WriteLine("Введите, куда сохранить");
                     path = Console.ReadLine();
                     if (path.Contains(".json"))
                     {
                         string json = JsonConvert.SerializeObject(models);
                         //Console.ReadLine();
                         File.WriteAllText(path, json);
                         Console.WriteLine("СОхранено");
                         //File.WriteAllLines("C:\\Users\\Даниил Селезнев\\Desktop\\txt.txt", models);
                     }
                     else if (path.Contains(".xml"))
                     {
                         XmlSerializer xml = new XmlSerializer(typeof(List<Model>));
                         using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                         {
                             xml.Serialize(fs, models);
                         } 
                         Console.WriteLine("Сохранено");
                     }
                     else if (path.Contains(".txt"))
                     {
                         foreach (var items in models)
                         {
                             File.AppendAllText(path, items.Name + "\n");
                             File.AppendAllText(path, items.Width + "\n");
                             File.AppendAllText(path, items.Height + "\n");
                         }

                         Console.WriteLine("Сохранено");
                     }

                     break;
                 case ConsoleKey.Escape:
                     Environment.Exit(0);
                     break;

             }
         }
     }
 }
 
