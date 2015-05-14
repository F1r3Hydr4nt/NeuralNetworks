using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworks
{
    class Program
    { 
        static void Main(string[] args)
        {
            BackPropogationNetwork network = new BackPropogationNetwork();
            network.CreateNetwork(2, 2, 1);
            network.InitialiseNetwork();
            network.Train(LogicGates.inputs, LogicGates.resultsXNOR);
        }
    }
}
