using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworks
{
    class NeuronLayer
    {
        public NeuronLayer(int n)
        {
            numNeurons = n;
            neurons = new List<Neuron>();
            outputs = new List<double>();
        }

        public void InitialiseLayer(int inputsPerNeuron){
            for (int i = 0; i < numNeurons; i++)
            {
                neurons.Add(new Neuron(inputsPerNeuron));
                outputs.Add(new double());
            }
            foreach(Neuron n in neurons)n.InitialiseWeights();
        }

        int numNeurons;
        public List<Neuron> neurons;
        List<double> outputs;

        public void SetInputs(double [] inputs)
        {
            foreach (Neuron n in neurons)
            {
                n.SetInputs(inputs);
            }
        }
        public double[] GetOutputs()
        {
            int index = 0;
            foreach (Neuron n in neurons)
            {
                outputs[index] = n.output;
                index++;
            }
            return outputs.ToArray();
        }

        public void AdjustNeuronWeights()
        {
            foreach (Neuron n in neurons) n.AdjustWeights();
        }

        internal void CalculateErrors(double [] expectedOutputs)
        {
            int index = 0;
            foreach (Neuron n in neurons)
            {
                n.CalculateError(expectedOutputs[index]);
                index++;
            }
        }

        internal void CalculateErrors(NeuronLayer neuronLayer)
        {
            int index = 0;
            foreach (Neuron n in neurons)
            {
                double expectedValue = new double();
                foreach (Neuron n2 in neuronLayer.neurons) expectedValue += n2.error * n2.weights[index];
                n.CalculateError(expectedValue);
                index++;
            }

        }
    }
}
