using MathNet.Filtering.IIR;
using MathNet.Filtering;
using MathNet.Numerics.Statistics;
using System.Linq;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;

namespace gravitySensorReader
{
	public static class StatisticsExtensions
	{
		private const double SampleRatePerSeconds = 20.0;

		public static double[] FilterNoise(this decimal[] data)
		{
			var dataAsDouble = data.Select(d => (double)d).ToArray();
			return FilterNoise(dataAsDouble);
		}

		public static double[] FilterNoise(this double[] data)
		{
			if (data.StandardDeviation() < .1)			
				return new double[data.Length];
			
			return data;
		}

		public static double[] ApplyLowPassMovingAverageFilter(this double[] data, int windowSize)
		{
			double[] filteredData = new double[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				double sum = 0;
				int count = 0;
				for (int j = i; j >= 0 && j > i - windowSize; j--)
				{
					sum += data[j];
					count++;
				}
				filteredData[i] = sum / count;
			}
			return filteredData;
		}

		private static double[] ApplyHighPassFilter(this double[] data, double sampleRate, double cutoffFrequency)
		{
			var highPassFilter = OnlineIirFilter.CreateHighpass(ImpulseResponse.Finite, sampleRate, cutoffFrequency);
			return highPassFilter.ProcessSamples(data);
		}
		public static double CalculateRpm(this double[] accelerometerData)
		{
			// Convert frequency to RPM (1 Hz = 60 RPM)
			double rpm = accelerometerData.CalculateFrequency() * 60.0;

			return rpm;
		}

		public static double CalculateFrequency(this double[] accelerometerData)
		{
			// Perform FFT on the accelerometer data
			var complexData = new Complex[accelerometerData.Length];
			for (int i = 0; i < accelerometerData.Length; i++)
			{
				complexData[i] = new Complex(accelerometerData[i], 0);
			}

			Fourier.Forward(complexData, FourierOptions.Matlab);

			// Find the magnitude of the frequency components
			double[] magnitudes = new double[complexData.Length / 2];
			for (int i = 0; i < magnitudes.Length; i++)
			{
				magnitudes[i] = complexData[i].Magnitude;
			}

			// Find the index of the dominant frequency
			int maxIndex = 0;
			double maxMagnitude = 0.0;
			for (int i = 1; i < magnitudes.Length; i++) // Start from 1 to ignore the DC component
			{
				if (magnitudes[i] > maxMagnitude)
				{
					maxMagnitude = magnitudes[i];
					maxIndex = i;
				}
			}

			// Calculate the frequency corresponding to the dominant component
			double dominantFrequency = maxIndex * SampleRatePerSeconds / accelerometerData.Length; // in Hz

			return dominantFrequency;
		}

		public static double CalculateWeightedRpm(this double[] accelerometerData)
		{
			double[] weightedData = new double[accelerometerData.Length];
			int length = accelerometerData.Length;
			double totalWeight = 0;

			// Apply a linear weighting scheme, where recent data has more weight
			for (int i = 0; i < length; i++)
			{
				double weight = (double)(i + 1) / length; // Weight increases with more recent data
				weightedData[i] = accelerometerData[i] * weight;
				totalWeight += weight;
			}

			// Normalize the weighted data
			for (int i = 0; i < length; i++)
			{
				weightedData[i] /= totalWeight;
			}

			// Now apply FFT to the weighted data
			return CalculateRpm(weightedData);
		}
	}
}
