using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworks
{
    /*
     * Steps:
    1. forward propagation - calculates the output of the neural network
    2. back propagation - adjusts the weights and the biases according to the global error

    How it works?

    initialize all weights and biases with random values between 0 and 1
    calculate the output of the network
    calculate the global error
    adjust the weights of the output neuron using the global error
    calculate the hidden neurons' errors (split the global error)
    adjust the hidden neurons' weights using their errors
    go to step 2) and repeat this until the error gets minimal
     * 
     */

    class BackPropogationNetwork
    {
        public BackPropogationNetwork() { }
        public int numInputs, numOutputs, numHiddenNeurons;
        List<NeuronLayer> neuronLayers;

        public void CreateNetwork(int inputs,int hiddenNeurons, int outputs)
        {
            numInputs = inputs;
            numOutputs = outputs;
            numHiddenNeurons = hiddenNeurons;
            neuronLayers = new List<NeuronLayer>();
        }

        public void InitialiseNetwork()
        {
            neuronLayers.Add(new NeuronLayer(numHiddenNeurons));
            neuronLayers.Add(new NeuronLayer(numOutputs));
            neuronLayers[0].InitialiseLayer(numInputs);//hidden neuron layer
            neuronLayers[1].InitialiseLayer(numHiddenNeurons);//output layer
        }


        public void Train(double[][] inputs, double[] results)
        {
            int epoch = 0;

        Retry:
            epoch++;
            for (int i = 0; i < 4; i++)  // Iterate through the test data adjusting weights until epoch > maxEpoch or global error is sufficiently small
            {
                /*
                 // 1) forward propagation (calculates output)
                //set inputs of hidden layer
                neuronLayers[0].SetInputs(inputs[i]);
                neuronLayers[0].CalculateOutputs();

                //set inputs of output layer
                neuronLayers[1].SetInputs(neuronLayers[0].GetOutputs());
                neuronLayers[1].CalculateOutputs();

                double output = neuronLayers[1].neurons[0].output;

                Console.WriteLine(inputs[i][0]+","+inputs[i][1]+"?="+output);
                
                // 2) back propagation (adjusts weights)
 
                // adjusts the weight of the output neuron, based on it's error
                double[] expectedOutputs = new double[] { results[i] };
                neuronLayers[1].CalculateErrors(results);
                neuronLayers[1].AdjustNeuronWeights();

                neuronLayers[0].CalculateErrors(neuronLayers[1]);
                neuronLayers[0].AdjustNeuronWeights();

                /*
  // 1) forward propagation (calculates output)
                 */

                neuronLayers[0].SetInputs(inputs[i]);

                neuronLayers[1].SetInputs(neuronLayers[0].GetOutputs());

                Console.WriteLine(inputs[i][0] + "," + inputs[i][1] + "==" + neuronLayers[1].neurons[0].output);
              /*
                hiddenNeuron1.inputs = new double[] { inputs[i, 0], inputs[i, 1] };
                hiddenNeuron2.inputs = new double[] { inputs[i, 0], inputs[i, 1] };
 
                outputNeuron.inputs = new double[] { hiddenNeuron1.output, hiddenNeuron2.output };
 
 
                Console.WriteLine("{0} xor {1} = {2}", inputs[i, 0], inputs[i, 1], outputNeuron.output);
 
                // 2) back propagation (adjusts weights)
 
               */
                double output = neuronLayers[1].neurons[0].output;
                neuronLayers[1].neurons[0].error = Sigmoid.Derivative(output) * (results[i] - output);
                neuronLayers[1].neurons[0].AdjustWeights();

                neuronLayers[0].neurons[0].error = Sigmoid.Derivative(neuronLayers[0].neurons[0].output) * neuronLayers[1].neurons[0].error * neuronLayers[1].neurons[0].weights[0];
                neuronLayers[0].neurons[1].error = Sigmoid.Derivative(neuronLayers[0].neurons[1].output) * neuronLayers[1].neurons[0].error * neuronLayers[1].neurons[0].weights[1];

                neuronLayers[0].neurons[1].AdjustWeights();
                neuronLayers[0].neurons[0].AdjustWeights();


                /*
                // adjusts the weight of the output neuron, based on it's error
                outputNeuron.error = sigmoid.derivative(outputNeuron.output) * (results[i] - outputNeuron.output);
                outputNeuron.adjustWeights();
 
                // then adjusts the hidden neurons' weights, based on their errors
                hiddenNeuron1.error = sigmoid.derivative(hiddenNeuron1.output) * outputNeuron.error * outputNeuron.weights[0];
                hiddenNeuron2.error = sigmoid.derivative(hiddenNeuron2.output) * outputNeuron.error * outputNeuron.weights[1];
 
                hiddenNeuron1.adjustWeights();
                hiddenNeuron2.adjustWeights();
            }
                 * */
                //}
            }
            if (epoch < 20000)
                goto Retry;


            Console.ReadLine();
        }
    }
}