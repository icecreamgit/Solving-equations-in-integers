﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\Магистр_3_сем\\Рояк\\Lab_2\\input.txt";
            List<List<int>> B = readFile(path);
            List<List<int>> outputB = new List<List<int>>();
            int Fx = B[0][B[0].Count - 1];
            B[0].Remove(Fx);
            List<List<int>> identity = identityMatrix(B[0].Count);
            foreach (List<int> array in identity)
            {
                B.Add(array);
            }

            LinearEquation linearEquation = new LinearEquation();
            linearEquation.main_matrix = B;
            linearEquation.calculationOfMatrix();
            outputB = linearEquation.main_matrix;
            linearEquation.searcherMatrixResult();
            if (Fx % linearEquation.resultCalculateMatrix != 0)
            {
                Console.WriteLine($"Fx : {Fx} не делится на {linearEquation.resultCalculateMatrix}");
            }
            linearEquation.disisionMatrix(Fx);
        }
        static List<List<int>> readFile(string path)
        {
            String line;
            StreamReader sr = new StreamReader(path);
            List<List<int>> arrayLine = new List<List<int>>();


            line = sr.ReadLine();
            while (line != null)
            {
                arrayLine.Add(reglexReturn(line));
                line = sr.ReadLine();
            }
            sr.Close();
            return arrayLine;
        }
        static List<int> reglexReturn(string line)
        {
            List<int> ret = new List<int>();
            Regex rx = new Regex(@"\d+");

            foreach (Match match in rx.Matches(line))
            {
                ret.Add(Convert.ToInt32(match.Value));
            }
            return ret;
        }
        static List<List<int>> identityMatrix(int n)
        {
            List<List<int>> M =
            Enumerable.Range(0, n).Select(i => Enumerable.Repeat(0, n).Select((z, j) => j == i ? 1 : 0).ToList()).ToList();
            return M;
        }


        
        
    }
}