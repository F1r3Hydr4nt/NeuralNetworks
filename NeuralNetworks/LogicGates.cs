using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworks
{
    static class LogicGates
    {
        // the input values
        public static double[][] inputs = new double[][]
            {
                new double[]{ 0, 0},
                new double[]{ 0, 1},
                new double[]{ 1, 0},
                new double[]{ 1, 1}
            };

        // desired results
        //AND
        public static double[] resultsAND = { 0, 0, 0, 1 };
        //AND
        public static double[] resultsOR = { 0, 1, 1, 1 };
        //NAND
        public static double[] resultsNAND = { 1, 1, 1, 0 };
        //NOR
        public static double[] resultsNOR = { 1, 0, 0, 0 };
        //XOR
        public static double[] resultsXOR = { 0, 1, 1, 0 };
        //XNOR
        public static double[] resultsXNOR = { 1, 0, 0, 1 };
    }
}
