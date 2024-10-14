using System.Linq;

namespace gravitySensorReader
{
	public static class FourierAnalysis
	{
		public static (decimal X, decimal Y, decimal Z) CalculateFrequency((decimal x, decimal y, decimal z)[] data)
		{
			var dataX = data.Select(d => d.x).ToArray();
			var dataY = data.Select(d => d.y).ToArray();
			var dataZ = data.Select(d => d.z).ToArray();

			var filteredX = dataX.FilterNoise();
			var x = filteredX.CalculateFrequency();

			var filteredY = dataY.FilterNoise();
			var y = filteredY.CalculateFrequency();

			var filteredZ = dataZ.FilterNoise();
			var z = filteredZ.CalculateFrequency();

			return ((decimal)x, (decimal)y, (decimal)z);
		}
	}
}
