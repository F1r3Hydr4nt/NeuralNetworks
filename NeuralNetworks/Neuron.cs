using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworks
{
    class Neuron
    {
        //Contructor takes the number of inputs and initialises the input list
        public Neuron(int nInputs) {
            numInputs = nInputs;
            inputs = new List<double>();
        }
        //Initialises the weights list with randomised values and randomises the bias weight
        public void InitialiseWeights()
        {
            weights = new List<double>();
            Random rand = new Random();
            for (int i = 0; i < numInputs; i++)
            {
                weights.Add(rand.NextDouble());
                inputs.Add(new double());
            }
            biasWeight = rand.NextDouble();
        }

        public void AdjustWeights()
        {
            for (int i = 0; i < weights.Count; i++)
            {
                weights[i] += error * inputs[i];
            }
            //The bias "threshold" value gets updated along with the weights
            biasWeight += error;
        }

        public double [] GetWeights()
        {
            return weights.ToArray();
        }
        
        //Calculates the output of the neuron
        public void CalculateOutput()
        {
            double result=0;
            for (int i = 0; i < weights.Count; i++)
            {
                result+=(weights[i] * inputs[i]);
            }
            //dont forget the bias
            result+=biasWeight;
            //pass through the sigmoid activation function
           // output=Sigmoid.Output(result);
        }

        public double output
        {
            get
            {
                double result = 0;
                for (int i = 0; i < weights.Count; i++)
                {
                    result += (weights[i] * inputs[i]);
                }
                //dont forget the bias
                result += biasWeight;
                //pass through the sigmoid activation functio
               
                return Sigmoid.Output(result);
            }
        }
 

        public void SetInputs(double [] inputArray)
        {
            int index = 0;
            foreach (double d in inputArray)
            {
                inputs[index] = d;
                index++;
            }
        }

        int numInputs;
        List<double> inputs;
        public List<double> weights;
        double biasWeight;
        public double error;
        internal void CalculateError(double expectedValue)
        {
            error = Sigmoid.Derivative(output) * (expectedValue - output);
        }
    }
}
