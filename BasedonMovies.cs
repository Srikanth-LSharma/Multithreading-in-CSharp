using System;
using System.IO;
using CSharpBasics.TabularData;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp1
{
    public class BasedonMovies
    {
        IPrintTabularData<Udata> moviedata = new TablePrinter<Udata>();
        string[] Threadnamesfn = new string[20];
        public void Thread1(float[] ratingarray, string[] lines, float[] countarray, int age1,int age2,string gender, int[] agelist,string[] genderlist, 
                            float[] ratingarrayage,float[] ratingarraygender, float[] countarrayage,float[] countarraygender,int c,int n)
        {
            var temp = (n + c < lines.Length) ? n + c : lines.Length;
            for (int i = c; i < temp; i++)
            {
                string[] fields = lines[i].Split('\t');
                int movieid = Convert.ToInt32(fields[1]);
                ratingarray[movieid] += Convert.ToInt32(fields[2]);
                countarray[movieid] += 1;
                int userid = Convert.ToInt32(fields[0]);
                int age = agelist[userid];
                if (age>=age1 &&age<=age2)
                {
                    ratingarrayage[movieid] += Convert.ToInt32(fields[2]);
                    countarrayage[movieid] += 1;
                }
                string usergender = genderlist[userid];
                if (string.Equals(usergender, gender.ToUpper()))
                {
                    ratingarraygender[movieid] += Convert.ToInt32(fields[2]);
                    countarraygender[movieid] += 1;
                }
            }
        }
        //public void Thread2(float[] ratingarray, string[] lines, float[] countarray, int age1, int age2, string gender, int[] agelist, string[] genderlist, float[] ratingarrayage, float[] ratingarraygender, float[] countarrayage, float[] countarraygender)
        //{
        //    for (int i = 15000; i < 30000; i++)
        //    {
        //        string[] fields = lines[i].Split('\t');
        //        int movieid = Convert.ToInt32(fields[1]);
        //        ratingarray[movieid] += Convert.ToInt32(fields[2]);
        //        countarray[movieid] += 1;
        //        int userid = Convert.ToInt32(fields[0]);
        //        int age = agelist[userid];
        //        if (age >= age1 && age <= age2)
        //        {
        //            ratingarrayage[movieid] += Convert.ToInt32(fields[2]);
        //            countarrayage[movieid] += 1;
        //        }
        //        string usergender = genderlist[userid];
        //        if (string.Equals(usergender, gender.ToUpper()))
        //        {
        //            ratingarraygender[movieid] += Convert.ToInt32(fields[2]);
        //            countarraygender[movieid] += 1;
        //        }
        //    }
        //}
        //public void Thread3(float[] ratingarray, string[] lines, float[] countarray, int age1, int age2, string gender, int[] agelist, string[] genderlist, float[] ratingarrayage, float[] ratingarraygender, float[] countarrayage, float[] countarraygender)
        //{
        //    for (int i = 30000; i < 45000; i++)
        //    {
        //        string[] fields = lines[i].Split('\t');
        //        int movieid = Convert.ToInt32(fields[1]);
        //        ratingarray[movieid] += Convert.ToInt32(fields[2]);
        //        countarray[movieid] += 1;
        //        int userid = Convert.ToInt32(fields[0]);
        //        int age = agelist[userid];
        //        if (age >= age1 && age <= age2)
        //        {
        //            ratingarrayage[movieid] += Convert.ToInt32(fields[2]);
        //            countarrayage[movieid] += 1;
        //        }
        //        string usergender = genderlist[userid];
        //        if (string.Equals(usergender, gender.ToUpper()))
        //        {
        //            ratingarraygender[movieid] += Convert.ToInt32(fields[2]);
        //            countarraygender[movieid] += 1;
        //        }
        //    }
        //}
        //public void Thread4(float[] ratingarray, string[] lines, float[] countarray, int age1, int age2, string gender, int[] agelist, string[] genderlist, float[] ratingarrayage, float[] ratingarraygender, float[] countarrayage, float[] countarraygender)
        //{
        //    for (int i = 45000; i < 60000; i++)
        //    {
        //        string[] fields = lines[i].Split('\t');
        //        int movieid = Convert.ToInt32(fields[1]);
        //        ratingarray[movieid] += Convert.ToInt32(fields[2]);
        //        countarray[movieid] += 1;
        //        int userid = Convert.ToInt32(fields[0]);
        //        int age = agelist[userid];
        //        if (age >= age1 && age <= age2)
        //        {
        //            ratingarrayage[movieid] += Convert.ToInt32(fields[2]);
        //            countarrayage[movieid] += 1;
        //        }
        //        string usergender = genderlist[userid];
        //        if (string.Equals(usergender, gender.ToUpper()))
        //        {
        //            ratingarraygender[movieid] += Convert.ToInt32(fields[2]);
        //            countarraygender[movieid] += 1;
        //        }
        //    }
        //}
        //public void Thread5(float[] ratingarray, string[] lines, float[] countarray, int age1, int age2, string gender, int[] agelist, string[] genderlist, float[] ratingarrayage, float[] ratingarraygender, float[] countarrayage, float[] countarraygender)
        //{
        //    for (int i = 60000; i < 75000; i++)
        //    {
        //        string[] fields = lines[i].Split('\t');
        //        int movieid = Convert.ToInt32(fields[1]);
        //        ratingarray[movieid] += Convert.ToInt32(fields[2]);
        //        countarray[movieid] += 1;
        //        int userid = Convert.ToInt32(fields[0]);
        //        int age = agelist[userid];
        //        if (age >= age1 && age <= age2)
        //        {
        //            ratingarrayage[movieid] += Convert.ToInt32(fields[2]);
        //            countarrayage[movieid] += 1;
        //        }
        //        string usergender = genderlist[userid];
        //        if (string.Equals(usergender, gender.ToUpper()))
        //        {
        //            ratingarraygender[movieid] += Convert.ToInt32(fields[2]);
        //            countarraygender[movieid] += 1;
        //        }
        //    }
        //}
        //public void Thread6(float[] ratingarray, string[] lines, float[] countarray, int age1, int age2, string gender, int[] agelist, string[] genderlist, float[] ratingarrayage, float[] ratingarraygender, float[] countarrayage, float[] countarraygender)
        //{
        //    for (int i = 75000; i < 90000; i++)
        //    {
        //        string[] fields = lines[i].Split('\t');
        //        int movieid = Convert.ToInt32(fields[1]);
        //        ratingarray[movieid] += Convert.ToInt32(fields[2]);
        //        countarray[movieid] += 1;
        //        int userid = Convert.ToInt32(fields[0]);
        //        int age = agelist[userid];
        //        if (age >= age1 && age <= age2)
        //        {
        //            ratingarrayage[movieid] += Convert.ToInt32(fields[2]);
        //            countarrayage[movieid] += 1;
        //        }
        //        string usergender = genderlist[userid];
        //        if (string.Equals(usergender, gender.ToUpper()))
        //        {
        //            ratingarraygender[movieid] += Convert.ToInt32(fields[2]);
        //            countarraygender[movieid] += 1;
        //        }
        //    }
        //}
        //public void Thread7(float[] ratingarray, string[] lines, float[] countarray, int age1, int age2, string gender, int[] agelist, string[] genderlist, float[] ratingarrayage, float[] ratingarraygender, float[] countarrayage, float[] countarraygender)
        //{
        //    for (int i = 90000; i < lines.Length; i++)
        //    {
        //        string[] fields = lines[i].Split('\t');
        //        int movieid = Convert.ToInt32(fields[1]);
        //        ratingarray[movieid] += Convert.ToInt32(fields[2]);
        //        countarray[movieid] += 1;
        //        int userid = Convert.ToInt32(fields[0]);
        //        int age = agelist[userid];
        //        if (age >= age1 && age <= age2)
        //        {
        //            ratingarrayage[movieid] += Convert.ToInt32(fields[2]);
        //            countarrayage[movieid] += 1;
        //        }
        //        string usergender = genderlist[userid];
        //        if (string.Equals(usergender, gender.ToUpper()))
        //        {
        //            ratingarraygender[movieid] += Convert.ToInt32(fields[2]);
        //            countarraygender[movieid] += 1;
        //        }
        //    }
        //}
        //public void Threadmain(float[] ratingarray, string[] lines, float[] countarray, int age1, int age2, string gender, int[] agelist, string[] genderlist, float[] ratingarrayage, float[] ratingarraygender, float[] countarrayage, float[] countarraygender)
        //{
        //    for (int i = 0; i < lines.Length; i++)
        //    {
        //        string[] fields = lines[i].Split('\t');
        //        int movieid = Convert.ToInt32(fields[1]);
        //        ratingarray[movieid] += Convert.ToInt32(fields[2]);
        //        countarray[movieid] += 1;
        //        int userid = Convert.ToInt32(fields[0]);
        //        int age = agelist[userid];
        //        if (age >= age1 && age <= age2)
        //        {
        //            ratingarrayage[movieid] += Convert.ToInt32(fields[2]);
        //            countarrayage[movieid] += 1;
        //        }
        //        string usergender = genderlist[userid];
        //        if (string.Equals(usergender, gender.ToUpper()))
        //        {
        //            ratingarraygender[movieid] += Convert.ToInt32(fields[2]);
        //            countarraygender[movieid] += 1;
        //        }
        //    }
        //}

    }
}
