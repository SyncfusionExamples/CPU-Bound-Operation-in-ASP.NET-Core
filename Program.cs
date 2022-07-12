using System;
using System.IO;
using System.Threading.Tasks;

namespace Cpu_bound_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            StartBackgroundWrite(213434);
        }
      
        
        private static  async void StartBackgroundWrite(float value)
        {
            Console.WriteLine("Started CPU Bound asynchronous task on a background thread");
            //Cpu bound operation is called here;
            await Task.Run(() => SavingText(value));
        }

        //This method runs in the background;
        private static  async void SavingText(float value)
        {
            //Finds the location path
            string path = @"D:\Cpu.txt";
            try
            {
                if (!File.Exists(path))
                {
                    using (var myFile = File.Create(path))
                    {
                        //Writes the file:
                        TextWriter tw = new StreamWriter(path, false);
                        tw.WriteLine(value);
                        tw.Close();

                    }

                }
                else if (File.Exists(path))
                {
                    using (var myFile = File.Create(path))
                    {
                        //writes the file:
                        TextWriter tw = new StreamWriter(path, true);
                        tw.WriteLine(value);
                        tw.Close();

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        
    }

   
}
