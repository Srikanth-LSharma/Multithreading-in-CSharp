using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using CSharpBasics.TabularData;

namespace MovieApp1
{
    public class ThreadingClass
    {
        public void ThreadingClass1(string[] lines,string[] lines1, string[] lines2, string[] movienamelist,int[] agelist, string[] genderlist,
                                    int threadcount,int records_per_thread, int[,] genrelist,string[] genrenamelist)               //Based on Movies
        {
            IPrintTabularData<Udata> moviedata = new TablePrinter<Udata>();
            IPrintHeadingData<Heading> headingdata = new HeaderPrinter<Heading>();
            var movielist = new List<Udata>();
            var movieagelist = new List<Udata>();
            var moviegenderlist = new List<Udata>();
            var moviegenrelist = new List<Udata>();
            BasedonMovies movie = new BasedonMovies();

            var heading = new List<Heading>();
            var heading1 = new List<Heading>();
            var heading2 = new List<Heading>();
            var heading3 = new List<Heading>();
         
            heading.Add(new Heading { Title = " Top movies based on Rating " });
            heading1.Add(new Heading { Title = " Top movies based on Age " });
            heading2.Add(new Heading { Title = " Top movies based on Gender " });


            Console.WriteLine(" Enter the age range between which you want to display the top movies:");
            Console.Write(" Enter the age(lower limit): ");
            int age1=Convert.ToInt32(Console.ReadLine());
            Console.Write(" Enter the age(upper limit): ");
            int age2 = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Enter the gender based on which you want to display the top movies (m for male and f for female): ");
            string gender = Console.ReadLine();
            Console.Write(" Enter the genre based on which you want to display the top movies: ");
            string genre = Console.ReadLine();

            heading3.Add(new Heading { Title = "Top movies based in "+genre+" genre "});
            int genreid=0;


            for (int i = 1; i < genrenamelist.Length-1; i++)
            {
                if(genrenamelist[i].ToLower() == genre.ToLower())
                {
                    genreid = i+1;
                    Console.WriteLine("GenreID"+ genreid);
                }                         
            }


            float[] ratingarray = new float[3000];
            float[] countarray = new float[3000];
            float[] ratingarrayage = new float[3000];
            float[] ratingarraygender = new float[3000];
            float[] countarrayage = new float[3000];
            float[] countarraygender = new float[3000];
           
            int c = 0;
            int n = records_per_thread;

            Thread[] T = new Thread[threadcount];

            T[0] = new Thread(delegate ()
            {
                movie.Thread1(ratingarray, lines, countarray, age1, age2, gender, agelist, genderlist, ratingarrayage, 
                              ratingarraygender, countarrayage, countarraygender, c, n);
            });

            //T[1] = new Thread(delegate ()
            //{
            //    movie.Thread2(ratingarray, lines, countarray, age1, age2, gender, agelist, genderlist, ratingarrayage, ratingarraygender, countarrayage, countarraygender);
            //});

            //T[2] = new Thread(delegate ()
            //{
            //    movie.Thread3(ratingarray, lines, countarray, age1, age2, gender, agelist, genderlist, ratingarrayage, ratingarraygender, countarrayage, countarraygender);
            //});

            //T[3] = new Thread(delegate ()
            //{
            //    movie.Thread4(ratingarray, lines, countarray, age1, age2, gender, agelist, genderlist, ratingarrayage, ratingarraygender, countarrayage, countarraygender);
            //});
            //T[4] = new Thread(delegate ()
            //{
            //    movie.Thread5(ratingarray, lines, countarray, age1, age2, gender, agelist, genderlist, ratingarrayage, ratingarraygender, countarrayage, countarraygender);
            //});
            //T[5] = new Thread(delegate ()
            //{
            //    movie.Thread6(ratingarray, lines, countarray, age1, age2, gender, agelist, genderlist, ratingarrayage, ratingarraygender, countarrayage, countarraygender);
            //});
            //T[6] = new Thread(delegate ()
            //{
            //    movie.Thread7(ratingarray, lines, countarray, age1, age2, gender, agelist, genderlist, ratingarrayage, ratingarraygender, countarrayage, countarraygender);
            //});

            for (int i = 1; i < threadcount; i++)
            {
                T[i] = new Thread(delegate ()
                {
                    c += records_per_thread - 1;
                    movie.Thread1(ratingarray, lines, countarray, age1, age2, gender, agelist, genderlist, ratingarrayage, ratingarraygender, countarrayage, countarraygender, c, n);
                  
                });
            }

            Stopwatch s1 = new Stopwatch();

            s1.Start();
            for(int i=0; i <threadcount; i++)
            {
                T[i].Start();
            }
            for(int i = 0; i < threadcount; i++)
            {
                T[i].Join();
            }
            s1.Stop();
                    

            for (int j = 0; j < movienamelist.Length; j++)
            {
                movielist.Add(new Udata { MovieID = j, MovieName = movienamelist[j], Rating = ratingarray[j] / countarray[j], Count = countarray[j] });
            }
            List<Udata> sortedmovie = movielist.Where(user => user.Count > 20).OrderByDescending(user => user.Rating).ThenByDescending(user=>user.Count).Take(10).ToList();
            headingdata.PrintHeader(heading);
            moviedata.PrintTable(sortedmovie);

            for (int j = 0; j < ratingarrayage.Length; j++)
            {
                movieagelist.Add(new Udata { MovieID = j, MovieName = movienamelist[j], Rating = ratingarrayage[j] / countarrayage[j], Count = countarrayage[j] });
            }
            List<Udata> sortedmovieage = movieagelist.Where(user => user.Count > 20).OrderByDescending(user => user.Rating).ThenByDescending(user => user.Count).Take(5).ToList();
            headingdata.PrintHeader(heading1);
            moviedata.PrintTable(sortedmovieage);

            for (int j = 0; j < ratingarraygender.Length; j++)
            {
                moviegenderlist.Add(new Udata { MovieID = j, MovieName = movienamelist[j], Rating = ratingarraygender[j] / countarraygender[j], Count = countarraygender[j] });
            }
            List<Udata> sortedmoviegender = moviegenderlist.Where(user => user.Count > 20).OrderByDescending(user => user.Rating).ThenByDescending(user => user.Count).Take(5).ToList();


            headingdata.PrintHeader(heading2);
            moviedata.PrintTable(sortedmoviegender);

            for (int i = 0; i < movienamelist.Length; i++)
            {

                if (genrelist[i, genreid] == 1) 
                {
                    moviegenrelist.Add(new Udata { MovieID = i, MovieName = movienamelist[i], Rating = ratingarray[i] / countarray[i], Count = countarray[i] });
                }
                
            }
            List<Udata> sortedmoviegenre = moviegenrelist.Where(user => user.Count > 20).OrderByDescending(user => user.Rating).ThenByDescending(user => user.Count).Take(5).ToList();
            headingdata.PrintHeader(heading3);
            moviedata.PrintTable(sortedmoviegenre);

            Console.WriteLine("  Processing time with Threading: {0} milliseconds", s1.ElapsedMilliseconds);
        }
    }
}