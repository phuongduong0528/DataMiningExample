using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using SequentialPatternMining;

namespace DataTransformTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RetailData> retailDatas = new List<RetailData>();
            string file;
            Console.Write("File path: ");
            file = Console.ReadLine();
            try
            {
                CsvReader csvReader = new CsvReader(new StreamReader(file));
                while (csvReader.Read())
                {
                    retailDatas.Add(csvReader.GetRecord<RetailData>());
                }
                CsvWriter csvWriter = new CsvWriter(new StreamWriter("F:\\output.csv"));
                
            }
            catch(DirectoryNotFoundException a)
            {
                Console.WriteLine("Khong tim thay duong dan");
            }
            catch (FileNotFoundException b)
            {
                Console.WriteLine("Khong tim thay file");
            }
            catch (IOException c)
            {
                Console.WriteLine("Loi doc ghi du lieu");
            }
            catch(Exception d)
            {
                Console.WriteLine(d.Message);
            }
            Console.WriteLine("\n\n=====================");
            Console.ReadKey();
        }
    }
}
