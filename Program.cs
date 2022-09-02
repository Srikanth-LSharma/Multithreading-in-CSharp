using System;
using System.IO;
using CSharpBasics.TabularData;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics;

namespace MovieApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadingClass TClass = new ThreadingClass();

            
            string[] movienamelist = new string[3000];
            string[] genderlist = new string[3000];
            string[] genrenamelist = new string[20];
            int[,] genrelist = new int[3000, 20];
            try
            {
                string[] lines = File.ReadAllLines("udata.txt");
                string[] lines1 = File.ReadAllLines("uuser.txt");
                string[] lines2 = File.ReadAllLines("uitem.txt");
                string[] lines3 = File.ReadAllLines("ugenre.txt");
                int[] agelist = new int[3000];

                int records_per_thread=15000;

                int count = lines.Length / records_per_thread;
                int threadcount = (lines.Length % records_per_thread) == 0 ? count : count + 1;
           
                for (int i = 0; i < lines1.Length; i++)
                {
                    string[] fields1 = lines1[i].Split('|');
                    int userid = Convert.ToInt32(fields1[0]);
                    agelist[userid] = Convert.ToInt32(fields1[1]);
                    genderlist[userid] = fields1[2];
                   
                }
                for (int i = 0; i < lines2.Length; i++)
                {
                    string[] fields2 = lines2[i].Split('|');
                    int movieid = Convert.ToInt32(fields2[0]);
                    movienamelist[movieid] = fields2[1];
                    for(int j = 1; j < genrenamelist.Length; j++)
                    {
                        genrelist[movieid, j] = Convert.ToInt32(fields2[j + 4]);
                    }
                }
                //Console.WriteLine("Genrelist content for toystory in animation: {0}", genrelist[1, 7]);
                
                for (int i = 0; i < lines3.Length; i++)
                {
                    string[] fields3 = lines3[i].Split('|');
                    int genreid = Convert.ToInt32(fields3[1]);
                    genrenamelist[genreid] = fields3[0];
                }
                TClass.ThreadingClass1(lines,lines1,lines2,movienamelist,agelist,genderlist,threadcount,records_per_thread,genrelist,genrenamelist);
            }
            catch (Exception)
            {
                Console.WriteLine("\n Either the file is not found or there is some exception that is not handled \n");
            }


}
    }
}